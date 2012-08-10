using System;
using System.Collections.Generic;
using System.Text;

namespace VisualControls{
    public class ListOptions{
        private bool bMultiSelect;

        public bool IsMultiSelect{
            get { return this.bMultiSelect; }
            set { this.bMultiSelect = value; }
        }

        public ListOptions(){
            this.bMultiSelect = true;
        }
        public ListOptions(bool multiselect){
            this.bMultiSelect = multiselect;
        }
    }
}
