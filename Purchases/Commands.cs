using System;
using System.Collections.Generic;
using System.Text;

namespace Purchases
{
    public class Commands{
        public static System.Data.SqlClient.SqlCommand Receipts(){
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "SELECT r.ReceiptID, r.Paid, r.Price, r.Discount, r.DiscountCard,\n" +
                                "       r.Comment, r.Vendor, r.Deleted, r.Number,\n" +
                                "       r.Created, r.Updated,\n" +
                                "       v.VendorName\n" +
//                                "       MONTH(r.Paid)
                                "FROM Purchases.Receipts AS r\n" +
                                "LEFT JOIN Purchases.Vendors AS v\n"+
                                "       ON v.VendorID = r.Vendor\n" +
                                "ORDER BY r.Paid, r.ReceiptID";
                cmd.CommandTimeout = 0;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sQuery;
                return cmd;
        }

        /// <summary>
        /// This method returns SqlCommand object for receipts list
        /// </summary>
        /// <param name="criteria">Options for receipts to select</param>
        /// <returns></returns>
        public static System.Data.SqlClient.SqlCommand Receipts(Purchases.Criteria criteria ){
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            string joins = "", conditions = "", orders = "", tp = "";
            orders = "ORDER BY r.Paid, r.ReceiptID";
            if (criteria != null){
                if (criteria.Top > 0){
                    tp = "TOP " + criteria.Top.ToString();
                    orders = "ORDER BY r.Price DESC";
                }
                if ((criteria.Categories != null) && (criteria.Categories.Count > 0)){
                    joins += "LEFT JOIN (SELECT DISTINCT rc.ReceiptID, p.Category\n" +
                             "             FROM Purchases.ReceiptContents AS rc\n" +
                             "             JOIN Producer.Products AS p\n" +
                             "               ON p.ProductID = rc.ProductID) AS rcc\n" +
                             "  ON rcc.ReceiptID = r.ReceiptID\n";
                    conditions += (conditions.Length == 0 ? "WHERE " : "\nAND ");
                    string[] parameters = new string[criteria.Categories.Count];
                    for (int i = 0; i < criteria.Categories.Count; i++){
                        parameters[i] = string.Format("@Category{0}", i);
                        cmd.Parameters.AddWithValue(parameters[i], criteria.Categories[i]);
                    }
                    conditions += string.Format("rcc.Category IN( {0} )", string.Join(", ", parameters));
                }
                if ((criteria.Vendors != null) && (criteria.Vendors.Count > 0))
                {
                    conditions += (conditions.Length == 0 ? "WHERE " : "\nAND ");
                    string[] parameters = new string[criteria.Vendors.Count];
                    for (int i = 0; i < criteria.Vendors.Count; i++)
                    {
                        parameters[i] = string.Format("@Vendor{0}", i);
                        cmd.Parameters.AddWithValue(parameters[i], criteria.Vendors[i]);
                    }
                    conditions += string.Format("r.Vendor IN( {0} )", string.Join(", ", parameters));
                }
                if ((criteria.Dates != null) && (criteria.Dates.Length > 0)){
                    string sign = "";
                    if (DateFilterType.More == criteria.DateFilter)
                        sign = ">";
                    else if (DateFilterType.MoreOrEqual == criteria.DateFilter)
                        sign = ">=";
                    else if (DateFilterType.Less == criteria.DateFilter)
                        sign = "<";
                    else if (DateFilterType.LessOrEqual == criteria.DateFilter)
                        sign = "<=";
                    else if (DateFilterType.Equal == criteria.DateFilter)
                        sign = "=";

                    conditions += (conditions.Length == 0 ? "WHERE " : "\nAND ");
                    switch( criteria.DateFilter ){
                        case DateFilterType.Between:
                            conditions += "r.Paid BETWEEN @StartDate AND @EndDate";
                            cmd.Parameters.AddWithValue("@StartDate", criteria.Dates[0]);
                            cmd.Parameters.AddWithValue("@EndDate", criteria.Dates[1]);
                            break;
                        case DateFilterType.More:
                        case DateFilterType.MoreOrEqual:
                        case DateFilterType.Less:
                        case DateFilterType.LessOrEqual:
                        case DateFilterType.Equal:
                            conditions += "r.Paid " + sign + " @TargetDate";
                            cmd.Parameters.AddWithValue("@TargetDate", criteria.Dates[0]);
                            break;
                        case DateFilterType.Exact:
                        default:
                            string[] parameters = new string[criteria.Dates.Length];
                            for (int i = 0; i < criteria.Dates.Length; i++){
                                parameters[i] = string.Format("@Paid{0}", criteria.Dates[i].ToShortDateString() );
                                cmd.Parameters.AddWithValue(parameters[i], criteria.Dates[i].ToShortDateString());
                            }
                            conditions += string.Format("r.Paid IN( {0} )", string.Join(", ", parameters));
                            break;
                    }
                }
            }
            string sQuery = "SELECT " + tp + " r.ReceiptID, r.Paid, r.Price, r.Discount, r.DiscountCard,\n" +
                            "       r.Comment, r.Vendor, r.Deleted, r.Number,\n" +
                            "       r.Created, r.Updated,\n" +
                            "       v.VendorName, v.VendorType\n" +
                            "FROM Purchases.Receipts AS r\n" +
                            "LEFT JOIN Purchases.Vendors AS v\n" +
                            "       ON v.VendorID = r.Vendor\n" +
                            joins +
                            conditions + "\n" +
                            orders;
            cmd.CommandTimeout = 0;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sQuery;
            return cmd;
        }

