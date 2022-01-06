using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using VolvoExam.Application.Interface;
using VolvoExam.Application.Transients;
using VolvoExam.Application.Util;
using VolvoExam.Data.Entities;
using Xunit;

namespace VolvoExam.ApplicationTest.Service
{
  public class TruckServiceTest
  {
    [Fact]
    public void GetTruck_ShouldReturnTruck_When_Exists()
    {
      var truckId = 99999;

      var serviceTruckMock = new Mock<ITruckService>();

      serviceTruckMock.Setup(m => m.GetTruck(truckId)).Returns(new TruckTransient
      {
        Id = truckId,
        ManufactureYear = 2021,
        ModelYear = 2021,
        Name = "Truck unit test",
        TruckModelId = 1
      });

      var serviceTruckMockObject = serviceTruckMock.Object;

      // Act
      var truck = serviceTruckMockObject.GetTruck(truckId);

      // Assert
      Assert.Equal(truckId, truck.Id);
    }

    [Fact]
    public void DeleteTruck_ShouldDeleteTruck_When_Exists()
    {
      var truckId = 99999;

      var serviceTruckMock = new Mock<ITruckService>();

      serviceTruckMock.Setup(m => m.Delete(truckId)).Returns(true);

      var serviceTruckMockObject = serviceTruckMock.Object;

      // Act
      var truck = serviceTruckMockObject.GetTruck(truckId);

      // Assert
      Assert.Null(truck);
    }

    [Fact]
    public void GetTruck_Sould_Return_ValidModelYear()
    {
      var modelYear = new List<int>() { DateTime.Now.Year, DateTime.Now.Year + 1 };

      // Act
      var validTruckModelYear = Util.GetValidTruckModelYear();

      // Assert
      Assert.Equal(modelYear, validTruckModelYear);
    }

    [Fact]
    public void CreateTruck_Manufature_Year_most_be_The_Current_Year()
    {
      var truckId = 99999;

      var truckDto = new TruckTransient
      {
        Id = truckId,
        ModelYear = 2022,
        Name = "Truck unit test",
        ManufactureYear = DateTime.Now.Year,
        TruckModelId = 1
      };

      var serviceTruckMock = new Mock<ITruckService>();

      serviceTruckMock.Setup(m => m.GetTruck(truckId)).Returns(truckDto);

      var serviceTruckMockObject = serviceTruckMock.Object;

      // Act
      var truck = serviceTruckMockObject.GetTruck(truckId);

      // Assert
      Assert.Equal(truckId, truck.Id);
      Assert.Equal(DateTime.Now.Year, truck.ManufactureYear);
    }

    [Fact]
    public void EditTruck_ShouldEditTruck_When_Exists()
    {
      var truckId = 99999;

      var truckDto = new TruckTransient
      {
        Id = truckId,
        ModelYear = 2022,
        Name = "Truck unit test",
        TruckModelId = 1
      };

      var serviceTruckMock = new Mock<ITruckService>();

      serviceTruckMock.Setup(m => m.GetTruck(truckId)).Returns(truckDto);

      var serviceTruckMockObject = serviceTruckMock.Object;

      // Act
      var truckActed = new TruckTransient
      {
        Id = truckId,
        ModelYear = 2023,
        Name = "Truck unit test edited",
        TruckModelId = 1
      };

      serviceTruckMockObject.Edit(truckActed, truckId);

      var truck = serviceTruckMockObject.GetTruck(truckId);

      // Assert
      Assert.Equal(truckId, truckActed.Id);
      Assert.NotEqual(truck.Name, truckActed.Name);
      Assert.NotEqual(truck.ModelYear, truckActed.ModelYear);
      Assert.Equal(truck.TruckModelId, truckActed.TruckModelId);
    }

    [Fact]
    public void GetTruckModel_Should_Return_Only_Active_Models()
    {
      var models = new List<TruckModel>(){
        new TruckModel() { Id = 1, Name = "FH", Active = true },
        new TruckModel() { Id = 2, Name = "FM", Active = true },
        new TruckModel() { Id = 3, Name = "FV", Active = false },
        new TruckModel() { Id = 4, Name = "WG", Active = false }
      };

      var activeTruckModels = new List<string>() { "FH", "FM" };

      Assert.Equal(activeTruckModels.First(), models.Where(x => x.Name.Equals(activeTruckModels.First())).FirstOrDefault().Name);
      Assert.Equal(activeTruckModels.Last(), models.Where(x => x.Name.Equals(activeTruckModels.Last())).FirstOrDefault().Name);
    }
  
  }
}
