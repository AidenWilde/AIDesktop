namespace AIDesktop.Data
{
    public class CognitiveServicesReadResultRequest
    {
    }

    public class CognitiveServicesReadResultResponse
    {
        public string status { get; set; }
        public DateTime createdDateTime { get; set; }
        public DateTime lastUpdatedDateTime { get; set; }
        public AnalyzeResult analyzeResult { get; set; }

        public class Appearance
        {
            public string style { get; set; }
            public double styleConfidence { get; set; }
        }

        public class Word
        {
            public List<int> boundingBox { get; set; }
            public string text { get; set; }
            public double confidence { get; set; }
        }

        public class Line
        {
            public List<int> boundingBox { get; set; }
            public string text { get; set; }
            public Appearance appearance { get; set; }
            public List<Word> words { get; set; }
        }

        public class ReadResult
        {
            public int page { get; set; }
            public double angle { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public string unit { get; set; }
            public List<Line> lines { get; set; }
        }

        public class AnalyzeResult
        {
            public string version { get; set; }
            public string modelVersion { get; set; }
            public List<ReadResult> readResults { get; set; }
        }
    }
}
