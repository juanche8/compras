<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.XpCollection1 = New DevExpress.Xpo.XPCollection(Me.components)
        Me.PopupContainerControl1 = New DevExpress.XtraEditors.PopupContainerControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.CheckedListBoxControl1 = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.PopupContainerEdit1 = New DevExpress.XtraEditors.PopupContainerEdit()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        CType(Me.XpCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PopupContainerControl1.SuspendLayout()
        CType(Me.CheckedListBoxControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupContainerEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XpCollection1
        '
        Me.XpCollection1.DisplayableProperties = "IdProveedor;RazonSocial;Rubro"
        Me.XpCollection1.ObjectType = GetType(SistemaCompras.MontagneAdministracion.Proveedores)
        '
        'PopupContainerControl1
        '
        Me.PopupContainerControl1.Controls.Add(Me.SimpleButton1)
        Me.PopupContainerControl1.Controls.Add(Me.CheckedListBoxControl1)
        Me.PopupContainerControl1.Location = New System.Drawing.Point(26, 58)
        Me.PopupContainerControl1.Name = "PopupContainerControl1"
        Me.PopupContainerControl1.Size = New System.Drawing.Size(221, 171)
        Me.PopupContainerControl1.TabIndex = 16
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(0, 145)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton1.TabIndex = 14
        Me.SimpleButton1.Text = "enviar"
        '
        'CheckedListBoxControl1
        '
        Me.CheckedListBoxControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CheckedListBoxControl1.DataSource = Me.XpCollection1
        Me.CheckedListBoxControl1.DisplayMember = "RazonSocial"
        Me.CheckedListBoxControl1.Location = New System.Drawing.Point(0, 3)
        Me.CheckedListBoxControl1.MultiColumn = True
        Me.CheckedListBoxControl1.Name = "CheckedListBoxControl1"
        Me.CheckedListBoxControl1.Size = New System.Drawing.Size(218, 104)
        Me.CheckedListBoxControl1.SortOrder = System.Windows.Forms.SortOrder.Ascending
        Me.CheckedListBoxControl1.TabIndex = 13
        Me.CheckedListBoxControl1.ValueMember = "IdProveedor"
        '
        'PopupContainerEdit1
        '
        Me.PopupContainerEdit1.EditValue = "Seleccion de proveedor"
        Me.PopupContainerEdit1.Location = New System.Drawing.Point(26, 32)
        Me.PopupContainerEdit1.Name = "PopupContainerEdit1"
        Me.PopupContainerEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PopupContainerEdit1.Properties.PopupControl = Me.PopupContainerControl1
        Me.PopupContainerEdit1.Size = New System.Drawing.Size(232, 20)
        Me.PopupContainerEdit1.TabIndex = 15
        '
        'TextEdit1
        '
        Me.TextEdit1.Location = New System.Drawing.Point(52, 6)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Size = New System.Drawing.Size(206, 20)
        Me.TextEdit1.TabIndex = 17
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.TextEdit1)
        Me.Controls.Add(Me.PopupContainerControl1)
        Me.Controls.Add(Me.PopupContainerEdit1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.XpCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PopupContainerControl1.ResumeLayout(False)
        CType(Me.CheckedListBoxControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupContainerEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XpCollection1 As DevExpress.Xpo.XPCollection
    Friend WithEvents PopupContainerControl1 As DevExpress.XtraEditors.PopupContainerControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CheckedListBoxControl1 As DevExpress.XtraEditors.CheckedListBoxControl
    Friend WithEvents PopupContainerEdit1 As DevExpress.XtraEditors.PopupContainerEdit
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
End Class
