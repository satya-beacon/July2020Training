using System;
using System.Collections.Generic;
using System.Text;

namespace UsermanagementApp.Entity.ViewModels
{
    public class ContactFilterViewModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string SearchString { get; set; }
    }
}
