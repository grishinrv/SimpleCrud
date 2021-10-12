using MahApps.Metro.Controls;
using SimpleCrud.MVVM.Services;

namespace SimpleCrud.Desktop
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            OperationTrackerService.OnOperationFinished += o =>
                StatusBlock.Text = $"{o.Activity}: {o.Name} finished at {o.CompletionTime}";
        }


        private void HamburgerMenuControl_OnItemClick(object sender, ItemClickEventArgs args)
        {
            this.HamburgerMenuControl.Content = args.ClickedItem;
            this.HamburgerMenuControl.IsPaneOpen = false;
        }
    }
}
