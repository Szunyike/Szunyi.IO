Imports System.IO
Imports System.Runtime.CompilerServices

Public Module Import
    ''' <summary>
    ''' Parse Sequences From User-Defined Enumerable Files
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function Parse_Sequence(Files As IEnumerable(Of FileInfo)) As IEnumerable(Of Bio.ISequence)
        For Each File In Files
            Using x As New FileStream(File.FullName, FileMode.Open)

                Dim fa = Bio.IO.SequenceParsers.FindParserByFileName(File.FullName)
                For Each Seq In fa.Parse(x)
                    Yield Seq
                Next
            End Using
        Next
    End Function
    ''' <summary>
    ''' Parse Sequences From User-Defined Enumerable File
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function Parse_Sequence(File As FileInfo) As IEnumerable(Of Bio.ISequence)
        If IsNothing(File) = True Then
            Yield Nothing
        Else
            Using x As New FileStream(File.FullName, FileMode.Open)
                Dim fa = Bio.IO.SequenceParsers.FindParserByFileName(File.FullName)
                For Each Seq In fa.Parse(x)
                    Yield Seq
                Next
            End Using
        End If

    End Function
    ''' <summary>
    ''' Parse Sequences From User-Selected Enumerable Files
    ''' </summary>
    ''' <returns></returns>
    Public Iterator Function Parse_Sequence() As IEnumerable(Of Bio.ISequence)
        Dim Files = Szunyi.IO.Pick_Up.Sequence
        For Each Seq In Parse_Sequence(Files)
            Yield Seq
        Next

    End Function


    ''' <summary>
    ''' Parse All SequenceIDs
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function Parse_SequenceIDs(Files As IEnumerable(Of FileInfo)) As IEnumerable(Of String)
        For Each I In From x In Files.Parse_Sequence Select x.ID
            Yield I
        Next
    End Function
    ''' <summary>
    ''' Parse All Short SequenceIDs (First Part After splitting by USer_Defined separator)
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function Parse_Short_SequenceIDs(Files As IEnumerable(Of FileInfo), Optional separator As String = " ") As IEnumerable(Of String)
        For Each I In From x In Files.Parse_Sequence Select x.ID
            Yield Split(I, separator).First
        Next
    End Function
    ''' <summary>
    ''' Parse Distinct SequenceIDs
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function Parse_Distinct_SequenceIDs(Files As IEnumerable(Of FileInfo)) As IEnumerable(Of String)
        For Each I In (From x In Files.Parse_Sequence Select x.ID).Distinct
            Yield I
        Next
    End Function
    ''' <summary>
    ''' Parse Short Distinct SequenceIDs (First Part After splitting by USer_Defined separator)
    ''' </summary>
    ''' <param name="Files"></param>
    ''' <returns></returns>
    <Extension()>
    Public Iterator Function Parse_Distinct_Short_SequenceIDs(Files As IEnumerable(Of FileInfo)) As IEnumerable(Of String)
        Dim out As New List(Of String)
        For Each I In Parse_Short_SequenceIDs(Files)
            out.Add(I)
        Next
        For Each ID In out.Distinct
            Yield ID
        Next
    End Function



End Module

