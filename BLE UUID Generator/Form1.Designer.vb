<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.btnCopyText = New System.Windows.Forms.Button()
        Me.txtUUID = New System.Windows.Forms.TextBox()
        Me.btnEnterUUID = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(13, 13)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(125, 35)
        Me.btnGenerate.TabIndex = 0
        Me.btnGenerate.Text = "&Generate UUID"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'txtOutput
        '
        Me.txtOutput.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtOutput.Font = New System.Drawing.Font("Lucida Console", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutput.Location = New System.Drawing.Point(0, 56)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.Size = New System.Drawing.Size(1005, 135)
        Me.txtOutput.TabIndex = 1
        '
        'btnCopyText
        '
        Me.btnCopyText.Enabled = False
        Me.btnCopyText.Location = New System.Drawing.Point(868, 12)
        Me.btnCopyText.Name = "btnCopyText"
        Me.btnCopyText.Size = New System.Drawing.Size(125, 35)
        Me.btnCopyText.TabIndex = 2
        Me.btnCopyText.Text = "&Copy"
        Me.btnCopyText.UseVisualStyleBackColor = True
        '
        'txtUUID
        '
        Me.txtUUID.Location = New System.Drawing.Point(315, 20)
        Me.txtUUID.Name = "txtUUID"
        Me.txtUUID.Size = New System.Drawing.Size(296, 20)
        Me.txtUUID.TabIndex = 3
        '
        'btnEnterUUID
        '
        Me.btnEnterUUID.Enabled = False
        Me.btnEnterUUID.Location = New System.Drawing.Point(617, 19)
        Me.btnEnterUUID.Name = "btnEnterUUID"
        Me.btnEnterUUID.Size = New System.Drawing.Size(75, 23)
        Me.btnEnterUUID.TabIndex = 4
        Me.btnEnterUUID.Text = "Enter"
        Me.btnEnterUUID.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(312, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(287, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Use formatter to split your own UUID with or without dashes"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1005, 191)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnEnterUUID)
        Me.Controls.Add(Me.txtUUID)
        Me.Controls.Add(Me.btnCopyText)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.btnGenerate)
        Me.Name = "Form1"
        Me.Text = "BLE UUID Generator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnGenerate As Button
    Friend WithEvents txtOutput As TextBox
    Friend WithEvents btnCopyText As Button
    Friend WithEvents txtUUID As TextBox
    Friend WithEvents btnEnterUUID As Button
    Friend WithEvents Label1 As Label
End Class
