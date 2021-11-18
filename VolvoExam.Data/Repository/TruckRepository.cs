using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VolvoExam.Data.Entities;
using VolvoExam.Data.Interface;

namespace VolvoExam.Data.Repository
{
  public class TruckRepository : ITruckRepository
  {
    readonly VolvoExamDbContext _context;

    public TruckRepository(VolvoExamDbContext context)
    {
      _context = context;
    }

    IEnumerable<TruckModel> ITruckRepository.ListTruckModel()
    {
      return _context.Set<TruckModel>().Where(x => x.Active == true).ToList();
    }

    void ITruckRepository.Create(Truck truck)
    {
      _context.Set<Truck>().Add(truck);
      _context.SaveChanges();
    }

    void ITruckRepository.Delete(long? id)
    {
      var truck = _context.Set<Truck>().Where(x => x.Id == id).FirstOrDefault();
      _context.Set<Truck>().Remove(truck);
      _context.SaveChanges();
    }

    void ITruckRepository.Edit(Truck truck)
    {
      _context.Update(truck);
      _context.SaveChanges();
    }

    Truck ITruckRepository.GetTruck(long? id)
    {
      return _context.Set<Truck>().Where(x => x.Id == id).FirstOrDefault();
    }

    IEnumerable<Truck> ITruckRepository.List()
    {
      return _context.Truck.OrderBy(x => x.Name).ToList();
    }
  }
}
