namespace Management.Core.Models.SchoolManager
{
    public partial class AcademicTranscript
    {
        public long AcademicTranscriptId { get; set; }
        public string? AcademicTranscriptCode { get; set; }
        public double? PointOne { get; set; }
        public double? PointTwo { get; set; }
        public double? PontThree { get; set; }
        public double? PointFour { get; set; }
        public double? PointFive { get; set; }
        public double? TestPointOne { get; set; }
        public double? TestPointTwo { get; set; }
        public double? TestPointThree { get; set; }
        public double? FinalTestPoint { get; set; }
        public double? AverageScore { get; set; }
        public long StudentId { get; set; }
        public long SubjectId { get; set; }
    }
}