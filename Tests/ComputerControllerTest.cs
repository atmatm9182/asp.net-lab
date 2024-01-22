using lab3_App.Controllers;
using lab3_App.Models;
using Microsoft.AspNetCore.Mvc;

public class ComputerControllerTest
{
    private ComputerController _controller;
    private IComputerService _service;

    public ComputerControllerTest()
    {
        _service = new MemoryComputerService(new CurrentDateTimeProvider());
        _service.Add(new Computer() { Name = "Test1" });
        _service.Add(new Computer() { Name = "Test2" });
        _controller = new ComputerController(_service);
    }

    [Fact]
    public void IndexTest()
    {
        var result = _controller.Index();
        Assert.IsType<ViewResult>(result);
        var view = result as ViewResult;
        Assert.IsType<List<Computer>>(view.Model);
        List<Computer>? list = view.Model as List<Computer>;
        Assert.NotNull(list);
        Assert.Equal(2, list.Count);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void DetailsTestForExistingComputers(int id)
    {
        var result = _controller.Details(id);
        Assert.IsType<ViewResult>(result);
        var view = result as ViewResult;
        Assert.IsType<Computer>(view.Model);
        Computer model = view.Model as Computer;
        Assert.NotNull(model);
        Assert.Equal(id, model.Id);
    }

    [Fact]
    public void DetailsTestForNonExistingComputer()
    {
        var result = _controller.Details(9999);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void CreateTest()
    {
        var model = new Computer { Id = 3, CPU = "Turbo Pentium", GPU = "Integrated intel graphic 512mb", RAM = 4, Name = "ASUS Laptop" };
        var prevCount = _service.FindAll().Count;
        _controller.Create(model);
        Assert.Equal(prevCount + 1, _service.FindAll().Count);
    }

    [Fact]
    public void UpdateTest()
    {
        Computer model = _service.FindById(1);
        float oldRam = model.RAM;
        model.RAM = 2137;
        _controller.Update(model);
        Assert.NotEqual(_service.FindById(1).RAM, oldRam);
    }

    [Fact]
    public void UpdateForNonExistingComputerTest()
    {
        Computer model = new Computer { Id = 50 };
        var result = _controller.Update(model);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void DeleteTest()
    {
        Computer model = _service.FindById(2);
        _controller.Delete(model);
        Assert.Equal(_service.FindById(2), null);
    }

    [Fact]
    public void DeleteNonExistingComputerTest()
    {
        Computer model = new Computer { Id = 50 };
        var result = _controller.Delete(model);
        Assert.IsType<NotFoundResult>(result);
    }
}