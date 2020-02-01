using ConsultingCompany.DataStore;
using ConsultingCompany.Lib;
using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace ConsultingCompanyMVC
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
             var container = new UnityContainer();


            container.RegisterType<IConsultingCompanyRepository, ConsultingCompanyRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
             
        }

        
        
    }
}