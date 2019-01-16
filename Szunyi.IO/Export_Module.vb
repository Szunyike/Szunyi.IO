Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Public Module Export_Module
    ''' <summary>
    ''' Get File From SaveFileDialog
    ''' </summary>
    ''' <param name="Extension"></param>
    ''' <param name="Dir"></param>
    ''' <param name="Title"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function File_To_Save(Extension As String, Dir As DirectoryInfo, Optional Title As String = "Select Save File") As FileInfo
        Dim sfd1 As New SaveFileDialog With {.Title = Title, .Filter = Extension}
        sfd1.InitialDirectory = Dir.FullName
        If sfd1.ShowDialog = DialogResult.OK Then
            Return New FileInfo(sfd1.FileName)
        Else
            Return Nothing
        End If
    End Function
    ''' <summary>
    ''' Get File From SaveFileDialog
    ''' </summary>
    ''' <param name="Extension"></param>
    ''' <param name="Title"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function File_To_Save(Extension As String, Optional Title As String = "Select Save File") As FileInfo
        Dim sfd1 As New SaveFileDialog With {.Title = Title, .Filter = Extension}

        If sfd1.ShowDialog = DialogResult.OK Then
            Return New FileInfo(sfd1.FileName)
        Else
            Return Nothing
        End If
    End Function
#Region "Text"
    ''' <summary>
    ''' Export Text into User-Selected File
    ''' </summary>
    ''' <param name="txt"></param>
    ''' <param name="Title"></param>
    ''' <param name="extension"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_Text(ByVal txt As String, Optional Title As String = "Save As", Optional extension As String = "") As String
        Dim FIle = File_To_Save(extension, Title)
        If IsNothing(FIle) = False Then
            Return Export_Text(txt, FIle)
        Else
            Return String.Empty
        End If
    End Function
    ''' <summary>
    '''  Export Text into User-Defined File
    ''' </summary>
    ''' <param name="txt"></param>
    ''' <param name="File"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_Text(ByVal txt As String, File As FileInfo) As String
        Try
            Using sg As New System.IO.StreamWriter(File.FullName)
                sg.Write(txt)
            End Using
            Return String.Empty
        Catch ex As Exception
            Return (ex.ToString)
        End Try
    End Function

    ''' <summary>
    ''' Export Text into User-Selected File
    ''' </summary>
    ''' <param name="str"></param>
    ''' <param name="Title"></param>
    ''' <param name="extension"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_Text(ByVal str As System.Text.StringBuilder, Optional Title As String = "Save As", Optional extension As String = "") As String
        Dim FIle = File_To_Save(extension, Title)
        If IsNothing(FIle) = False Then
            Return Export_Text(str, FIle)
        Else
            Return String.Empty
        End If
    End Function
    ''' <summary>
    '''  Export Text into User-Defined File
    ''' </summary>
    ''' <param name="str"></param>
    ''' <param name="File"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_Text(ByVal str As System.Text.StringBuilder, File As FileInfo) As String
        Try
            Using sg As New System.IO.StreamWriter(File.FullName)
                sg.Write(str.ToString)
            End Using
            Return String.Empty
        Catch ex As Exception
            Return (ex.ToString)
        End Try
    End Function

#End Region

#Region "FASTA"
    ''' <summary>
    ''' Export Sequence in FASTA format into User-Selected  File
    ''' </summary>
    ''' <param name="Seq"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_FASTA(ByVal Seq As Bio.ISequence) As String
        Dim FIle = File_To_Save(File_Extensions.Fasta)
        If IsNothing(FIle) = False Then
            Return Export_FASTA(Seq, FIle)
        Else
            Return String.Empty
        End If
    End Function
    ''' <summary>
    ''' Export Sequences in FASTA format into User-Selected  File
    ''' </summary>
    ''' <param name="Seqs"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_FASTA(ByVal Seqs As IEnumerable(Of Bio.ISequence)) As String
        Dim FIle = File_To_Save(File_Extensions.Fasta)
        If IsNothing(FIle) = False Then
            Return Export_FASTA(Seqs, FIle)
        Else
            Return String.Empty
        End If
    End Function
    ''' <summary>
    ''' Export Sequence in FASTA format into User-Defined  File
    ''' </summary>
    ''' <param name="Seq"></param>
    ''' <param name="File"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_FASTA(ByVal Seq As Bio.ISequence, File As FileInfo) As String
        Try
            Dim sw As New Bio.IO.FastA.FastAFormatter
            Dim TheStream As New FileStream(File.FullName, FileMode.Create)
            Try
                sw.Format(TheStream, Seq)
            Catch ex As Exception
                Return (ex.ToString)
            End Try
            TheStream.Close()
            Return String.Empty
        Catch ex As Exception
            Return (ex.ToString)
        End Try
    End Function
    ''' <summary>
    ''' Export Sequences in FASTA format into User-Defined  File
    ''' </summary>
    ''' <param name="Seqs"></param>
    ''' <param name="File"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_FASTA(ByVal Seqs As IEnumerable(Of Bio.ISequence), File As FileInfo) As String
        Try
            Dim sw As New Bio.IO.FastA.FastAFormatter
            Dim TheStream As New FileStream(File.FullName, FileMode.Create)
            Try
                For Each seq In Seqs
                    sw.Format(TheStream, seq)
                Next
            Catch ex As Exception
                Return (ex.ToString)
            End Try
            TheStream.Close()
            Return String.Empty
        Catch ex As Exception
            Return (ex.ToString)
        End Try
    End Function
#End Region

#Region "FASTQ"
    ''' <summary>
    ''' Export Sequence in FASTQ format into User-Selected File
    ''' </summary>
    ''' <param name="Seq"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_FASTQ(ByVal Seq As Bio.QualitativeSequence) As String
        Dim FIle = File_To_Save(File_Extensions.FastQ)
        If IsNothing(FIle) = False Then
            Return Export_FASTQ(Seq, FIle)
        Else
            Return String.Empty
        End If
    End Function
    ''' <summary>
    ''' Export Sequences in FASTQ format into User-Selected File
    ''' </summary>
    ''' <param name="Seqs"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_FASTQ(ByVal Seqs As IEnumerable(Of Bio.ISequence)) As String
        Dim FIle = File_To_Save(File_Extensions.FastQ)
        If IsNothing(FIle) = False Then
            Return Export_FASTQ(Seqs, FIle)
        Else
            Return String.Empty
        End If
    End Function
    ''' <summary>
    ''' Export Sequence in FASTQ format into User-Defined  File
    ''' </summary>
    ''' <param name="Seq"></param>
    ''' <param name="File"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_FASTQ(ByVal Seq As Bio.QualitativeSequence, File As FileInfo) As String
        Try
            Dim sw As New Bio.IO.FastQ.FastQFormatter
            Dim TheStream As New FileStream(File.FullName, FileMode.Create)
            Try
                sw.Format(TheStream, Seq)
            Catch ex As Exception
                Return (ex.ToString)
            End Try
            TheStream.Close()
            Return String.Empty
        Catch ex As Exception
            Return (ex.ToString)
        End Try
    End Function
    ''' <summary>
    ''' Export Sequences in FASTQ format into User-Defined  File
    ''' </summary>
    ''' <param name="Seqs"></param>
    ''' <param name="File"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_FASTQ(ByVal Seqs As IEnumerable(Of Bio.ISequence), File As FileInfo) As String
        Try
            Dim sw As New Bio.IO.FastQ.FastQFormatter
            Dim TheStream As New FileStream(File.FullName, FileMode.Create)
            Try

                sw.Format(TheStream, Seqs)

            Catch ex As Exception
                Return (ex.ToString)
            End Try
            TheStream.Close()
            Return String.Empty
        Catch ex As Exception
            Return (ex.ToString)
        End Try
    End Function
#End Region

#Region "GenBank"
    ''' <summary>
    ''' Export Sequence in GenBank format into User-Selected File
    ''' </summary>
    ''' <param name="Seq"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_GenBank(ByVal Seq As Bio.ISequence) As String
        Dim FIle = File_To_Save(File_Extensions.GenBank)
        If IsNothing(FIle) = False Then
            Return Export_GenBank(Seq, FIle)
        Else
            Return String.Empty
        End If
    End Function
    ''' <summary>
    ''' Export Sequences in GenBank format into User-Selected File
    ''' </summary>
    ''' <param name="Seqs"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_GenBank(ByVal Seqs As IEnumerable(Of Bio.ISequence)) As String
        Dim FIle = File_To_Save(File_Extensions.GenBank)
        If IsNothing(FIle) = False Then
            Return Export_GenBank(Seqs, FIle)
        Else
            Return String.Empty
        End If
    End Function
    ''' <summary>
    ''' Export Sequence in GenBank format into User-Defined File
    ''' </summary>
    ''' <param name="Seq"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_GenBank(ByVal Seq As Bio.ISequence, File As FileInfo) As String
        Try
            Dim sw As New Bio.IO.GenBank.GenBankFormatter
            Dim TheStream As New FileStream(File.FullName, FileMode.Create)
            Try
                sw.Format(TheStream, Seq)
            Catch ex As Exception
                Return (ex.ToString)
            End Try
            TheStream.Close()
            Return String.Empty
        Catch ex As Exception
            Return (ex.ToString)
        End Try
    End Function
    ''' <summary>
    ''' Export Sequences in GenBank format into User-Defined File
    ''' </summary>
    ''' <param name="Seqs"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_GenBank(ByVal Seqs As IEnumerable(Of Bio.ISequence), File As FileInfo) As String
        Try
            Dim sw As New Bio.IO.GenBank.GenBankFormatter
            Dim TheStream As New FileStream(File.FullName, FileMode.Create)
            Try
                For Each seq In Seqs
                    sw.Format(TheStream, seq)
                Next
            Catch ex As Exception
                Return (ex.ToString)
            Finally
                TheStream.Close()
            End Try
            TheStream.Close()

            Return String.Empty
        Catch ex As Exception
            Return (ex.ToString)
        End Try
    End Function
#End Region

#Region "BED"
    ''' <summary>
    '''  Export Sequences in BED format into User-Selected File
    ''' </summary>
    ''' <param name="Seqs"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_BED(ByVal Seqs As IList(Of Bio.SequenceRange)) As String
        Dim FIle = File_To_Save(File_Extensions.BED)
        If IsNothing(FIle) = False Then
            Return Export_BED(Seqs, FIle)
        Else
            Return String.Empty
        End If
    End Function
    ''' <summary>
    '''  Export Sequences in BED format into User-Defined File
    ''' </summary>
    ''' <param name="Seqs"></param>
    ''' <param name="File"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_BED(ByVal Seqs As IList(Of Bio.ISequenceRange), File As FileInfo) As String
        Try
            Dim sw As New Bio.IO.Bed.BedFormatter
            Dim TheStream As New FileStream(File.FullName, FileMode.Create)
            Try

                sw.Format(TheStream, Seqs)

            Catch ex As Exception
                Return (ex.ToString)
            End Try
            TheStream.Close()
            Return String.Empty
        Catch ex As Exception
            Return (ex.ToString)
        End Try
    End Function
