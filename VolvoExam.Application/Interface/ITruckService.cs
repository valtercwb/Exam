using System.Collections;
using System.Collections.Generic;
using VolvoExam.Application.Transients;
using VolvoExam.Data.Entities;

namespace VolvoExam.Application.Interface
{
  public interface ITruckService
  {
    IEnumerable<TruckTransient> List();

    TruckTransient GetTruck(long? id);

    void Delete(long? id);

    void Create(TruckTransient truck);

    void Edit(TruckTransient truck, long? id);
    IEnumerable<TruckModel> ListTruckModel();
    IEnumerable<int> GetValidTruckModelYears();
  }
}
