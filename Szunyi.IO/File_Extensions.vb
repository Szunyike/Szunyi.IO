''' <summary>
''' This class Constants used For Picking File(s) From FileDialogs
''' </summary>
Public Class File_Extensions
    ''' <summary>
    ''' Extensions For Import VanKrevelen
    ''' </summary>
    Public Const mzXML = "mzXML (*.mzXML)|*.mzXML"
    ''' <summary>
    ''' Extensions For Import CSV
    ''' </summary>
    Public Const csv = "CSV (*.csv)|*.csv"
    ''' <summary>
    ''' Extensions For Import PoreChop
    ''' </summary>
    Public Const PoreCHop = "PoreChop|*.porechop"
    ''' <summary>
    ''' Extensions For Import SAM ,BAM or FASTQ
    ''' </summary>
    Public Const SAM_BAM_Fastq As String = "SAM/BAM/FASTQ (*.sam,*bam.*.fastq)|*.sam;*.bam.*.fastq|Sam (*.sam)|*.sam|Bam (*.bam)|*.bam|fastq (*.fastq)|*.fastq"
    ''' <summary>
    ''' Extensions For Import GenBankk-like Location File, SAM or BAM
    ''' </summary>
    Public Const Loc_SAM_BAM As String = "GBK Location Files or SAM/BAM|*.loc;*.sam;*.bam"
    ''' <summary>
    ''' Extensions For Import GenBankk-like Location File
    ''' </summary>
    Public Const Location As String = "GBK LocationFiles|*.loc"
    ''' <summary>
    ''' Extensions For Import Picard Report File
    ''' </summary>
    Public Const rep As String = "Picard Report Files|*.rep"
    ''' <summary>
    ''' Extensions For Import VCF Files
    ''' </summary>
    Public Const vcf As String = "VCF Files|*.vcf"
    ''' <summary>
    ''' Extensions For Import BED FIles
    ''' </summary>
    Public Const BED As String = "BED Files|*.bed"

    ''' <summary>
    ''' Extensions For Import log FIles
    ''' </summary>
    Public Const Log = "LOG Files|*.log"
    ''' <summary>
    ''' Extensions For Import XML FIles
    ''' </summary>
    Public Const Xml = "XML Files|*.xml"
    ''' <summary>
    ''' Extensions For Import tabulated Files
    ''' </summary>
    Public Const All_TAB_Like = "All Tab-Like Files|*.tdt;*.tab;*.txt;*.tsv;*.csv"
    ''' <summary>
    ''' Extensions For Import Fast5 FIles
    ''' </summary>
    Public Const Fast5 As String = "FAST5 (*.fast5)|*.fast5"
    ''' <summary>
    ''' Extensions For Import FASTA FIles
    ''' </summary>
    Public Const Fasta As String = "FASTA (*.fa,*.fas,*.fasta.*.fna)|*.fa;*.fas;*.fasta;*.fna"
    ''' <summary>
    ''' Extensions For Import GenBank FIles
    ''' </summary>
    Public Const GenBank As String = "GenBank (*.gbk,*.gb,*.gbff)|*.gb;*.gbk;*.gbff"
    ''' <summary>
    ''' Extensions For Import GFF3 FIles
    ''' </summary>
    Public Const gff3 As String = "GFF3 (*.gff)|*.gff3"
    ''' <summary>
    ''' Extensions For Import SAM FIles
    ''' </summary>
    Public Const SAM As String = "SAM (*.sam)|*.sam"
    ''' <summary>
    ''' Extensions For Import BAM FIles
    ''' </summary>
    Public Const BAM As String = "BAM (*.bam)|*.bam"
    ''' <summary>
    ''' Extensions For Import SAM or BAM FIles
    ''' </summary>
    Public Const SAM_BAM As String = "SAM/BAM (*.sam,*bam)|*.sam;*.bam|Sam (*.sam)|*.sam|Bam (*.bam)|*.bam"
    ''' <summary>
    ''' Extensions For Import HDF5 FIles
    ''' </summary>
    Public Const HDF5 As String = "HDF5 (*.h5)|*.h5"
    ''' <summary>
    ''' Extensions For Import gzip FIles
    ''' </summary>
    Public Const Gzip As String = "Gzip Files(*.gz) |*.gz"
    ''' <summary>
    ''' Extensions For Import FASTA or FASTQ FIles
    ''' </summary>
    Public Const Fasta_FastQ As String = "FASTA and FASTQ (*.fa,*.fas,*.fasta,*.fast1,*.fq)|*.fa;*.fas;*.fasta;*.fq;*.fastq"
    ''' <summary>
    ''' Extensions For Import FASTQ FIles
    ''' </summary>
    Public Const FastQ As String = "FASTQ (*.fq,*.fastq)|*.fq;*.fastq"
    ''' <summary>
    ''' Extensions For Import any kind of Sequence File
    ''' </summary>
    Public Const SequenceFileTypesToImport As String = "All Sequence File|*.fa;*.fas;*.fasta;*.fna;*gb;*.gbk;*.fq;*.fastQ|" &
                  "Fasta (*.fa,*.fas) Multiple|*.fa;*.fas|" &
    "FastQ (*.fq,*.fastq) Multiple|*.fq;*.fastq|" &
    "GenBank  (*.gbk,*.gb)|*.gb;*.gbk"
    ''' <summary>
    ''' Extensions For Import Settings FIles
    ''' </summary>
    Public Const Settings = "Settings Files|*.set"
    ''' <summary>
    ''' Extensions For Import NEXML FIles
    ''' </summary>
    Public Const PhylogeneticXml = "Nexml Files|*.nexml"
    ''' <summary>
    ''' Extensions For Import SignalP FIles
    ''' </summary>
    Public Const SignalP = ".SignalP"
    ''' <summary>
    ''' Extensions For Import VanKrevelen crude data FIles
    ''' </summary>
    Public Const VanKrevelen = "VanKrevelen crude data (*.VKC)|*.VKC"

    '  Public Const Blast_PairWise = "Pairwise|*.b0"
    ' Public Const Blast_Query_Anchored_wIdentities = "Query - anchored showing identities|*.b1"
    ' Public Const Blast_Query_Anchored_woIdentities = "Query - anchored showing identities|*.b2"
    ' Public Const Blast_Flat_Query_Anchored_wIdentities = "Flat Query - anchored showing identities|*.b3"
    ' Public Const Blast_Flat_Query_Anchored_woIdentities = "Flat Query - anchored showing identities|*.b4"

    ''' <summary>
    ''' Extensions For Import BLAST XML(b5) FIles
    ''' </summary>
    Public Const Blast_XML = "Blast XML|*.xml;*.b5"
    ''' <summary>
    ''' Extensions For Import BLAST tabular(b6) FIles
    ''' </summary>
    Public Const Blast_tabular = "Blast tabular|*.b6"
    ''' <summary>
    ''' Extensions For Import BLAST tabular(b7) commented FIles
    ''' </summary>
    Public Const Blast_tabular_wComment = "Blast tabular with comment lines|*.b7"
    ''' <summary>
    ''' Extensions For Import Mathematical Filtering FIles
    ''' </summary>
    Public Const Filter = "Mathematical Filtering|*.fil"
    ''' <summary>
    ''' Extensions For Import KAnalyse FIles
    ''' </summary>
    Public Const KAnalyse = "KAnalyse Files|*.kc"
    ''' <summary>
    ''' Extensions For Import every kind of BLAST  FIles
    ''' </summary>
    Public Const BlastAll = "All Blast Type|*.b0;*.b1;*.b2;*.b3;*.b4;*.b5;*.b6;*.b7;*.8;*.b9;*.b10;*.b11;*.b12;*.b13;*.b14;*.b15;*.b16;*.b17;*.xml;"
    '   Public Const Blast = BlastAll & "|" & Blast_XML & "|" & SAM_BAM & "|" & Blast_PairWise & "|" & Blast_Query_Anchored_wIdentities & "|" & Blast_Query_Anchored_woIdentities &
    '      "|" & Blast_Flat_Query_Anchored_wIdentities & "|" & Blast_Flat_Query_Anchored_woIdentities & "|" & Blast_tabular & "|" & Blast_tabular_wComment

End Class
''' <summary>
''' This class Constants used For File ReName
''' </summary>
Public Class File_Extension
    ''' <summary>
    ''' Used For Save Or Rename KMERAnalyse File
    ''' </summary>
    Public Const KAnalyse = "*.kc"
    ''' <summary>
    ''' Used For Save Or Rename GenBank File
    ''' </summary>
    Public Const GenBank = ".gbk"
    ''' <summary>
    ''' Used For Save Or Rename FASTA File
    ''' </summary>
    Public Const fasta = ".fa"
    ''' <summary>
    ''' Used For Save Or Rename Filter File
    ''' </summary>
    Public Const Filter = ".fil"
    ''' <summary>
    ''' Used For Save Or Rename VanKrevelen File
    ''' </summary>
    Public Const VanKrevelen = ".VKC"
    ''' <summary>
    ''' Used For Save Or Rename XML File
    ''' </summary>
    Public Const Xml = ".xml"
    ''' <summary>
    ''' Used For Save Or Rename BLAST Type = 0 File
    ''' </summary>
    Public Const b0 = ".b0"
    ''' <summary>
    ''' Used For Save Or Rename BLAST Type = 1 File
    ''' </summary>
    Public Const b1 = ".b1"
    ''' <summary>
    ''' Used For Save Or Rename BLAST Type = 2 File
    ''' </summary>
    Public Const b2 = ".b2"
    ''' <summary>
    ''' Used For Save Or Rename BLAST Type = 3 File
    ''' </summary>
    Public Const b3 = ".b3"
    ''' <summary>
    ''' Used For Save Or Rename BLAST Type = 4 File
    ''' </summary>
    Public Const b4 = ".b4"
    ''' <summary>
    ''' Used For Save Or Rename BLAST Type = 5 File
    ''' </summary>
    Public Const b5 = ".b5"
    ''' <summary>
    ''' Used For Save Or Rename BLAST Type = 6 File
    ''' </summary>
    Public Const b6 = ".b6"
    ''' <summary>
    ''' Used For Save Or Rename BLAST Type = 7 File
    ''' </summary>
    Public Const b7 = ".b7"
    ''' <summary>
    ''' Used For Save Or Rename BLAST Type =8 File
    ''' </summary>
    Public Const b8 = ".b8"
    ''' <summary>
    ''' Used For Save Or Rename BLAST Type = 9 File
    ''' </summary>
    Public Const b9 = ".b9"
    ''' <summary>
    ''' Used For Save Or Rename BLAST Type = 10 File
    ''' </summary>
    Public Const b10 = ".b10"
    ''' <summary>
    ''' Used For Save Or Rename BLAST Type = 11 File
    ''' </summary>
    Public Const b11 = ".b12"
    ''' <summary>
    ''' Used For Save Or Rename BLAST Type = 10 File
    ''' </summary>
    Public Const b12 = ".b12"
    ''' <summary>
    ''' Used For Save Or Rename BLAST Type = 13 File
    ''' </summary>
    Public Const b13 = ".b13"
    ''' <summary>
    ''' Used For Save Or Rename BLAST Type = 14 File
    ''' </summary>
    Public Const b14 = ".b14"
    ''' <summary>
    ''' Used For Save Or Rename BLAST Type = 15 File
    ''' </summary>
    Public Const b15 = ".b15"
    ''' <summary>
    ''' Used For Save Or Rename BLAST Type = 16 File
    ''' </summary>
    Public Const b16 = ".b16"
    ''' <summary>
    ''' Used For Save Or Rename BLAST Type = 17 File
    ''' </summary>
    Public Const b17 = ".b17"
    ''' <summary>
    ''' Used For Save Or Rename BLAST Type = 18 File
    ''' </summary>
    Public Const b18 = ".b18"
End Class


