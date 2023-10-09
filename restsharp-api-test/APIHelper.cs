using RestSharp;
using restsharp_api_test.model;

namespace restsharp_api_test
{
    public class APIHelper
    {
        public RestClient restClient;
        public String baseUrl = "https://api.restful-api.dev";
        public String basePath = "/objects";

        public APIHelper()
            {
                this.restClient = new RestClient(new RestClientOptions
                {
                    BaseUrl = new Uri(baseUrl)
                });
            }


        public ICollection<Phone> getPhoneList()
            {
                var request = new RestRequest(basePath);
                return restClient.Get<ICollection<Phone>>(request);
            }

        public Phone getPhoneById(String id)
            {
                var request = getRestRquestId(id);
                return restClient.Get<Phone>(request);
            }
        public Phone createPhone(Phone phone) 
            {
                var request = new RestRequest(basePath);
                request.AddBody(phone);
                RestResponse response = restClient.Execute(request);
                return restClient.Post<Phone>(request);
            }

        public Phone updatePhone(Phone phone)
            {
                var request = getRestRquestId(phone.Id);
                request.AddBody(phone);
                return restClient.Put<Phone>(request); ;
            }

        public DeletedMsg deletePhone(String id)
            {
                var request = getRestRquestId(id);
                return restClient.Delete<DeletedMsg>(request);
            }

        public Phone patchUpdatePhone(String bodyContent,string id)
        {
            var request = getRestRquestId(id);
            request.AddStringBody(bodyContent, DataFormat.Json);
            return restClient.Patch<Phone>(request); ;
        }

        private RestRequest getRestRquestId(string id) {
            return new RestRequest(basePath + "/{id}")
                            .AddUrlSegment("id", id);
        }
    }
}
