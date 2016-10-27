Imports DevExpress.Xpo
Imports DevExpress.XtraEditors.Controls

Public Class Form1
    Dim i As Integer
    Public Session1 As Session = XpoHelper.GetNewSession()
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)


        For x = 0 To CheckedListBoxControl1.ItemCount - 1
            Try
                Dim email As String = Session1.ExecuteScalar("Select Email  from Proveedores where Email is not null AND Email <> ''  and RazonSocial like '" & CheckedListBoxControl1.GetDisplayItemValue(x) & "'").ToString
            Catch ex As Exception
                If x = 0 Then
                    MsgBox("Solo se enviaran mails a los Proveedores que quedan seleccionados " & vbNewLine & "debido a que el resto no poseen correos electronicos asignados", vbInformation)
                Else
                End If
                CheckedListBoxControl1.SetItemChecked(x, CheckState.Unchecked)
            End Try
        Next

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        XpCollection1.Session = Session1

    End Sub

    Private Sub PopupContainerEdit1_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckedListBoxControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBoxControl1.SelectedIndexChanged

    End Sub

    Sub CheckedListBoxControl1_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles CheckedListBoxControl1.ItemCheck
        ' TextEdit1.Text = CheckedListBoxControl1.Text

    End Sub

    Private Sub CheckedListBoxControl1_ItemChecking(sender As Object, e As ItemCheckingEventArgs) Handles CheckedListBoxControl1.ItemChecking
        Dim i = CheckedListBoxControl1.Text

        TextEdit1.Text = i.ToString + "," + TextEdit1.Text
    End Sub
End Class