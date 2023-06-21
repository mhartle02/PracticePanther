
using PracticePanther.Library.Models;

namespace PracticePanther.Library.Services
{
    public class ClientService
    {
        public List<Client> Clients
        {
            get
            {
                return clients;
            }
        }

        private List<Client> clients;

        private static ClientService? instance;

        public static ClientService Current
        {
            get
            {
                if (instance == null)
                {
                    instance =  new ClientService();
                }
                    
                    return instance;
            }
        }
        private ClientService()
        {
            clients = new List<Client>
            {

            };
        }

        public void Delete(int id)
        {
            var clientToDelete = Clients.FirstOrDefault(c => c.Id == id);
            if (clientToDelete != null)
            {
                Clients.Remove(clientToDelete);
            }
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

        private int LastId
        {
            get
            {
                return Clients.Any() ? Clients.Select(c => c.Id).Max() : 0;
            }
        }

        public List<Client> Search(string query)
        {


            return Clients.Where(c => c.Name.ToUpper().Contains(query.ToUpper())).ToList();
        }
    }
}











        //private static object _lock = new object();
        //private static ClientService? instance;
        //public static ClientService Current 
        //{
        //    get
        //    {
        //        lock(_lock)
        //        {
        //            if (instance == null)
        //            {
        //                instance = new ClientService();
        //            }
        //        }
        //        return instance;
        //    }

        //}

        //private List<Client> CurrentClients;
        //private ClientService()
        //{
        //    CurrentClients = new List<Client>
        //    {
        //        new Client {Id = 1, Name = "Mason Hartle"},
        //        new Client {Id = 2, Name = "John Doe"}
        //    };
        //}

        //public List<Client> Search (string query)
        //{


        //    return CurrentClients.Where(c => c.Name.ToUpper().Contains(query.ToUpper())).ToList();
        //}

        //public Client? Get(int id)
        //{
        //    return CurrentClients.FirstOrDefault(c => c.Id == id);
        //}

        //public List<Client> currentclients
        //{
        //    get { return CurrentClients; }
        //}
        //public void Add(Client? client)
        //{
        //    if (client != null)
        //    {
        //        CurrentClients.Add(client);
        //    }
        //}

        //public void Read()
        //{
        //    CurrentClients.ForEach(Console.WriteLine);
        //}

        //public void Delete(int id)
        //{
        //    var ClientToRemove = Get(id);
        //    if (ClientToRemove != null)
        //    {
        //        Clients.Remove(ClientToRemove);
        //    }
        //}
        //public void Delete(Client c)
        //{
        //    Delete(c.Id);
        //}


