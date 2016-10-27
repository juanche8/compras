Imports System.Data.SqlClient
Imports MailBee.Mime
Imports MailBee.SmtpMail
Imports System.Data.OleDb
Imports System.Data

Module Module1
    Public Usuario As String
    Public Password As String
    Public Rol As String
    Public Sector As String
    Public Sectorid As Integer
    Public Aprobar As Integer
    Public Responsable As String
    Public Permiso As String
    Public Pedido As String
    Public Back As Integer
    Public Borrar As Integer
    Public Cotiza As Integer
    Public Vencer As Integer
    Public producto As Integer

    Public Function Sendmail(logfile As String, subject As String, provider As String, adjunto As String, cuerpo As String) As Boolean
        Dim mailer As New Smtp()
        mailer.SmtpServers.Add("srvcorreo.montagneoutdoors.local", "sistemas", "lobito1.2016")
        mailer.Message.From.AsString = "juanyoris@montagne.com.ar"
        mailer.Message.To.AsString = provider
        mailer.Message.Subject = subject
        mailer.Message.BodyPlainText = cuerpo
        mailer.AddAttachment(adjunto)
        mailer.Send()
        Return True
    End Function
End Module
