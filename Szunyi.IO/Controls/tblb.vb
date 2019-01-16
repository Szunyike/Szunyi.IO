Imports System.Reflection
''' <summary>
''' UserControl Designed For Selecting One or More components from
''' Either Enumerable Of String, Sequence Or FIle
''' </summary>
Public Class tblb
    Public Property Original As New List(Of Object)
    Public Property Selected As New List(Of Object)
    Public Property SelItem As Object
    Public Property DisplayMember As String
    Public Event IndexChanged(ByVal Item As Object)
    Public Event D_Click(ByVal Item As Object)
    <System.ComponentModel.Browsable(False)>
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Private Originals As New List(Of Szunyi.Common.Common_Classes.KeyObject)

    Private Sub lb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lb.SelectedIndexChanged
        If lb.SelectedIndex <> -1 Then
            SelItem = lb.Items(lb.SelectedIndex)
            RaiseEvent IndexChanged(lb.Items(lb.SelectedIndex))
        End If
    End Sub
    Private Sub lb_DoubleClick(sender As Object, e As EventArgs) Handles lb.DoubleClick
        RaiseEvent D_Click(SelItem)
    End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ls As List(Of Object), DisplayMember As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DisplayMember = DisplayMember
        Me.Original = ls
    End Sub
    Private Sub Set_Originals()
        Me.Originals = New List(Of Common.Common_Classes.KeyObject)

        For Each Item In Me.Original

            Me.Originals.Add(New Common.Common_Classes.KeyObject(Szunyi.Common.Util_Helpers.Get_Property_Value(Item, DisplayMember), Item))
        Next
    End Sub
    Public Sub SetIt(ls As IEnumerable(Of Object), DisplayMember As String)
        Me.DisplayMember = DisplayMember

        If IsNothing(Me.Original) = True Then Me.Original = New List(Of Object)
        Me.Original = ls.ToList
        Set_Originals()

        lb.DataSource = Nothing
        lb.DataSource = Original
        lb.DisplayMember = Me.DisplayMember

    End Sub
    Public Sub SetDisplayMember(DisplayMember As String)
        Me.DisplayMember = DisplayMember
        lb.DisplayMember = DisplayMember
        lb.DataSource = Me.Original
        Set_Originals()

    End Sub

    Private Sub tb1_TextChanged(sender As Object, e As EventArgs) Handles tb.TextChanged
        If tb.Text.Length > 2 Then
            UpdateIt(Get_Filterd_Result(tb.Text))
        Else
            Clear()
        End If
    End Sub
    Private Sub UpdateIt(ls As IEnumerable(Of Object))
        If IsNothing(Me.Selected) = True Then Me.Selected = New List(Of Object)
        Me.Selected.Clear()
        For Each Item In ls
            Me.Selected.Add(Item)
        Next
        lb.DataSource = Nothing
        lb.DataSource = Me.Selected
        lb.DisplayMember = Me.DisplayMember
    End Sub
    Private Sub Clear()
        lb.DataSource = Me.Original
        lb.DisplayMember = Me.DisplayMember
    End Sub
    Private Function Get_Filterd_Result(pattern As String) As IEnumerable(Of Object)
        Dim res = From x In Me.Originals Where IsNothing(x.Key) = False AndAlso x.Key.ToUpper.Contains(pattern.ToUpper)

        If res.Count > 0 Then
            Dim Final = From x In res Select x.Obj

            Return Final
        Else
            Return New List(Of Bio.Web.Blast.BlastSearchRecord)

        End If
    End Function
End Class
