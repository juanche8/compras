Public Class RpODC
    Private Sub XrLabel26_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles XrLabel26.BeforePrint
        XrLabel26.Text = Now.Date.ToLongDateString
    End Sub
    ' 
End Class