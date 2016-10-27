Imports System.ComponentModel
Imports DevExpress.Xpo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI
Public Class FrPedidos
    'TRUNCATE TABLE (Transact-SQL) Quita todas las filas de una tabla sin registrar las eliminaciones individuales de filas. TRUNCATE TABLE es similar a la instrucción DELETE sin una cláusula WHERE; no obstante, TRUNCATE TABLE es más rápida y utiliza menos recursos de registros de transacciones y de sistema.

    Dim nped As Integer
    Public Idpedido As Integer
    Public Session1 As Session = XpoHelper.GetNewSession()
    Dim querylinq1 As New XPQuery(Of MontagneAdministracion.Pedidos)(Session1)
    Dim querylinq2 As New XPQuery(Of MontagneAdministracion.Usuarios)(Session1)
    Dim op = New MontagneAdministracion.Pedidos(Session1)
    ' selecciona y asigna el ultimo idpedido de la tabla pedidos
    Dim report As New RpPedidos()                                                 ' lineas para habilitar la asignacion de datos e impresion del reporte 
    Dim tool As ReportPrintTool = New ReportPrintTool(report)
    Private Sub FrPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        XpColDatosPedido.Session = Session1                                   ' se le asignan los xpcolection a la sesion iniciada (session1)
        XpColDetallePedido.Session = Session1
        XpColUsuario.Session = Session1
        XpColEstado.Session = Session1
        XpColProductos.Session = Session1
        XpColProveedores.Session = Session1
        If Cotiza = 1 Then                                              ' si el permiso es diferente a 1 (seccionoficina) se establecen los labels
            labelestado.Text = "Aprobado"
        Else
            labelestado.Text = "Pendiente de aprobacion"
        End If
        '  Else
        ' labelestado.Text = "Aprobado"
        '  End If
        Labelresponsable.Text = Responsable                                  ' asignamos los valores a los controles del formulario
        Labelfechapedido.Text = Now.Date.ToShortDateString                   ' al label se le asigna la fecha actual en formato corto
        Labelsector.Text = Sector

        fechaentrega.EditValue = Today.Date.AddDays(15) ' al datetime se le asigna el dia de hoy como valor inicial
        'If CheckEdit2.CheckState.Unchecked Then
        '  prioridad.Text = "Urgente"
        ' Else
        prioridad.Text = "Normal"
        'End If

        '''''''''''' 
        'selecciona la tabla pedidos a la session1
        With op
            .Sector = Sectorid                                'se asignan los datos a los campos de la tabla pedidos desde el control correspondiente
            .FechaPedido = Labelfechapedido.Text
            .Responsable = Labelresponsable.Text

            ' .Observaciones = memobserv.Text
            ' .FechaRecepcion = fechaentrega.DateTime

            ' .Urgente = prioridad.text

            '.Urgente = "Urgente"


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If labelestado.Text = "Aprobado" Then              ' si el label es aprobado, va a guardar en el campo estado el numero 2(APROBADO)
                .Estado = "2"
            Else
                .Estado = "7"                                  ' si no, guarda el 7, que por defecto es en espera de aprobacion.
            End If
            .Save()                                            ' guarda los objetos en la datastore     
        End With
        '''''''''''''
        Back = 0
        nped = Session1.ExecuteScalar("select max(IdPedido) from Pedidos")
        Labelnumeropedido.Text = nped
    End Sub
    Private Sub GridView1_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles GridView1.InitNewRow
        GridView1.SetRowCellValue(e.RowHandle, "FechaPedido", Mid(Now.Date.ToShortDateString, 1, 10))
        GridView1.SetRowCellValue(e.RowHandle, "Sector", Sector)
        GridView1.SetRowCellValue(e.RowHandle, "Responsable", Responsable)
        GridView1.SetRowCellValue(e.RowHandle, "IdPedido", nped)
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click       'Verifica si el usuario tiene elementos seleccionados en la grilla
        If GridView1.RowCount = 1 Then
            MsgBox("Aun no tienes nada seleccionado", vbOKOnly, "Sin items")
            Return
        End If

        For x = 0 To 0 'Step CheckedListBoxControl1.CheckedItems(CheckState.Checked)
            Try
                Dim producto As String = Session1.ExecuteScalar("Select IdProducto from PedidosDetalles where IdProducto = 0")
                Dim cantidad As String = Session1.ExecuteScalar("Select * from PedidosDetalles where Cantidad = .00")
                GridView1.RefreshData()
                If producto = "0" Then
                    MsgBox("Un campo no tiene producto asignado!", vbInformation)
                    Return
                End If
                If cantidad Is Nothing Then
                    If MsgBox("Seguro que desea finalizar el pedido?", vbYesNo, "Finalizar pedido?") = vbYes Then
                        Botonimprimir.Enabled = True
                        GridControl1.Enabled = False
                        MsgBox("Ahora puede imprimir su pedido!", vbInformation)
                        SimpleButton1.Enabled = False
                    End If
                Else

                    MsgBox("Hay un item sin cantidad asignada.", vbInformation)
                        GridView1.RefreshData()
                    End If
            Catch ex As Exception
            End Try
        Next
    End Sub
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        FrProductos.Show()
    End Sub
    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        '  MsgBox(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colIdDetalle))
        Dim del = Session1.ExecuteNonQuery("DELETE From PedidosDetalles Where IdDetalle = " & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, colIdDetalle))
        'Pedido = Pedido(del)2"
        GridView1.RefreshData()
        GridView1.DeleteSelectedRows()
    End Sub
    Private Sub BotonimprimirClick(sender As Object, e As EventArgs) Handles Botonimprimir.Click
        Dim querylinq1 As New XPQuery(Of MontagneAdministracion.Pedidos)(Session1)
        Dim aq = New MontagneAdministracion.Pedidos(Session1) 'selecciona la tabla pedidos a la session1
        With op
            '.IdPedido = GridView1.GetRowCellValue(0, colIdPedido)
            ' .Sector = Sectorid                                'se asignan los datos a los campos de la tabla pedidos desde el control correspondiente
            '.FechaPedido = Labelfechapedido.Text
            '.Responsable = Labelresponsable.Text
            .Observaciones = memobserv.Text
            .FechaRecepcion = fechaentrega.DateTime
            .Urgente = prioridad.Text

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'If nped = nped Then
            '    .IdPedido = nped
            'Else
            '    .IdPedido = nped + 1

            'End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'If labelestado.Text = "Aprobado" Then              ' si el label es aprobado, va a guardar en el campo estado el numero 2(APROBADO)
            '    .Estado = "2"
            'Else
            '    .Estado = "7"                                  ' si no, guarda el 7, que por defecto es en espera de aprobacion.
            'End If
            .Save()                                            ' guarda los objetos en la datastore     
        End With
        report.FilterString = "IdPedido =" & nped           ' se hace el filterstring con el IDPEDIDO de la tabla, y traigo el campo Pedido cargado en el load
        tool.Report.ShowPreviewDialog()                        ' luego muestro el preview del reporte
        SimpleButton1.Enabled = True
        Back = 1                                               ' estos dos ultimos son para cerrar y reabrir el formulario para actualizarlo
        Close()
    End Sub
    Private Sub FrPedidos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing ' advierte que pierde datos si no imprime, si acepta, se borran los registros de los pedidos seleccionados en la grid de la bdd
        If SimpleButton1.Enabled = False And Botonimprimir.Enabled = True Then
            If MsgBox("Debes imprimir el Comprobante para guardar los datos del pedido. ¿Desesas salir?", vbYesNo, "Atencion!") = vbNo Then
                e.Cancel = True
            Else
                'Dim del = Session1.ExecuteNonQuery("DELETE From PedidosDetalles Where IdPedido = " & nped)
                'Dim del1 = Session1.ExecuteNonQuery("DELETE From Pedidos Where IdPedido = " & nped)
                e.Cancel = False
            End If

        End If

    End Sub
    Private Sub fechaentrega_Validating(sender As Object, e As CancelEventArgs) Handles fechaentrega.Validating
        If fechaentrega.DateTime >= Today.Date.AddDays(15) Then
        Else
            MsgBox("Esta es una fecha estimada de entrega. No puede ser menor a 15 dias. Elegí una mayor a: " & Today.Date.AddDays(15), vbExclamation, "ERROR")
            fechaentrega.EditValue = Today.Date.AddDays(15)
            fechaentrega.Focus()
            If fechaentrega.DateTime < Date.Today Then
                MsgBox("No es posible esta seleccion.")
            End If
        End If
    End Sub
    Private Sub FrPedidos_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If SimpleButton1.Enabled = True And Botonimprimir.Enabled = False Then
            If MsgBox("No se ha terminado el proceso de Solicitud de Materiales. ¿Desesas salir?", vbYesNo, "Atencion!") = vbNo Then
                e.Cancel = True
            Else
                Dim del = Session1.ExecuteNonQuery("DELETE From PedidosDetalles Where IdPedido = " & Labelnumeropedido.Text)
                Dim del1 = Session1.ExecuteNonQuery("DELETE From Pedidos Where IdPedido = " & Labelnumeropedido.Text)
                e.Cancel = False
            End If

        End If
    End Sub
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If MsgBox("Se procedera a establecer la solicitud con motivo de urgencia", vbOKCancel) = vbCancel Then
        Else
            fechaentrega.CausesValidation = False
            fechaentrega.EditValue = Today
            imagurgente.Visible = True
            prioridad.Text = "Urgente"
        End If
    End Sub
    ''' <summary>
    ''' desde aca se haran los filtros de rubros por sector
    ''' pendiente de modificaciones
    ''' </summary>
    Private Sub GridControl1_Load(sender As Object, e As EventArgs) Handles GridControl1.Load   '''******* pendiente por seguir para clasificar rubros por sector******
        If Sectorid = 1 Then
            XpColProductos.CriteriaString = "Rubro = 'SISTEMAS'"
        End If
        If Sectorid = 3 Then
            XpColProductos.CriteriaString = "Rubro =  'SISTEMAS' or Rubro = 'FERRETERIA'"
            '  XpColProductos.CriteriaString = "Rubro =  'FERRETERIA'"
        End If
    End Sub
    Private Sub FrPedidos_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub
    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.CheckState = CheckState.Checked Then
            XpColProductos.CriteriaString = Nothing
            'XpColProductos.Reload()
        Else
            If Sectorid = 1 Then
                XpColProductos.CriteriaString = "Rubro = 'SISTEMAS'"
            End If
            If Sectorid = 3 Then
                XpColProductos.CriteriaString = "Rubro =  'SISTEMAS' or Rubro = 'FERRETERIA'"
                '  XpColProductos.CriteriaString = "Rubro =  'FERRETERIA'"
            End If
        End If
    End Sub
    Private Sub RepositoryItemGridLookUpEdit1_BeforePopup(sender As Object, e As EventArgs) Handles RepositoryItemGridLookUpEdit1.BeforePopup
        XpColProductos.Reload()
    End Sub

    Private Sub CheckEdit2_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckEdit2.CheckStateChanged
        If CheckEdit2.Checked Then
#Enable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance

            MsgBox("Se procedera a establecer la solicitud con motivo de urgencia", vbOKCancel)
            fechaentrega.CausesValidation = False
            fechaentrega.EditValue = Today
            imagurgente.Visible = True
            prioridad.Text = "Urgente"
            CheckEdit2.Text = "Prioridad: Urgente!"
            If fechaentrega.DateTime < Date.Today Then
                MsgBox("No es posible esta seleccion.")
            End If
        Else
            fechaentrega.CausesValidation = True
            If fechaentrega.DateTime >= Today.Date.AddDays(15) Then
            Else
                fechaentrega.EditValue = Today.Date.AddDays(15)
                fechaentrega.Focus()
                If fechaentrega.DateTime < Date.Today Then
                    MsgBox("No es posible esta seleccion.")
                End If
            End If

            imagurgente.Visible = False
            prioridad.Text = "Normal"
            CheckEdit2.Text = "Prioridad: Normal"
        End If
    End Sub

    Private Sub CheckEdit2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit2.CheckedChanged

    End Sub
End Class