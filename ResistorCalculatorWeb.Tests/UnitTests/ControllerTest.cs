using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResistorCalculatorWeb;
using ResistorCalculatorWeb.Controllers;

namespace ResistorCalculatorWeb.Tests.Controllers
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void ViewUpdate()
        {
            // Arrange
            EntriesController controller = new EntriesController();

            // Act
            ViewResult result = controller.ViewDelete(null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddEdit()
        {
            // Arrange
            EntriesController controller = new EntriesController();

            // Act
            ViewResult result = controller.AddEdit(null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
