using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFSimpleTabsNavApp.ViewModels
{

    public class TabItemViewModel : BaseViewModel
    {
        public string Key { get; }
        public string Title { get; }
        public object Content { get; } // This holds the ViewModel instance

        public TabItemViewModel(string title, object content, string tabKey)
        {
            Key = tabKey;
            Title = title;
            Content = content;
        }
    }
}
