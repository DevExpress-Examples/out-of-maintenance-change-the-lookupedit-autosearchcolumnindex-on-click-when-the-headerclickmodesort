Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.XtraEditors
Imports System.Reflection
Imports DevExpress.Utils.Win

Namespace WindowsFormsApplication1
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			Dim sortColumnIndex As Integer = LookUpEdit1.Properties.SortColumnIndex
		End Sub

	Private Function GetPopupForm(ByVal edit As LookUpEdit) As PopupLookUpEditForm
		Return CType((CType(edit, IPopupControl)).PopupWindow, PopupLookUpEditForm)
	End Function

	Private Function GetPopupFormViewInfo(ByVal popupForm As PopupLookUpEditForm) As PopupLookUpEditFormViewInfo
		Dim pi = GetType(PopupBaseForm).GetProperty("ViewInfo", BindingFlags.NonPublic Or BindingFlags.Instance)
		Return CType(pi.GetValue(popupForm), PopupLookUpEditFormViewInfo)
	End Function

	Private Function GetPressInfo(ByVal popupForm As PopupLookUpEditForm) As LookUpPopupHitTest
		Dim fi As FieldInfo = GetType(PopupLookUpEditForm).GetField("_pressInfo", BindingFlags.NonPublic Or BindingFlags.Instance)
		Return TryCast(fi.GetValue(popupForm), LookUpPopupHitTest)
	End Function

	Private popupForm As PopupLookUpEditForm

	Private Sub SavePopupParams(ByVal popupForm As PopupLookUpEditForm)
		Dim mi As MethodInfo = GetType(PopupLookUpEditForm).GetMethod("SavePopupParams", BindingFlags.Instance Or BindingFlags.NonPublic)
		mi.Invoke(popupForm, Nothing)
	End Sub

	Private Sub popupForm_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
		Dim popupForm As PopupLookUpEditForm = TryCast(sender, PopupLookUpEditForm)
		Dim vi As PopupLookUpEditFormViewInfo = GetPopupFormViewInfo(popupForm)
		Dim upTest As LookUpPopupHitTest = vi.GetHitTest(New Point(e.X, e.Y))
		Dim pressInfo As LookUpPopupHitTest = GetPressInfo(TryCast(sender, PopupLookUpEditForm))
		If upTest.HitType = pressInfo.HitType AndAlso upTest.Index = pressInfo.Index AndAlso Math.Abs(upTest.Point.X - pressInfo.Point.X) < SystemInformation.DragSize.Width AndAlso (Math.Abs(upTest.Point.Y - pressInfo.Point.Y) < SystemInformation.DragSize.Height) AndAlso upTest.HitType = DevExpress.XtraEditors.Popup.LookUpPopupHitType.Header Then
			vi.AutoSearchHeaderIndex = upTest.Index
			SavePopupParams(popupForm)
		End If
	End Sub

		Private Sub LookUpEdit1_CloseUp(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles LookUpEdit1.CloseUp

			If popupForm IsNot Nothing AndAlso popupForm.CurrentValue IsNot Nothing Then
				RemoveHandler popupForm.MouseUp, AddressOf popupForm_MouseUp
			End If
		End Sub

		Private Sub LookUpEdit1_Popup(ByVal sender As Object, ByVal e As EventArgs) Handles LookUpEdit1.Popup
			popupForm = GetPopupForm(TryCast(sender, LookUpEdit))
			If popupForm IsNot Nothing Then
				AddHandler popupForm.MouseUp, AddressOf popupForm_MouseUp
			End If
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim table As New DataTable()
			table.Columns.Add("ID", GetType(Int32))
			table.Columns.Add("PRODUCT")
			table.Columns.Add("PLATFORM")
			table.Rows.Add(1, "Grid", "VCL")
			table.Rows.Add(2, "TreeList", "VCL")
			table.Rows.Add(3, "VerticalGrid", "VCL")
			table.Rows.Add(4, "Bars", "VCL")
			table.Rows.Add(5, "Editors", "VCL")
			table.Rows.Add(6, "Grid", ".Net")
			table.Rows.Add(7, "TreeList", ".Net")
			table.Rows.Add(8, "VerticalGrid", ".Net")
			table.Rows.Add(9, "Bars", ".Net")
			table.Rows.Add(10, "Editors", ".Net")
			LookUpEdit1.Properties.DataSource = table
			LookUpEdit1.Properties.ValueMember = "ID"
			LookUpEdit1.Properties.DisplayMember = "PRODUCT"
			LookUpEdit1.Properties.PopulateColumns()
		End Sub
	End Class
End Namespace