#End Region

#Region "GFF3"
    ''' <summary>
    '''  Export Sequences in GFF3 format into User-Selected File
    ''' </summary>
    ''' <param name="Seq"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_GFF3(ByVal Seq As Bio.ISequence) As String
        Dim FIle = File_To_Save(File_Extensions.gff3)
        If IsNothing(FIle) = False Then
            Return Export_GFF3(Seq, FIle)
        Else
            Return String.Empty
        End If
    End Function
    ''' <summary>
    '''  Export Sequences in GFF3 format into User-Selected File
    ''' </summary>
    ''' <param name="Seqs"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_GFF3(ByVal Seqs As IEnumerable(Of Bio.ISequence)) As String
        Dim FIle = File_To_Save(File_Extensions.gff3)
        If IsNothing(FIle) = False Then
            Return Export_GFF3(Seqs, FIle)
        Else
            Return String.Empty
        End If
    End Function
    ''' <summary>
    '''  Export Sequence in GFF3 format into User-Defined File
    ''' </summary>
    ''' <param name="Seq"></param>
    ''' <param name="File"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_GFF3(ByVal Seq As Bio.ISequence, File As FileInfo) As String
        Try
            Dim sw As New Bio.IO.Gff.GffFormatter
            Dim TheStream As New FileStream(File.FullName, FileMode.Create)
            Try
                sw.Format(TheStream, Seq)
            Catch ex As Exception
                Return (ex.ToString)
            End Try
            TheStream.Close()
            Return String.Empty
        Catch ex As Exception
            Return (ex.ToString)
        End Try
    End Function
    ''' <summary>
    '''  Export Sequences in GFF3 format into User-Defined File
    ''' </summary>
    ''' <param name="Seqs"></param>
    ''' <param name="File"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_GFF3(ByVal Seqs As IEnumerable(Of Bio.ISequence), File As FileInfo) As String
        Try
            Dim sw As New Bio.IO.Gff.GffFormatter
            Dim TheStream As New FileStream(File.FullName, FileMode.Create)
            Try
                For Each seq In Seqs
                    sw.Format(TheStream, seq)
                Next
            Catch ex As Exception
                Return (ex.ToString)
            End Try
            TheStream.Close()
            Return String.Empty
        Catch ex As Exception
            Return (ex.ToString)
        End Try
    End Function
#End Region

#Region "SAM/BAM"
    ''' <summary>
    ''' Export SAM Aligned Sequences Into User-Selected Or User_Defined File
    ''' </summary>
    ''' <param name="Sams"></param>
    ''' <param name="Header"></param>
    ''' <param name="File"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Export_Sam(Sams As List(Of Bio.IO.SAM.SAMAlignedSequence), Header As Bio.IO.SAM.SAMAlignmentHeader, Optional File As FileInfo = Nothing)
        Try

            If IsNothing(File) = False Then
                File = File_To_Save(File_Extensions.SAM)
            Else
                Return String.Empty
            End If

            Dim str As New StreamWriter(File.FullName, FileMode.Create)
            Dim x As New Bio.IO.SAM.SAMFormatter()
            Bio.IO.SAM.SAMFormatter.WriteHeader(str, Header)
            For Each SAM In Sams
                Bio.IO.SAM.SAMFormatter.WriteSAMAlignedSequence(str, SAM)
            Next

            str.Flush()
            str.Close()
            Return String.Empty
        Catch ex As Exception
            Return ex.ToString
        End Try
    End Function


#End Region

End Module
