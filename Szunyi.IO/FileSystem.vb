Imports System.IO



Public Class FileSystem
        Public Shared Function Delete(Files_To_Delete As IEnumerable(Of FileInfo)) As String
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
        Public Shared Function Move(OriginalFiles As List(Of FileInfo), NewFIles As List(Of FileInfo))
            Dim log As New List(Of String)
            For i1 = 0 To OriginalFiles.Count - 1
                Move(OriginalFiles(i1), NewFIles(i1), log)
            Next
            Return log
        End Function
        Public Shared Sub Move(OriginalFile As FileInfo, NewFIle As FileInfo, log As List(Of String))
            Try
                If NewFIle.Exists = False Then
                    OriginalFile.MoveTo(NewFIle.FullName)
                End If

            Catch ex As Exception
                log.Add("Unable Move From " & OriginalFile.FullName & " to " & NewFIle.FullName)
            End Try

        End Sub
        Public Shared Function Move(Files As List(Of FileInfo), Dir As DirectoryInfo, log As List(Of String))
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
        Public Shared Sub Merge_Files(Files As List(Of FileInfo), SaveFile As FileInfo)
            Try
                Using sw As New StreamWriter(SaveFile.FullName)
                    For Each File In Files
                        For Each Line In Szunyi.IO.Import.Text.Parse(File)
                            sw.Write(Line)
                            sw.WriteLine()
                        Next
                    Next
                End Using
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Sub
    End Class


