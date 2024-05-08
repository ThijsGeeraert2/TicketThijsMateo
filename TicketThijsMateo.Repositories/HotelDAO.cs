using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using TicketThijsMateo.Domains.Context;
using SerpApi;
using Newtonsoft.Json.Linq;
using TicketThijsMateo.Repositories.Interfaces;

namespace TicketThijsMateo.Repositories
{
    public class HotelDAO : IDAO<Hotel>
    {
        private const string ApiKey = "bc035837a8cbd877cdc91e7a74b5f68b649b5fe23196cd8dfa2aa98c6319798c";

        public HotelDAO()
        {

        }

        public Task AddAsync(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }



        public async Task<IEnumerable<Hotel>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Hotel>?> GetAllWedstrijdenBetweenClubs(int thuisploegId, int uitploegId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Hotel>> GetHotelsNearStadium(string stadiumName)
        {
            List<Hotel> hotels = new List<Hotel>();

            Hashtable parameters = new Hashtable();
            parameters.Add("q", "Hotel bij jan breydel stadion brugge");
            parameters.Add("hl", "en");
            parameters.Add("gl", "us");
            parameters.Add("google_domain", "google.com");

            try
            {
                GoogleSearch search = new GoogleSearch(parameters, ApiKey);
                JObject data = search.GetJson();
                JArray results = (JArray)data["organic_results"];

                int count = 0;

                foreach (JObject result in
                    results)
                {
                    var hotel = new Hotel
                    {
                        Name = result["title"].ToString(),
                        Address = result["link"].ToString(),
                        //Thumbnail = result["thumbnail"].ToString()


                    };

                    hotels.Add(hotel);

                    count++;
                    if (count >= 5)
                    {
                        break;
                    }
                }
            }
            catch (SerpApiSearchException ex)
            {
                Console.WriteLine("Exception:");
                Console.WriteLine(ex.ToString());
            }

            return hotels;
        }
    }
}

