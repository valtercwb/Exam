using System.Collections;
using System.Collections.Generic;
using VolvoExam.Application.Transients;
using VolvoExam.Data.Entities;

namespace VolvoExam.Application.Interface
{
  public interface ITruckService
  {
    IEnumerable<TruckTransient> List();
    IEnumerable<TruckModel> ListTruckModel();
    IEnumerable<int> GetValidTruckModelYears();
    TruckTransient GetTruck(long? id);
    bool Delete(long? id);
    bool Create(TruckTransient truck);
    bool Edit(TruckTransient truck, long? id);
  }
}
