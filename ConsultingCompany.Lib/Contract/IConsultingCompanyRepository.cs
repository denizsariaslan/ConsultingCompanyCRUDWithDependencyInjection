using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultingCompany.Lib
{
    public interface IConsultingCompanyRepository
    {
        List<Resource> Resources { get; }

        List<Client> Clients { get;  }

        List<Client> GetAllClients();
       
        void InsertClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(int id);

        List<Resource> SelectResource();

        void InsertResource(Resource resource);

        void UpdateResource(Resource resource);

        void DeleteResource(int id);

        //List<Client> AssignedClients(Resource resource);


    }
}
