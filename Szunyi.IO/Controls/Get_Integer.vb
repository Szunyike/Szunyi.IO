﻿Imports System.ComponentModel
Imports Szunyi.IO.Outer_Programs

Namespace Controls
    Public Class Get_Integer

        Dim m_MIn_Value As Integer
        Dim m_Max_Value As Integer
        Public Property i_P As Input_Description
        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Public Sub New(Label As String, Def_Value As Integer, Min_Value As Double, Max_Value As Double)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.Label1.Text = Label
            Me.TextBox1.Text = Def_Value
            Me.m_Max_Value = Max_Value
            Me.m_MIn_Value = Min_Value
            Me.Dock = System.Windows.Forms.DockStyle.Top
        End Sub

        Public Sub New(i_P As Input_Description)
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.GroupBox1.Text = i_P.Flag
            Me.i_P = i_P
            Label1.DataBindings.Add(New System.Windows.Forms.Binding("Text", i_P, "Description"))

            If i_P.Default_Value <> Double.NaN Then Me.TextBox1.Text = i_P.Default_Value

            Me.m_Max_Value = i_P.MaxValue
            Me.m_MIn_Value = i_P.MinValue
            Me.Dock = System.Windows.Forms.DockStyle.Top
            TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", i_P, "Default_Value"))

        End Sub


        Private Sub TextBox1_Validating(sender As Object, e As CancelEventArgs) Handles TextBox1.Validating
            Try
                Dim d As Integer = TextBox1.Text
                If Me.m_MIn_Value <> Double.NaN AndAlso d < Me.m_MIn_Value Then
                    MsgBox("Minimum value is too low. The minamle accepted values is " & Me.m_MIn_Value)
                    e.Cancel = True
                End If
                If Me.m_Max_Value <> Double.NaN AndAlso d > Me.m_Max_Value Then
                    MsgBox("Maximum value is too high. MAx accepted value is " & Me.m_Max_Value)
                    e.Cancel = True
                End If
            Catch ex As Exception
                MsgBox("Enter a valid integer")
                e.Cancel = True
            End Try
        End Sub



        Private Sub Get_Integer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        End Sub
    End Class
End Namespace

