Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Bars

Namespace SilverlightApplication66
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
		End Sub

		' After the Frame navigates, ensure the BarButton representing the current page is checked
		Private Sub ContentFrame_Navigated(ByVal sender As Object, ByVal e As NavigationEventArgs)
			For Each item As BarCheckItem In barManager1.Items
				item.IsChecked = item.Tag.ToString().Equals(e.Uri.ToString())
			Next item
		End Sub

		' If an error occurs during navigation, show an error window
		Private Sub ContentFrame_NavigationFailed(ByVal sender As Object, ByVal e As NavigationFailedEventArgs)
			e.Handled = True
			Dim errorWin As ChildWindow = New ErrorWindow(e.Uri)
			errorWin.Show()
		End Sub

		Private Sub barManager1_ItemClick(ByVal sender As Object, ByVal e As DevExpress.Xpf.Bars.ItemClickEventArgs)
			ContentFrame.Navigate(New Uri(e.Item.Tag.ToString(), UriKind.Relative))
		End Sub
	End Class
End Namespace