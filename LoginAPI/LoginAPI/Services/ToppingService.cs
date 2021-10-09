using LoginAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LoginAPI.Services
{
    public class ToppingService
    {
        public ToppingDTO ToppingDetail(ToppingDTO toppingDtO)
        {
            ToppingDTO topDTO = null;

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri("http://localhost:15458/api/");
                var postTask = client.PostAsJsonAsync<ToppingDTO>("Toppings", toppingDtO);

                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadFromJsonAsync<ToppingDTO>();
                    data.Wait();
                    topDTO = data.Result;



                }

            }
            return topDTO;
        }

        public ToppingDTO ToppingDetail(int id)
        {
            ToppingDTO topDTO = null;

            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:15458/api/");
                    var postTask = client.GetAsync("Toppings/" + id);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<ToppingDTO>();
                        data.Wait();
                        topDTO = data.Result;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return topDTO;
        }
        public ICollection<ToppingDTO> AllToppings()
        {
            List<ToppingDTO> tops = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:15458/api/");
                    // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var getTask = client.GetAsync("Toppings");
                    getTask.Wait();
                    var result = getTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<List<ToppingDTO>>();
                        data.Wait();
                        tops = data.Result;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return tops;
        }
    }
}
