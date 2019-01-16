Imports System.Windows.Forms
Imports Szunyi.IO.Outer_Programs

Namespace Controls
    Public Class Set_Console_Properties
        Public Property Input_Descriptions As New List(Of Outer_Programs.Input_Description)
        Public Property obj As Object
        Public Sub New(obj As Object)
            Me.obj = obj
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Dim t = obj.GetType
            If t.IsClass = True Then
                Dim Props = t.GetProperties
                Dim gr1 As New OK_Cancel

                '  Panel1.Controls.Add(gr1)
                AddHandler gr1.Button1.Click, AddressOf bOK_CLick
                AddHandler gr1.Button2.Click, AddressOf bCancel_Click
                For Each Prop In Props
                    Dim Pinfo = Prop.PropertyType.GetProperties()
                    Dim t1 = Prop.GetType
                    Dim I_P As Outer_Programs.Input_Description = Prop.GetValue(obj)
                    '       Dim pinfo2 = sI_Pg2.GetType.GetProperties
                    '   Dim x1 = CType(Prop, Szunyi.Outer_Programs.Input_Description)
                    Me.Input_Descriptions.Add(I_P)

                    Select Case I_P.Type
                        Case Outer_Programs.Input_Description_Type.Boolean
                            '   Dim gr As New CheckBox(I_P)

                         '   Me.Panel1.Controls.Add(gr)
                        Case Outer_Programs.Input_Description_Type.Double
                            Dim r As New Get_Double(I_P)
                            Me.Panel1.Controls.Add(r)
                        Case Outer_Programs.Input_Description_Type.Integer
                            Dim r As New Get_Integer(I_P)
                            Me.Panel1.Controls.Add(r)
                        Case Outer_Programs.Input_Description_Type.Selection
                            Dim x As New cb(I_P)
                            Me.Panel1.Controls.Add(x)
                        Case Outer_Programs.Input_Description_Type.String
                            Dim x As New GroupBox
                            Me.Panel1.Controls.Add(x)

                            Dim x1 As New Label
                            x1.DataBindings.Add(New System.Windows.Forms.Binding("Text", I_P, "Description"))
                            x1.Dock = DockStyle.Top
                            x.Controls.Add(x1)

                            Dim x2 As New TextBox
                            x2.DataBindings.Add(New System.Windows.Forms.Binding("Text", I_P, "Default_Value"))
                            x2.Dock = DockStyle.Top
                            x.Controls.Add(x2)
                            x.Dock = DockStyle.Top
                            Me.Panel1.Controls.Add(x)
                    End Select

                Next
                Panel1.Controls.Add(gr1)



            End If

        End Sub

        Private Sub bCancel_Click(sender As Object, e As EventArgs)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub bOK_CLick(sender As Object, e As EventArgs)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        End Sub
    End Class
End Namespace

