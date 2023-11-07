using Api.Controllers;
using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Controllers
{
    public class ContactsControllerTests
    {
        [Fact]
        public void GetContacts_ShouldBeAContactListWhenCalled()
        {
            var mockRepo = new Mock<ApplicationDbContext>();
            mockRepo.Setup(c => c.Contacts)
                .ReturnsDbSet(GetContacts());

            ContactsController contactsController = new ContactsController(mockRepo.Object);

            var sut = contactsController.GetContacts().Result.Value;

            Assert.NotNull(sut);
            Assert.IsAssignableFrom<IEnumerable<Contact>>(sut);
        }

        [Fact]
        public void GetContacts_ShouldNotBeEmpty()
        {
            var mockRepo = new Mock<ApplicationDbContext>();
            mockRepo.Setup(c => c.Contacts)
                .ReturnsDbSet(GetContacts());

            ContactsController contactsController = new ContactsController(mockRepo.Object);

            var sut = contactsController.GetContacts().Result.Value;

            Assert.NotEmpty(sut);
        }

        [Fact]
        public void GetContacts_ShouldContactNotBeEmpty()
        {
            var mockRepo = new Mock<ApplicationDbContext>();
            mockRepo.Setup(c => c.Contacts)
                .ReturnsDbSet(GetContacts());

            ContactsController contactsController = new ContactsController(mockRepo.Object);

            var sut = contactsController.GetContacts().Result.Value.First<Contact>();

            Assert.NotNull(sut);
            Assert.NotEqual(Guid.Empty, sut.Id);
            Assert.NotEqual(String.Empty, sut.Nome);
        }

        [Fact]
        public void GetContacts_ShouldThrowExceptionIfOutOfRange()
        {
            var mockRepo = new Mock<ApplicationDbContext>();
            mockRepo.Setup(c => c.Contacts)
                .ReturnsDbSet(GetContacts());

            ContactsController contactsController = new ContactsController(mockRepo.Object);

            var sut = contactsController.GetContacts().Result.Value.First<Contact>();

            Assert.Throws<IndexOutOfRangeException>(() => contactsController.GetContacts().Result.Value.ToArray()[1]);
        }

        private IEnumerable<Contact> GetContacts()
        {
            return new List<Contact>()
            {
                new Contact() {Id = Guid.NewGuid(), Nome = "Daniel", Telefone = "4363636363", Email = "cwew@ewlklew.com", Duvida = ""}
            };
        }
    }
}
