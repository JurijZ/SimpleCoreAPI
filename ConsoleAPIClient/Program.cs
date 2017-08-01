using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace ConsoleAPIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\nPress Enter to retrieve all records OR enter a specific ID number: ");

            string inputString = String.Empty;
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey();
                inputString += keyInfo.KeyChar;
            }
            while (keyInfo.Key != ConsoleKey.Enter);
            Console.Write("\n");

            Console.Write("\nEntered value is: {0}", inputString);
            Console.Write("\n");

            //Console.WriteLine("----------");
            //var repo2 = ProcessRepositories(inputString).Result;
            //Console.WriteLine(repo2.Name);
            //Console.WriteLine("----------");


            if (inputString.Length > 1)
            {
                Console.Write("\nFetching specific ID");
                Console.Write("\n");

                var repo = ProcessRepositories(inputString).Result;
                
                Console.WriteLine(repo.ID);
                Console.WriteLine(repo.Name);
                Console.WriteLine(repo.OriginPostCode);
                Console.WriteLine(repo.Rating);
                Console.WriteLine();
                
            }
            else
            {
                Console.Write("\nFetching All IDs");
                Console.Write("\n");

                var repositories = ProcessRepositories().Result;

                foreach (var repo in repositories)
                {
                    Console.WriteLine(repo.ID);
                    Console.WriteLine(repo.Name);
                    Console.WriteLine(repo.OriginPostCode);
                    Console.WriteLine(repo.Rating);
                    Console.WriteLine();
                }
            }
        //}

        //Console.ReadLine();
        }

        // For all IDs
        private static async Task<List<DTO>> ProcessRepositories()
        {
            var client = new HttpClient();
            var serializer = new DataContractJsonSerializer(typeof(List<DTO>));
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            string apicall = "http://localhost:5000/api/Products/";
            Console.WriteLine(apicall);

            //var stringTask = client.GetStringAsync("http://localhost:5000/api/Products");
            var streamTask = client.GetStreamAsync("http://localhost:5000/api/Products");
            var repositories = serializer.ReadObject(await streamTask) as List<DTO>;

            return repositories;
        }

        // For a single ID
        private static async Task<DTO> ProcessRepositories(string ID)
        {
            var client = new HttpClient();
            var serializer = new DataContractJsonSerializer(typeof(DTO));

            string apicall = "http://localhost:5000/api/Products/" + ID;
            Console.WriteLine(apicall);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            
            var streamTask = client.GetStreamAsync(apicall);
            var repositories = serializer.ReadObject(await streamTask) as DTO;
            
            return repositories;
        }
    }
}