Namespace Outer_Programs
    Public Class Settings_For_Console
        Public Shared Function Get_Console_Command(x As List(Of Input_Description)) As String
            Dim str As New System.Text.StringBuilder
            For Each pron In x
                If pron.Selected_Value <> String.Empty Then
                    Select Case pron.Type
                        Case Input_Description_Type.Boolean
                            If pron.Selected_Value = 1 Then
                                str.Append("-").Append(pron.Flag).Append(" ")
                            Else
                                str.Append("-").Append(pron.Flag).Append(" ")
                            End If
                        Case Input_Description_Type.Selection
                            str.Append("-").Append(pron.Flag).Append(" ").Append(pron.Selected_Value).Append(" ")
                        Case Input_Description_Type.String

                        Case Else
                            If pron.Selected_Value <> Double.NaN.ToString Then
                                str.Append("-").Append(pron.Flag).Append(" ").Append(pron.Selected_Value).Append(" ")
                            End If
                    End Select

                End If

            Next
            Return str.ToString
        End Function
    End Class

    Public Class Input_Description
        Public Property Flag As String ' minsites, minw
        Public Property Type As Input_Description_Type ' Integer, Double, string, Selection 'Ey Enum$
        Public Property Description As String
        Public Property MinValue As Double
        Public Property MaxValue As Double
        Public Property Default_Min_Value As Double
        Public Property Default_Max_Value As Double
        Public Property Values As List(Of String)
        Public Property Selected_Value As String
        Public Property Default_Value As Double
        Public Property File_Flag As String
        Public Sub New(Type As Input_Description_Type)
            Me.Type = Type
        End Sub
        Public Sub New(Flag As String,
                           Type As Input_Description_Type,
                           Description As String,
                           MinValue As Double,
                           MaxValue As Double,
                           Default_Min_Value As Double,
                           Default_Max_Value As Double,
                           Default_Value As Double,
                           Selections As String,
                           File_Flag As String)
            Me.Flag = Flag
            Me.Type = Type
            Me.Description = Description
            Me.MinValue = MinValue
            Me.MaxValue = MaxValue
            Me.Default_Min_Value = Default_Min_Value
            Me.Default_Max_Value = Default_Max_Value
            Me.Default_Value = Default_Value
            Me.Values = Split(Selections, "|").ToList
            If Me.Type = Input_Description_Type.Selection Then
                Me.Selected_Value = Me.Values.First
            End If
            Me.File_Flag = File_Flag
        End Sub

        Public Sub New(Flag As String,
                           Type As Input_Description_Type,
                           Description As String,
                           MinValue As Double,
                           MaxValue As Double,
                           Default_Min_Value As Double,
                           Default_Max_Value As Double,
                           Default_Value As Double,
                           Selections As List(Of String),
                           File_Flag As String)
            Me.Flag = Flag
            Me.Type = Type
            Me.Description = Description
            Me.MinValue = MinValue
            Me.MaxValue = MaxValue

            Me.Default_Min_Value = Default_Min_Value
            Me.Default_Max_Value = Default_Max_Value
            Me.Default_Value = Default_Value
            Me.Values = Selections
            If Me.Type = Input_Description_Type.Selection Then
                Me.Selected_Value = Me.Values(Me.Default_Value)
            End If
            Me.File_Flag = File_Flag
        End Sub

    End Class

    Public Enum Input_Description_Type
        [Integer] = 1
        [Double] = 2
        [String] = 3
        Selection = 4
        [Boolean] = 5

    End Enum
End Namespace

Public Class Parameters
    Public Shared Function Get_Integer(Title As String) As Input_Description
        Dim x As New Szunyi.IO.Outer_Programs.Input_Description(Szunyi.IO.Outer_Programs.Input_Description_Type.Integer)
        x.Description = Title
        Return x
    End Function
    Public Shared Function Get_Integer(Title As String, Default_Value As Integer) As Input_Description
        Dim x As New Szunyi.IO.Outer_Programs.Input_Description(Szunyi.IO.Outer_Programs.Input_Description_Type.Integer)
        x.Default_Value = Default_Value
        x.MinValue = Integer.MinValue
        x.MaxValue = Integer.MaxValue
        x.Description = Title
        Return x
    End Function
    Public Shared Function Get_Integer(Title As String, Default_Value As Integer, Min As Integer) As Input_Description
        Dim x As New Szunyi.IO.Outer_Programs.Input_Description(Szunyi.IO.Outer_Programs.Input_Description_Type.Integer)
        x.Default_Value = Default_Value
        x.MinValue = Min
        x.MaxValue = Integer.MaxValue
        x.Description = Title
        Return x
    End Function
    Public Shared Function Get_Integer(Title As String, Default_Value As Integer, Min As Integer, Max As Integer) As Input_Description
        Dim x As New Szunyi.IO.Outer_Programs.Input_Description(Szunyi.IO.Outer_Programs.Input_Description_Type.Integer)
        x.Default_Value = Default_Value
        x.MinValue = Min
        x.MaxValue = Max
        x.Description = Title
        Return x
    End Function
End Class
