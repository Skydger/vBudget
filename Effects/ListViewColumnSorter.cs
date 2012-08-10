using System;
using System.Collections.Generic;
using System.Text;

namespace Effects{
    using System.Collections;
    using System.Windows.Forms;

    /// <summary>
    /// This class is an implementation of the 'IComparer' interface.
    /// </summary>
    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int ColumnToSort;
        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder OrderOfSort;
        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y){
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Сравнение значений
            int ix = 0, iy = 0;
            decimal dx = 0, dy = 0;
            string xitem = listviewX.SubItems[ColumnToSort].Text;
            string yitem = listviewY.SubItems[ColumnToSort].Text;
            string dformat = "dd.MM.yyyy HH:mm";
            System.DateTime dtmx = System.DateTime.Now, dtmy = System.DateTime.Now;
            if (System.Int32.TryParse(xitem, out ix) &&
                System.Int32.TryParse(yitem, out iy)){
                compareResult = ix - iy;
            }else if ( System.Decimal.TryParse(xitem, out dx) &&
                       System.Decimal.TryParse(yitem, out dy)){
                compareResult = (int)(dx - dy);
            }else if (System.DateTime.TryParseExact( xitem, dformat,
                                                     System.Globalization.CultureInfo.InvariantCulture,
                                                     System.Globalization.DateTimeStyles.None, out dtmx) &&
                      System.DateTime.TryParseExact( yitem,dformat,
                                                     System.Globalization.CultureInfo.InvariantCulture,
                                                     System.Globalization.DateTimeStyles.None, out dtmy)){
                compareResult = System.DateTime.Compare(dtmx, dtmy);
                //int dyear = dtmx.Year - dtmy.Year;
                //int dmonth = dtmx.Month - dtmy.Month;
                //int dday = dtmx.Day - dtmy.Day;
                //int dhour = dtmx.Hour - dtmy.Hour;
                //int dmin = dtmx.Minute - dtmy.Minute;
                //int dsec = dtmx.Second - dtmy.Second;
                //compareResult = dyear * 365 * 24 * 3600;
                //compareResult -= dmonth * 31 * 24 * 3600;
                //compareResult -= dday * 24 * 3600;
                //compareResult -= dhour * 3600;
                //compareResult -= dmin * 60;
                //compareResult -= dsec;
            }else{
                compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
            }

            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending){
                // Ascending sort is selected, return normal result of compare operation
//                compareResult = compareResult;
            }else if (OrderOfSort == SortOrder.Descending){
                // Descending sort is selected, return negative result of compare operation
                compareResult = -compareResult;
            }else{
                // Return '0' to indicate they are equal
                compareResult = 0;
            }
            return compareResult;
        }
/*
        public int Compare(object x, object y)
        {
            int returnVal;
            // Determine whether the type being compared is a date type.
            try
            {
                // Parse the two objects passed as a parameter as a DateTime.
                System.DateTime firstDate =
                        DateTime.Parse(((ListViewItem)x).SubItems[col].Text);
                System.DateTime secondDate =
                        DateTime.Parse(((ListViewItem)y).SubItems[col].Text);
                // Compare the two dates.
                returnVal = DateTime.Compare(firstDate, secondDate);
            }
            // If neither compared object has a valid date format, compare
            // as a string.
            catch
            {
                // Compare the two items as a string.
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                            ((ListViewItem)y).SubItems[col].Text);
            }
            // Determine whether the sort order is descending.
            if (order == SortOrder.Descending)
                // Invert the value returned by String.Compare.
                returnVal *= -1;
            return returnVal;
        }
*/
        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn{
            set{
                ColumnToSort = value;
            }get{
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order{
            set{
                OrderOfSort = value;
            }get{
                return OrderOfSort;
            }
        }

    }
}
