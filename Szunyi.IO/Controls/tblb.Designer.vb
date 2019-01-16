<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tblb
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.tb = New System.Windows.Forms.TextBox()
        Me.lb = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'tb
        '
        Me.tb.Dock = System.Windows.Forms.DockStyle.Top
        Me.tb.Location = New System.Drawing.Point(0, 0)
        Me.tb.Name = "tb"
        Me.tb.Size = New System.Drawing.Size(369, 22)
        Me.tb.TabIndex = 0
        '
        'lb
        '
        Me.lb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lb.FormattingEnabled = True
        Me.lb.ItemHeight = 16
        Me.lb.Location = New System.Drawing.Point(0, 22)
        Me.lb.Name = "lb"
        Me.lb.Size = New System.Drawing.Size(369, 404)
        Me.lb.TabIndex = 1
        '
        'UserControl1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lb)
        Me.Controls.Add(Me.tb)
        Me.Name = "UserControl1"
        Me.Size = New System.Drawing.Size(369, 426)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tb As Windows.Forms.TextBox
    Friend WithEvents lb As Windows.Forms.ListBox
End Class
