Imports System.IO
Imports System.Runtime.CompilerServices

Public Module Extensions
#Region "Linux"
    ''' <summary>
    ''' Return Linux Like Path From DirectoryInfo
    ''' </summary>
    ''' <param name="Dir"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function FullName_Linux(Dir As DirectoryInfo) As String
        Dim Drive = System.IO.Path.GetPathRoot(Dir.FullName)
        ' Set : and path separator
        Dim DriveToSmallCapital = Dir.FullName.Replace(Drive, Drive.ToLower).Replace(":", "").Replace("\", "/")
        ' escape space
        DriveToSmallCapital = DriveToSmallCapital.Replace(" ", "\ ")
        Dim tmpFile = "/mnt/" & DriveToSmallCapital
        Return tmpFile


    End Function
    ''' <summary>
    ''' Return Linux Like Path From Fileinfo
    ''' </summary>
    ''' <param name="File"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function FullName_Linux(File As FileInfo) As String
        Dim Drive = System.IO.Path.GetPathRoot(File.FullName)
        ' Set : and path separator
        Dim DriveToSmallCapital = File.FullName.Replace(Drive, Drive.ToLower).Replace(":", "").Replace("\", "/")
        ' escape space
        DriveToSmallCapital = DriveToSmallCapital.Replace(" ", "\ ")
        Dim tmpFile = "/mnt/" & DriveToSmallCapital
        Return tmpFile

    End Function
    ''' <summary>
    ''' Return Linux Like Path From Fileinfo
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function FullName_Linux(Files As IEnumerable(Of FileInfo)) As IEnumerable(Of String)
        For Each FIle In Files
            Yield FIle.FullName_Linux
        Next
    End Function
#End Region

#Region "Phyton"
    ''' <summary>
    ''' Return Phyton Like Path From FileInfo
    ''' </summary>
    ''' <param name="File"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function FullName_Python(File As FileInfo) As String
        Dim Path = File.FullName
        Return Path.Replace("\", "\\").Replace(",", ".")
    End Function
    ''' <summary>
    ''' Return Phyton Like Path From Fileinfo
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function FullName_Python(Files As IEnumerable(Of FileInfo)) As IEnumerable(Of String)
        For Each FIle In Files
            Yield FIle.FullName_Linux
        Next
    End Function

#End Region

#Region "Windows cmd"
    ''' <summary>
    ''' Return Windows Comnad Prompt Path From FileInfo
    ''' </summary>
    ''' <param name="x"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function FullName_Windows_cmd(x As FileInfo) As String
        Dim Path = Chr(34) & x.FullName & Chr(34)
        Return Path
    End Function
    ''' <summary>
    ''' Return Windows Comnad Prompt Path From FileInfo
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function FullName_Windows_cmd(Files As IEnumerable(Of FileInfo)) As IEnumerable(Of String)
        For Each FIle In Files
            Yield FIle.FullName_Windows_cmd
        Next
    End Function

#End Region

#Region "Change Extension"
    ''' <summary>
    ''' Return new FIleInfo. After Last . the extension Will be Changed
    ''' </summary>
    ''' <param name="File"></param>
    ''' <param name="extension"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function ChangeExtension(File As FileInfo, extension As String) As FileInfo
        Return New FileInfo(File.DirectoryName & "\" & Path.GetFileNameWithoutExtension(File.FullName) & extension)
    End Function
    ''' <summary>
    ''' Return new FIleInfo. After Last . the extension Will be Changed
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <param name="extension"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function ChangeExtension(Files As IEnumerable(Of FileInfo), extension As String) As IEnumerable(Of FileInfo)
        For Each File In Files
            Yield New FileInfo(File.DirectoryName & "\" & Path.GetFileNameWithoutExtension(File.FullName) & extension)
        Next
    End Function
#End Region

#Region "Append Before Extension"
    ''' <summary>
    ''' Append String before Extension
    ''' </summary>
    ''' <param name="File"></param>
    ''' <param name="Append"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Append_Before_Extension(File As FileInfo, Append As String) As FileInfo
        Return New FileInfo(Path.GetDirectoryName(File.FullName) &
                            Path.DirectorySeparatorChar &
                            Path.GetFileNameWithoutExtension(File.FullName) &
                            Append & File.Extension)
    End Function
    ''' <summary>
    ''' Append String before Extension
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <param name="Append"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function Append_Before_Extension(Files As IEnumerable(Of FileInfo), Append As String) As IEnumerable(Of FileInfo)
        For Each FIle In Files
            Yield FIle.Append_Before_Extension(Append)
        Next
    End Function

    ''' <summary>
    ''' Append SecondFile Name wo Extension before Extension
    ''' </summary>
    ''' <param name="File"></param>
    ''' <param name="SecondFile"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Append_Before_Extension(File As FileInfo, SecondFile As FileInfo) As FileInfo
        Return New FileInfo(Path.GetDirectoryName(File.FullName) &
                            Path.DirectorySeparatorChar &
                            Path.GetFileNameWithoutExtension(File.FullName) & "_" &
                            Path.GetFileNameWithoutExtension(SecondFile.FullName) & File.Extension)
    End Function
    ''' <summary>
    ''' Append String before Extension
    ''' </summary>
    ''' <param name="File"></param>
    ''' <param name="Files"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function Append_Before_Extension(File As FileInfo, Files As IEnumerable(Of FileInfo)) As IEnumerable(Of FileInfo)
        For Each F In Files
            Yield File.Append_Before_Extension(F)
        Next
    End Function
    ''' <summary>
    ''' Append String Before File.Name
    ''' </summary>
    ''' <param name="File"></param>
    ''' <param name="txt"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Append_First(File As FileInfo, txt As String) As FileInfo
        Return New FileInfo(Path.GetDirectoryName(File.FullName) & Path.DirectorySeparatorChar & txt & "_" & File.Name)
    End Function
    ''' <summary>
    ''' Append String Before Files.Name
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <param name="txt"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function Append_First(Files As IEnumerable(Of FileInfo), txt As String) As IEnumerable(Of FileInfo)
        For Each File In Files
            Yield File.Append_First(txt)
        Next
        Return
    End Function

    ''' <summary>
    ''' 1 Get File wo Extension, 2 Append Before Extension
    ''' </summary>
    ''' <param name="File"></param>
    ''' <param name="Append"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Append_Before_Extension_wNew_Extension(File As FileInfo, Append As String) As FileInfo

        Return New FileInfo(File.DirectoryName & "/" & File.woExtension.Name & Append & File.Extension)

    End Function
    ''' <summary>
    ''' 1 Get File wo Extension, 2 Append Before Extension
    ''' </summary>
    ''' <param name="File"></param>
    ''' <param name="Append"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Append_Before_Extension_wNew_Extension(File As FileInfo, Append As String, Extension As String) As FileInfo
        Return New FileInfo(File.DirectoryName & "/" & File.woExtension.Name & Append & Extension)
    End Function

#End Region

#Region "Merge"
    ''' <summary>
    ''' Merge Files Line By Line Into New File 
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <param name="DestinationFile"></param>
    <Extension()>
    Public Sub Merge(Files As IEnumerable(Of FileInfo), DestinationFile As FileInfo)
        Try
            Using sw As New StreamWriter(DestinationFile.FullName)
                For Each File In Files
                    If File Is Files.Last Then
                        Dim str As New System.Text.StringBuilder
                        For Each Line In File.Parse_Lines()
                            str.Append(Line)
                            str.Append(vbCrLf)
                        Next
                        If str.Length > 0 Then
                            str.Length -= 2
                            sw.Write(str.ToString)
                        End If
                    Else
                        For Each Line In File.Parse_Lines
                            sw.Write(Line)
                            sw.WriteLine()
                        Next
                    End If

                Next
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' Merge Files Line By Line Into New File 
    ''' </summary>
    ''' <param name="Files"></param>
    <Extension()>
    Public Sub Merge(Files As IEnumerable(Of FileInfo))
        Dim DestinationFile As FileInfo = Szunyi.IO.File_To_Save(Files.First.Extension)
        Files.Merge(DestinationFile)
    End Sub

    ''' <summary>
    ''' Merge Files Line By Line Into New File 
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <param name="DestinationFile"></param>
    <Extension()>
    Public Sub Merge_wFirstHeaderOnly(Files As IEnumerable(Of FileInfo), DestinationFile As FileInfo, Optional NofHeaderLine As Integer = 1)
        Try
            Using sw As New StreamWriter(DestinationFile.FullName)
                For Each File In Files
                    If File Is Files.First Then
                        For Each Line In File.Parse_Lines
                            sw.Write(Line)
                            sw.WriteLine()
                        Next
                    ElseIf File Is Files.Last Then
                        Dim str As New System.Text.StringBuilder
                        For Each Line In File.Parse_Lines(NofHeaderLine)
                            str.Append(Line)
                            str.Append(vbCrLf)
                        Next
                        If str.Length > 0 Then
                            str.Length -= 2
                            sw.Write(str.ToString)
                        End If
                    Else
                        For Each Line In File.Parse_Lines(NofHeaderLine)
                            sw.Write(Line)
                            sw.WriteLine()
                        Next
                    End If

                Next
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' Merge Files Line By Line Into New File 
    ''' </summary>
    ''' <param name="Files"></param>
    <Extension()>
    Public Sub Merge_wFirstHeaderOnly(Files As IEnumerable(Of FileInfo), Optional NofHeaderLine As Integer = 1)
        Dim DestinationFile As FileInfo = Szunyi.IO.File_To_Save(Files.First.Extension)
        Files.Merge_wFirstHeaderOnly(NofHeaderLine)
    End Sub
#End Region

#Region "Convert"
    ''' <summary>
    ''' Convert and Save a CSV file to tdt file in to the same directory
    ''' </summary>
    ''' <param name="FIle"></param>
    <Extension()>
    Public Sub Convert_CSV_To_TDT(File As FileInfo)
        Dim NewFile = File.ChangeExtension(".tdt")
        Using sw As New StreamWriter(NewFile.FullName)
            For Each Line In File.Parse_Lines
                Dim s = Line.Replace(",", vbTab)
                sw.Write(s)
                sw.WriteLine()
            Next
        End Using
    End Sub
    ''' <summary>
    ''' Convert and Save a CSV files to tdt files in to the same directory
    ''' </summary>
    ''' <param name="FIles"></param>
    <Extension()>
    Public Sub Convert_CSV_To_TDT(Files As IEnumerable(Of FileInfo))
        For Each FIle In Files
            FIle.Convert_CSV_To_TDT
        Next
    End Sub
    ''' <summary>
    ''' Convert and Save a TDT file to CSV file in to the same directory
    ''' </summary>
    ''' <param name="FIle"></param>
    <Extension()>
    Public Sub Convert_TDT_to_CSV(FIle As FileInfo)
        Dim NewFile = FIle.ChangeExtension(".tdt")
        Using sw As New StreamWriter(NewFile.FullName)
            For Each Line In FIle.Parse_Lines
                Dim s = Line.Replace(vbTab, ",")
                sw.Write(s)
                sw.WriteLine()
            Next
        End Using
    End Sub
    ''' <summary>
    ''' Convert and Save a TDT files to CSV files in to the same directory
    ''' </summary>
    ''' <param name="FIles"></param>
    <Extension()>
    Public Sub Convert_TDT_to_CSV(Files As IEnumerable(Of FileInfo))
        For Each FIle In Files
            FIle.Convert_TDT_to_CSV
        Next
    End Sub
#End Region

#Region "Group By"
    ''' <summary>
    ''' Group FIles By Their FileName
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function GroupBy_FileName(Files As IEnumerable(Of FileInfo)) As IEnumerable(Of IEnumerable(Of FileInfo))
        Dim gr = From x In Files Group By x.Name Into Group
        For Each g In gr
            Yield g.Group
        Next

    End Function
    ''' <summary>
    ''' Group FIles By Their Extension
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function GroupBy_Extension(Files As IEnumerable(Of FileInfo)) As IEnumerable(Of IEnumerable(Of FileInfo))
        Dim gr = From x In Files Group By x.Extension Into Group
        For Each g In gr
            Yield g.Group
        Next
    End Function
#End Region

#Region "Filter"
    ''' <summary>
    ''' Return All FIles where Name contain PartialID
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <param name="PartialID"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function Filter_ByPartialID(Files As IEnumerable(Of FileInfo), PartialID As String) As IEnumerable(Of FileInfo)
        Dim x = From t In Files Where t.Name.IndexOf(PartialID, comparisonType:=StringComparison.InvariantCultureIgnoreCase)
        For Each File In Files
            Yield File
        Next
    End Function
    ''' <summary>
    ''' Return All FIles where Name contain One of the PartialID
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <param name="PartialIDs"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function Filter_ByPartialID(Files As IEnumerable(Of FileInfo), PartialIDs As IEnumerable(Of String)) As IEnumerable(Of FileInfo)
        For Each PartialID In PartialIDs
            For Each File In Files.Filter_ByPartialID(PartialID)
                Yield File
            Next
        Next
    End Function
    ''' <summary>
    ''' Return All FIles where extension equal extension 
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <param name="Extension"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function Filter_ByExtension(Files As IEnumerable(Of FileInfo), Extension As String) As IEnumerable(Of FileInfo)
        Dim x = From t In Files Where t.Extension.IndexOf(Extension, comparisonType:=StringComparison.InvariantCultureIgnoreCase) > -1
        For Each File In Files
            Yield File
        Next
    End Function
    ''' <summary>
    ''' Return All FIles where extension equal extension 
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <param name="Extensions"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function Filter_ByExtension(Files As IEnumerable(Of FileInfo), Extensions As IEnumerable(Of String)) As IEnumerable(Of FileInfo)
        For Each Extension In Extensions
            For Each File In Files.Filter_ByExtension(Extension)
                Yield File
            Next
        Next
    End Function

#End Region
#Region "Directory"
    ''' <summary>
    '''  Yield All FIles Recursively From Directory 
    ''' </summary>
    ''' <param name="Dir"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function GetFiles_All_Recursive(Dir As DirectoryInfo) As IEnumerable(Of FileInfo)
        Dim Files = Dir.GetFiles.ToList
        For Each sDir In Dir.EnumerateDirectories
            Files.AddRange(GetFiles_All_Recursive(sDir))
        Next
        For Each File In Files
            Yield File
        Next
    End Function

    ''' <summary>
    '''  Yield All FIles Recursively From Directories 
    ''' </summary>
    ''' <param name="Dirs"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function GetFiles_All_Recursive(Dirs As IEnumerable(Of DirectoryInfo)) As IEnumerable(Of FileInfo)
        For Each D In Dirs
            For Each FIle In GetFiles_All_Recursive(D)
                Yield FIle
            Next
        Next
    End Function

    ''' <summary>
    ''' Return a File based on Basic Directory and a FileName
    ''' </summary>
    ''' <param name="Dir"></param>
    ''' <param name="FileName"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Add_File(Dir As DirectoryInfo, FileName As String)
        Return New FileInfo(Dir.FullName & FileName)
    End Function
#End Region

#Region "Parse Text Files"
    ''' <summary>
    ''' Into Array by Separator From Defined Range or Full Line
    ''' </summary>
    ''' <param name="file"></param>
    ''' <param name="Separator"></param>
    ''' <param name="FirstLineIndex"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function ParseToArray(file As FileInfo,
        Separator As String,
                  Optional FirstLineIndex As Integer = 0,
         Optional LastIndex As Integer = -1) As IEnumerable(Of String())

        If IsNothing(file) = False Then
            If file.Exists = True Then
                Using sr As New StreamReader(file.FullName)
                    Dim Index As Integer = 0
                    Do
                        Dim Line = sr.ReadLine
                        If Index >= FirstLineIndex Then
                            Yield Split(sr.ReadLine, Separator)
                        End If
                        If Index = LastIndex Then Exit Do
                        Index += 1
                    Loop Until sr.EndOfStream = True
                End Using
            End If
        End If

    End Function
    ''' <summary>
    ''' Return Full File As String 
    ''' </summary>
    ''' <param name="file"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Read_All(file As FileInfo) As String
        Try
            Using sw As New StreamReader(file.FullName)
                Return sw.ReadToEnd
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return String.Empty
        End Try

    End Function
    ''' <summary>
    ''' Return First Line StartWith
    ''' </summary>
    ''' <param name="file"></param>
    ''' <param name="StartWith"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Parse_First_Line_StartWith(file As FileInfo, StartWith As String) As String
        For Each Line In file.Parse_Lines
            If Line.StartsWith(StartWith) = True Then Return Line
        Next
        Return String.Empty
    End Function
    ''' <summary>
    ''' Return First Line StartWith
    ''' </summary>
    ''' <param name="file"></param>
    ''' <param name="StartWith"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Parse_First_LineS_StartWith(file As FileInfo, StartWith As String) As List(Of String)
        Dim out As New List(Of String)
        For Each Line In file.Parse_Lines
            If Line.StartsWith(StartWith) = True Then
                out.Add(Line)
            Else
                Exit For
            End If
        Next
        Return out
    End Function

    ''' <summary>
    ''' Read Several Lines for example FASTQ file 
    ''' </summary>
    ''' <param name="file"></param>
    ''' <param name="Nof_Line"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function Parse_Lines_by_Group(file As FileInfo, Nof_Line As Integer) As IEnumerable(Of List(Of String))
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
    ''' <summary>
    ''' Read Several Lines Split every Line by Separator and Group By the Xth Column
    ''' </summary>
    ''' <param name="file"></param>
    ''' <param name="Separator"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function Parse_Lines_by_Group(file As FileInfo, Separator As String, Xth As Integer) As IEnumerable(Of List(Of String))
        If file.Exists = True Then
            Using sr As New StreamReader(file.FullName)
                Dim FirstItem As String = ""
                Dim Out As New List(Of String)
                Do
                    Dim Line = sr.ReadLine
                    Dim s = Split(Line, Separator)
                    If s(Xth) <> FirstItem Then
                        If Out.Count = 0 Then
                            Out.Add(Line)
                        Else
                            Yield Out
                            Out.Clear()
                            FirstItem = s(Xth)
                            Out.Add(Line)
                        End If
                    Else
                        Out.Add(Line)
                    End If
                Loop Until sr.EndOfStream = True
                Yield Out
            End Using
        End If

    End Function
    ''' <summary>
    ''' Read Several Lines Separated By LineStart
    ''' </summary>
    ''' <param name="file"></param>
    ''' <param name="Item_Separator"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function Parse_Lines_by_Group(file As FileInfo, Item_Separator As String) As IEnumerable(Of List(Of String))
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

    ''' <summary>
    ''' Read Several Lines based on Not Start With
    ''' </summary>
    ''' <param name="File"></param>
    ''' <param name="Not_Start_With"></param>
    ''' <returns></returns>
    Public Iterator Function Parse_Lines_By_Group_NotStartWith(File As FileInfo, Not_Start_With As String) As IEnumerable(Of List(Of String))
        If File.Exists = True Then
            Dim cLines As New List(Of String)
            Using sr As New StreamReader(File.FullName)
                Do
                    Dim Line = sr.ReadLine
                    If Line.StartsWith(Not_Start_With) = False Then
                        cLines.Add(Line)
                    Else
                        If cLines.Count > 0 Then
                            Yield Szunyi.Common.CloneStrings(cLines)
                            cLines.Clear()
                        End If
                    End If
                Loop Until sr.EndOfStream = True
                Yield cLines
            End Using
        End If
    End Function

    <Extension()>
    Public Iterator Function Parse_Lines(File As FileInfo, Optional FirstLineIndex As Integer = 0, Optional LastLineIndex As Integer = -1) As IEnumerable(Of String)
        If File.Exists = True Then
            Dim cIndex As Integer = 0
            Using sr As New StreamReader(File.FullName)
                Do
                    Dim Line = sr.ReadLine
                    If FirstLineIndex < cIndex Then
                        If cIndex = LastLineIndex Then Exit Do
                        Yield Line
                    End If
                    cIndex += 1
                Loop Until sr.EndOfStream = True
            End Using
        End If
    End Function

#End Region
#Region "Change Delete Extension"
    ''' <summary>
    ''' Return File wo Extension
    ''' </summary>
    ''' <param name="File"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function woExtension(File As FileInfo) As FileInfo
        Return New FileInfo(Path.GetFileNameWithoutExtension(File.FullName))
    End Function
    ''' <summary>
    ''' Yield Files wo Extension
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function woExtension(Files As IEnumerable(Of FileInfo)) As IEnumerable(Of FileInfo)
        For Each File In Files
            Yield File.woExtension
        Next
    End Function

#End Region

    ''' <summary></summary>
    ''' <param name="File"></param>
    ''' <param name="Path"></param>
    <Extension()>
    Public Function Change_Directory(ByRef File As FileInfo, ByVal Path As DirectoryInfo) As FileInfo
        If Path.FullName.EndsWith("\") = True Then
            Return New FileInfo(Path.FullName & File.Name)
        Else
            Return New FileInfo(Path.FullName & "\" & File.Name)
        End If
    End Function
    ''' <summary></summary>
    ''' <param name="File"></param>
    ''' <param name="Seaparator"></param>
    <Extension()>
    Public Iterator Function GetHeader(File As FileInfo, Optional Seaparator As String = vbTab, Optional NofLine As Integer = 1) As IEnumerable(Of String)
        Dim res As New List(Of String)
        If IsNothing(File) = False Then
            Using sr As New StreamReader(File.FullName)
                Dim Line = sr.ReadLine
                For Each s In Split(Line)
                    Yield s
                Next
            End Using
        End If
    End Function
    ''' <summary></summary>
    ''' <param name="File"></param>
    ''' <param name="Seaparator"></param>
    <Extension()>
    Public Iterator Function ConvertToDirectories(Folder_Names As IEnumerable(Of String)) As IEnumerable(Of DirectoryInfo)
        For Each F In Folder_Names
            Yield New DirectoryInfo(F)
        Next
    End Function
End Module


