namespace AIDesktop.Data
{
    public class CognitiveServicesStartReadResultRequest
    {
        public string url { get; set; }
        public Byte[] image { get; set; }
    }

    public class CognitiveServicesStartReadResultResponse
    {
        // Operation-Location is a header from the Post response that contains the operation id
    }
}
