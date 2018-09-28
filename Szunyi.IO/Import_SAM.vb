Imports System.IO
Imports Bio.IO.SAM

Namespace Import
    Public Class Import_SAM
        Public Class Headers
#Region "Get Headers"
            ''' <summary>
            ''' Return Distinct Read Group RG based on 
            ''' </summary>
            ''' <param name="files"></param>
            ''' <returns></returns>
            Public Shared Function Get_Read_Groups(files As List(Of FileInfo)) As List(Of SAMRecordField)
                Dim Headers = Get_Header(files)
                Dim out As New List(Of SAMRecordField)
                For Each Header As SAMAlignmentHeader In Headers
                    Dim RGs = From x In Header.RecordFields Where x.Typecode = "RG"

                    out.AddRange(RGs)

                    Dim kj As Int16 = 54
                Next
                Return out
            End Function
            Public Shared Function Get_Organism_Length(File As FileInfo, RName As String) As Long

                Dim S = Get_ReferenceSequences(File)
                Dim r = (From x In S Where x.Name = RName Select x.Length).Sum
                Return r

            End Function
            Public Shared Function Get_Organism_Length(File As FileInfo) As Long

                Dim S = Get_ReferenceSequences(File)
                Dim r = (From x In S Select x.Length).Sum
                Return r

            End Function
            Public Shared Function Get_Organism_Length(Files As List(Of FileInfo)) As Long

                Dim S = Get_ReferenceSequences(Files)
                Dim r = (From x In S Select x.Length).Sum
                Return r

            End Function
            ''' <summary>
            ''' 
            ''' </summary>
            ''' <param name="File"></param>
            ''' <returns></returns>
            Public Shared Function Get_Comments(File As FileInfo) As String
                If IsNothing(File) = True Then Return String.Empty
                Dim Header = Get_Header(File)
                Dim str As New System.Text.StringBuilder
                For Each CO In Header.Comments
                    str.Append("#").Append(CO).AppendLine()
                Next
                If str.Length > 0 Then
                    str.Length -= 2
                    Return str.ToString
                End If
                Return String.Empty
            End Function
            ''' <summary>
            ''' Return Headers From SAM OR Bam File
            ''' </summary>
            ''' <param name="Files"></param>
            ''' <returns></returns>
            Public Shared Function Get_Header(files As List(Of FileInfo)) As List(Of SAMAlignmentHeader)
                Dim out As New List(Of SAMAlignmentHeader)
                For Each File In files
                    out.Add(Get_Header(File))
                Next
                Return out
            End Function

            ''' <summary>
            ''' Return Header From SAM OR Bam File
            ''' </summary>
            ''' <param name="File"></param>
            ''' <returns></returns>
            Public Shared Function Get_Header(File As FileInfo) As SAMAlignmentHeader
                Try
                    Using sr As New FileStream(File.FullName, FileMode.Open)
                        If File.Extension = ".Bam" Or File.Extension = ".bam" Then
                            Dim sa As New Bio.IO.BAM.BAMParser()
                            Return sa.GetHeader(sr)
                        ElseIf File.Extension = ".Sam" Or File.Extension = ".sam" Then
                            Return Bio.IO.SAM.SAMParser.ParseSAMHeader(sr)
                        End If
                    End Using
                Catch ex As Exception

                End Try

                Return Nothing
            End Function
            ''' <summary>
            ''' Return Header From SAM OR Bam File
            ''' </summary>
            ''' <param name="h"></param>
            ''' <returns></returns>
            Public Shared Function Get_Header_s(h As SAMAlignmentHeader) As String

                Dim str As New System.Text.StringBuilder
                '  str.Append(File.Name).AppendLine()
                For Each I In h.RecordFields
                    str.Append("@").Append(I.Typecode)
                    For Each i1 In I.Tags
                        str.Append(vbTab).Append(i1.Tag).Append(":").Append(i1.Value)
                    Next
                    str.AppendLine()
                Next
                For Each I In h.ReferenceSequences
                    str.Append(I.Name).Append(vbTab).Append(I.Length).AppendLine()

                Next
                Return str.ToString
            End Function
            ''' <summary>
            ''' 
            ''' </summary>
            ''' <param name="reference_Sequences"></param>
            ''' <returns></returns>
            Public Shared Function Get_Header(reference_Sequences As List(Of ReferenceSequenceInfo)) As String
                Dim str As New System.Text.StringBuilder
                For Each refSeq In reference_Sequences
                    str.Append("@SQ").Append(vbTab).Append("SN:").Append(refSeq.Name).Append("LN:").Append(refSeq.Length).AppendLine()
                Next
                If str.Length > 0 Then str.Length -= 2
                Return str.ToString
            End Function

