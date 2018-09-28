Imports System.IO

Namespace Import
    Public Class Sequences
        Public Shared Iterator Function Parse(Files As IEnumerable(Of FileInfo)) As IEnumerable(Of Bio.ISequence)
            For Each File In Files
                Using x As New FileStream(File.FullName, FileMode.Open)
                    Dim fa = Bio.IO.SequenceParsers.FindParserByFileName(File.FullName)
                    For Each Seq In fa.Parse(x)
                        Yield Seq
                    Next
                End Using
            Next
        End Function
        Public Shared Iterator Function Parse(File As FileInfo) As IEnumerable(Of Bio.ISequence)
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
        Public Shared Iterator Function Parse() As IEnumerable(Of Bio.ISequence)
            Dim Files = Szunyi.IO.Pick_Up.Sequence
            For Each Seq In Parse(Files)
                Yield Seq
            Next

        End Function
    End Class

    Public Class SequenceIDs
        Public Shared Iterator Function All_Full(Files As IEnumerable(Of FileInfo)) As IEnumerable(Of String)
            For Each I In From x In Sequences.Parse(Files) Select x.ID
                Yield I
            Next
        End Function
        Public Shared Iterator Function All_Short(Files As IEnumerable(Of FileInfo), Optional separator As String = " ") As IEnumerable(Of String)
            For Each I In From x In Sequences.Parse(Files) Select x.ID
                Yield Split(I, separator).First
            Next
        End Function
        Public Shared Iterator Function Distinct_Full(Files As IEnumerable(Of FileInfo)) As IEnumerable(Of String)
            For Each I In (From x In Sequences.Parse(Files) Select x.ID).Distinct
                Yield I
            Next
        End Function
        Public Shared Iterator Function Distinct_Short(Files As IEnumerable(Of FileInfo)) As IEnumerable(Of String)
            Dim out As New List(Of String)
            For Each I In All_Short(Files)
                out.Add(I)
            Next
            For Each ID In out.Distinct
                Yield ID
            Next
        End Function

    End Class

End Namespace

