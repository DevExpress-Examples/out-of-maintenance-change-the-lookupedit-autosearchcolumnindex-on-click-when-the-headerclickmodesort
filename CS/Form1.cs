using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors;
using System.Reflection;
using DevExpress.Utils.Win;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int sortColumnIndex = LookUpEdit1.Properties.SortColumnIndex;
        }

    private PopupLookUpEditForm GetPopupForm(LookUpEdit edit ) {
        return (PopupLookUpEditForm)((IPopupControl)edit).PopupWindow;
    }

    private PopupLookUpEditFormViewInfo GetPopupFormViewInfo(PopupLookUpEditForm popupForm) {
        var pi = typeof(PopupBaseForm).GetProperty("ViewInfo", BindingFlags.NonPublic | BindingFlags.Instance);
        return (PopupLookUpEditFormViewInfo)pi.GetValue(popupForm);
    }

    private LookUpPopupHitTest GetPressInfo(PopupLookUpEditForm popupForm) {
        FieldInfo fi = typeof(PopupLookUpEditForm).GetField("_pressInfo", BindingFlags.NonPublic | BindingFlags.Instance);
        return fi.GetValue(popupForm) as LookUpPopupHitTest;
    }

    private PopupLookUpEditForm popupForm; 

    void SavePopupParams(PopupLookUpEditForm popupForm) {
        MethodInfo mi = typeof(PopupLookUpEditForm).GetMethod("SavePopupParams", BindingFlags.Instance | BindingFlags.NonPublic);
        mi.Invoke(popupForm, null);
    }

    private void popupForm_MouseUp(object sender, MouseEventArgs e)
    {
        PopupLookUpEditForm popupForm = sender as PopupLookUpEditForm;
        PopupLookUpEditFormViewInfo vi = GetPopupFormViewInfo(popupForm);
        LookUpPopupHitTest upTest = vi.GetHitTest(new Point(e.X, e.Y));
        LookUpPopupHitTest pressInfo = GetPressInfo(sender as PopupLookUpEditForm);
        if (upTest.HitType == pressInfo.HitType && upTest.Index == pressInfo.Index &&
            Math.Abs(upTest.Point.X - pressInfo.Point.X) < SystemInformation.DragSize.Width &&
            (Math.Abs(upTest.Point.Y - pressInfo.Point.Y) < SystemInformation.DragSize.Height) &&
            upTest.HitType == DevExpress.XtraEditors.Popup.LookUpPopupHitType.Header)
        {
            vi.AutoSearchHeaderIndex = upTest.Index;
            SavePopupParams(popupForm);
        }
    }
     
        private void LookUpEdit1_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {

            if (popupForm != null && popupForm.CurrentValue!= null) 
                popupForm.MouseUp -= new MouseEventHandler(popupForm_MouseUp);
        }

        private void LookUpEdit1_Popup(object sender, EventArgs e)
        {
            popupForm = GetPopupForm(sender as LookUpEdit);
            if (popupForm != null)
                popupForm.MouseUp += new MouseEventHandler(popupForm_MouseUp);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(Int32));
            table.Columns.Add("PRODUCT");
            table.Columns.Add("PLATFORM");
            table.Rows.Add(1, "Grid", "VCL");
            table.Rows.Add(2, "TreeList", "VCL");
            table.Rows.Add(3, "VerticalGrid", "VCL");
            table.Rows.Add(4, "Bars", "VCL");
            table.Rows.Add(5, "Editors", "VCL");
            table.Rows.Add(6, "Grid", ".Net");
            table.Rows.Add(7, "TreeList", ".Net");
            table.Rows.Add(8, "VerticalGrid", ".Net");
            table.Rows.Add(9, "Bars", ".Net");
            table.Rows.Add(10, "Editors", ".Net");
            LookUpEdit1.Properties.DataSource = table;
            LookUpEdit1.Properties.ValueMember = "ID";
            LookUpEdit1.Properties.DisplayMember = "PRODUCT";
            LookUpEdit1.Properties.PopulateColumns();
        }
    }
}
