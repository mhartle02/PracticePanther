using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticePanther.CLI.Models;

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
            CurrentClients = new List<Client>();
        }

        public Client? Get(int id)
        {
            return CurrentClients.FirstOrDefault(c => c.Id == id);
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
    }
}

