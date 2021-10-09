using LoginAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LoginAPI.Services
{
    public class OrderDetailsService
    {

        public OrderDetailsDTO Orderdetail(OrderDetailsDTO orderdetDtO)
        {
            OrderDetailsDTO ordersDTO = null;

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri("http://localhost:24368/api/");
                var postTask = client.PostAsJsonAsync<OrderDetailsDTO>("OrderDetails", orderdetDtO);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadFromJsonAsync<OrderDetailsDTO>();
                    data.Wait();
                    ordersDTO = data.Result;



                }

            }
            return ordersDTO;
        }

        public OrderDetailsDTO DetailsById(int id)
        {
            OrderDetailsDTO ordDTO = null;

            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:24368/api/");
                    var postTask = client.GetAsync("OrderDetails/" + id);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<OrderDetailsDTO>();
                        data.Wait();
                        ordDTO  = data.Result;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return ordDTO;
        }

        public ICollection<OrderDetailsDTO> GetAllOrderDetails()
        {
            List<OrderDetailsDTO> order = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:24368/api/");
                    // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var getTask = client.GetAsync("OrderDetails");
                    getTask.Wait();
                    var result = getTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<List<OrderDetailsDTO>>();
                        data.Wait();
                        order = data.Result;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return order;
        }

    }
}
