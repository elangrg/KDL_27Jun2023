using Newtonsoft.Json;
using System.Reflection;

namespace conMicroserviceBasedUIApp
{
    internal class Program
    {
        static void Main(string[] args)
        {


            GetOrders();
            GetProducts();

            Console.WriteLine("Press any key to Exit...");
            Console.ReadKey();
        }



        static void GetOrders()
        {
            // Direct
            // string URLOrder = @"http://localhost:5244/api/Order";

            //Using API Gateway
            string URLOrder = @"http://localhost:5245/gateway/order";

            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(URLOrder))
                {
                    response.Wait();

                    var result = response.Result;


                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();

                        var orderJsonString = readTask.Result;

                        var ords = JsonConvert.DeserializeObject<string[]>(orderJsonString)?.ToList();

                        foreach (var item in ords)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
            }


        }



        static void GetProducts()
        {
            // Direct
            // string URLProduct = @"http://localhost:5287/api/Product";
            //Using API Gateway
            string URLProduct = @"http://localhost:5245/gateway/Product";

            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(URLProduct))
                {
                    response.Wait();

                    var result = response.Result;


                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();

                        var productJsonString = readTask.Result;

                        var prds = JsonConvert.DeserializeObject<string[]>(productJsonString)?.ToList();

                        foreach (var item in prds)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
            }


        }


    }
}