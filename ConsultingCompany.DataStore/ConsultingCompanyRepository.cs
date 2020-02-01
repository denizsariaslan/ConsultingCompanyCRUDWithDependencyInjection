
namespace ConsultingCompany.DataStore
{
    using System.Collections.Generic;
    using System;
    using ConsultingCompany.Lib;

    public class ConsultingCompanyRepository : IConsultingCompanyRepository
    {
        public ConsultingCompanyRepository()
        {
          //  Initialize();
        }

        private static List<Resource> _resources = null;

        private static List<Client> _clients = null;

        public List<Resource> Resources
        {
            get
            {
                return _resources;
            }
        }


        public List<Client> Clients
        {
            get
            {
                return _clients;
            }
        }

        private void Initialize()
        {
            _resources = new List<Resource>()
                                  {
                                      new Resource() { Id=0, FirstName = "Christopher", LastName = "Smith", YearsofExperience=4, Type = ResourceType.Developer },
                                      new Resource() { Id=1,  FirstName = "Brianna", LastName = "Jones", YearsofExperience=1, Type = ResourceType.Developer },
                                      new Resource() { Id=2, FirstName = "John", LastName = "Bill", YearsofExperience=8, Type = ResourceType.Developer },
                                      new Resource() { Id=3, FirstName = "Linda", LastName = "Mayer", YearsofExperience=7, Type = ResourceType.Developer },
                                      new Resource() { Id=4, FirstName = "Jasona", LastName = "Gold", YearsofExperience=2,  Type = ResourceType.ProjectManager },
                                      new Resource() { Id=5, FirstName = "Jenny", LastName = "Mike", YearsofExperience=6,  Type = ResourceType.ProjectManager },
                                      new Resource() { Id=6, FirstName = "Boby", LastName = "Lawrence", YearsofExperience=7,  Type = ResourceType.Architect },
                                      new Resource() { Id=7, FirstName = "Susanna", LastName = "Kennedy", YearsofExperience=3, Type = ResourceType.QA },
                                      new Resource() { Id=8, FirstName = "Jerry", LastName = "Williams", YearsofExperience=9, Type = ResourceType.Architect },
                                      new Resource() { Id=9, FirstName = "Erica", LastName = "Hammill", YearsofExperience=10, Type = ResourceType.QA }
                                  };

            _clients = new List<Client>()
                                {
                                            new Client()
                                                {
                                                        Id = 0,
                                                            CompanyName = "SalesForce",
                                                            ContactFirstName = "Tom",
                                                            ContactLastName = "Greaner",

                                                },
                                            new Client()
                                                {
                                                Id = 1,
                                                    CompanyName = "Ebay",
                                                    ContactFirstName = "Adam",
                                                    ContactLastName = "Lary"
                                                },
                                            new Client()
                                                {
                                                Id = 2,
                                                    CompanyName = "Mercedes",
                                                    ContactFirstName = "Hans",
                                                    ContactLastName = "Mattheus"
                                                },
                                };
        }

        public List<Client> GetAllClients()
        {
            if(Clients != null)
                {
                
                return Clients;

            }
            else
            {
                Initialize();
                return Clients;

            }

        }

        public void InsertClient(Client clientTobeInsert)
        {
            int contClient = Clients.Count;
            clientTobeInsert.Id = contClient + 1;
            Clients.Add(clientTobeInsert);
          
        }

        public void UpdateClient(Client client)
        {
            Client clientUpdate = Clients.Find(x => x.Id == client.Id);
            clientUpdate.CompanyName = client.CompanyName;
            clientUpdate.ContactFirstName = client.ContactFirstName;
            clientUpdate.ContactLastName = client.ContactLastName;
            clientUpdate.City = client.City;
            clientUpdate.State = client.State;
            clientUpdate.Zip = client.Zip;
           
        }

        public void DeleteClient(int id)
        {
            Client clientDelete = Clients.Find(x => x.Id == id);
            Clients.Remove(clientDelete);
        }

        public List<Resource> SelectResource()
        {
            if (Resources != null)
            {

                return Resources;

            }
            else
            {
                Initialize();
                return Resources;

            }

        }

        public void InsertResource(Resource resource)
        {
            int countresourceList = Resources.Count;
            resource.Id = countresourceList + 1;
            Resources.Add(resource);
        }
        public void UpdateResource(Resource resource)
        {
            Resource resourceUpdate = Resources.Find(x => x.Id == resource.Id);
            resourceUpdate.FirstName = resource.FirstName;
            resourceUpdate.LastName = resource.LastName;
            resourceUpdate.YearsofExperience = resource.YearsofExperience;
            resourceUpdate.Type = resource.Type;
          


        }
        public void DeleteResource(int id)
        {
            Resource resourceDelete = Resources.Find(x => x.Id == id);
            Resources.Remove(resourceDelete);
        }

      
    }
}
