using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TFLRoadStatus.Exceptions;
using TFLRoadStatus.Interfaces;

namespace TFLRoadStatus.Model
{
    public class GetRoadInformation
    {
        
        private  string baseUrl;
        private readonly string app_id;
        private readonly string app_key;
        private static HttpClient _httpClient;
        private IConfigurationWrapper _configWrapper;

        public GetRoadInformation(IConfigurationWrapper wrapper)
        {
           _configWrapper = wrapper;
            baseUrl = _configWrapper.GetValue("Url");
            app_id = _configWrapper.GetValue("app_Id");
            app_key = _configWrapper.GetValue("app_Key");
        }
        private void EnsureHttpClientCreated()
        {
            if (_httpClient == null)
            {
                CreateHttpClient();
            }
        }
        private void CreateHttpClient()
        {
            _httpClient = new HttpClient();
        }
        public HttpResponseMessage IsValidStatusCode(string RoadId)
        {
            using (_httpClient)
            {
                EnsureHttpClientCreated();
                HttpResponseMessage responseMessage = _httpClient.GetAsync($"{baseUrl}{RoadId}?app_id={ app_id}&amp;app_key={ app_key}").Result;
                return responseMessage;
            }
         
        }
        public async Task<IEnumerable<Road>> GetRoadById(string RoadId)
        {
            IEnumerable<Road> roads = null;
            try
            {
                
                using (_httpClient)
                {
                    //EnsureHttpClientCreated();
                    //HttpResponseMessage responseMessage = _httpClient.GetAsync($"{baseUrl}{RoadId}?app_id={ app_id}&amp;app_key={ app_key}").Result;
                    HttpResponseMessage responseMessage = IsValidStatusCode(RoadId);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        roads = await responseMessage.Content.ReadAsAsync<IList<Road>>();
                    }
                    else
                    {
                        throw new RoadIdNotFoundException(responseMessage.StatusCode, RoadId);
                    }

                }
                return roads;
                //Display.DisplayInformation(roads);
            }
            catch(RoadIdNotFoundException ex)
            {
                return roads;
            }
            
        }
    }
}
