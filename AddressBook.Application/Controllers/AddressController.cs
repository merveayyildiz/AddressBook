using AddressBook.DataAccess.Repository;
using AddressBook.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Application.Controllers
{
  public class AddressController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;
    public AddressController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
      return View();
    }
    public IActionResult GetAddressByCustomerId(int id)
    {
      ViewBag.CustomerId = id;
      var result = _unitOfWork.WhereInclude<Address>(x => x.CustomerId == id);
      return View("GetAddressByCustomerId", result);
    }
    public IActionResult Delete(int id)
    {
      var address = _unitOfWork.FirstOrDefault<Address>(x => x.AddressId == id);

      _unitOfWork.Delete(address);
      _unitOfWork.Save();
      return RedirectToAction("GetAddressByCustomerId", "Address", new { id = address.CustomerId });
    }

    public IActionResult Edit(int id)
    {
      var address = _unitOfWork.FirstOrDefault<Address>(x => x.AddressId == id);
      return View("Edit", address);

    }

    [HttpPost]
    public IActionResult Edit(Address input)
    {
      _unitOfWork.Update(input);
      _unitOfWork.Save();
      return RedirectToAction("GetAddressByCustomerId", "Address", new { id = input.CustomerId });

    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Address input, int id)
    {
      if (ModelState.IsValid)
      {
        input.CustomerId = id;
        _unitOfWork.Add(input);
        _unitOfWork.Save();
        return RedirectToAction("GetAddressByCustomerId", "Address", new { id = id });
      }
      return View(input);
    }
  }
}
