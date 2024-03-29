﻿using PracticePanther.API.Database;
using PracticePanther.Library.DTO;
using PracticePanther.Library.Models;

namespace PracticePanther.API.EC
{
    public class ClientEC
    {
        public ClientDTO AddOrUpdate(ClientDTO dto)
        {
            //if (dto.Id > 0)
            //{
            //    var clientToUpdate
            //        = Filebase.Current.Clients
            //        .FirstOrDefault(c => c.Id == dto.Id);
            //    if(clientToUpdate != null) {
            //        Filebase.Current.Clients.Remove(clientToUpdate);
            //    }
            //    Filebase.Current.Clients.Add(new Client(dto));
            //}
            //else
            //{
            //    Filebase.Current.Clients.Add(new Client(dto));
            //}

            //Filebase.Current.AddOrUpdate(new Client(dto));

            //if(dto.Id <= 0 )
            //{
                var result = MsSqlContext.Current.Insert(new Client(dto));
                return new ClientDTO(result);
            //}

            return dto;
        }

        public ClientDTO? Get(int id)
        {
            var returnVal = FakeDatabase.Clients
                 .FirstOrDefault(c => c.Id == id)
                 ?? new Client();

            return new ClientDTO(returnVal);
        }

        public bool Delete(int id)
        {
            var result = MsSqlContext.Current.Delete(id);
            return result;
        }

        public IEnumerable<ClientDTO> Search(string query = "")
        {
            return MsSqlContext.Current.Get()
                .Where(c => c.Name.ToUpper()
                    .Contains(query.ToUpper()))
                .Take(1000)
                .Select(c => new ClientDTO(c));
        }
    }
}