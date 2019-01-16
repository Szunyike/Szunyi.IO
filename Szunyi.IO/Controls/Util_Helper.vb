Imports System.Xml.Serialization

Public Class Util_Helpers
    Public Shared Function Get_All_Enum_Names_Values(Of t)(ByVal currentlySelectedEnum As Object) As List(Of String)
        Dim out As New List(Of String)
        Dim enumList As Type = GetType(t)
        If Not enumList.IsEnum Then Throw New InvalidOperationException("Object is not an Enum.")

        Dim values() As Integer = CType([Enum].GetValues(GetType(t)), Integer())
        Dim Names() = CType([Enum].GetNames(GetType(t)), String())


        For i1 = 0 To values.Count - 1
            out.Add(Names(i1) & ":" & values(i1))
        Next
        Return out


    End Function

    Public Shared Function Get_All_Enum_Names(Of t)(ByVal currentlySelectedEnum As Object) As List(Of String)
        Dim out As New List(Of String)
        Dim enumList As Type = GetType(t)
        If Not enumList.IsEnum Then Throw New InvalidOperationException("Object is not an Enum.")

        Dim values() As Integer = CType([Enum].GetValues(GetType(t)), Integer())
        Dim Names() = CType([Enum].GetNames(GetType(t)), String())

        Return Names.ToList


    End Function
    Public Shared Function Get_Enum_Name(Of T)(first As String) As String
        Dim enumList As Type = GetType(T)
        Dim x = CType([Enum].Parse(GetType(T), first), T)
        Dim values() As Integer = CType([Enum].GetValues(GetType(T)), Integer())
        Dim Names() = CType([Enum].GetNames(GetType(T)), String())

        For i1 = 0 To Names.Count - 1
            If values(i1) = first Then
                Return Names(i1)
            End If
        Next
        Return -1
    End Function

    Public Shared Function Get_Enum_Value(Of T)(first As String) As Integer
        Dim enumList As Type = GetType(T)
        Dim x = CType([Enum].Parse(GetType(T), first), T)
        Dim values() As Integer = CType([Enum].GetValues(GetType(T)), Integer())
        Dim Names() = CType([Enum].GetNames(GetType(T)), String())

        For i1 = 0 To Names.Count - 1
            If Names(i1) = first Then
                Return values(i1)
            End If
        Next
        Return -1
    End Function
    Public Shared Function Get_Enum_Value(Of T)(Items As List(Of String)) As List(Of Integer)
        Dim enumList As Type = GetType(T)
        Dim x = CType([Enum].Parse(GetType(T), Items.First), T)
        Dim values() As Integer = CType([Enum].GetValues(GetType(T)), Integer())
        Dim Names() = CType([Enum].GetNames(GetType(T)), String())
        Dim out As New List(Of Integer)
        For Each Item In Items
            For i1 = 0 To Names.Count - 1
                If Names(i1) = Item Then
                    out.Add(values(i1))
                End If
            Next
        Next

        Return out
    End Function

    Public Shared Function Get_Property_Value(src As Object, Property_Name As String)
        Return src.GetType().GetProperty(Property_Name).GetValue(src)
    End Function
    Public Shared Function Set_Filter_Settings(Of t)(ls As List(Of Szunyi.IO.Filter_Setting)) As List(Of Szunyi.IO.Filter_Setting)
        For Each Item In ls
            Item.EnumValue = Get_Enum_Value(Of t)(Item.Name)
        Next
        Return ls
    End Function
End Class

Public Class XML
    Public Shared Function Serialize(Of T)(ByVal dataToSerialize As T) As String
        Try
            Dim stringwriter = New System.IO.StringWriter()
            Dim serializer = New XmlSerializer(GetType(T))
            serializer.Serialize(stringwriter, dataToSerialize)
            Return stringwriter.ToString()
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Shared Sub Serialize(Of T)(ByVal dataToSerialize As T, F As System.IO.FileInfo)
        Try
            Dim stringwriter = New System.IO.StringWriter()
            Dim serializer = New XmlSerializer(GetType(T))
            serializer.Serialize(stringwriter, dataToSerialize)
            '  Szunyi.IO.Export.Text(stringwriter.ToString(), F)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Shared Function Deserialize(Of T)(ByVal xmlText As String) As T
        Try
            Dim stringReader = New System.IO.StringReader(xmlText)
            Dim serializer = New XmlSerializer(GetType(T))
            Dim text = stringReader.ReadToEnd
            Dim k = serializer.Deserialize(stringReader)
            Return CType(serializer.Deserialize(stringReader), T)
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Shared Function Deserialize(Of T)(ByVal File As System.IO.FileInfo) As T
        Try

            Dim stringReader = New System.IO.StringReader(File.Read_All)
            Dim serializer = New XmlSerializer(GetType(T))


            Return CType(serializer.Deserialize(stringReader), T)
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class