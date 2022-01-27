using AddressBook.DataAccess.Repository;
using AddressBook.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Application.Controllers
{
  public class CustomerController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;
    public CustomerController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public IActionResult AllCustomer()
    {
      var customers = _unitOfWork.All<Customer>();
      return View(customers);
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Customer customer)
    {
      if (ModelState.IsValid)
      {
        _unitOfWork.Add(customer);
        _unitOfWork.Save();
        return RedirectToAction(nameof(AllCustomer));
      }
      return View(customer);
    }

    public IActionResult Delete(int id)
    {
      var customer = _unitOfWork.FirstOrDefault<Customer>(x => x.CustomerId == id);

      _unitOfWork.Delete(customer);
      _unitOfWork.Save();
      return RedirectToAction(nameof(AllCustomer));

    }

    public IActionResult Edit(int id)
    {
      var customer = _unitOfWork.FirstOrDefault<Customer>(x => x.CustomerId == id);
      return View("Edit", customer);

    }

    [HttpPost]
    public IActionResult Edit(Customer customer)
    {
      _unitOfWork.Update(customer);
      _unitOfWork.Save();
      return RedirectToAction("AllCustomer");
    }
  }
}
