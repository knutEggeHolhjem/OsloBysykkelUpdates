using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OsloBysykkelUpdates
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            try
            {
                //Add header specified by the api. 
                client.DefaultRequestHeaders.Add("Client-Identifier", "KnutEggeHolhjem-OsloBysykkelUpdates");

                //Make a get request and wait for response, response should be a jason with status of stations. 
                string response = client.GetStringAsync("https://gbfs.urbansharing.com/oslobysykkel.no/station_information.json").Result;

                //Deserialize response message to class genereated from jason. 
                StationStatusJson StationStatus = JsonConvert.DeserializeObject<StationStatusJson>(response);

                //Write each station to console. Custom ToString contains station: id, num_bikes_available and num_docks_available
                StationStatus.data.stations.ForEach(station => Console.WriteLine(station.ToString()));

                Console.ReadLine();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
