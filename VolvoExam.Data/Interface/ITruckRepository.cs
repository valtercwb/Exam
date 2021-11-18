using System.Collections;
using System.Collections.Generic;
using VolvoExam.Data.Entities;

namespace VolvoExam.Data.Interface
{
  public interface ITruckRepository
  {
    void Delete(long? id);
    Truck GetTruck(long? id);
    IEnumerable<Truck> List();
    void Create(Truck truck);
    void Edit(Truck truck);
    IEnumerable<TruckModel> ListTruckModel();
  }
}
