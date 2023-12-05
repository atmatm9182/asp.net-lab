using lab3_App.Controllers;
using lab3_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{
    public class ContactControllerTest
    {
        private ContactController _controller;
        private IContactService _contactService;

        public ContactControllerTest() 
        {
            _contactService = new MemoryContactService(new CurrentDateTimeProvider());
            _contactService.Add(new Contact() { Id = 1 });
            _contactService.Add(new Contact() { Id = 2 });
            _controller = new ContactController(_contactService);
        }

        [Fact]
        public void IndexTest()
        {
            var result = _controller.Index();
            Assert.IsType<ViewResult>(result);
            var view = (ViewResult)result;
            Assert.Equal("Index", view.ViewName);
            var model = view.Model;
            Assert.IsType<List<Contact>>(model);
            Assert.Equal(2, ((List<Contact>)model).Count);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void DetailsTestForExistingContacts(int id)
        {
            var result = _controller.Details(id);
            Assert.IsType<ViewResult>(result);
            var view = (ViewResult)result;
            var model = (Contact)view.Model;
            Assert.Equal(id, model.Id);
        }

        [Fact]
        public void DetailsTestForNotExistingContacts()
        {
            var result = _controller.Details(100);
            Assert.IsType<NotFoundResult>(result);
            
        }
    }
}