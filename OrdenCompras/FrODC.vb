Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.XtraReports.UI

Public Class FrODC
    Public Session1 As Session = XpoHelper.GetNewSession()
    Dim report As New RpODC()
    Dim tool As ReportPrintTool = New ReportPrintTool(report)
    Dim resultSet As SelectedData = Session1.ExecuteQuery("SELECT * from VistaODC")

    Private Sub FrODC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        XpDataView2.LoadData(resultSet)
        Pedidos.Session = Session1
        PedidosDetalles.Session = Session1
        'GridView2.Columns("colTotalProducto1").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "colTotalProducto1", "<Color=red>TOTAL</color>={0}")
        XpDataView2.FilterString = "Estado = 1 and ODCEnviada <> 1"
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click
        lblCUIT.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colCUIT_CUIL)
        lbldomicilio.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colDomicilio)
        lblemail.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colEmail)
        lbllocalidad.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colLocalidad)
        XpDataView1 = XpDataView2
        ' MsgBox(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colIdPedido1))
        ' GridView2.FindFilterText = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colIdPedido1).ToString
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        ' GridView1.SetFocusedRowCellValue(colODCEnviada, 1)

        '  Session1.ExecuteNonQuery("Update Pedidos SET Estado = 5 where IdPedido = " & CInt(GridView1.GetFocusedRowCellValue(colIdPedido)))



        ' PedidosDetalles.CriteriaString = "ODCEnviada <> 1"
        ' PedidosDetalles.Reload()
        If lblemail.Text = "" Then
            MsgBox("El proveedor no tiene email asignado.", vbCritical)
            Return

        Else
            report.FilterString = "IdPedido =" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colIdPedido) & "and IdProveedor= " & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colIdProveedor)
            report.ExportToPdf("C:\Reportes\ODCs\OrdenDeCompraNro-" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colIdPedido).ToString + ".pdf")
            report.CreateDocument()
            tool.Report.ShowPreviewDialog()

            Dim email1 As String = Session1.ExecuteScalar("Select Email  from Proveedores where Email is not null AND Email <> ''  and RazonSocial like '" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colRazonSocial) & "'").ToString
            Sendmail("logger", "Orden de Compra - Montagne Outdoors S.A", email1, "C:\Reportes\ODCs\OrdenDeCompraNro-" + GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colIdPedido).ToString & ".pdf", "Estimado " + GridView1.GetRowCellDisplayText(GridView1.FocusedRowHandle, colRazonSocial) + ", hemos recibido su cotización." & vbCrLf & "Debido a que estamos satisfechos con las condiciones, ésta ha sido seleccionada." & vbCrLf & "Como archivo adjunto se encuentra la Orden de Compra. " & vbCrLf & "Si tiene alguna inquietud o pregunta, por favor contactarnos." & vbCrLf & "Departamento de Compras Montagne.")
            MsgBox("El correo con la ORDEN DE COMPRA ha sido enviada al proveedor: " + GridView1.GetRowCellDisplayText(GridView1.FocusedRowHandle, colRazonSocial) + ".", vbInformation)
            Session1.ExecuteNonQuery("Update PedidosDetalles SET ODCEnviada = 1 where IdPedido =" & CInt(GridView2.GetFocusedRowCellValue(colIdPedido)) & "and IdProveedor = " & CInt(GridView2.GetFocusedRowCellValue(colIdProveedor)))
            Dim resultSet1 As SelectedData = Session1.ExecuteQuery("SELECT * from VistaODC")
            'XpDataView2.LoadData(resultSet1)
            XpDataView2.FilterString = "Estado = 1 and ODCEnviada <> 1 "
            XpDataView2.LoadData(resultSet1)
            Pedidos.Reload()
        End If
    End Sub
End Class