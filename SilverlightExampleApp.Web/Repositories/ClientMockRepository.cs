using System;
using System.Collections.Generic;
using SilverlightExampleApp.Web.Factories;
using SilverlightExampleApp.Web.Models;

namespace SilverlightExampleApp.Web.Repositories
{
    public class ClientMockRepository : IRepository<Client>
    {
        public List<Client> Clients { get; set; }

        public ClientMockRepository()
        {
            Clients = ClientFactory.GetAll();
        }

        #region IRepository<Client> Members

        public Client Get(int id)
        {
            return Clients.Find(c => id == c.Id);
        }

        public IList<Client> GetAll()
        {
            return Clients;
        }

        public void Insert(Client item)
        {
            Clients.Add(item);
        }

        public void Update(Client item)
        {
            Client client = Clients.Find(c => item.Id == c.Id);
            client.FirstName = item.FirstName;
            client.FamilyName = item.FamilyName;
            client.Title = item.Title;
            client.Residence = item.Residence;
        }

        public void Delete(Client item)
        {
            Client client = Clients.Find(c => item.Id == c.Id);
            Clients.Remove(client);
        }

        #endregion
    }
}