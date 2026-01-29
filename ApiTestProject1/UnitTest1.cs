using Newtonsoft.Json;
using RestSharp;
using System.Text.Json.Nodes;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ApiTestProject1
{
    public class FakeApiTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetBooksTest1()
        {
            var baseUrl = "https://fakerestapi.azurewebsites.net/api/v1/Books";
            var client = new RestClient(baseUrl);
            var request = new RestRequest(baseUrl, Method.Get);
            var response = client.Execute(request);
            var jsonData = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(jsonData);
        }
        [Test]
        //Get request using RestClientOptions Class
        public void GetBooksTest2()
        {

            var client = new RestClient(new RestClientOptions
            {
                BaseUrl = new Uri("https://fakerestapi.azurewebsites.net/api/v1/Books"),
                RemoteCertificateValidationCallback = (_, _, _, _) => true
            });
            var request = new RestRequest("https://fakerestapi.azurewebsites.net/api/v1/Books");
            var response = client.Get(request);
            var jsonData = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(jsonData);
        }

        [Test]
        //Post Request
        public void PostBooksTest3()
        {
            var baseUrl = "https://fakerestapi.azurewebsites.net/api/v1/Books";
            var client = new RestClient(baseUrl);

            var request = new RestRequest(baseUrl, Method.Post);
            request.AddJsonBody(new
            {
                Id = 100,
                Title = "Test Book",
                Description = "Mussum Ipsum, cacilds vidis litro abertis.  Quem num gosta di mim que vai caçá sua turmis!",
                Excerpt = "uem num gosta di mim que vai caçá sua turmis!",
                PageCount = 100,
                PublishDate = "2025-07-03T13:50:32.6884665+00:00"
            });
            var response = client.Execute(request);
            var jsonData = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(jsonData);

        }
        [Test]
        //Post Request #2
        public void PostBooksTest4()
        {
            var baseUrl = "https://fakerestapi.azurewebsites.net/api/v1/Books";
            var client = new RestClient(baseUrl);

            var request = new RestRequest(baseUrl, Method.Post);
            request.AddJsonBody(new
            {

                Title = "Test Book",
                Description = "Mussum Ipsum, cacilds vidis litro abertis.  Quem num gosta di mim que vai caçá sua turmis!",
                Excerpt = "uem num gosta di mim que vai caçá sua turmis!",
                PageCount = 700,
                PublishDate = "2025-07-03T13:50:32.6884665+00:00"
            });
            var response = client.Execute(request);
            var jsonData = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(jsonData);

        }
        [Test]
        //Put Request #1
        public void PutBooksTest5()
        {
            var baseUrl = "https://fakerestapi.azurewebsites.net/api/v1/Books/1";

            var client = new RestClient();

            var request = new RestRequest(baseUrl, Method.Put);
            request.AddJsonBody(new
            {
                Id = 1,
                Title = "Book Of Life",
                Description = "Mussum Ipsum, cacilds vidis litro abertis.  Quem num gosta di mim que vai caçá sua turmis!",
                Excerpt = "uem num gosta di mim que vai caçá sua turmis!",
                PageCount = 700,
                PublishDate = "2025-07-03T13:50:32.6884665+00:00"
            });
            var response = client.Execute(request);
            var jsonData = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(jsonData);

        }
        // TESTING A DIFFERENT URL - PRODUCTS
        [Test]
        public void ProductPutRequest()
        {
            // send PUT request with RestSharp
            var client = new RestClient("https://testapi.jasonwatmore.com");
            var request = new RestRequest("products/1");
            request.AddBody(new
            {
                name = "RestSharp PUT Request Example"
            });
            var response = client.ExecutePut(request);

            // deserialize json string response to JsonNode object
            //var data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;
            var data = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(data);

        }
        [Test]
        public void ProductGetRequestAllProducts()
        {
            // send Get request with RestSharp
            var client = new RestClient("https://testapi.jasonwatmore.com");
            var request = new RestRequest("products");
            var response = client.ExecuteGet(request);

            // deserialize json string response to JsonNode object
            //var data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;
            var data = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(data);

        }
        [Test]
        public void ProductGetRequestSingleProduct()
        {
            // send Get request with RestSharp
            var client = new RestClient("https://testapi.jasonwatmore.com");
            var request = new RestRequest("products/2");
            var response = client.ExecuteGet(request);

            // deserialize json string response to JsonNode object
            //var data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;
            var data = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(data);

        }
        [Test]
        public void ProductPostRequest_CreateNewProduct()
        {
            // send Post request with RestSharp
            var client = new RestClient("https://testapi.jasonwatmore.com");
            var request = new RestRequest("products");
            request.AddBody
                (new
                {
                    name = "Cnome 2000",
                    price = "9000"
                });
            var response = client.ExecutePost(request);

            // deserialize json string response to JsonNode object
            //var data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;
            var data = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(data);

        }
        [Test]
        public void ProductPutRequest_UpdateProduct()
        {
            // send Post request with RestSharp
            var client = new RestClient("https://testapi.jasonwatmore.com");
            var request = new RestRequest("products/569");
            request.AddBody
                (new
                {

                    name = "Cnome 2000",
                    price = 400
                });
            var response = client.ExecutePut(request);

            // deserialize json string response to JsonNode object
            //var data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;
            var data = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(data);

        }
        [Test]
        public void ProductPutRequest_UpdateProduct2()
        {
            // send Post request with RestSharp
            var client = new RestClient("https://testapi.jasonwatmore.com");
            var request = new RestRequest("products/1");
            request.AddBody
                (new
                {

                    name = "Cnome 2000",
                    price = 400
                });
            var response = client.ExecutePut(request);

            // deserialize json string response to JsonNode object
            //var data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;
            var data = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(data);

        }
        [Test]
        public void ProductDeleteRequest()
        {
            // send Post request with RestSharp
            var client = new RestClient("https://testapi.jasonwatmore.com");
            var request = new RestRequest("products/1");
            var response = client.ExecuteDelete(request);
            // deserialize json string response to JsonNode object
            //var data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;
            var data = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(data);
            // Console.WriteLine(response);

        }

        //NEW URL -ACTIVITIES

        [Test]
        public void ActivitiesGetRequest()
        {
            // send Get request with RestSharp
            var client = new RestClient("https://fakerestapi.azurewebsites.net/");
            var request = new RestRequest("api/v1/Activities");
            var response = client.ExecuteGet(request);
            // deserialize json string response to JsonNode object
            //var data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;
            var data = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(data);
            // Console.WriteLine(response);
        }
        [Test]
        public void ActivitiesGetRequest1()
        {
            // send Get request with RestSharp
            var client = new RestClient("https://fakerestapi.azurewebsites.net/");
            var request = new RestRequest("api/v1/Activities/7");
            var response = client.ExecuteGet(request);
            // deserialize json string response to JsonNode object
            //var data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;
            var data = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(data);
            // Console.WriteLine(response);
        }
    
    [Test]
        public void ActivitiesPostRequest1()
        {
            // send Get request with RestSharp
            var client = new RestClient("https://fakerestapi.azurewebsites.net/");
            var request = new RestRequest("api/v1/Activities");
            request.AddJsonBody(new
            {
                id= 31,
                title = "MyActivites",
                dueDate = "2025-07-28T17:58:56.709Z",
                completed = true
            });
            var response = client.ExecutePost(request);
            // deserialize json string response to JsonNode object
            //var data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;
            var data = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(data);
            // Console.WriteLine(response);
        }
        [Test]
        public void ActivitiesDeleteRequest1()
        {
            // send Get request with RestSharp
            var client = new RestClient("https://fakerestapi.azurewebsites.net/");
            var request = new RestRequest("api/v1/Activities/7");
            var response = client.ExecuteDelete(request);
            // deserialize json string response to JsonNode object
            //var data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!;
            var data = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(data);
            // Console.WriteLine(response);
        }
    }
}