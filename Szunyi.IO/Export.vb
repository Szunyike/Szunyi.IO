Imports System.IO
Imports System.Windows.Forms


Public Class Export
    Public Shared Function File_To_Save(Optional Extension As String = "", Optional Title As String = "Select Save File") As FileInfo
        Dim sfd1 As New SaveFileDialog With {.Title = Title, .Filter = Extension}

        If sfd1.ShowDialog = DialogResult.OK Then
            Return New FileInfo(sfd1.FileName)
        Else
            Return Nothing
        End If
    End Function
#Region "Text"
    Public Shared Function Text(ByVal txt As String, Optional Title As String = "Save As", Optional extension As String = "") As String
        Dim FIle = File_To_Save(extension, Title)
        If IsNothing(FIle) = False Then
            Return Text(txt, FIle)
        Else
            Return String.Empty
        End If
    End Function

    Public Shared Function Text(ByVal txt As String, File As FileInfo) As String
        Try
            Using sg As New System.IO.StreamWriter(File.FullName)
                sg.Write(txt)
            End Using
            Return String.Empty
        Catch ex As Exception
            Return (ex.ToString)
        End Try
    End Function

#End Region

#Region "Fasta"
    Public Shared Function Fasta(ByVal Seq As Bio.ISequence) As String
        Dim FIle = File_To_Save(File_Extensions.Fasta)
        If IsNothing(FIle) = False Then
            Return Fasta(Seq, FIle)
        Else
            Return String.Empty
        End If
    End Function
    Public Shared Function Fasta(ByVal Seqs As IEnumerable(Of Bio.ISequence)) As String
        Dim FIle = File_To_Save(File_Extensions.Fasta)
        If IsNothing(FIle) = False Then
            Return Fasta(Seqs, FIle)
        Else
            Return String.Empty
        End If
    End Function
    Public Shared Function Fasta(ByVal Seq As Bio.ISequence, File As FileInfo) As String
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
    Public Shared Function Fasta(ByVal Seqs As IEnumerable(Of Bio.ISequence), File As FileInfo) As String
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

#Region "fastq"
    Public Shared Function Fastq(ByVal Seq As Bio.QualitativeSequence) As String
        Dim FIle = File_To_Save(File_Extensions.FastQ)
        If IsNothing(FIle) = False Then
            Return Fastq(Seq, FIle)
        Else
            Return String.Empty
        End If
    End Function
    Public Shared Function Fastq(ByVal Seqs As IEnumerable(Of Bio.ISequence)) As String
        Dim FIle = File_To_Save(File_Extensions.FastQ)
        If IsNothing(FIle) = False Then
            Return Fastq(Seqs, FIle)
        Else
            Return String.Empty
        End If
    End Function
    Public Shared Function Fastq(ByVal Seq As Bio.QualitativeSequence, File As FileInfo) As String
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
    Public Shared Function Fastq(ByVal Seqs As IEnumerable(Of Bio.ISequence), File As FileInfo) As String
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
    Public Shared Function GenBank(ByVal Seq As Bio.ISequence) As String
        Dim FIle = File_To_Save(File_Extensions.GenBank)
        If IsNothing(FIle) = False Then
            Return GenBank(Seq, FIle)
        Else
            Return String.Empty
        End If
    End Function
    Public Shared Function GenBank(ByVal Seqs As IEnumerable(Of Bio.ISequence)) As String
        Dim FIle = File_To_Save(File_Extensions.GenBank)
        If IsNothing(FIle) = False Then
            Return GenBank(Seqs, FIle)
        Else
            Return String.Empty
        End If
    End Function
    Public Shared Function GenBank(ByVal Seq As Bio.ISequence, File As FileInfo) As String
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
    Public Shared Function GenBank(ByVal Seqs As IEnumerable(Of Bio.ISequence), File As FileInfo) As String
        Try
            Dim sw As New Bio.IO.GenBank.GenBankFormatter
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

#Region "BED"

    Public Shared Function BED(ByVal Seqs As IList(Of Bio.SequenceRange)) As String
        Dim FIle = File_To_Save(File_Extensions.BED)
        If IsNothing(FIle) = False Then
            Return BED(Seqs, FIle)
        Else
            Return String.Empty
        End If
    End Function

    Public Shared Function BED(ByVal Seqs As IList(Of Bio.ISequenceRange), File As FileInfo) As String
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

#Region "gff"
    Public Shared Function Gff(ByVal Seq As Bio.ISequence) As String
        Dim FIle = File_To_Save(File_Extensions.gff3)
        If IsNothing(FIle) = False Then
            Return Gff(Seq, FIle)
        Else
            Return String.Empty
        End If
    End Function
    Public Shared Function Gff(ByVal Seqs As IEnumerable(Of Bio.ISequence)) As String
        Dim FIle = File_To_Save(File_Extensions.gff3)
        If IsNothing(FIle) = False Then
            Return Gff(Seqs, FIle)
        Else
            Return String.Empty
        End If
    End Function
    Public Shared Function Gff(ByVal Seq As Bio.ISequence, File As FileInfo) As String
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
    Public Shared Function Gff(ByVal Seqs As IEnumerable(Of Bio.ISequence), File As FileInfo) As String
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
    Public Shared Function Export_Sam(Sams As List(Of Bio.IO.SAM.SAMAlignedSequence), Header As Bio.IO.SAM.SAMAlignmentHeader, Optional File As FileInfo = Nothing)

        Try


            If IsNothing(FIle) = False Then
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
End Class


