Imports System.IO
Imports System.Windows.Forms



Public Class Pick_Up
    ''' <summary>
    ''' Return a list of FileInfos Or empty liast
    ''' </summary>
    ''' <param name="Title"></param>
    ''' <param name="Filter"></param>
    ''' <returns></returns>
    Public Shared Iterator Function Files(Optional Filter As String = "",
                                               Optional Title As String = "Select Files",
                                               Optional StartDir As DirectoryInfo = Nothing) As IEnumerable(Of FileInfo)

        Dim ofd1 As New OpenFileDialog With {.Title = Title, .Multiselect = True, .Filter = Filter}

        If IsNothing(StartDir) = False Then ofd1.InitialDirectory = StartDir.FullName

        If Filter <> "" Then ofd1.Filter = Filter
        If ofd1.ShowDialog = DialogResult.OK Then
            Dim Out As New List(Of FileInfo)
            Dim Names = ofd1.FileNames
            '  Names.Sort()
            For Each FileName In ofd1.FileNames
                Yield New FileInfo(FileName)
            Next

        End If

    End Function


    ''' <summary>
    ''' Return Fileinfo, else return nothing
    ''' </summary>
    ''' <param name="Title"></param>
    ''' <param name="Filter"></param>
    ''' <returns></returns>
    Public Shared Function File(Optional Filter As String = "",
                                              Optional Title As String = "Select Files",
                                              Optional StartDir As DirectoryInfo = Nothing) As FileInfo

        Dim ofd1 As New OpenFileDialog
        If IsNothing(StartDir) = False Then ofd1.InitialDirectory = StartDir.FullName
        ofd1.Multiselect = False
        ofd1.Title = Title
        If Filter <> "" Then ofd1.Filter = Filter
        If ofd1.ShowDialog = DialogResult.OK Then
            Return New FileInfo(ofd1.FileName)
        End If
        Return Nothing
    End Function


    Public Shared Function Directory(Optional Title As String = "Select Directory", Optional Dir As DirectoryInfo = Nothing) As DirectoryInfo
        Dim x1 As New FolderSelectDialog With {.Title = Title}

        If IsNothing(Dir) = False Then x1.InitialDirectory = Dir.FullName
        If x1.ShowDialog <> DialogResult.OK Then
            Return New DirectoryInfo(x1.FolderNames.First)
        Else
            Return Nothing
        End If
    End Function

    Public Shared Iterator Function Directories(Optional Title As String = "Select Directory", Optional Dir As DirectoryInfo = Nothing) As IEnumerable(Of DirectoryInfo)
        Dim x1 As New FolderSelectDialog With {.Title = Title}

        If IsNothing(Dir) = False Then x1.InitialDirectory = Dir.FullName
        If x1.ShowDialog <> DialogResult.OK Then
            For Each FolderName In x1.FolderNames
                Yield New DirectoryInfo(FolderName)

            Next
        End If
    End Function


