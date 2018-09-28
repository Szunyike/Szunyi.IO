
Public Class File_Extensions
        Public Const csv = "csv (*.csv)|*.csv"
        Public Const PoreCHop = "PoreChop|*.porechop"
        Public Const SAM_BAM_Fastq As String = "Sam/Bam/fastq (*.sam,*bam.*.fastq)|*.sam;*.bam.*.fastq|Sam (*.sam)|*.sam|Bam (*.bam)|*.bam|fastq (*.fastq)|*.fastq"
        Public Const Loc_SAM_BAM As String = "GBK Location Files or SAM/BAM|*.loc;*.sam;*.bam"
        Public Const Location As String = "GBK LocationFiles|*.loc"
        Public Const rep As String = "Picard Report Files|*.rep"
        Public Const gpg As String = "EGA Files|*.gpg"
        Public Const vcf As String = "Vcf Files|*.vcf"
        Public Const BED As String = "Bed Files|*.bed"
        Public Const SelectFolder As String = "Select Folder"
        Public Const Log = "log Files|*.log"
        Public Const Xml = "xml Files|*.xml"
        Public Const All_TAB_Like = "All Tab-Like Files|*.tdt;*.tab;*.txt;*.tsv;*.csv"
        Public Const Fast5 As String = "Fast5 (*.fast5)|*.fast5"
        Public Const Fasta As String = "Fasta (*.fa,*.fas,*.fasta.*.fna)|*.fa;*.fas;*.fasta;*.fna"
        Public Const GenBank As String = "GenBank (*.gbk,*.gb)|*.gb;*.gbk"
        Public Const gff3 As String = "gff3 (*.gff)|*.gff3"
        Public Const SAM As String = "Sam (*.sam)|*.sam"
        Public Const BAM As String = "Bam (*.bam)|*.bam"
        Public Const SAM_BAM As String = "Sam/Bam (*.sam,*bam)|*.sam;*.bam|Sam (*.sam)|*.sam|Bam (*.bam)|*.bam"
        Public Const HDF5 As String = "HDF5 (*.h5)|*.h5"
        Public Const Gzip As String = "Gzip Files(*.gz) |*.gz"

        Public Const Fasta_FastQ As String = "Fasta and Fastq (*.fa,*.fas,*.fasta,*.fast1,*.fq)|*.fa;*.fas;*.fasta;*.fq;*.fastq"
        Public Const Fasta_FastQ_gz As String = "Fasta, Fastq and gz (*.fa,*.fas,*.fasta,*.fast1,*.fq,*.gz)|*.fa;*.fas;*.fasta;*.fq;*.fastq,*.gz|Fasta and Fastq (*.fa,*.fas,*.fasta,*.fast1,*.fq)|*.fa;*.fas;*.fasta;*.fq;*.fastq|Gzip Files(*.gz) |*.gz"
        Public Const FastQ As String = "fastq (*.fq,*.fastq)|*.fq;*.fastq"

        Public Const SequenceFileTypesToImport As String = "All Sequence File|*.fa;*.fas;*.fasta;*.fna;*gb;*.gbk;*.fq;*.fastQ|" &
                      "Fasta (*.fa,*.fas) Multiple|*.fa;*.fas|" &
        "FastQ (*.fq,*.fastq) Multiple|*.fq;*.fastq|" &
        "GenBank  (*.gbk,*.gb)|*.gb;*.gbk|"


        Public Const Settings = "Settings Files|*.set"
        Public Const PhylogeneticXml = "Nexml Files|*.nexml"
        Public Const SignalP = ".SignalP"
    End Class

