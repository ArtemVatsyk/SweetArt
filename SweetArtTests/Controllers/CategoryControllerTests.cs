using Microsoft.VisualStudio.TestTools.UnitTesting;
using SweetArt.Controllers;
using SweetArt.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Routing;

namespace SweetArt.Controllers.Tests
{
    [TestClass()]
    public class CategoryControllerTests
    {
        [TestMethod()]
        public async Task GetTestAsync()
        {
            var testCategory = GetTestsCategories();
            var controller = new CategoryController(testCategory);

            var result = await controller.Get();
            Assert.AreEqual(testCategory.Count, result);

        }


        [TestMethod()]
        public void PostTest()
        {
            // Arrange
            var testCategory = GetTestsCategories();
            var controller = new CategoryController(testCategory);


            controller.CakeContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary { { "controller", "categories" } });

            // Act
            Category category = new Category() { Id = Guid.Parse("0b65ff35-bb93-46cc-b566-62decfbf3dad"), Name = "Wedding cake" };
            var response = controller.Post(category);

            // Assert
            Assert.AreEqual("http://localhost/api/category", response.Headers.Location.AbsoluteUri);
        }

        [TestMethod()]
        public void PutTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        private List<Category> GetTestsCategories()
        {
            var testCategories = new List<Category>();
            testCategories.Add(new Category { Id = Guid.Parse("0b45ff35-bb93-46cc-b566-62decfbf3dad"), Name = "Wedding cake" });
            testCategories.Add(new Category { Id = Guid.Parse("0b45ff35-bb92-46cc-b566-12decfbf3dad"), Name = "Cake" });
            testCategories.Add(new Category { Id = Guid.Parse("9cf2487f-e25e-4c0d-86ae-a9a9b76f05e7"), Name = "Macaroon" });
            return testCategories;
        }
    }
}