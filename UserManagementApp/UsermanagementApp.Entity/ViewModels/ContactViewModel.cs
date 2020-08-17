using System;
using System.Collections.Generic;
using System.Text;

namespace UsermanagementApp.Entity.ViewModels
{
    public class ContactViewModel
    {
        public int PageIndex { get; set; }
        public int TotalItems { get; set; }
        public List<UserContact> Items { get; set; }
    }
}
