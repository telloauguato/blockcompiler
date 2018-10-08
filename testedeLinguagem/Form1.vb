Imports System
Imports System.IO
Imports System.Text
Public Class Form1
    Function procedimento(ByVal code As Integer, ByVal obj As String) As String
        Dim codeText As String = Nothing
        If code = 0 Then
            codeText = "Compiler definition --> " & My.Settings.path & " --> " & My.Settings.saida
        ElseIf code = 1 Then
            codeText = "Start auto-compiler --> " & My.Settings.path
        ElseIf code = 2 Then
            codeText = "End compiler"
        ElseIf code = 3 Then
            codeText = "Re-copiler file auto --> this.file"
        ElseIf code = 4 Then
            codeText = "Open file --> this.file"
        ElseIf code = 5 Then
            codeText = "compiler project --> this.file --> " & My.Settings.saida
        ElseIf code = 6 Then
            codeText = "compiler complet --> this.file"
        ElseIf code = 7 Then
            codeText = "creating viewer --> " & obj
        ElseIf code = 8 Then
            codeText = "add var --> " & obj
        End If
        Return Now & " --> " & codeText & vbCrLf & monitora.Text
    End Function
    Function salvar(ByVal conteudo As String, ByVal name As String) As String
        Dim newText As StreamWriter = New StreamWriter(My.Settings.saida & "\" & name & ".php")
        newText.Write("<!doctype html><html><head><meta charset='utf8'>" & conteudo & "</body></html>")
        newText.Close()
        Return Nothing
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles act.Tick
        Dim info As FileInfo = New FileInfo(My.Settings.path)
        Dim base As String = My.Settings.base
        My.Settings.variaveis = Nothing
        My.Settings.valores = Nothing
        My.Settings.viewerNow = Nothing
        My.Settings.objects = Nothing
        My.Settings.objectsValues = Nothing
        My.Settings.viewerActive = False
        If info.Length <> base Then
            If actCheck.Checked Then
                compilador.Start()
            End If
        End If
    End Sub

    Private Sub editInfo_Click(sender As Object, e As EventArgs) Handles editInfo.Click
        Form2.ShowDialog()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.acesso = False Then
            Dim newText As StreamWriter = New StreamWriter(Application.StartupPath.ToString & "\block.block")
            newText.Write("set word 'Hello guys'" & vbCrLf & vbCrLf & "viewer index {" & vbCrLf & vbTab & "show word" & vbCrLf & "}")
            newText.Close()
            My.Computer.FileSystem.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Blocker")
            My.Settings.path = Application.StartupPath.ToString & "\block.block"
            My.Settings.saida = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Blocker"
            My.Settings.acesso = True
        End If
        path.Text = My.Settings.path
        saida.Text = My.Settings.saida
        Dim file As FileInfo = New FileInfo(My.Settings.path)
        My.Settings.base = file.Length
        monitora.Text = procedimento(0, Nothing)
        act.Start()
        monitora.Text = procedimento(1, Nothing)
    End Sub

    Private Sub actCheck_Click(sender As Object, e As EventArgs) Handles actCheck.Click
        If actCheck.Checked Then
            act.Start()
            compliler.Enabled = False
            monitora.Text = procedimento(1, Nothing)
        Else
            act.Stop()
            compliler.Enabled = True
            monitora.Text = procedimento(2, Nothing)
        End If
    End Sub

    Private Sub ver_Click(sender As Object, e As EventArgs) Handles ver.Click
        Diagnostics.Process.Start(My.Settings.saida)
    End Sub

    Private Sub compilador_Tick(sender As Object, e As EventArgs) Handles compilador.Tick
        Dim info As FileInfo = New FileInfo(My.Settings.path)
        My.Settings.variaveis = Nothing
        My.Settings.valores = Nothing
        My.Settings.base = info.Length
        monitora.Text = procedimento(3, Nothing)
        monitora.Text = procedimento(4, Nothing)
        Dim result As String = Nothing
        Dim str() As String
        Dim times As Integer = 0
        Dim texto As New IO.StreamReader(My.Settings.path)
        Dim linha As String = texto.ReadToEnd
        str = Split(linha, vbCrLf)
        Dim variaveis() As String = Nothing
        Dim valores() As String = Nothing
        Dim conteudo As String = Nothing
        Dim header As String = Nothing
        Dim conteudo2 As String = Nothing
        Dim conteudo3 As String = Nothing
        For i As Integer = 0 To str.Length - 1
            str(i) = str(i).Replace(vbTab, "")
            Dim codigo As String = str(i)
            Dim arraay() As String
            arraay = codigo.Split(" ")
            If arraay(0) = "set" Then
                My.Settings.variaveis = My.Settings.variaveis & arraay(1).ToString & ".var|var."
                conteudo2 = arraay(2).Replace("_", " ") & ".var|var."
                My.Settings.valores = My.Settings.valores & conteudo2
                conteudo2 = ""
            ElseIf arraay(0) = "object" Then
                My.Settings.objects = My.Settings.objects & arraay(1) & ".@@objects|objects@@."
                conteudo3 = String.Join(" ", arraay).Replace("object " & arraay(1), "")
                My.Settings.objectsValues = My.Settings.objectsValues & conteudo3 & ".@@objects|objects@@."
                conteudo3 = Nothing
            ElseIf arraay(0) = "viewer" Then
                My.Settings.viewerNow = arraay(1)
                My.Settings.viewerActive = True
                If times = 0 Then
                    Dim arrStr As String() = Directory.GetFiles(My.Settings.saida, "*.php")
                    For o As Integer = 0 To arrStr.Length - 1
                        File.Delete(arrStr(o))
                    Next
                    times = 1
                End If
                monitora.Text = procedimento(7, arraay(1))
            ElseIf arraay(0) = "show" Then
                Dim var() As String = My.Settings.variaveis.Split(".var|var.")
                Dim value() As String = My.Settings.valores.Split(".var|var.")
                Dim resultVar As String = Nothing
                For a As Integer = 0 To var.Length - 1
                    If var(a) = arraay(1) Then
                        resultVar = value(a).Replace("@dot", ".")
                        Exit For
                    End If
                Next
                conteudo = conteudo & resultVar
            ElseIf arraay(0) = "call" Then
                Dim var() As String = My.Settings.objects.Split(".@@objects|objects@@.")
                Dim value() As String = My.Settings.objectsValues.Split(".@@objects|objects@@.")
                Dim resultVar As String = Nothing
                For a As Integer = 0 To var.Length - 1
                    If var(a) = arraay(1) Then
                        Dim o As Integer = 0
                        For b As Integer = 2 To arraay.Length - 1
                            Dim varLink() As String = My.Settings.variaveis.Split(".var|var.")
                            Dim valueLink() As String = My.Settings.valores.Split(".var|var.")
                            Dim resultVarLink As String = Nothing
                            For c As Integer = 0 To varLink.Length - 1
                                If varLink(c) = arraay(b) Then
                                    resultVarLink = valueLink(c)
                                    Exit For
                                Else
                                    resultVarLink = arraay(b)
                                End If
                            Next
                            value(a) = value(a).Replace("{" & o & "}", resultVarLink.Replace("_", " ").Replace("@dot", "."))
                            o = o + 1
                        Next
                        resultVar = value(a)
                    End If
                Next
                conteudo = conteudo & resultVar
            ElseIf arraay(0) = "title" Then
                header = header & "<title>" & arraay(1).Replace("_", " ") & "</title>"
            ElseIf arraay(0) = "text" Then
                conteudo = conteudo & "<" & arraay(1) & ">" & String.Join(" ", arraay).Replace(arraay(0) & " " & arraay(1) & " ", "") & "</" & arraay(1) & ">"
            ElseIf arraay(0) = "link" Then
                Dim varLink() As String = My.Settings.variaveis.Split(".var|var.")
                Dim valueLink() As String = My.Settings.valores.Split(".var|var.")
                Dim resultVarLink As String = Nothing
                Dim resultVarLink2 As String = Nothing
                For a As Integer = 0 To varLink.Length - 1
                    If varLink(a) = arraay(1) Then
                        resultVarLink = valueLink(a)
                        Exit For
                    Else
                        resultVarLink = arraay(1)
                    End If
                Next
                For a As Integer = 0 To varLink.Length - 1
                    If varLink(a) = arraay(2) Then
                        resultVarLink2 = valueLink(a)
                        Exit For
                    Else
                        resultVarLink2 = arraay(2)
                    End If
                Next
                conteudo = conteudo & "<a href='" & resultVarLink & ".php'>" & resultVarLink2 & "</a>"
            ElseIf arraay(0) = "}" Then
                If My.Settings.viewerActive = True Then
                    salvar(header & "</head><body>" & conteudo, My.Settings.viewerNow)
                    My.Settings.viewerActive = False
                    conteudo = ""
                    header = ""
                End If
            ElseIf arraay(0) = "newLine" Then
                conteudo = conteudo & "<br />"
            ElseIf arraay(0) = "line" Then
                conteudo = conteudo & "<hr>"
            ElseIf arraay(0) = "img" Then
                conteudo = conteudo & "<img src='" & arraay(1) & "' alt='" & arraay(2).Replace("_", " ") & "'>"
            ElseIf arraay(0) = "lorem" Then
                Dim lorem As String = Nothing
                lorem = My.Settings.lorem.Substring(arraay(1), arraay(2))
                conteudo = conteudo & lorem
            ElseIf arraay(0) = "responsive" Then
                header = header & "<meta name='viewport' content='width=device-width, initial-scale=1'>"
            ElseIf arraay(0) = "theme" Then

            Else
                conteudo = conteudo & str(i)
            End If
        Next
        texto.Close()
        monitora.Text = procedimento(5, Nothing)
        monitora.Text = procedimento(6, Nothing)
        compilador.Stop()
    End Sub

    Private Sub compliler_Click(sender As Object, e As EventArgs) Handles compliler.Click
        compilador.Start()
    End Sub
End Class
