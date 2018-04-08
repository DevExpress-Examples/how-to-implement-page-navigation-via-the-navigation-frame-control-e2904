using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Bars;

namespace SilverlightApplication66
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // After the Frame navigates, ensure the BarButton representing the current page is checked
        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            foreach (BarCheckItem item in barManager1.Items)
                item.IsChecked = item.Tag.ToString().Equals(e.Uri.ToString());
        }

        // If an error occurs during navigation, show an error window
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            e.Handled = true;
            ChildWindow errorWin = new ErrorWindow(e.Uri);
            errorWin.Show();
        }

        private void barManager1_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            ContentFrame.Navigate(new Uri(e.Item.Tag.ToString(), UriKind.Relative));
        }
    }
}