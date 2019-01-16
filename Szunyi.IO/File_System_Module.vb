Imports System.IO
Imports System.Runtime.CompilerServices

''' <summary>
''' Module For Deleting Or Moving FIles
''' </summary>
Public Module File_System_Module
    ''' <summary>
    ''' Deletes Files Using Error Handling
    ''' </summary>
    ''' <param name="Files_To_Delete"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Delete(Files_To_Delete As IEnumerable(Of FileInfo)) As String
        Dim log As New System.Text.StringBuilder
        For Each File In Files_To_Delete
            Try
                File.Delete()
            Catch ex As Exception
                log.Append(ex.ToString).AppendLine()
            End Try
        Next
        Return log.ToString
    End Function
    ''' <summary>
    ''' Move Files Using Error Handling
    ''' </summary>
    ''' <param name="OriginalFiles"></param>
    ''' <param name="NewFIles"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Move(OriginalFiles As List(Of FileInfo), NewFIles As List(Of FileInfo))
        Dim log As New List(Of String)
        For i1 = 0 To OriginalFiles.Count - 1
            Move(OriginalFiles(i1), NewFIles(i1), log)
        Next
        Return log
    End Function
    ''' <summary>
    ''' Move File Using Error Handling
    ''' </summary>
    ''' <param name="OriginalFile"></param>
    ''' <param name="NewFIle"></param>
    ''' <param name="log"></param>
    <Extension()>
    Public Sub Move(OriginalFile As FileInfo, NewFIle As FileInfo, log As List(Of String))
        Try
            If NewFIle.Exists = False Then
                OriginalFile.MoveTo(NewFIle.FullName)
            End If

        Catch ex As Exception
            log.Add("Unable Move From " & OriginalFile.FullName & " to " & NewFIle.FullName)
        End Try

    End Sub
    ''' <summary>
    ''' Move Files into Dictionary Using Error Handling
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <param name="Dir"></param>
    ''' <param name="log"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Move(Files As List(Of FileInfo), Dir As DirectoryInfo, log As List(Of String))
        Dim Out As New List(Of FileInfo)
        For Each OriginalFile In Files
            Dim NewFile = New FileInfo(Dir.FullName & OriginalFile.Name)
            Try

                Out.Add(NewFile)
                If NewFile.Exists = False Then
                    OriginalFile.MoveTo(NewFile.FullName)
                End If

            Catch ex As Exception
                log.Add("Unable Move From " & OriginalFile.FullName & " to " & NewFile.FullName)
            End Try

        Next

        Return Out
    End Function

End Module


