using System;
using System.Collections.Generic;
using System.Text;

namespace Purchases{
    /// <summary>
    /// ���� �������� �� �����
    /// </summary>
    public enum DateFilterType { Less = 1, LessOrEqual = 2, Equal = 3, Between = 4, MoreOrEqual = 5, More = 6, Exact = 7 };

    /// <summary>
    /// �������� ������ ����� �����
    /// </summary>
    public class Criteria{
        private int [] categories;
        private int [] vendors;
        private DateTime[] dates;
        private DateFilterType date_filter;
        private int top;

        /// <summary>
        /// ��������� �������
        /// </summary>
        public int [] Categories{
            get { return this.categories; }
            set{
                System.Array.Resize(ref this.categories, value.Length);
                System.Array.Copy(value, this.categories, value.Length);
            }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public int [] Vendors{
            get { return this.vendors; }
            set{
                System.Array.Resize(ref this.vendors, value.Length);
                System.Array.Copy(value, this.vendors, value.Length);
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        public DateTime[] Dates{
            get { return this.dates; }
            set{
                System.Array.Resize(ref this.dates, value.Length);
                System.Array.Copy(value, this.dates, value.Length);
            }
        }
        /// <summary>
        /// ��� ������� �� �����
        /// </summary>
        public DateFilterType DateFilter{
            get { return this.date_filter; }
            set { this.date_filter = value; }
        }
        /// <summary>
        /// ���������� ��������� �������
        /// </summary>
        public int Top{
            get { return this.top; }
            set { this.top = value; }
        }

        public Criteria(){
            this.categories = null;
            this.vendors = null;
            this.dates = null;
            this.date_filter = DateFilterType.Exact;
            this.top = -1;
        }
    }
}
