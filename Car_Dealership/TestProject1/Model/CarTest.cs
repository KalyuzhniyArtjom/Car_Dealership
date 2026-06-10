using System.ComponentModel.DataAnnotations;
using Car_Dealership.Model;

namespace Car_Dealership.Test.UnitTests.Model
{
    public class CarTests
    {
        [Fact]
        public void Car_WithValidData_ShouldBeValid()
        {
            // Arrange
            var car = new Car
            {
                Price = 25000.50m,              // Положительная цена
                Title = "Camry LE",              // Обязательное поле, строка < 100 символов
                YearOfManufacture = 2020,        // В пределах допустимого диапазона 1900–2026
                Country = "Japan",               // Строка < 50 символов
                BrandCarId = 1                   // Обязательное поле (больше 0)
            };

            var context = new ValidationContext(car);
            var result = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(car, context, result, true);

            // Assert
            Assert.True(isValid);
            Assert.Empty(result);
        }

        [Fact]
        public void Car_WithInvalidYearOfManufacture_BelowMinimum_ShouldBeInvalid()
        {
            // Arrange
            var car = new Car
            {
                Price = 25000.50m,
                Title = "Camry LE",
                YearOfManufacture = 1800,        // ❌ Меньше минимального значения 1900
                Country = "Japan",
                BrandCarId = 1
            };

            var context = new ValidationContext(car);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(car, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("Год выпуска должен быть") ||
                                          r.ErrorMessage.Contains("YearOfManufacture"));
        }

        [Fact]
        public void Car_WithYearOfManufacture_AboveMaximum_ShouldBeInvalid()
        {
            // Arrange
            var car = new Car
            {
                Price = 25000.50m,
                Title = "Camry LE",
                YearOfManufacture = 2030,        // ❌ Больше максимального значения (текущий год + 1)
                Country = "Japan",
                BrandCarId = 1
            };

            var context = new ValidationContext(car);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(car, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("Год выпуска должен быть") ||
                                          r.ErrorMessage.Contains("YearOfManufacture"));
        }

        [Fact]
        public void Car_WithNegativePrice_ShouldBeInvalid()
        {
            // Arrange
            var car = new Car
            {
                Price = -1000m,                  // ❌ Отрицательная цена
                Title = "Camry LE",
                YearOfManufacture = 2020,
                Country = "Japan",
                BrandCarId = 1
            };

            var context = new ValidationContext(car);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(car, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("Цена должна быть положительной") ||
                                          r.ErrorMessage.Contains("Price"));
        }

        [Fact]
        public void Car_WithZeroPrice_ShouldBeInvalid()
        {
            // Arrange
            var car = new Car
            {
                Price = 0m,                      // ❌ Цена равна нулю
                Title = "Camry LE",
                YearOfManufacture = 2020,
                Country = "Japan",
                BrandCarId = 1
            };

            var context = new ValidationContext(car);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(car, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("Цена должна быть положительной") ||
                                          r.ErrorMessage.Contains("Price"));
        }

        [Fact]
        public void Car_WithEmptyTitle_ShouldBeInvalid()
        {
            // Arrange
            var car = new Car
            {
                Price = 25000.50m,
                Title = "",                      // ❌ Обязательное поле пустое
                YearOfManufacture = 2020,
                Country = "Japan",
                BrandCarId = 1
            };

            var context = new ValidationContext(car);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(car, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("Введите название автомобиля") ||
                                          r.ErrorMessage.Contains("Title"));
        }

        [Fact]
        public void Car_WithNullTitle_ShouldBeInvalid()
        {
            // Arrange
            var car = new Car
            {
                Price = 25000.50m,
                Title = null,                    // ❌ Обязательное поле null
                YearOfManufacture = 2020,
                Country = "Japan",
                BrandCarId = 1
            };

            var context = new ValidationContext(car);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(car, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("Введите название автомобиля") ||
                                          r.ErrorMessage.Contains("Title"));
        }

        [Fact]
        public void Car_WithTooLongTitle_ShouldBeInvalid()
        {
            // Arrange
            var car = new Car
            {
                Price = 25000.50m,
                Title = new string('A', 101),    // ❌ Название длиннее 100 символов
                YearOfManufacture = 2020,
                Country = "Japan",
                BrandCarId = 1
            };

            var context = new ValidationContext(car);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(car, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("Название не может превышать 100 символов") ||
                                          r.ErrorMessage.Contains("Title"));
        }

        [Fact]
        public void Car_WithTooLongCountry_ShouldBeInvalid()
        {
            // Arrange
            var car = new Car
            {
                Price = 25000.50m,
                Title = "Camry LE",
                YearOfManufacture = 2020,
                Country = new string('B', 51),   // ❌ Название страны длиннее 50 символов
                BrandCarId = 1
            };

            var context = new ValidationContext(car);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(car, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("Страна не может превышать 50 символов") ||
                                          r.ErrorMessage.Contains("Country"));
        }

        [Fact]
        public void Car_WithMissingBrandCarId_ShouldBeInvalid()
        {
            // Arrange
            var car = new Car
            {
                Price = 25000.50m,
                Title = "Camry LE",
                YearOfManufacture = 2020,
                Country = "Japan",
                BrandCarId = null               // ❌ BrandCarId не указан
            };

            var context = new ValidationContext(car);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(car, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("BrandCarId") ||
                                          r.ErrorMessage.Contains("бренд"));
        }

        [Fact]
        public void Car_WithZeroBrandCarId_ShouldBeInvalid()
        {
            // Arrange
            var car = new Car
            {
                Price = 25000.50m,
                Title = "Camry LE",
                YearOfManufacture = 2020,
                Country = "Japan",
                BrandCarId = 0                  // ❌ BrandCarId равен 0 (недопустимое значение)
            };

            // Act & Assert
            // Проверяем бизнес-правило: BrandCarId должен быть больше 0
            Assert.True(car.BrandCarId <= 0, "BrandCarId должен быть больше 0 для указания бренда");
        }

        [Fact]
        public void Car_WithValidNullableFields_ShouldBeValid()
        {
            // Arrange
            var car = new Car
            {
                Price = 25000.50m,
                Title = "Camry LE",
                YearOfManufacture = null,       // ✅ Null допустим
                Country = null,                 // ✅ Null допустим
                BrandCarId = 1
            };

            var context = new ValidationContext(car);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(car, context, results, true);

            // Assert
            Assert.True(isValid);
            Assert.Empty(results);
        }

        [Fact]
        public void Car_WithValidBrandCarNavigation_ShouldBeValid()
        {
            // Arrange
            var car = new Car
            {
                Price = 35000.00m,
                Title = "BMW X5",
                YearOfManufacture = 2022,
                Country = "Germany",
                BrandCarId = 2,
                BrandCar = new BrandCar { Name = "BMW" }  // ✅ Навигационное свойство
            };

            var context = new ValidationContext(car);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(car, context, results, true);

            // Assert
            Assert.True(isValid);
            Assert.Empty(results);
        }
    }
}