using MahApps.Metro.Controls;

namespace SimpleCrud.Desktop
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HamburgerMenu_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        {
            this.HamburgerMenu.Content = e.InvokedItem;

            if (!e.IsItemOptions && this.HamburgerMenu.IsPaneOpen)
            {
                // You can close the menu if an item was selected
                // this.HamburgerMenu.SetCurrentValue(HamburgerMenuControl.IsPaneOpenProperty, false);
            }
        }
    }
}
