﻿using AIDesktop.Data;
using System.Net.Http.Headers;

namespace AIDesktop.Web
{
    public interface IAzureApiClient
    {
        public string StartCognitiveServiceReadTextProcess(CognitiveServicesStartReadResultRequest request);
    }

    // I could setup a http request pipeline a layer above in the service to handle the sequential calls to retrieve the result I actually care about
    public class AzureApiClient : IAzureApiClient
    {
        private HttpClient _httpClient;

        public AzureApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Settings.AzureCognitiveServicesApiKey);
            //_httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Region", "uksouth");
        }

        // step 1
        public string StartCognitiveServiceReadTextProcess(CognitiveServicesStartReadResultRequest request)
        {
            var postUrl = Settings.AzureCognitiveServicesBaseApiUrl + Settings.AzureCognitiveServicesStartTextAnalysisApiUrl;
            string headerValue;
            using (var content = new ByteArrayContent(request.image))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                var response = _httpClient.PostAsync(postUrl, content);
                response.Wait();
                if (response.Result.IsSuccessStatusCode)
                {
                    var expectedHeader = response.Result.Headers.FirstOrDefault(x => x.Key == "Operation-Location").Value.ToString();
                    headerValue = expectedHeader;
                }
            }
            
            return null;
        }

        // step 2 - retrieve the actual response from the processed Cognitive Service endpoint result from the header
        public void GetCognitiveServiceReadTextResult()
        {
        }
    }

    /*
        step 1
    Submitting data to the service

     You submit either a local image or a remote image to the Read API. For local, you put the binary image data in the HTTP request body. For remote, you specify the image's URL by formatting the request body like the following: {"url":"http://example.com/images/test.jpg"}.

    
    step 2

    The call returns with a response header field called Operation-Location. The Operation-Location value is a URL that contains the Operation ID to be used in the next step


        step 3 getting read data

    call off to https://{endpoint}/vision/v3.2/read/analyzeResults/{operationId} to get the results

     */
}
