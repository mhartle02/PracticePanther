
using Newtonsoft.Json;
using PracticePanther.Library.Models;
using PracticePanther.Library.Utilities;
using System.Text.Json.Nodes;

namespace PracticePanther.Library.Services
{
    public class ClientService
    {
        private List<Client> clients;
        public List<Client> Clients
        {
            get
            {
                return clients ?? new List<Client>();
            }
        }

        private static ClientService? instance;

        public static ClientService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClientService();
                }
                return instance;
            }
        }
        private ClientService()
        {
            var response = new WebRequestHandler()
              .Get("/Client")
              .Result;
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
              clients = JsonConvert
                .DeserializeObject<List<Client>>(response, settings) 
                ?? new List<Client>();
            
        }

        public void Add(Client c)
        {
            if (c.Id == 0)
            {
                //add
                c.Id = LastId + 1;
            }

            Clients.Add(c);
        }

        public void Delete(int id)
        {
            var clientToDelete = Clients.FirstOrDefault(c => c.Id == id);
            if (clientToDelete != null)
            {
                Clients.Remove(clientToDelete);
            }
        }

        public void AddOrUpdate(Client c)
        {
       
              var response 
                =  new WebRequestHandler().Post("/Client", c).Result;
            

        }

        public Client? Get(int id)
        {
            /*var response = new WebRequestHandler()
                .Get($"/Client/GetClients/{id}")
                .Result;
            var client = JsonConvert.DeserializeObject<Client>(response);*/
            return Clients.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Client> Search(string query)
        {
            return Clients
                .Where(c => c.Name.ToUpper()
                    .Contains(query.ToUpper()));
        }

        private int LastId
        {
            get
            {
                return Clients.Any() ? Clients.Select(c => c.Id).Max() : 0;
            }
        }
    }
}











