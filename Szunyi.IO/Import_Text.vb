Imports System.IO

Namespace Import
    Public Class Text
        Public Shared Function Full(file As FileInfo) As String
            Try
                Using sw As New StreamReader(file.FullName)
                    Return sw.ReadToEnd
                End Using
            Catch ex As Exception
                MsgBox(ex.ToString)
                Return String.Empty
            End Try

        End Function
        Private Shared Iterator Function Get_Lines(Sr As StreamReader) As IEnumerable(Of String)
            Do
                Yield Sr.ReadLine
            Loop Until Sr.EndOfStream = True
        End Function
        Public Shared Iterator Function Parse(File As FileInfo, Optional Not_Start_With As String = "", Optional Start_With As String = "", Optional NofLine As Integer = -1) As IEnumerable(Of String)
            If File.Exists = True Then
                Using sr As New StreamReader(File.FullName)
                    If NofLine = -1 Then ' All Lines
                        If Not_Start_With = "" And Start_With = "" Then
                            For Each Line In Get_Lines(sr)
                                Yield Line
                            Next
                        ElseIf Not_Start_With <> "" And Start_With = "" Then
                            For Each Line In Get_Lines(sr)
                                If Line.StartsWith(Not_Start_With) = False Then Yield Line
                            Next
                        ElseIf Not_Start_With = "" And Start_With <> "" Then
                            For Each Line In Get_Lines(sr)
                                If Line.StartsWith(Start_With) = True Then Yield Line
                            Next
                        Else
                            For Each Line In Get_Lines(sr)
                                If Line.StartsWith(Start_With) = True And Line.StartsWith(Not_Start_With) = False Then Yield Line
                            Next
                        End If

                    Else
                        Dim Index As Integer = 0
                        If Not_Start_With = "" And Start_With = "" Then
                            For Each Line In Get_Lines(sr)
                                Yield Line
                                Index += 1
                                If Index = NofLine Then Exit For
                            Next
                        ElseIf Not_Start_With <> "" And Start_With = "" Then
                            For Each Line In Get_Lines(sr)
                                If Line.StartsWith(Not_Start_With) = False Then Yield Line
                                Index += 1
                                If Index = NofLine Then Exit For
                            Next
                        ElseIf Not_Start_With = "" And Start_With <> "" Then
                            For Each Line In Get_Lines(sr)
                                If Line.StartsWith(Start_With) = True Then Yield Line
                                Index += 1
                                If Index = NofLine Then Exit For
                            Next
                        Else
                            For Each Line In Get_Lines(sr)
                                If Line.StartsWith(Start_With) = True And Line.StartsWith(Not_Start_With) = False Then Yield Line
                                Index += 1
                                If Index = NofLine Then Exit For
                            Next
                        End If
                    End If
                End Using
            End If
        End Function

        Public Shared Function GetHeader(TheFile As FileInfo, NofHeaderLine As Integer,
                                 Optional ToRemove As List(Of String) = Nothing) As List(Of String)
            Dim res As New List(Of String)
            Dim s1() As String
            If IsNothing(TheFile) = True Then Return Nothing
            Using sr As New StreamReader(TheFile.FullName)
                If IsNothing(ToRemove) = True Then
                    For i1 = 1 To NofHeaderLine
                        s1 = Split(sr.ReadLine, vbTab)
                        If res.Count = 0 Then
                            res = s1.ToList
                        Else
                            For i2 = 0 To s1.Count - 1
                                res(i2) = res(i2) & " " & s1(i2)
                            Next
                        End If
                    Next
                Else
                    For i1 = 1 To NofHeaderLine
                        Dim Line As String = sr.ReadLine
                        For Each Item In ToRemove
                            Line = Line.Replace(Item, "")
                        Next
                        s1 = Split(Line, vbTab)
                        If IsNothing(res) = True Then
                            res = s1.ToList
                        Else
                            For i2 = 0 To s1.Count - 1
                                res(i2) = res(i2) & " " & s1(i2)
                            Next
                        End If
                    Next
                End If
            End Using
            Return res
        End Function

        Public Shared Function GetHeader(TheFile As FileInfo, NofHeaderLine As Integer,
                                  ToRemove As List(Of String),
                                  InterestingColumnsIDs As List(Of Integer)) As List(Of String)

            Dim res As New List(Of String)
            Dim resII As New Dictionary(Of Integer, String)
            Dim s1() As String
            If IsNothing(TheFile) = True Then Return Nothing
            Using sr As New StreamReader(File.OpenRead(TheFile.FullName))
                If NofHeaderLine = 0 Then
                    Do
                        Dim Line = sr.ReadLine
                        If Line.StartsWith("#") = False Then
                            res = Split(Line, vbTab).ToList
                            Exit Do
                        End If
                    Loop Until sr.EndOfStream = True
                Else

                    If IsNothing(InterestingColumnsIDs) = True Then
                        For i1 = 1 To NofHeaderLine
                            s1 = Split(sr.ReadLine, vbTab)
                            If res.Count = 0 Then
                                res = s1.ToList
                            Else
                                For i2 = 0 To s1.Count - 1
                                    res(i2) = res(i2) & " " & s1(i2)
                                Next
                            End If
                        Next
                    Else
                        For i1 = 1 To NofHeaderLine
                            s1 = Split(sr.ReadLine, vbTab)
                            For i2 = 0 To s1.Count - 1
                                If InterestingColumnsIDs.Contains(i2) = True Then
                                    If resII.ContainsKey(i2) = False Then
                                        resII.Add(i2, s1(i2))
                                    Else
                                        resII(i2) = resII(i2) & " " & s1(i2)
                                    End If
                                End If
                            Next
                        Next
                        res = resII.Values.ToList
                    End If
                End If


            End Using
            Return res
        End Function



