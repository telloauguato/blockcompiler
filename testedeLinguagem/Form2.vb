
Public Class Form2
    Private Sub btnPath_Click(sender As Object, e As EventArgs) Handles btnPath.Click
        Dim ofd As New OpenFileDialog
        ofd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Blocker"
        ofd.Title = "Abrir arquivo"
        ofd.Filter = "block files (*.block)|*.block"
        Dim dr As DialogResult = ofd.ShowDialog()
        If dr = System.Windows.Forms.DialogResult.OK Then
            TextBox1.Text = ofd.FileName
        End If
    End Sub

    Private Sub btnSaida_Click(sender As Object, e As EventArgs) Handles btnSaida.Click
        Dim fbd As New FolderBrowserDialog
        Dim dr As DialogResult = fbd.ShowDialog()
        If dr = System.Windows.Forms.DialogResult.OK Then
            TextBox2.Text = fbd.SelectedPath
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text <> "" Then
            If TextBox2.Text <> "" Then
                My.Settings.path = TextBox1.Text
                My.Settings.saida = TextBox2.Text
                My.Settings.Save()
                My.Settings.Reload()
                Form1.path.Text = TextBox1.Text
                Form1.saida.Text = TextBox2.Text
                Form1.monitora.Text = Environment.UserName & "-->Time:(" & Now & ")" & vbCrLf & "Compiler definition: " & My.Settings.path & "<-->" & My.Settings.saida & vbCrLf & Form1.monitora.Text
                Me.Close()
            Else
                MsgBox("Não foi definida nenhuma saída!", MsgBoxStyle.OkOnly, "ERROR 988 - _Block Compiler")
            End If
        Else
            MsgBox("Não foi definido nenhum arquivo!", MsgBoxStyle.OkOnly, "ERROR 982 - _Block Compiler")
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.path
        TextBox2.Text = My.Settings.saida
    End Sub
End Class