        public static System.Data.SqlClient.SqlCommand ReceiptContents(Guid receipt_id){
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                string sQuery = "SELECT rc.ContentID, rc.ReceiptID, rc.Position, rc.ProductID, pp.ProductName,\n" +
                                "       rc.Amount, rc.Price, rc.Discount, rc.Units, rc.Buyer, rc.Receiver,\n" +
//                                "       bb.Surname AS BuyerSurname, bb.Name AS BuyerName, bb.SecondName AS BuyerSecondName,\n" +
//                                "       rr.Surname AS ReceiverSurname, rr.Name AS ReceiverName, rr.SecondName AS ReceiverSecondName,\n" +
                                "       bb.Surname + ' ' + SUBSTRING(bb.Name, 1,1) + '. ' + \n" +
                                "       SUBSTRING(bb.SecondName, 1,1) + '.' AS BuyerFullName,\n" +
                                "       rr.Surname + ' ' + SUBSTRING(rr.Name, 1,1) + '. ' + \n" +
                                "       SUBSTRING(rr.SecondName, 1,1) + '.' AS ReceiverFullName\n" +
                                "FROM Purchases.ReceiptContents AS rc\n" +
//                                "LEFT JOIN Purchases.Vendors AS v\n"+
//                                "       ON v.VendorID = r.Vendor\n" +
                                "LEFT JOIN Producer.Products AS pp\n" +
                                "       ON pp.ProductID = rc.ProductID\n" +
                                "LEFT JOIN Persons.Users AS bb\n" +
                                "       ON bb.UserID = rc.Buyer\n" +
                                "LEFT JOIN Persons.Users AS rr\n" +
                                "       ON rr.UserID = rc.Receiver\n" +
                                "WHERE rc.ReceiptID = @Receipt\n" +
                                "ORDER BY rc.Position";
                cmd.Parameters.AddWithValue("@Receipt", receipt_id);
                cmd.CommandTimeout = 0;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sQuery;
                return cmd;
        }
/*
 SELECT r.ReceiptID, r.Price, pc.PriceSum
  FROM [Purchases].[Receipts] AS r
  LEFT JOIN ( SELECT ReceiptID, SUM(Amount*Price*(1-ISNULL(Discount, 0))) AS PriceSum
			    FROM [Purchases].[ReceiptContents]
			GROUP BY ReceiptID) AS pc
	     ON r.ReceiptID = pc.ReceiptID
WHERE r.Price <> pc.PriceSum
 */ 
    }
}