#Region "Parse Iterator"
        Private Shared Function CloneStrings(ls As IEnumerable(Of String))
            Dim out As New List(Of String)
            For Each Item In ls
                out.Add(Item)
            Next
            Return out
        End Function
        Public Shared Iterator Function Read_Lines_by_Group(file As FileInfo, Nof_Line As Integer) As IEnumerable(Of List(Of String))
            If file.Exists = True Then
                Using sr As New StreamReader(file.FullName)

                    Do
                        Dim Out As New List(Of String)
                        For i1 = 1 To Nof_Line
                            Out.Add(sr.ReadLine)
                        Next

                        Yield Out
                    Loop Until sr.EndOfStream = True

                End Using
            End If

        End Function
        Public Shared Iterator Function Read_Lines_by_Group(file As FileInfo, Item_Separator As String) As IEnumerable(Of List(Of String))
            If file.Exists = True Then
                Using sr As New StreamReader(file.FullName)
                    Dim s As String
                    Dim Out As New List(Of String)
                    Do

                        s = sr.ReadLine
                        If s.StartsWith(Item_Separator) = True Then
                            If Out.Count = 0 Then
                                Out.Add(s)

                            Else
                                Yield Out
                                Out.Clear()
                                Out.Add(s)
                            End If
                        Else
                            Out.Add(s)
                        End If

                    Loop Until sr.EndOfStream = True
                    Yield Out
                End Using
            End If

        End Function

        Public Shared Iterator Function Parse_Group_Lines(File As FileInfo, Not_Start_With As String) As IEnumerable(Of List(Of String))
            If File.Exists = True Then
                Dim cLines As New List(Of String)
                Using sr As New StreamReader(File.FullName)
                    Do
                        Dim Line = sr.ReadLine
                        If Line.StartsWith(Not_Start_With) = True Then
                            If cLines.Count > 0 Then

                                Yield CloneStrings(cLines)
                                cLines.Clear()

                            End If

                        Else
                            cLines.Add(Line)
                        End If
                    Loop Until sr.EndOfStream = True
                    Yield cLines


                End Using
            End If
        End Function

        ''' <summary>
        ''' Into Lines Skip First Lines
        ''' </summary>
        ''' <param name="File"></param>
        ''' <param name="FirstLineIndex"></param>
        ''' <returns></returns>
        Public Shared Iterator Function ParseNotFirst(File As FileInfo, FirstLineIndex As Integer) As IEnumerable(Of String)
            Using sr As New StreamReader(File.FullName)
                For i1 = 1 To FirstLineIndex
                    sr.ReadLine()
                Next
                Do
                    Yield sr.ReadLine
                Loop Until sr.EndOfStream = True

            End Using
        End Function

        ''' <summary>
        ''' Into Array Skip Firts Lines
        ''' </summary>
        ''' <param name="file"></param>
        ''' <param name="Separator"></param>
        ''' <param name="FirstLineIndex"></param>
        ''' <returns></returns>
        Public Shared Iterator Function ParseToArray(file As FileInfo, Separator As String, FirstLineIndex As Integer) As IEnumerable(Of String())
            If IsNothing(file) = False Then

                If file.Exists = True Then
                    Using sr As New StreamReader(file.FullName)
                        For i1 = 1 To FirstLineIndex
                            sr.ReadLine()
                        Next
                        Do

                            Yield Split(sr.ReadLine, Separator)
                        Loop Until sr.EndOfStream = True
                    End Using
                End If
            End If

        End Function

        Public Shared Iterator Function ParseByDelimiter(file As FileInfo, LineSeparator As String, Optional EndOfInteresting As String = Nothing) As IEnumerable(Of List(Of String))
            If IsNothing(file) = False Then

                If file.Exists = True Then
                    If IsNothing(EndOfInteresting) = True Then
                        Using sr As New StreamReader(file.FullName)
                            Dim out As New List(Of String)
                            Do
                                Dim Line = sr.ReadLine
                                If Line.StartsWith(LineSeparator) = True Then
                                    If out.Count > 0 Then
                                        Yield out
                                        out.Clear()
                                    End If
                                Else

                                    out.Add(Line)
                                End If
                            Loop Until sr.EndOfStream = True
                            If out.Count > 0 Then Yield out
                        End Using
                    Else
                        Using sr As New StreamReader(file.FullName)
                            Dim out As New List(Of String)
                            Do
                                Dim Line = sr.ReadLine
                                If Line.StartsWith(LineSeparator) = True Then
                                    If out.Count > 0 Then
                                        Yield out
                                        out.Clear()
                                    End If
                                ElseIf Line.StartsWith(EndOfInteresting) Then
                                    Yield out
                                    Exit Function
                                Else

                                    out.Add(Line)
                                End If
                            Loop Until sr.EndOfStream = True
                            If out.Count > 0 Then Yield out
                        End Using
                    End If

                End If
            End If
        End Function

        Public Shared Function ParseFIrstLinesStartWiths(file As FileInfo, LineStart As String) As List(Of String)
            Dim out As New List(Of String)
            If IsNothing(file) = False Then

                If file.Exists = True Then
                    Try
                        Using sr As New StreamReader(file.FullName)

                            Do
                                Dim Line = sr.ReadLine
                                If IsNothing(Line) = False Then
                                    If Line.StartsWith(LineStart) = True Then
                                        out.Add(Line)
                                    Else
                                        Return out
                                    End If
                                End If

                            Loop Until sr.EndOfStream = True

                        End Using

                    Catch ex As Exception
                        Return New List(Of String)
                    End Try

                End If
            End If
            Return out
        End Function
        Public Shared Iterator Function Ignore_Before_Contains_Group_By_Start(fIle As FileInfo, First_Interesting_Line As String, separator As String) As IEnumerable(Of List(Of String))

            If IsNothing(fIle) = False Then

                If fIle.Exists = True Then
                    Try
                        Using sr As New StreamReader(fIle.FullName)
                            ' Find First Line
                            Dim Line As String
                            Do
                                Line = sr.ReadLine
                                If IsNothing(Line) = False Then
                                    If Line.Contains(First_Interesting_Line) = True Then
                                        Exit Do

                                    End If
                                Else
                                    Yield New List(Of String)
                                End If
                            Loop
                            Dim out As New List(Of String)
                            out.Add(Line) ' The First Line
                            Do
                                Line = sr.ReadLine
                                If Line.StartsWith(separator) = True Then
                                    out.Add(Line)
                                ElseIf Line = "" Then
                                    Dim u As Int16 = 65
                                Else

                                    Yield out
                                    out.Clear()
                                    out.Add(Line)
                                End If

                            Loop Until sr.EndOfStream = True

                        End Using

                    Catch ex As Exception

                    End Try

                End If
            End If

        End Function
        Public Shared Iterator Function Ignore_Before_Contains_Group_By_Not_Start(fIle As FileInfo, First_Interesting_Line As String, separator As String) As IEnumerable(Of List(Of String))

            If IsNothing(fIle) = False Then

                If fIle.Exists = True Then
                    Try
                        Using sr As New StreamReader(fIle.FullName)
                            ' Find First Line
                            Dim Line As String
                            Do
                                Line = sr.ReadLine
                                If IsNothing(Line) = False Then
                                    If Line.Contains(First_Interesting_Line) = True Then
                                        Exit Do

                                    End If
                                Else
                                    Yield New List(Of String)
                                End If
                            Loop
                            Dim out As New List(Of String)
                            out.Add(Line) ' The First Line
                            Do
                                Line = sr.ReadLine
                                If Line.StartsWith(separator) = True Then
                                    out.Add(Line)
                                ElseIf Line = "" Then
                                    Dim u As Int16 = 65
                                Else

                                    Yield out
                                    out.Clear()
                                    out.Add(Line)
                                End If

                            Loop Until sr.EndOfStream = True

                        End Using

                    Catch ex As Exception

                    End Try

                End If
            End If

        End Function
        Public Iterator Function cIgnore_Before_Contains_Group_By_Not_Start(fIle As FileInfo, First_Interesting_Line As String, separator As String) As IEnumerable(Of List(Of String))

            If IsNothing(fIle) = False Then

                If fIle.Exists = True Then
                    Try
                        Using sr As New StreamReader(fIle.FullName)
                            ' Find First Line
                            Dim Line As String
                            Do
                                Line = sr.ReadLine
                                If IsNothing(Line) = False Then
                                    If Line.Contains(First_Interesting_Line) = True Then
                                        Exit Do

                                    End If
                                Else
                                    Yield New List(Of String)
                                End If
                            Loop
                            Dim out As New List(Of String)
                            out.Add(Line) ' The First Line
                            Do
                                Line = sr.ReadLine
                                If Line.StartsWith(separator) = True Then
                                    out.Add(Line)
                                ElseIf Line = "" Then

                                Else

                                    Yield out
                                    out.Clear()
                                    out.Add(Line)
                                End If

                            Loop Until sr.EndOfStream = True

                        End Using

                    Catch ex As Exception

                    End Try

                End If
            End If

        End Function

#End Region


    End Class
End Namespace

