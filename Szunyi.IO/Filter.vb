Imports System.IO


Public Class Filter
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Files"></param>
        ''' <param name="PartOfFileName"></param>
        ''' <returns></returns>
        Public Shared Iterator Function Contain(Files As List(Of FileInfo), PartOfFileName As String) As IEnumerable(Of FileInfo)
            Dim x = From t In Files Where t.Name.Contains(PartOfFileName)

            For Each File In Files
                Yield File
            Next

        End Function
        Public Shared Iterator Function Contains(Files As List(Of FileInfo), ls As List(Of String)) As IEnumerable(Of FileInfo)

            Dim out As New List(Of FileInfo)
            For Each File In Files
                For Each s In ls
                    If File.Name.Contains(s) Then
                        Yield File
                        Exit For
                    End If
                Next

            Next

        End Function
        ''' <summary>
        ''' Retrun New List Of List of Fileinfo where extensions are match
        ''' </summary>
        ''' <param name="Files"></param>
        ''' <param name="Extension"></param>
        ''' <returns></returns>
        Public Shared Iterator Function ByExtension(Files As List(Of FileInfo), Extension As String) As IEnumerable(Of FileInfo)

            For Each File In From x In Files Where x.Extension = Extension
                Yield File
            Next

        End Function
    End Class
    Public Class Sort
        Public Class ByFileName
            Implements IComparer(Of FileInfo)

            Public Function Compare(x As FileInfo, y As FileInfo) As Integer Implements IComparer(Of FileInfo).Compare
                Return x.Name.CompareTo(y.Name)
            End Function
        End Class
    End Class
    Public Class Iter
        Public Shared Iterator Function ByFileName(Files As List(Of FileInfo)) As IEnumerable(Of IEnumerable(Of FileInfo))
            Dim gr = From x In Files Group By x.Name Into Group

            For Each g In gr
                Yield g.Group
            Next
        End Function
    End Class

