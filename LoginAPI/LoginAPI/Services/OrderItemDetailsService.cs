using LoginAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LoginAPI.Services
{
    public class OrderItemDetailsService
    {
        public OrderItemDetailsDTO Orderdetail(OrderItemDetailsDTO orderDtO)
        {
            OrderItemDetailsDTO ordersitemDTO = null;

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri("http://localhost:12834/api/");
                var postTask = client.PostAsJsonAsync<OrderItemDetailsDTO>("Order", orderDtO);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadFromJsonAsync<OrderItemDetailsDTO>();
                    data.Wait();
                    ordersitemDTO = data.Result;



                }

            }
            return ordersitemDTO;
        }


        public OrderItemDetailsDTO DetailsById(int id)
        {
            OrderItemDetailsDTO ordDTO = null;

            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:12834/api/");
                    var postTask = client.GetAsync("Order/" + id);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadFromJsonAsync<OrderItemDetailsDTO>();
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

        public ICollection<OrderItemDetailsDTO> GetAllOrderDetails()
        {
            List<OrderItemDetailsDTO> order = null;
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
                        var data = result.Content.ReadFromJsonAsync<List<OrderItemDetailsDTO>>();
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
