using ITEAProject.Controllers;
using ITEAProject.Models;
using ITEAProject.Models.ModelRepositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ITEAProjectTests
{
    public class BranchIndexTest
    {
        [Fact]
        public void BranchIndexModelCount()
        {
            //Arrange
            var BranchesMock = new Mock<IBranchRepository>();
            BranchesMock.Setup(mock => mock.AllBranches())
                .Returns(GetTestBranches());
            var controller = new BranchController(BranchesMock.Object);

            //Act
            var result = controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Branch>>(
                         viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void AddNewBranch_ReturnsIndex_WhenModelState_IsValid()
        {
            var BranchesMock = new Mock<IBranchRepository>();
            BranchesMock.Setup(mock => mock.NewBranch(It.IsAny<Branch>()))
                .Verifiable();
            var controller = new BranchController(BranchesMock.Object);
            
            var newBranch = GetTestBranches().First();
            var result = controller.Create(newBranch);
            
            var redirectToActionResult = Assert.IsType<RedirectResult>(result);

              Assert.Equal("~/Branch/Index", redirectToActionResult.Url);
             BranchesMock.Verify();
        }

        [Fact]
        public void GoBack_When_ModelIsInvalid()
        {
            var BranchesMock = new Mock<IBranchRepository>();
            BranchesMock.Setup(mock => mock.NewBranch(It.IsAny<Branch>()))
                .Verifiable();
            var controller = new BranchController(BranchesMock.Object);

            var newBranch = GetTestBranches().First();
            controller.ModelState.AddModelError("Address", "aa");
            var result = controller.Create(newBranch);

            var redirectToActionResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Create", redirectToActionResult.ViewName);
        }

        private List<Branch> GetTestBranches()
        {
            return new List<Branch>()
            {
                 new Branch()
                {
                     Address="ww",
                    Phone="+380662959547"
                },

                new Branch()
                {
                    Id=2,
                    Address="TestAddress1",
                    Phone="+380662959547"
                },
                new Branch()
                {
                    Id=3,
                    Address="TestAddress2",
                    Phone="+380662959500"
                }
            };
        }


    }
}