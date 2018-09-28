Imports System.IO


Public Class Rename

    ''' <summary>
    ''' Return File wo Extension
    ''' </summary>
    ''' <param name="File"></param>
    ''' <returns></returns>
    Public Shared Function woExtension(File As FileInfo) As FileInfo
        Return New FileInfo(Path.GetFileNameWithoutExtension(File.FullName))

    End Function

    ''' <summary>
    ''' Return Files wo Extension
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <returns></returns>
    Public Shared Iterator Function woExtension(Files As List(Of FileInfo)) As IEnumerable(Of FileInfo)
        For Each File In Files
            Yield woExtension(File)
        Next

    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="File"></param>
    ''' <param name="extension"></param>
    ''' <returns></returns>
    Public Shared Function ChangeExtension(File As FileInfo, extension As String) As FileInfo
        Return New FileInfo(Path.GetFileNameWithoutExtension(File.FullName))
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <param name="extension"></param>
    ''' <returns></returns>
    Public Shared Iterator Function ChangeExtension(Files As IEnumerable(Of FileInfo), extension As String) As IEnumerable(Of FileInfo)
        For Each File In Files
            Yield New FileInfo(Path.GetFileNameWithoutExtension(File.FullName))
        Next

    End Function

    Public Shared Function Append_Before_Extension(File As FileInfo, Append As String) As FileInfo
        Return New FileInfo(Path.GetDirectoryName(File.FullName) & Path.DirectorySeparatorChar & Path.GetFileNameWithoutExtension(File.FullName) & Append & File.Extension)
    End Function
    Public Shared Function Append_Before_Extension(File As FileInfo, Second_file As FileInfo) As FileInfo
        Return New FileInfo(Path.GetDirectoryName(File.FullName) & Path.DirectorySeparatorChar & Path.GetFileNameWithoutExtension(File.FullName) & Path.GetFileNameWithoutExtension(Second_file.FullName) & File.Extension)
    End Function
    Public Shared Function Append_Before_Extension_wNew_Extension(BasicFile As FileInfo, SecondFile As FileInfo, ext As String) As FileInfo
        Dim t = BasicFile.DirectoryName & "\" & BasicFile.Name.Trim(BasicFile.Extension.ToCharArray) &
                     "_" & SecondFile.Name.Trim(SecondFile.Extension.ToCharArray) & ext
        Dim x As New FileInfo(t)
        Return x

    End Function
    Public Shared Function Append_Before_Extension_wNew_Extension(BasicFile As FileInfo, Append As String) As FileInfo
        Dim t = BasicFile.DirectoryName & "\" & BasicFile.Name.Trim(BasicFile.Extension.ToCharArray) & Append
        Dim x As New FileInfo(t)
        Return x

    End Function

    Public Shared Function Windos_Console(file As FileInfo) As String
        Return Chr(34) & file.FullName & Chr(34)
    End Function
End Class


