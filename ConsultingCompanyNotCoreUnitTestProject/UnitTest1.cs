using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ConsultingCompany.DataStore;
using ConsultingCompany.Lib;
using ConsultingCompanyMVC.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ConsultingCompanyNotCoreUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private IConsultingCompanyRepository _repository;
        private Mock<IConsultingCompanyRepository> _viewRepository;

        [TestInitialize]
        public void Initialize()
        {
            _repository = new ConsultingCompanyRepository();
            _repository.GetAllClients();
        }

        [TestMethod]
        public void Is_Index_Return_Expected_List()
        {
            var _repo = new Mock<IConsultingCompanyRepository>();

            _repo.Setup(p => p.GetAllClients()).Returns(GetAllCients());

            var controller = new ClientController(_repo.Object);

            var result = controller.Index();

            var viewresult = Xunit.Assert.IsType<ViewResult>(result);

            var model = Xunit.Assert.IsAssignableFrom<List<Client>>(viewresult.ViewData.Model);

            Xunit.Assert.Equal(3, model.Count);

        }

        private List<Client> GetAllCients()
        {
            return new List<Client>                     {
                                    new Client()
                                                {
                                                Id = 0,
                                                    CompanyName = "Microsoft",
                                                    ContactFirstName = "Bill",
                                                    ContactLastName = "Gates",

                                                },
                                            new Client()
                                                {
                                                Id = 1,
                                                    CompanyName = "Facebook",
                                                    ContactFirstName = "Mark",
                                                    ContactLastName = "Zuckerberg"
                                                },
                                            new Client()
                                                {
                                                Id = 2,
                                                    CompanyName = "Amazon",
                                                    ContactFirstName = "Jeff",
                                                    ContactLastName = "Bezos"
                                                },
                                };
        }


        [TestMethod]
        public void SuccessFullyAddClient()
        {
            Client newClient =
                new Client() { CompanyName = "Tesla", ContactLastName = "Musk", ContactFirstName = "Elon" };
            this._repository.InsertClient(newClient);
            Assert.IsTrue(_repository.Clients.Count == 4);

            foreach (var client in this._repository.Clients)
            {
                Console.WriteLine($"CompanyName: {client.CompanyName} Contact Name: {client.ContactFirstName} {client.ContactLastName}");
            }
        }


        [TestMethod]
        public void SuccessFullyAddResouce()
        {
            Resource newResource = new Resource() { FirstName = "Mike", LastName = "Stubbs", Type = ResourceType.QA };
            this._repository.InsertResource(newResource);
            Assert.IsTrue(_repository.Resources.Count == 11);

            foreach (var resource in this._repository.Resources)
            {
                Console.WriteLine($"Name: {resource.FirstName} {resource.LastName} Type: {resource.Type}");
            }
        }
        //[TestMethod]
        //public void Is_ClientContoller_Insert_New_Client()
        //{
        //    Client newClient =

        //          new Client()
        //          {
        //              Id = 0,
        //              CompanyName = "Microsoftcengiz",
        //              ContactFirstName = "Bill",
        //              ContactLastName = "Gates",

        //          };

        //    var liste = new List<Client>();
        //    var _repo = new Mock<IConsultingCompanyRepository>();

        //    _repo.Setup(p => p.InsertClient(It.Is<Client>(x => x.CompanyName == newClient.CompanyName && x.Id == newClient.Id && x.ContactFirstName == newClient.ContactFirstName
        //        ))).Callback((Client i)=> { liste.Add(i);  });


        //    var controller = new ClientController(_repo.Object);

        //    var result = controller.Create(newClient);

        //    var viewresult = Xunit.Assert.IsType<ViewResult>(result);

        //    var model = Xunit.Assert.IsAssignableFrom<Client>(viewresult.ViewData.Model);

        //    Xunit.Assert.Equal(newClient.ContactFirstName, model.ContactFirstName);

        //}

       
    }
}
