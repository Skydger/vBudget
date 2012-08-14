using System;
using System.Collections.Generic;
using System.Text;

namespace Effects{
    public class Dates{
        public static System.String GetMonthName(int Index){
            System.String MonthName = "";
            switch (Index){
                case 1:
                    MonthName = "€нварь";
                    break;
                case 2:
                    MonthName = "февраль";
                    break;
                case 3:
                    MonthName = "март";
                    break;
                case 4:
                    MonthName = "апрель";
                    break;
                case 5:
                    MonthName = "май";
                    break;
                case 6:
                    MonthName = "июнь";
                    break;
                case 7:
                    MonthName = "июль";
                    break;
                case 8:
                    MonthName = "август";
                    break;
                case 9:
                    MonthName = "сент€брь";
                    break;
                case 10:
                    MonthName = "окт€брь";
                    break;
                case 11:
                    MonthName = "но€брь";
                    break;
                case 12:
                    MonthName = "декабрь";
                    break;
                default:
                    MonthName = "неизвестный";
                    break;
            }
            return MonthName;
        }

    }
}
