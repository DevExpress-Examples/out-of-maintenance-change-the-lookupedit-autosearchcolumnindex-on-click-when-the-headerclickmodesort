Imports Microsoft.VisualBasic
Imports System
Namespace WindowsFormsApplication1
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.LookUpEdit1 = New DevExpress.XtraEditors.LookUpEdit()
			CType(Me.LookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' LookUpEdit1
			' 
			Me.LookUpEdit1.Location = New System.Drawing.Point(169, 236)
			Me.LookUpEdit1.Name = "LookUpEdit1"
			Me.LookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.LookUpEdit1.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup
			Me.LookUpEdit1.Size = New System.Drawing.Size(400, 20)
			Me.LookUpEdit1.TabIndex = 1
'			Me.LookUpEdit1.CloseUp += New DevExpress.XtraEditors.Controls.CloseUpEventHandler(Me.LookUpEdit1_CloseUp);
'			Me.LookUpEdit1.Popup += New System.EventHandler(Me.LookUpEdit1_Popup);
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(738, 493)
			Me.Controls.Add(Me.LookUpEdit1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.LookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Friend WithEvents LookUpEdit1 As DevExpress.XtraEditors.LookUpEdit
	End Class
End Namespace

