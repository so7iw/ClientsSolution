using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClientsSolution.Models;

namespace ClientsSolution.Controllers
{
    public class ClientsController : ApiController
    {
        public IEnumerable<Client> Get()
        {
            using(ClientsEntities entities = new ClientsEntities())
            {
                return entities.Clients.ToList();
            }
        }
        public Client Get(int id)
        {
            using (ClientsEntities entities = new ClientsEntities())
            {
                return entities.Clients.FirstOrDefault(c => c.Contract_no == id);
            }
        }
        public string Post (Client client)
        {
            using (ClientsEntities entities = new ClientsEntities())
            {
                entities.Clients.Add(client);
                entities.SaveChanges();
                return "Client added";
            }
        }

        public string Put (int id, Client client)
        {
            using (ClientsEntities entities = new ClientsEntities())
            {
                var clientNew = entities.Clients.FirstOrDefault(c => c.Contract_no == id);
                clientNew.First_name = client.First_name;
                clientNew.Last_name = client.Last_name;
                clientNew.Duration = client.Duration;

                entities.Entry(clientNew).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();

                return "Client updated.";
            }
        }
        public string Delete (int id)
        {
            using (ClientsEntities entities = new ClientsEntities())
            {
                Client client = entities.Clients.FirstOrDefault(c => c.Contract_no == id);
                entities.Clients.Remove(client);
                entities.SaveChanges();

                return "Client deleted.";
            }
        }
    }
}
