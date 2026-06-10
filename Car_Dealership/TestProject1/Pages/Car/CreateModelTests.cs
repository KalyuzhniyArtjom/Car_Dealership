using Car_Dealership.Data;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairShop.Test.UnitTests.Pages.Car
{
    public class CreateModelTests
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public void OnPost_ShouldReturnPage_WhenModelStateIsInvalid()
        {
            // Arrange
            var context = GetDbContext();
            var pageModel = new Car_Dealership.Pages.Cars.CreateModel(context);

            pageModel.ModelState.AddModelError("Brand", "Required");

            // Act
            var result = pageModel.OnPost();

            // Assert
            result.Should().BeOfType<PageResult>();
            context.Cars.Count().Should().Be(0);
        }
    }
}