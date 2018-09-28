Imports System.IO

Public Class Get_Files
    ''' <summary>
    '''  Retrurn Empty List Or List of FIleinfoFrom FOlder
    ''' </summary>
    ''' <param name="Dir"></param>
    ''' <returns></returns>
    Public Shared Iterator Function All_Recursive(Dir As DirectoryInfo) As IEnumerable(Of FileInfo)
        Dim Files = Dir.GetFiles.ToList
        For Each sDir In Dir.EnumerateDirectories
            FIles.AddRange(All_Recursive(sDir))
        Next
        For Each File In Files
            Yield File
        Next
    End Function
    ''' <summary>
    '''  Yield All Files with add Extension in directory
    ''' </summary>
    ''' <param name="Dir"></param>
    ''' <returns></returns>
    Public Shared Iterator Function All_Recursive(Dir As DirectoryInfo, Extension As String) As IEnumerable(Of FileInfo)
        Dim Files = Dir.GetFiles.ToList
        For Each sDir In Dir.EnumerateDirectories
            Files.AddRange(All_Recursive(sDir, Extension))
        Next

        For Each File In Files
            If File.Extension = Extension Then Yield File
        Next
    End Function
    ''' <summary>
    '''  Yield All Files with add Extensions in directory
    ''' </summary>
    ''' <param name="Dir"></param>
    ''' <returns></returns>
    Public Shared Iterator Function All_Recursive(Dir As DirectoryInfo, Extensions As List(Of String)) As IEnumerable(Of FileInfo)
        Dim Files = Dir.GetFiles.ToList
        For Each sDir In Dir.EnumerateDirectories
            FIles.AddRange(All_Recursive(sDir, Extensions))
        Next

        For Each File In FIles
            If Extensions.Contains(File.Extension) Then Yield File
        Next
    End Function

    ''' <summary>
    '''  Retrurn Empty List Or List of FIleinfoFrom FOlder
    ''' </summary>
    ''' <param name="Dir"></param>
    ''' <returns></returns>
    Public Shared Iterator Function All(Dir As DirectoryInfo) As IEnumerable(Of FileInfo)
        For Each File In Dir.GetFiles
            Yield File
        Next
    End Function
    ''' <summary>
    '''  Yield All Files with add Extension in directory
    ''' </summary>
    ''' <param name="Dir"></param>
    ''' <returns></returns>
    Public Shared Iterator Function All(Dir As DirectoryInfo, Extension As String) As IEnumerable(Of FileInfo)
        For Each File In Dir.GetFiles
            If File.Extension = Extension Then Yield File
        Next
    End Function
    ''' <summary>
    '''  Yield All Files with add Extensions in directory
    ''' </summary>
    ''' <param name="Dir"></param>
    ''' <returns></returns>
    Public Shared Iterator Function All(Dir As DirectoryInfo, Extensions As List(Of String)) As IEnumerable(Of FileInfo)
        For Each File In Dir.GetFiles
            If Extensions.Contains(File.Extension) Then Yield File
        Next
    End Function

    ''' <summary>
    ''' Return List of FileInfo Or new List
    ''' </summary>
    ''' <param name="dir"></param>
    ''' <returns></returns>
    Public Shared Iterator Function First_Recursive(dir As DirectoryInfo) As IEnumerable(Of FileInfo)

        Dim FIles As New List(Of FileInfo)
        Try


            If dir.GetFiles.Count > 0 Then
                FIles.Add(dir.GetFiles.First)
            End If
            For Each sDir In dir.EnumerateDirectories
                FIles.AddRange(First_Recursive(sDir))
            Next

        Catch ex As Exception

        End Try
        For Each File In FIles
            Yield File
        Next
    End Function
End Class

