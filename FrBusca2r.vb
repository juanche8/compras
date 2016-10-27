Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.XtraEditors.Controls
Public Class FrBusca2r
    Public Session1 As Session = XpoHelper.GetNewSession()
    Private Sub FrBusca2r_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        SpinEdit1.Focus()
    End Sub
    Private Sub FrBusca2r_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        xpsector.Session = Session1
        XpCollectionIdped.Session = Session1
        XpCollectionPedDet.Session = Session1
        XpCollectionestados.Session = Session1
        'Dim getrecords As SelectedData = Session1.ExecuteQuery("Select * from VistaPedidosDetalle")
        ''XpDataView1.LoadData(getrecords)
        'XpDataView1.LoadData(getrecords)
        Me.ActiveControl = SpinEdit1
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        XpCollectionIdped.CriteriaString = "IdPedido = " & SpinEdit1.Value
        XpCollectionPedDet.CriteriaString = "IdPedido = " & SpinEdit1.Value
        BarCodeControl1.Text = SpinEdit1.Value
    End Sub
    Private Sub SpinEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles SpinEdit1.EditValueChanged
        XpCollectionIdped.CriteriaString = "IdPedido = " & SpinEdit1.Value
        XpCollectionPedDet.CriteriaString = "IdPedido = " & SpinEdit1.Value
        BarCodeControl1.Text = SpinEdit1.Value
    End Sub
    Private Sub SpinEdit1_KeyUp(sender As Object, e As KeyEventArgs) Handles SpinEdit1.KeyUp
        XpCollectionIdped.CriteriaString = "IdPedido = " & SpinEdit1.Value

        XpCollectionPedDet.CriteriaString = "IdPedido = " & SpinEdit1.Value
        BarCodeControl1.Text = SpinEdit1.Value
    End Sub
End Class
