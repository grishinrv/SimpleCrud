using MahApps.Metro.Controls;
using SimpleCrud.MVVM.Services;

namespace SimpleCrud.Desktop
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ApplicationStatusMessagesProvider.OnStatusMessage += m =>
                StatusBlock.Text = m;
        }


        private void HamburgerMenuControl_OnItemClick(object sender, ItemClickEventArgs args)
        {
            HamburgerMenuControl.Content = args.ClickedItem;
            HamburgerMenuControl.IsPaneOpen = false;
        }
    }
}
