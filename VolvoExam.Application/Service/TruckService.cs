using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using VolvoExam.Application.Interface;
using VolvoExam.Application.Transients;
using VolvoExam.Data.Entities;
using VolvoExam.Data.Interface;

namespace VolvoExam.Application.Service
{
  public class TruckService : ITruckService
  {
    readonly IMapper _mapper;
    readonly ITruckRepository _truckRepository;

    public TruckService(ITruckRepository truckRepository, IMapper mapper)
    {
      _truckRepository = truckRepository;
      _mapper = mapper;
    }

    public IEnumerable<TruckModel> ListTruckModel()
    {
      return _truckRepository.ListTruckModel();
    }

    bool ITruckService.Create(TruckTransient truck)
    {
      var truckEntity = new Truck()
      {
        Name = truck.Name,
        ManufactureYear = DateTime.Now.Year,
        ModelYear = truck.ModelYear,
        TruckModelId = truck.TruckModelId
      };

      return _truckRepository.Create(truckEntity);
    }

    bool ITruckService.Delete(long? id)
    {
      return _truckRepository.Delete(id);
    }

    bool ITruckService.Edit(TruckTransient truck, long? id)
    {
      var truckEntity = _truckRepository.GetTruck(id);
      truckEntity.Name = truck.Name;
      truckEntity.ModelYear = truck.ModelYear;
      truckEntity.TruckModelId = truck.TruckModelId;

      return _truckRepository.Edit(truckEntity);
    }

    public TruckTransient GetTruck(long? id)
    {
      return _mapper.Map<TruckTransient>(_truckRepository.GetTruck(id));
    }

    IEnumerable<TruckTransient> ITruckService.List()
    {
      return _mapper.Map<List<TruckTransient>>(_truckRepository.List());
    }

    IEnumerable<int> ITruckService.GetValidTruckModelYears()
    {
      return Util.Util.GetValidTruckModelYear();
    }
  }
}
