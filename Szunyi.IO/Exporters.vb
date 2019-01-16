Imports System.IO
Imports System.Windows.Forms

''' <summary>
''' These Exporters are Optimized for Streaming, Handling large Amount of Data
''' </summary>
Public Class Exporters
    ''' <summary>
    ''' Class To Write Enumerable of Strings Into File
    ''' </summary>

    Public Class Text_Exporter
        Implements IDisposable
        Private _stream As FileStream
        Private nFile As FileInfo
        Dim x As StreamWriter
        Public Sub New(File As FileInfo)
            Me.nFile = File
            x = New StreamWriter(File.FullName)
            x.AutoFlush = True

        End Sub
        ''' <summary>
        ''' Write a single Line to the end of the File, optionally Append vbcrlf Before Line
        ''' </summary>
        ''' <param name="Line"></param>
        ''' <param name="vbcrlfBefore"></param>
        Public Sub Write(Line As String, Optional vbcrlfBefore As Boolean = True)
            If vbcrlfBefore = True Then x.WriteLine()
            x.Write(Line)
        End Sub
        ''' <summary>
        ''' Write a several Line to the end of the File, optionally Append vbcrlf Before Line
        ''' </summary>
        ''' <param name="Lines"></param>
        ''' <param name="vbcrlfBefore"></param>
        Public Sub Write(Lines As IEnumerable(Of String), Optional vbcrlfBefore As Boolean = True)
            For Each Line In Lines
                Write(Line)
            Next
        End Sub
#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    _stream.Flush()
                    _stream.Close()

                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            ' TODO: uncomment the following line if Finalize() is overridden above.
            ' GC.SuppressFinalize(Me)
        End Sub
#End Region
    End Class
    ''' <summary>
    ''' Class To Write enumerable of Sequences Into File
    ''' </summary>
    Public Class Fasta_Exporter
        Implements IDisposable
        Private _stream As FileStream
        Private nFile As FileInfo
        Dim x As New Bio.IO.FastA.FastAFormatter
        Public Sub New(nFile As FileInfo)
            Me.nFile = nFile
            x.AutoFlush = True
            _stream = New FileStream(nFile.FullName, FileMode.Create, FileAccess.ReadWrite)
        End Sub
        ''' <summary>
        ''' Write Single Sequence to the end of File
        ''' </summary>
        ''' <param name="Seq"></param>
        Public Sub Write(Seq As Bio.ISequence)
            x.Format(_stream, Seq)
        End Sub
        ''' <summary>
        ''' Write Several Sequence to the end of File
        ''' </summary>
        ''' <param name="Seqs"></param>
        Public Sub Write(Seqs As IEnumerable(Of Bio.ISequence))
            x.Format(_stream, Seqs)
        End Sub
#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    _stream.Flush()
                    _stream.Close()

                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            ' TODO: uncomment the following line if Finalize() is overridden above.
            ' GC.SuppressFinalize(Me)
        End Sub
#End Region
    End Class

End Class


