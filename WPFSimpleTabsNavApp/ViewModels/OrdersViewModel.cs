using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSimpleTabsNavApp.ViewModels
{
    public class OrdersViewModel : BaseViewModel
    {
        // Existing Orders property
        public string Orders { get; set; } = "Here is the list of orders.";

        // New Title property
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public OrdersViewModel()
        {
            // Set default title or modify as needed
            Title = "Orders List"; // Example title
        }
    }
}
