namespace AIDesktop.Web
{
    public interface IAzureApiClient
    {
    }

    public class AzureApiClient : IAzureApiClient
    {
        private HttpClient _httpClient;

        public AzureApiClient(HttpClient httpClient)
        {
            _httpClient = new HttpClient();
        }

        public void Get()
        {
        }

        public void Post()
        {
        }
    }
}
