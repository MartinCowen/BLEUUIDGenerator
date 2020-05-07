Imports System.Runtime.Remoting.Services

Public Class Form1
    Dim WithEvents tmrStartup As New Timer

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Dim g As String = GenerateGUIDCheckNotReserved()
        DisplayUUID(g)

    End Sub
    Private Sub DisplayUUID(g As String)

        Dim s As String
        Dim nl As String = Environment.NewLine

        s = "// TODO: add name of your UUID in the three lines below." & nl ' inform user that name needs to be added
        s &= "// UUID : " & g & nl & nl 'the UUID in "normal" format for the C comments
        s &= "#define _SERVICE_BASE_UUID    " & SplitReverseGUID(g) & nl 'the split reversed format required by Nordic SDK
        s &= "#define _SERVICE_UUD          " & "0x" & g.Substring(4, 4) & nl 'last 16 bits of first 32 bits of UUID

        txtOutput.Text = s
    End Sub


    ''' <summary>
    ''' Generates a GUID using Microsoft API which does not clash with BT SIG reserved UUIDs
    ''' </summary>
    ''' <returns>GUID string with dashes in upper case</returns>
    Private Function GenerateGUIDCheckNotReserved() As String
        Dim g As Guid

        'keep generating GUID until one meets the rules. Chance of looping at all is extremely low, so we don't need to worry about how to exit in those cases or indication to user that is busy
        Do
            g = Guid.NewGuid()
        Loop While IsUUID_BTSIG_Reserved(g.ToString)
        Return g.ToString.ToUpper   'personal preference for uppercase guids as are used in #defines in C
    End Function
    ''' <summary>
    ''' Checks UUID string to see if it is a BT SIG reserved type
    ''' </summary>
    ''' <param name="s">UUID as a string, either with dashes or without</param>
    ''' <returns>True if reserved</returns>
    Private Function IsUUID_BTSIG_Reserved(s As String) As Boolean

        Return s.Replace("-", "").EndsWith("00001000800000805F9B34FB")  'BT SIG reserved Base UUID as per https://www.novelbits.io/uuid-for-custom-services-and-characteristics/

    End Function
    ''' <summary>
    ''' Takes a GUID in format 03B80E5A-EDE8-4B33-A751-6CE34EC4C700 and produces little endian hex formatted comma separated list with containing brackets
    ''' </summary>
    ''' <param name="g">Guid in string format, can include dashes</param>
    ''' <returns>Little endian hex format comma separated list with containing brackets</returns>
    Private Function SplitReverseGUID(g As String) As String

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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'reduce user interaction by automatically generating one GUID at startup, after waiting for all painting to complete
        'the button is now there for generating _another_ guid
        tmrStartup.Interval = 50
        tmrStartup.Start()
    End Sub

    Private Sub tmrStartup_Tick(sender As Object, e As EventArgs) Handles tmrStartup.Tick
        tmrStartup.Stop() 'run once
        btnGenerate.PerformClick()
    End Sub

    Private Sub btnEnterUUID_Click(sender As Object, e As EventArgs) Handles btnEnterUUID.Click
        DisplayUUID(txtUUID.Text)
        If IsUUID_BTSIG_Reserved(txtUUID.Text) Then
            MessageBox.Show("This UUID is reserved by BT SIG!" & Environment.NewLine & "It must not be used as a Vendor Specific UUID.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub txtUUID_TextChanged(sender As Object, e As EventArgs) Handles txtUUID.TextChanged
        btnEnterUUID.Enabled = Guid.TryParse(txtUUID.Text, New Guid)
    End Sub

    Private Sub txtUUID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUUID.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Guid.TryParse(txtUUID.Text, New Guid) Then
                btnEnterUUID.PerformClick()
            End If
        End If
    End Sub
End Class
