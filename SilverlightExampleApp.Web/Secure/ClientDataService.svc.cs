using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using SilverlightExampleApp.Web.Models;
using SilverlightExampleApp.Web.Repositories;

namespace SilverlightExampleApp.Web.Secure
{
    [ServiceContract(Namespace = "")]
    [SilverlightFaultBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ClientDataService
    {
        private IRepository<Client> _repo;

        public ClientDataService()
        {
            _repo = new ClientMockRepository();
        }

        [OperationContract]
        public Client Get(int id)
        {
            return _repo.Get(id);
        }

        [OperationContract]
        public IList<Client> GetAll()
        {
            return _repo.GetAll();
        }

        [OperationContract]
        public void Insert(Client item)
        {
            _repo.Insert(item);
        }

        [OperationContract]
        public void Update(Client item)
        {
            _repo.Update(item);
        }

        [OperationContract]
        public void Delete(Client item)
        {
            _repo.Delete(item);
        }
    }
}
