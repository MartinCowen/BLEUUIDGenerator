Public Class Form1
    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Dim g As String = GenerateGUIDCheckNotReserved()
        Dim s As String
        Dim nl As String = Environment.NewLine

        s = "// TODO: add name of your UUID in the three lines below." & nl
        s &= "// UUID : " & g & nl & nl
        s &= "#define _SERVICE_BASE_UUID    " & SplitReverseGUID(g) & nl
        s &= "#define _SERVICE_UUD          " & "0x" & g.Substring(4, 4) & nl

        txtOutput.Text = s

    End Sub

    Private Function GenerateGUIDCheckNotReserved() As String
        Dim g As Guid

        Do
            g = Guid.NewGuid()
        Loop While g.ToString.Contains("0000-1000-8000-00805F9B34FB")   'BT SIG reserved Base UUID as per https://www.novelbits.io/uuid-for-custom-services-and-characteristics/

        Return g.ToString.ToUpper   'personal preference for uppercase guids as are used in #defines in C
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="g"></param>
    ''' <returns></returns>
    Private Function SplitReverseGUID(g As String) As String
        'takes g GUID in format 03B80E5A-EDE8-4B33-A751-6CE34EC4C700
        'produces little endian hex formatted comma seperated list with containing brackets

        'first get rid of the dashes so that it is one long string that we can run through
        Dim gs As String = g.Replace("-", "")

        Dim r As String = "{"

        For i As Integer = gs.Length - 2 To 0 Step -2

            r &= "0x" & gs.Substring(i, 2)

            'add on comma for all except final element
            If i >= 2 Then r &= ","

        Next i

        'add final bracket
        r &= "}"

        Return r
    End Function

    Private Sub txtOutput_TextChanged(sender As Object, e As EventArgs) Handles txtOutput.TextChanged

        btnCopyText.Enabled = Not (txtOutput.Text = String.Empty)
    End Sub

    Private Sub btnCopyText_Click(sender As Object, e As EventArgs) Handles btnCopyText.Click
        My.Computer.Clipboard.SetText(txtOutput.Text)
    End Sub
End Class
