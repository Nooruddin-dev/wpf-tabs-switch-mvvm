using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using WPFSimpleTabsNavApp.Views;

using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WPFSimpleTabsNavApp.ViewModels
{




    public class MainWindowViewModel : BaseViewModel
    {
        public ObservableCollection<TabItemViewModel> Tabs { get; set; } = new ObservableCollection<TabItemViewModel>();
        private TabItemViewModel _selectedTab;

        public TabItemViewModel SelectedTab
        {
            get => _selectedTab;
            set => SetProperty(ref _selectedTab, value);
        }

        public ICommand AddTabCommand { get; }
        public ICommand CloseTabCommand { get; }

        public MainWindowViewModel()
        {
            AddTabCommand = new RelayCommand<string>(AddTab);
            CloseTabCommand = new RelayCommand<TabItemViewModel>(CloseTab);
        }

      

        private void AddTab(string tabKey)
        {
            var existingTab = Tabs.FirstOrDefault(t => t.Key == tabKey);
            if (existingTab != null)
            {
                SelectedTab = existingTab;
                return;
            }

            TabItemViewModel newTab = tabKey switch
            {
                "HomeView" => new TabItemViewModel("Home", new HomeViewModel(), tabKey),
                "ProductsView" => new TabItemViewModel("Products", new ProductsViewModel(), tabKey),
                "OrdersView" => new TabItemViewModel("Orders", new OrdersViewModel(), tabKey),
                _ => null
            };

            if (newTab != null)
            {
                Tabs.Add(newTab);
                SelectedTab = newTab;
            }
        }

        private void CloseTab(TabItemViewModel tab)
        {
            if (tab != null)
            {
                Tabs.Remove(tab);

                // Set a new active tab if the current selected tab is closed
                if (SelectedTab == tab && Tabs.Any())
                {
                    SelectedTab = Tabs.First();
                }
            }
        }
    }
}
