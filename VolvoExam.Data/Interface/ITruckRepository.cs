using System.Collections;
using System.Collections.Generic;
using VolvoExam.Data.Entities;

namespace VolvoExam.Data.Interface
{
  public interface ITruckRepository
  {
    IEnumerable<TruckModel> ListTruckModel();
    Truck GetTruck(long? id);
    IEnumerable<Truck> List();
    bool Create(Truck truck);
    bool Edit(Truck truck);
    bool Delete(long? id);
  }
}
