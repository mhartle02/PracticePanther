using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticePanther.Library.Models;

namespace PracticePanther.Library.Services
{
    public class ClientService
    {
        private static object _lock = new object();
        private static ClientService? instance;
        public static ClientService Current 
        {
            get
            {
                lock(_lock)
                {
                    if (instance == null)
                    {
                        instance = new ClientService();
                    }
                }
                return instance;
            }

        }

        private List<Client> CurrentClients;
        private ClientService()
        {
            CurrentClients = new List<Client>
            {
                new Client {Id = 1, Name = "Mason Hartle"},
                new Client {Id = 2, Name = "John Doe"}
            };
        }

        public List<Client> Search (string query)
        {

            
            return CurrentClients.Where(c => c.Name.ToUpper().Contains(query.ToUpper())).ToList();
        }

        public Client? Get(int id)
        {
            return CurrentClients.FirstOrDefault(c => c.Id == id);
        }

        public List<Client> currentclients
        {
            get { return CurrentClients; }
        }
        public void Add(Client? client)
        {
            if (client != null)
            {
                CurrentClients.Add(client);
            }
        }

        public void Read()
        {
            CurrentClients.ForEach(Console.WriteLine);
        }

        public void Delete(int id)
        {
            var ClientToRemove = Get(id);
            if (ClientToRemove != null)
            {
                CurrentClients.Remove(ClientToRemove);
            }
        }
        public void Delete(Client c)
        {
            Delete(c.Id);
        }


    }
}

