using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gallio.Framework;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using IdeaSeed.Core.Utils;
using IdeaSeed.Core.Data.NHibernate;
using NHibernate.Criterion;
using ISeCommerce.Core.Domain;
using ISeCommerce.Persistence.Repositories;

namespace ISeCommerce.PersistenceTests
{
    [TestFixture]
    public class PageTests
    {
        private PageRepository _pageRepository;
        private ProductCategoryRepository _productCategoryRepository;
        private BannerImageRepository _bannerRepository;

        [SetUp]
        public void TestFixtureSetup()
        {
            _bannerRepository = new BannerImageRepository();
            _pageRepository = new PageRepository();
            _productCategoryRepository = new ProductCategoryRepository();
        }

        [Test]
        public void CanGetByURLRoute()
        {
            string ROUTE = "Home";
            var p = _pageRepository.GetByURLRoute(1, ROUTE);
            Assert.AreEqual(1, p.ID);

        }

        [Test]
        public void CanGetProductCategoryRoots()
        {
            var list = _productCategoryRepository.GetRootCategories();
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual("Networking", list[0].Name);

        }

        [Test]
        public void CanGetProductCategoryByID()
        {
            int id = 3;
            var pc = _productCategoryRepository.GetByID(id, false);
            Assert.AreEqual(4, pc.ChildCategories.Count);
        }

        [Test]
        public void CanGetRecursivelyByCatID()
        {
            var id = 3;
            var list = _productCategoryRepository.RecursivelyGetByCategoryID(id);
            Assert.AreEqual(7, list.Count);
            Assert.AreEqual("Networking", list[0].Name);

        }

        [Test]
        public void CanGetBanners()
        {
            var list = _bannerRepository.GetAll();
            Assert.AreEqual(4, list.Count);
        }
    }
}
