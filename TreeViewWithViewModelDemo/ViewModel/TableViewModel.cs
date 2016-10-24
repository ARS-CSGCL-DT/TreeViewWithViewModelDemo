using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLib;

namespace TreeViewWithViewModelDemo.ViewModel
{
    class DescriptionViewModel :TreeViewItemViewModel
    {
        readonly Description _description;

        public DescriptionViewModel(Description description) 
            : base(null, true)
        {
            _description = description;
        }

        public string TableName
        {
            get { return _description.TableName; }
        }

        protected override void LoadChildren()
        {
            foreach (ID id in Database.ID(_description))
                base.Children.Add(new IDViewModel(id, this));
        }
    }
}
