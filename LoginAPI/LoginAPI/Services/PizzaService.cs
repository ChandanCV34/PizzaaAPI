using LoginAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LoginAPI.Services
{
    public class PizzaService
    {

        public PizzaDTO PizzaDetail(PizzaDTO pizzaDtO)
        {
            PizzaDTO pizzDTO = null;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:55643/api/");
                var postTask = client.PostAsJsonAsync<PizzaDTO>("Pizza", pizzaDtO);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadFromJsonAsync<PizzaDTO>();
                    data.Wait();
                    pizzDTO = data.Result;
                }

            }
            return pizzDTO;
        }

        public PizzaDTO PizzaDetail(int id)
        {
            PizzaDTO pizzDTO = null;

            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:55643/api/");
                    var postTask = client.GetAsync("Pizza/" + id);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<PizzaDTO>();
                        data.Wait();
                        pizzDTO = data.Result;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return pizzDTO;
        }
        public ICollection<PizzaDTO> AllPizzas()
        {
            List<PizzaDTO> pizzas = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:55643/api/");
                    // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var getTask = client.GetAsync("Pizza");
                    getTask.Wait();
                    var result = getTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<List<PizzaDTO>>();
                        data.Wait();
                        pizzas = data.Result;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return pizzas;
        }
    }
}
