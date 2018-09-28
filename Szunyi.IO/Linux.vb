Imports System.IO


Public Class Linux
        Public Shared Function Get_FileName(File As DirectoryInfo) As String
            Dim Drive = System.IO.Path.GetPathRoot(File.FullName)
            ' Set : and path separator
            Dim DriveToSmallCapital = File.FullName.Replace(Drive, Drive.ToLower).Replace(":", "").Replace("\", "/")
            ' escape space
            DriveToSmallCapital = DriveToSmallCapital.Replace(" ", "\ ")
            Dim tmpFile = "/mnt/" & DriveToSmallCapital
            Return tmpFile


        End Function
        Public Shared Function Get_FileName(File As FileInfo) As String
            Dim Drive = System.IO.Path.GetPathRoot(File.FullName)
            ' Set : and path separator
            Dim DriveToSmallCapital = File.FullName.Replace(Drive, Drive.ToLower).Replace(":", "").Replace("\", "/")
            ' escape space
            DriveToSmallCapital = DriveToSmallCapital.Replace(" ", "\ ")
            Dim tmpFile = "/mnt/" & DriveToSmallCapital
            Return tmpFile

        End Function

    End Class


