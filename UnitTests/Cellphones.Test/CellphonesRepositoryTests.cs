using System;
using System.Linq;
using NUnit.Framework;

namespace Cellphones.Test
{
    [TestFixture]
    public class CellphonesRepositoryTests
    {
        private ICellphonesRepository _cellphonesRepository;

        [OneTimeSetUp]
        public void Initialize()
        {
            _cellphonesRepository = new CellphonesRepository(); 
        }

        //[SetUp]
        //public void CleanUp()
        //{
        //    if (File.Exists(CellphonesRepository.RepositoryFilePath))
        //        File.(CellphonesRepository.RepositoryFilePath);
        //}

        //MethodName_StateUnderTest_ExpectedBehavior

        [Test]
        public void Add_PhoneNotNull_PhoneAdded()
        {
            //Arrange
            var phone = new Cellphone
            {
                Id = 0,
                Manufacturer = "Samsung",
                Model = "S8",
                Price = 1450.99m
            };

            //Act
            _cellphonesRepository.Add(phone);
            var addedPhone = _cellphonesRepository.GetAll().LastOrDefault();

            //Assert
            Assert.NotNull(addedPhone);
            Assert.AreEqual(phone.Model, addedPhone.Model);
            Assert.AreEqual(phone.Manufacturer, addedPhone.Manufacturer);
            Assert.AreEqual(phone.Price, addedPhone.Price);
        }

        [Test]
        public void Add_PhoneIsNull_ThrowArgumentNullException()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => 
            {
                _cellphonesRepository.Add(null);
            });
        }

        [Test]
        public void Remove_PhoneIsExists_PhoneRemoved()
        {
            //Arrange
            int id = 0;

            //Act
            _cellphonesRepository.Remove(id);
            var removedPhone = _cellphonesRepository.GetAll().FirstOrDefault(x => x.Id == id);

            //Assert
            Assert.Null(removedPhone);
        }

        [Test]
        public void Remove_PhoneIsNotExists_ThrowArgumentException()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                _cellphonesRepository.Remove(100);
            });
        }
    }
}
