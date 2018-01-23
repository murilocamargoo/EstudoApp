using System;
using System.Linq;
using AutoMapper;
using EstudoApp.Data.Repositories;
using EstudoApp.Domain.Entities;
using EstudoApp.Domain.Interfaces;
using EstudoApp.Infra.CrossCurtting.IoC;
using EsudoApp.Application.AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EsudoApp.Application.ViewModel;

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

            if (!ninjaClanRepository.FindBy(clan => clan.ClanName == ninjaClan.ClanName).Any())
            {
                ninjaClanRepository.Add(ninjaClan);
                ninjaClanRepository.Save();
            }

            Console.WriteLine(ninjaClan.Id);
        }

        [TestMethod]
        public void InsertNinja()
        {
            //inicializa a injeção de dependencia
            //SimpleInjectorContainer.RegisterServices();

            INinjaRepository ninjaRepository = new NinjaRepository();
            INinjaClanRepository ninjaClanRepository = new NinjaClanRepository();

            var ninjaClan = ninjaClanRepository.FindBy(nc => nc.ClanName == "Camargo's").FirstOrDefault();

            if (ninjaClan != null)
            {
                Ninja ninja = new Ninja
                {
                    NinjaName = "Bruna",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    NinjaClanId = ninjaClan.Id
                };

                if (!ninjaRepository.FindBy(n => n.NinjaName == ninja.NinjaName).Any())
                {
                    ninjaRepository.Add(ninja);
                    ninjaRepository.Save();
                }
            }
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

            if (!ninjaRepository.FindBy(n => n.NinjaName == ninja.NinjaName).Any())
            {
                ninjaRepository.Add(ninja);
                ninjaRepository.Save();
            }
        }

        [TestMethod]
        public void GetNinjaById()
        {
            INinjaRepository ninjaRepository = new NinjaRepository();

            var ninja = ninjaRepository.GetById(1);

            Assert.IsNotNull(ninja);
            Assert.AreEqual(ninja.Id, 1);
        }

        [TestMethod]
        public void GetNinjasBy()
        {
            INinjaRepository ninjaRepository = new NinjaRepository();

            var ninjas = ninjaRepository.FindBy(ninja => ninja.NinjaClan.ClanName == "Camargo's");

            Assert.IsNotNull(ninjas);

            Assert.AreEqual(ninjas.Count(), 2);

            foreach (var ninja in ninjas)
            {
                Console.WriteLine(ninja.NinjaName);
            }
        }

        [TestMethod]
        public void UpdateNinjaAndClan()
        {
            var ninjaRepository = new NinjaRepository();
            var ninjaClanRepository = new NinjaClanRepository();

            var ninja = ninjaRepository.GetById(1);
            var ninjaClan = ninjaClanRepository.GetById(ninja.NinjaClanId);

            ninja.NinjaName = "Murilo Cesar";
            ninjaRepository.Update(ninja);
            ninjaRepository.Save();

            ninjaClan.ClanName = "Gafanhotos";

            ninjaClanRepository.Update(ninjaClan);
            ninjaClanRepository.Save();
        }

        [TestMethod]
        public void DeleteNinja()
        {
            var ninjaRepository = new NinjaRepository();

            //ninjaRepository.Remove(ninja);
            //ninjaRepository.Save();
        }

        [TestMethod]
        public void TestAutoMapperNinja()
        {
            AutoMapperConfig.RegisterMappings();
            NinjaViewModel ninjaViewModel = new NinjaViewModel();

            ninjaViewModel.NinjaName = "Chimbinha";

            Ninja ninja = Mapper.Map<NinjaViewModel, Ninja>(ninjaViewModel);

            Assert.IsNotNull(ninja);
        }
    }
}