#Region "Sequence"
    ''' <summary>
    ''' Select Yield Fasta Files
    ''' </summary>
    ''' <returns></returns>
    Public Shared Iterator Function Fasta() As IEnumerable(Of FileInfo)
        For Each F In Files(File_Extensions.Fasta)
            Yield F
        Next
    End Function
    ''' <summary>
    ''' Select Yield Fasta Files
    ''' </summary>
    ''' <returns></returns>
    Public Shared Iterator Function Fasta_Fastq() As IEnumerable(Of FileInfo)
        For Each F In Files(File_Extensions.Fasta_FastQ)
            Yield F
        Next
    End Function

    ''' <summary>
    ''' Select Yield Fastq Files
    ''' </summary>
    ''' <returns></returns>
    Public Shared Iterator Function Fastq() As IEnumerable(Of FileInfo)
        For Each F In Files(File_Extensions.FastQ)
            Yield F
        Next
    End Function

    ''' <summary>
    ''' Select Yield GenBank Files
    ''' </summary>
    ''' <returns></returns>
    Public Shared Iterator Function GenBank() As IEnumerable(Of FileInfo)
        For Each F In Files(File_Extensions.GenBank)
            Yield F
        Next
    End Function

    ''' <summary>
    ''' Select Yield Sequence Files
    ''' </summary>
    ''' <returns></returns>
    Public Shared Iterator Function Sequence() As IEnumerable(Of FileInfo)
        For Each F In Files(File_Extensions.SequenceFileTypesToImport)
            Yield F
        Next
    End Function

    ''' <summary>
    ''' Select Yield fast5 Files
    ''' </summary>
    ''' <returns></returns>
    Public Shared Iterator Function Fast5() As IEnumerable(Of FileInfo)
        For Each F In Files(File_Extensions.Fast5)
            Yield F
        Next
    End Function


    ''' <summary>
    ''' Select Yield gff Files
    ''' </summary>
    ''' <returns></returns>
    Public Shared Iterator Function Gff() As IEnumerable(Of FileInfo)
        For Each F In Files(File_Extensions.gff3)
            Yield F
        Next
    End Function
#End Region

#Region "Text"
    ''' <summary>
    ''' Select Yield gff Files
    ''' </summary>
    ''' <returns></returns>
    Public Shared Iterator Function Csv() As IEnumerable(Of FileInfo)
        For Each F In Files(File_Extensions.csv)
            Yield F
        Next
    End Function
    ''' <summary>
    ''' Select Yield log Files
    ''' </summary>
    ''' <returns></returns>
    Public Shared Iterator Function Log() As IEnumerable(Of FileInfo)
        For Each F In Files(File_Extensions.Log)
            Yield F
        Next
    End Function
    ''' <summary>
    ''' Select Yield Tab-like Files
    ''' </summary>
    ''' <returns></returns>
    Public Shared Iterator Function TabLike() As IEnumerable(Of FileInfo)
        For Each F In Files(File_Extensions.All_TAB_Like)
            Yield F
        Next
    End Function

    ''' <summary>
    ''' Select Yield XML Files
    ''' </summary>
    ''' <returns></returns>
    Public Shared Iterator Function XML() As IEnumerable(Of FileInfo)
        For Each F In Files(File_Extensions.Xml)
            Yield F
        Next
    End Function

#End Region
#Region "Mapping"
    ''' <summary>
    ''' Select Yield SAM Files
    ''' </summary>
    ''' <returns></returns>
    Public Shared Iterator Function SAM() As IEnumerable(Of FileInfo)
        For Each F In Files(File_Extensions.SAM)
            Yield F
        Next
    End Function

    ''' <summary>
    ''' Select Yield BAM Files
    ''' </summary>
    ''' <returns></returns>
    Public Shared Iterator Function BAM() As IEnumerable(Of FileInfo)
        For Each F In Files(File_Extensions.BAM)
            Yield F
        Next
    End Function

    ''' <summary>
    ''' Select Yield SAM-BAM Files
    ''' </summary>
    ''' <returns></returns>
    Public Shared Iterator Function SAM_BAM() As IEnumerable(Of FileInfo)
        For Each F In Files(File_Extensions.SAM_BAM)
            Yield F
        Next
    End Function
#End Region
#Region "Annotation"
    ''' <summary>
    ''' Select Yield bed Files
    ''' </summary>
    ''' <returns></returns>
    Public Shared Iterator Function BED() As IEnumerable(Of FileInfo)
        For Each F In Files(File_Extensions.BED)
            Yield F
        Next
    End Function

    ''' <summary>
    ''' Select Yield vcf Files
    ''' </summary>
    ''' <returns></returns>
    Public Shared Iterator Function VCF() As IEnumerable(Of FileInfo)
        For Each F In Files(File_Extensions.vcf)
            Yield F
        Next
    End Function
#End Region

End Class

