using System;
using System.Collections.Generic;
using System.Text;

namespace Effects{
    public class Dates{
        public static System.String GetMonthName(int Index){
            System.String MonthName = "";
            switch (Index){
                case 1:
                    MonthName = "������";
                    break;
                case 2:
                    MonthName = "�������";
                    break;
                case 3:
                    MonthName = "����";
                    break;
                case 4:
                    MonthName = "������";
                    break;
                case 5:
                    MonthName = "���";
                    break;
                case 6:
                    MonthName = "����";
                    break;
                case 7:
                    MonthName = "����";
                    break;
                case 8:
                    MonthName = "������";
                    break;
                case 9:
                    MonthName = "��������";
                    break;
                case 10:
                    MonthName = "�������";
                    break;
                case 11:
                    MonthName = "������";
                    break;
                case 12:
                    MonthName = "�������";
                    break;
                default:
                    MonthName = "�����������";
                    break;
            }
            return MonthName;
        }

    }
}
