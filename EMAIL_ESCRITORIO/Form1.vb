Imports System.Net.Mail

Public Class FrmEnviaCorreo

    Dim Correo As New Clientes
    Dim Mail As New MailMessage
    Dim S As New SmtpClient

    Private Sub BtnEnviar_Click(sender As Object, e As EventArgs) Handles BtnEnviar.Click
        Try
            If Me.TxtRemitente.Text = "" Then
                MsgBox("Ingrese Remitente", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "EnviaCorreo v2.0")
                Me.TxtRemitente.Focus()
            ElseIf Me.TxtPassword.Text = "" Then
                MsgBox("Ingrese Password", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "EnviaCorreo v2.0")
                Me.TxtPassword.Focus()
            Else
                Mail.From = New MailAddress(Me.TxtRemitente.Text)

                Dim x As Integer

                For x = 0 To Correo.Mostrar_Clientes.Rows.Count - 1
                    Mail.Bcc.Add(Correo.Mostrar_Clientes.Rows(x)(2).ToString)
                    Mail.Subject = "Notificación de Cobranza"
                    Mail.Body = "Financiera Solución" & Chr(13) & "Notificación de Cobranza" & Chr(13) & Chr(13) & "Estimado Sr. " & Correo.Mostrar_Clientes.Rows(x)(1).ToString & Chr(13) _
               & "Se le hace recordar que ha la fecha Ud. tiene una deuda de S/. " & Correo.Mostrar_Clientes.Rows(x)(3).ToString & " Nuevos Soles 00/100 con nuestra entidad financiera, sirva" _
               & " acercarce a nuestras oficinas para efectuar el pago correspondiente" & Chr(13) & Chr(13) & "Gracias." & Chr(13) & "Financiera Solución."

                    Mail.Priority = MailPriority.High

                    '//Configurando el SMTPCLIENTE

                    S.Host = "smtp.live.com"
                    S.Credentials = New Net.NetworkCredential(Me.TxtRemitente.Text, Me.TxtPassword.Text)
                    S.EnableSsl = True

                    S.Send(Mail)
                Next

                MsgBox("Mensaje enviado satisfactoriamente")
                Me.TxtRemitente.Clear()
                Me.TxtPassword.Clear()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "EnviaCorreo v2.0")
            Me.TxtRemitente.Clear()
            Me.TxtPassword.Clear()
            Me.TxtRemitente.Focus()
        End Try


       

    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Application.Exit()
    End Sub

    Private Sub FrmEnviaCorreo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TxtRemitente_Enter(sender As Object, e As EventArgs) Handles TxtRemitente.Enter
        Me.TxtRemitente.BackColor = Color.FromArgb(250, 250, 171)
    End Sub

    Private Sub TxtPassword_Enter(sender As Object, e As EventArgs) Handles TxtPassword.Enter
        Me.TxtPassword.BackColor = Color.FromArgb(250, 250, 171)
    End Sub

    Private Sub TxtRemitente_Leave(sender As Object, e As EventArgs) Handles TxtRemitente.Leave
        Me.TxtRemitente.BackColor = Color.White
    End Sub

    Private Sub TxtPassword_Leave(sender As Object, e As EventArgs) Handles TxtPassword.Leave
        Me.TxtPassword.BackColor = Color.White
    End Sub

    Private Sub TxtRemitente_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtRemitente.KeyDown
        If Keys.Control And e.KeyCode = Keys.A Then
            MsgBox("CTRL + A ")
        End If
    End Sub

    Private Sub FrmEnviaCorreo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
  
    End Sub
End Class
