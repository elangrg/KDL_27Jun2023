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

            string URLOrder = @"http://localhost:5244/api/Order";

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

            string URLProduct = @"http://localhost:5287/api/Product";

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