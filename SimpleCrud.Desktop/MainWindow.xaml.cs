using MahApps.Metro.Controls;

namespace SimpleCrud.Desktop
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void HamburgerMenuControl_OnItemClick(object sender, ItemClickEventArgs args)
        {
            this.HamburgerMenuControl.Content = args.ClickedItem;
            this.HamburgerMenuControl.IsPaneOpen = false;
        }
    }
}
