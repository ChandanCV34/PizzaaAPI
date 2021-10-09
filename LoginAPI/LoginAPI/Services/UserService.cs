using LoginAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginAPI.Services
{
    public class UserService
    {
        private readonly PizzaContext _context;
        private readonly ITokenService _tokenService;

        public UserService(PizzaContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public UserDTO Register(UserDTO userDTO)
        {
            try
            {
                using var hmac = new HMACSHA512();
                var user = new User()
                {
                    UserId = userDTO.Emailid,

                    Name = userDTO.Name,
                    Address = userDTO.Address,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password)),
                    PasswordSalt = hmac.Key

                };

                _context.users.Add(user);
                _context.SaveChanges();
                userDTO.jwtToken = _tokenService.CreateToken(userDTO);
                userDTO.Password = "";
                return userDTO;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return null;
        }
        public UsersDTO Login(UsersDTO userDTO)
        {
            try
            {
                var myUser = _context.users.FirstOrDefault(u => u.UserId == userDTO.Emailid);
                if (myUser != null)
                {
                    using var hmac = new HMACSHA512(myUser.PasswordSalt);
                    var userPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));

                    for (int i = 0; i < userPassword.Length; i++)
                    {
                        if (userPassword[i] != myUser.PasswordHash[i])
                            return null;
                    }
                    userDTO.jwtToken = _tokenService.SecondToken(userDTO);
                    userDTO.Password = "";
                    return userDTO;
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return null;
        }

        public ICollection<User> GetAll()
        {
            IList<User> user = _context.users.ToList();
            if (user.Count > 0)

                return user;
            else
                return null;



        }
        public User Get(int id) 
        {
            User user = null;
             user = _context.users.FirstOrDefault(p => p.UserId == "id");
                return user;
            
        }

        public OrderDTO Orders (OrderDTO  orderDtO)
        {
            OrderDTO ordersDTO = null;
          
            using (var client = new HttpClient())
            {
                //var OrderDetailsDTO  = new OrderDetailsDTO()
                //{
                //    OrderId = orderDtO.OrderID,



                //};
                //_context.orderDetails.Add(OrderDetailsDTO);
                //_context.SaveChanges();

                client.BaseAddress = new Uri("http://localhost:12834/api/");
                var postTask = client.PostAsJsonAsync<OrderDTO>("Order", orderDtO);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadFromJsonAsync<OrderDTO>();
                    data.Wait();
                    ordersDTO = data.Result;



                }

            }
            return ordersDTO;
        }

        //public OrderDTO GetOrder(int id)
        //{
        //    OrderDTO ord = null;
        //    ord = _context.ordDetail.FirstOrDefault(e => e.OrderID == id);
        //    return ord;

        //}


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


        
      


      


    }
}
