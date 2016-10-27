Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports SistemaCompras.MontagneAdministracion.Sectores
Imports SistemaCompras.MontagneAdministracion
Public Class LoginForm1

    Public Session1 As Session = XpoHelper.GetNewSession()

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Close()
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim querylinq As New XPQuery(Of Usuarios)(Session1)             'asignacion de querylinq a las tablas de la bd como session1
        Dim querylinq2 As New XPQuery(Of Pedidos)(Session1)
        Dim querylinq3 As New XPQuery(Of Sectores)(Session1)
        Dim habilitado As Integer
        Dim list = From o In querylinq Where o.UsuarioID = Username.Text And o.Contraseña = Password.Text Select o  ' Declara y asigna espacio de almacenamiento para una o varias variables.
        Dim count As Integer = list.Count()

        If count > 0 Then                                                ' si count es mayor a 0 entonces 
            Usuario = Username.Text                                      ' toma el usuario del textbox usuario para validar, al igual que la contraseña
            Responsable = list.First.Nombres & " " & list.First.Apellidos   ' asigna a la variable responsable un string concatenado del nombre y apellido entre un espacio.
            Sectorid = CInt(list.First.Area)                                ' declara sectorid convirtiendolo a entero, el area del usuario (y contraseña)
            Dim list1 = From o In querylinq3 Where o.IdSector = Sectorid Select o.Sector    'asigna list1 desde querylinq3 donde idsector es Sectorid de la tabla sectores y selecciona el sector actual.
            Sector = list1.FirstOrDefault                                   ' toma el primer o default sectorid para asignarlo a Sector.
            Permiso = list.First.SeccionOficina                             ' a Permiso se le asigna el primero de la list(usuario y contraseña) de SeccionOficina
            Cotiza = list.First.Cotiza
            'habilitado = list.First.Habilitado
            Dim inhabilitado = Session1.ExecuteScalar("select Habilitado from Usuarios where UsuarioID = '" & Usuario & "'")
            If inhabilitado = 0 Then
                MsgBox("Temporalmente estas inhabilitado", vbInformation)
                Return
            Else
                Hide()                                                          ' procede a esconder el form login
                FrPrincipalCompras.Show()
            End If
            'Reload(querylinq)
        Else                                                                ' si no se validan el usuario y contraseñas muestra el msgbox
            MsgBox("Usuario o Contraseña incorrectas")
            Password.SelectionStart = 0
            Password.SelectionLength = Password.Text.Length
        End If

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        FrCambioContrasenia.ShowDialog()
    End Sub

    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        System.IO.Directory.CreateDirectory("c:\Reportes\Pedidos")
        System.IO.Directory.CreateDirectory("c:\Reportes\ODCs")

    End Sub
End Class
