using LoginAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LoginAPI.Services
{
    public class OrderService
    {

        public OrderDTO Orderdetail(OrderDTO order)
        {
            OrderDTO orders = null;

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri("http://localhost:12834/api/");
                var postTask = client.PostAsJsonAsync<OrderDTO>("Order", order);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadFromJsonAsync<OrderDTO>();
                    data.Wait();
                    orders = data.Result;



                }

            }
            return orders;
        }

        public OrderDTO Order(int id)
        {
            OrderDTO ordDTO = null;

            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:12834/api/");
                    var postTask = client.GetAsync("Order/"+ id);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<OrderDTO>();
                        data.Wait();
                        ordDTO = data.Result;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return ordDTO;
        }

        public ICollection<OrderDTO> GetAllOrders()
        {
            List<OrderDTO> order = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:12834/api/");
                    // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var getTask = client.GetAsync("Order");
                    getTask.Wait();
                    var result = getTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<List<OrderDTO>>();
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
