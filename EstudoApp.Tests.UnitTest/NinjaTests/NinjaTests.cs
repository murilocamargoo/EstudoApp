using System;
using System.Linq;
using EstudoApp.Data.Repositories;
using EstudoApp.Domain.Entities;
using EstudoApp.Domain.Interfaces;
using EstudoApp.Infra.CrossCurtting.IoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EstudoApp.Tests.UnitTest.NinjaTests
{
    [TestClass]
    public class NinjaTests
    {
        [TestMethod]
        public void InserNinjaClan()
        {
            SimpleInjectorContainer.RegisterServices();

            INinjaClanRepository ninjaClanRepository = new NinjaClanRepository();

            NinjaClan ninjaClan = new NinjaClan
            {
                DateModified = DateTime.Now,
                DateCreated = DateTime.Now,
                ClanName = "Camargo's",
                FoundationDate = DateTime.Today
            };

            ninjaClanRepository.Add(ninjaClan);
            ninjaClanRepository.Save();

            Console.WriteLine(ninjaClan.Id);
        }

        [TestMethod]
        public void InsertNinja()
        {
            //inicializa a injeção de dependencia
            SimpleInjectorContainer.RegisterServices();

            INinjaRepository ninjaRepository = new NinjaRepository();
            INinjaClanRepository ninjaClanRepository = new NinjaClanRepository();

            var ninjaClan = ninjaClanRepository.FindBy(nc => nc.ClanName == "Camargo's").FirstOrDefault();

            if (ninjaClan != null)
            {
                Ninja ninja = new Ninja
                {
                    NinjaName = "Murilo",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    NinjaClanId = ninjaClan.Id
                };

                ninjaRepository.Add(ninja);
            }
            ninjaRepository.Save();
        }

        [TestMethod]
        public void InsertNinjaWithoutClan()
        {
            //inicializa a injeção de dependencia
            SimpleInjectorContainer.RegisterServices();

            INinjaRepository ninjaRepository = new NinjaRepository();

            Ninja ninja = new Ninja
            {
                NinjaName = "Bolacha",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            ninjaRepository.Add(ninja);
            ninjaRepository.Save();
        }
    }
}