#End Region


#Region "Reference Seqs"
            ''' <summary>
            ''' return all unique Reference Sequence info
            ''' </summary>
            ''' <param name="Files"></param>
            ''' <returns></returns>
            Public Shared Function Get_ReferenceSequences(Files As List(Of FileInfo)) As List(Of Bio.IO.SAM.ReferenceSequenceInfo)
                Dim Headers = Get_Header(Files)

                Dim RefSeqs As New List(Of Bio.IO.SAM.ReferenceSequenceInfo)
                For Each Header In Headers
                    RefSeqs.AddRange(Header.ReferenceSequences)
                Next
                Dim uRefSeqs = From c In RefSeqs Select New With {Key c.Name, c.Length} Distinct.ToList
                Dim out As New List(Of Bio.IO.SAM.ReferenceSequenceInfo)
                For Each RefSeq In uRefSeqs
                    out.Add(New Bio.IO.SAM.ReferenceSequenceInfo(RefSeq.Name, RefSeq.Length))
                Next
                Return out
            End Function

            ''' <summary>
            ''' return all unique Reference Sequence info
            ''' </summary>
            ''' <param name="File"></param>
            ''' <returns></returns>
            Public Shared Function Get_ReferenceSequences(File As FileInfo) As List(Of Bio.IO.SAM.ReferenceSequenceInfo)
                Dim Headers = Get_Header(File)

                Dim RefSeqs As New List(Of Bio.IO.SAM.ReferenceSequenceInfo)

                RefSeqs.AddRange(Headers.ReferenceSequences)

                Dim uRefSeqs = From c In RefSeqs Select New With {Key c.Name, c.Length} Distinct.ToList
                Dim out As New List(Of Bio.IO.SAM.ReferenceSequenceInfo)
                For Each RefSeq In uRefSeqs
                    out.Add(New Bio.IO.SAM.ReferenceSequenceInfo(RefSeq.Name, RefSeq.Length))
                Next
                Return out
            End Function

            ''' <summary>
            ''' Return DIstinct SeqIDs
            ''' </summary>
            ''' <param name="Bams"></param>
            ''' <returns></returns>
            Public Shared Function Select_Reference_SeqIDs(Bams As List(Of FileInfo)) As List(Of String)
                Dim IDs = Get_Reference_SeqIDS(Bams)
                Return IDs.Distinct.ToList
            End Function

            ''' <summary>
            ''' Return Distinct list of SeqIDs or new list
            ''' </summary>
            ''' <param name="Bams"></param>
            ''' <returns></returns>
            Public Shared Function Get_Reference_SeqIDS(Bams As List(Of FileInfo)) As List(Of String)
                Dim IDs = Get_ReferenceSequences(Bams)
                If IDs.Count > 0 Then
                    Dim res = (From x In IDs Select x.Name).ToList
                    Return res.Distinct.ToList
                Else
                    Return New List(Of String)
                End If
            End Function


            ''' <summary>
            ''' Return Distinct list of SeqIDs or new list Ordered
            ''' </summary>
            ''' <param name="Bam"></param>
            ''' <returns></returns>
            Public Shared Function Get_Reference_SeqIDS(ByRef BAm As FileInfo) As List(Of String)
                Dim IDs = Get_ReferenceSequences(BAm)
                If IDs.Count > 0 Then
                    Dim res = (From x In IDs Select x.Name).ToList
                    res = res.Distinct.ToList
                    res.Sort()
                    Return res.ToList
                Else
                    Return New List(Of String)
                End If
            End Function
#End Region


        End Class

        Public Class ReadIDs
#Region "Read IDs"
            Public Shared Function Get_Sorted_Distinct_Read_IDs() As List(Of String)
                Dim Files = Szunyi.IO.Pick_Up.SAM_BAM
                Return Get_Sorted_Distinct_Read_IDs(Files)
            End Function
            Public Shared Function Get_Sorted_Distinct_Read_IDs(files As IEnumerable(Of FileInfo)) As List(Of String)
                Dim Read_IDs = Get_Read_IDs(files)
                Read_IDs.Distinct
                Read_IDs.Sort()
                Return Read_IDs

            End Function
            Public Shared Function Get_Sorted_Distinct_Read_IDs(file As FileInfo) As List(Of String)
                Dim Read_IDs = Get_Read_IDs(file)
                Read_IDs = Read_IDs.Distinct.ToList
                Read_IDs.Sort()
                Return Read_IDs

            End Function
            Public Shared Function Get_Read_IDs(file As FileInfo) As List(Of String)
                Dim out As New List(Of String)
                For Each sam In Parse(file)
                    out.Add(sam.QName)
                Next
                Return out
            End Function
            Public Shared Function Get_Read_IDs(files As IEnumerable(Of FileInfo)) As List(Of String)
                Dim out As New List(Of String)
                For Each sam In Parse(files)
                    out.Add(sam.QName)
                Next
                Return out
            End Function
            Public Shared Function Get_Sorted_Read_IDs(file As FileInfo) As List(Of String)
                Dim Read_IDs = Get_Read_IDs(file)
                Read_IDs.Sort()
                Return Read_IDs
            End Function
#End Region
        End Class


#Region "Parse"


        Public Shared Function ParseAll(Files As IEnumerable(Of FileInfo)) As List(Of Bio.IO.SAM.SAMAlignedSequence)
            Dim allsam As New List(Of Bio.IO.SAM.SAMAlignedSequence)
            For Each File In Files
                allsam.AddRange(ParseAll(File))
            Next
            Return allsam
        End Function
        Public Shared Function ParseAll(fIle As FileInfo) As List(Of Bio.IO.SAM.SAMAlignedSequence)
            Dim allsam As New List(Of Bio.IO.SAM.SAMAlignedSequence)
            For Each Sam In Parse(fIle)

                allsam.Add(Sam)

            Next
            Return allsam
        End Function
        Public Shared Iterator Function Parse(File As FileInfo) As IEnumerable(Of Bio.IO.SAM.SAMAlignedSequence)
            If File.Extension = ".bam" Then
                Using sr As New FileStream(File.FullName, FileMode.Open)

                    Dim sa As New Bio.IO.BAM.BAMParser()
                    For Each SAM As Bio.IO.SAM.SAMAlignedSequence In sa.Parse(sr)
                        Yield (SAM)
                    Next
                End Using
            ElseIf File.Extension = ".sam" Then
                For Each Line In Szunyi.IO.Import.Text.Parse(File, "@")
                    If Line <> "" Then
                        Yield Bio.IO.SAM.SAMParser.ParseSequence(Line)
                    End If

                Next
            End If


        End Function

        Public Shared Iterator Function Parse(File As FileInfo, SeqID As String, Start As Integer, Endy As Integer) As IEnumerable(Of Bio.IO.SAM.SAMAlignedSequence)
            Dim sa As New Bio.IO.BAM.BAMParser()
            Dim sg = Bio.IO.BAM.BAMParserExtensions.ParseRange(sa, File.FullName, SeqID, Start, Endy)
            If IsNothing(sg) = False Then

                For Each Sam In sg.AlignedSequences
                    Yield (Sam)
                Next
            End If

        End Function

        Public Shared Iterator Function Parse(Files As IEnumerable(Of FileInfo), SeqID As String) As IEnumerable(Of Bio.IO.SAM.SAMAlignedSequence)
            Dim sa As New Bio.IO.BAM.BAMParser()
            For Each file In Files
                Dim st = Bio.IO.BAM.BAMParserExtensions.ParseRange(sa, file.FullName, SeqID)

                For Each Sam In st.AlignedSequences
                    Yield (Sam)
                Next

            Next
        End Function

        Public Shared Iterator Function Parse(File As FileInfo, SeqID As String) As IEnumerable(Of Bio.IO.SAM.SAMAlignedSequence)
            Dim sa As New Bio.IO.BAM.BAMParser()
            Dim sg = Bio.IO.BAM.BAMParserExtensions.ParseRange(sa, File.FullName, SeqID)
            If IsNothing(sg) = False Then

                For Each Sam In sg.AlignedSequences
                    Yield (Sam)
                Next
            End If

        End Function

        Public Shared Iterator Function Parse(Files As IEnumerable(Of FileInfo), SeqIDs As List(Of String)) As IEnumerable(Of Bio.IO.SAM.SAMAlignedSequence)
            Dim sa As New Bio.IO.BAM.BAMParser()
            For Each File In Files
                For Each SeqID In SeqIDs

                    For Each Sam In Bio.IO.BAM.BAMParserExtensions.ParseRange(sa, File.FullName, SeqID).AlignedSequences
                        Yield (Sam)
                    Next

                Next
            Next


        End Function

        Public Shared Iterator Function Parse(Files As IEnumerable(Of FileInfo)) As IEnumerable(Of Bio.IO.SAM.SAMAlignedSequence)
            For Each File In Files
                For Each sam In Parse(File)
                    Yield sam
                Next
            Next
        End Function


#End Region
    End Class


End Namespace



