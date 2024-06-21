using global::LaptopDiscount;
using NUnit.Framework;

namespace LaptopDiscount.nUnitTests
{
    [TestFixture]
    public class DiscountTest
    {
        [Test]
        public void CalculateDiscountedPrice_WhenPartTimeEmployee_ShouldReturnFullPrice()
        {
            // Test ensures part-time employees do not receive a discount.
            // Arrange
            var employeeDiscount = new EmployeeDiscount
            {
                EmployeeType = EmployeeType.PartTime,
                Price = 1200m  
            };

            // Act
            var result = employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.AreEqual(1200m, result);
        }

        [Test]
        public void CalculateDiscountedPrice_WhenPartialLoadEmployee_ShouldReturnPriceWith5PercentDiscount()
        {
            // Test verifies that partial load employees receive a 5% discount.
            // Arrange
            var employeeDiscount = new EmployeeDiscount
            {
                EmployeeType = EmployeeType.PartialLoad,
                Price = 2500m  
            };

            // Act
            var result = employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.AreEqual(2375m, result);  // Expected discounted price: 2500 * 0.95 = 2375
        }

        [Test]
        public void CalculateDiscountedPrice_WhenFullTimeEmployee_ShouldReturnPriceWith10PercentDiscount()
        {
            // Test ensures full-time employees receive a 10% discount.
            // Arrange
            var employeeDiscount = new EmployeeDiscount
            {
                EmployeeType = EmployeeType.FullTime,
                Price = 5000m  
            };

            // Act
            var result = employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.AreEqual(4500m, result);  // Expected discounted price: 5000 * 0.90 = 4500
        }

        [Test]
        public void CalculateDiscountedPrice_WhenCompanyPurchasing_ShouldReturnPriceWith20PercentDiscount()
        {
            // Test ensures company purchases receive a 20% discount.
            // Arrange
            var employeeDiscount = new EmployeeDiscount
            {
                EmployeeType = EmployeeType.CompanyPurchasing,
                Price = 3000m  
            };

            // Act
            var result = employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.AreEqual(2400m, result);  // Expected discounted price: 3000 * 0.80 = 2400
        }

        [Test]
        public void CalculateDiscountedPrice_WhenPriceIsZero_ShouldReturnZero()
        {
            // Test ensures that if the price is zero, the discounted price remains zero.
            // Arrange
            var employeeDiscount = new EmployeeDiscount
            {
                EmployeeType = EmployeeType.FullTime,
                Price = 0m  
            };

            // Act
            var result = employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.AreEqual(0m, result);
        }

        [Test]
        public void CalculateDiscountedPrice_WhenPriceIsNegative_ShouldReturnDiscountedNegativePrice()
        {
            // Test checks if negative prices are handled correctly and returns the expected discounted negative price.
            // Arrange
            var employeeDiscount = new EmployeeDiscount
            {
                EmployeeType = EmployeeType.FullTime,
                Price = -800m  
            };

            // Act
            var result = employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.AreEqual(-720m, result);  // Expected discounted price: -800 + (800 * 0.10) = -720
        }
    }
}
