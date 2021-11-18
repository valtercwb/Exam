using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using VolvoExam.Application.Interface;
using VolvoExam.Application.Transients;
using VolvoExam.ViewModels;

namespace VolvoExam.Controllers
{
  public class TruckController : Controller
  {
    private readonly ITruckService _truckService;
    readonly IMapper _mapper;

    public TruckController(ITruckService truckService, IMapper mapper)
    {
      _truckService = truckService;
      _mapper = mapper;
    }

    /// <summary>
    /// List trucks
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
      var trucks = _mapper.Map<List<TruckViewModel>>(_truckService.List());

      return View(trucks);
    }

    /// <summary>
    /// Truck details
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public IActionResult Details(long? id)
    {
      if (id == null)
      {
        return BadRequest();
      }

      var truck = _mapper.Map<TruckViewModel>(_truckService.GetTruck(id));

      if (truck == null)
      {
        return NotFound();
      }

      return View(truck);
    }

    /// <summary>
    /// Open new truck form
    /// </summary>
    /// <returns></returns>
    public IActionResult Create()
    {
      ViewData["TruckModels"] = Util.ExtensionMethods.SetDefaultSelect(
        _truckService.ListTruckModel().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList());

      ViewData["ModelYear"] = Util.ExtensionMethods.SetDefaultSelect(
        _truckService.GetValidTruckModelYears().Select(x => new SelectListItem() { Text = x.ToString(), Value = x.ToString() }).ToList());

      return View();
    }

    /// <summary>
    /// Register new truck
    /// </summary>
    /// <param name="truck"></param>
    /// <returns></returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(TruckViewModel truck)
    {
      if (ModelState.IsValid)
      {

        _truckService.Create(_mapper.Map<TruckTransient>(truck));

        return RedirectToAction(nameof(Index));
      }

      return View(truck);
    }

    public IActionResult Delete(long? id)
    {
      if (id == null)
      {
        return BadRequest();
      }

      var truck = _mapper.Map<TruckViewModel>(_truckService.GetTruck(id));

      if (truck == null)
      {
        return NotFound();
      }

      return View(truck);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteTruck(long id)
    {
      _truckService.Delete(id);

      return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(long? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var truck = _mapper.Map<TruckViewModel>(_truckService.GetTruck(id));

      if (truck == null)
      {
        return NotFound();
      }

      ViewData["TruckModels"] = Util.ExtensionMethods.SetDefaultSelect(
        _truckService.ListTruckModel().Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList());

      ViewData["ModelYear"] = Util.ExtensionMethods.SetDefaultSelect(
        _truckService.GetValidTruckModelYears().Select(x => new SelectListItem() { Text = x.ToString(), Value = x.ToString() }).ToList());

      return View(truck);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(long? id, TruckViewModel truck)
    {
      if (id != truck.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        _truckService.Edit(_mapper.Map<TruckTransient>(truck), id);

        return RedirectToAction(nameof(Index));
      }

      return View(truck);
    }

  }
}
