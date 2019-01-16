Imports System.Collections.Generic
Imports System.IO
Imports System.Windows.Forms
Imports System.Xml.Serialization

Public Class Filter
    Public Property Setting As New List(Of Filter_Setting)
    Public Property MyT As Type
    Private Property Dir As DirectoryInfo


    Private Sub Filter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub New(ls As List(Of String))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(T As Type, SettingDir As DirectoryInfo)

        ' This call is required by the designer.
        InitializeComponent()
        Me.Dir = SettingDir
        ' Add any initialization after the InitializeComponent() call.
        Dim kj = T.GetType
        If T.IsEnum = True Then

            Dim x As New Windows.Forms.DataGridViewComboBoxColumn()
            x.Items.AddRange(CType([Enum].GetNames(T), String()))
            Dim x1 As New Windows.Forms.DataGridViewComboBoxColumn()
            x1.Items.AddRange(Szunyi.IO.Util_Helpers.Get_All_Enum_Names(Of Szunyi.Common.Enums.Filter)(Szunyi.Common.Enums.Filter.Bigger).ToArray)
            dgv1.Columns.Add(x)
            dgv1.Columns.Add(x1)
            dgv1.Columns.Add(New DataGridViewTextBoxColumn)

        End If


    End Sub

    Private Sub dgv1_NewRowNeeded(sender As Object, e As DataGridViewRowEventArgs) Handles dgv1.NewRowNeeded

    End Sub
    Private Sub DoIt()
        For Each Row As DataGridViewRow In dgv1.Rows
            If Row.Cells(2).Value <> "" Then
                Dim x As New Filter_Setting
                x.Value = Row.Cells(2).Value
                x.EnumName = Szunyi.Common.Util_Helpers.Get_Enum_Value(Of Szunyi.Common.Enums.Filter)(Row.Cells(1).Value)
                x.Name = Row.Cells(0).Value
                Me.Setting.Add(x)
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DoIt()
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick

    End Sub

    Private Sub Save(sender As Object, e As EventArgs) Handles Button4.Click
        DoIt()
        Dim File = Szunyi.IO.File_To_Save(Szunyi.IO.File_Extensions.Xml, Me.Dir)
        Szunyi.IO.XML.Serialize(Of List(Of Filter_Setting))(Me.Setting, File)
        Dim h = Me.Setting.GetType
        Me.DialogResult = DialogResult.OK
        Me.close

    End Sub

    Private Sub Load(sender As Object, e As EventArgs) Handles Button3.Click

        Dim FIle = Szunyi.IO.Pick_Up.File(Szunyi.IO.File_Extensions.Xml)
        If IsNothing(FIle) = False Then
            Dim t As New List(Of Filter_Setting)
            Me.Setting = Szunyi.IO.XML.Deserialize(Of List(Of Filter_Setting))(FIle)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub
End Class

<Serializable>
Public Class Filter_Setting
    Public Property Name As String
    Public Property EnumValue As Integer
    Public Property Value As String
    Public Property EnumName As String
    Public Sub New()

    End Sub
End Class