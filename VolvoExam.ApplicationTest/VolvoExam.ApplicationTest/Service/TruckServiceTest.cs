using Moq;
using System;
using System.Collections.Generic;
using VolvoExam.Application.Interface;
using VolvoExam.Application.Transients;
using VolvoExam.Application.Util;
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
        ModelYear = 2021,
        Name = "Truck unit test",
        TruckModelId = 1
      };

      var serviceTruckMock = new Mock<ITruckService>();

      serviceTruckMock.Setup(m => m.Create(truckDto)).Returns(true);

      var serviceTruckMockObject = serviceTruckMock.Object;

      // Act
      var truck = serviceTruckMockObject.GetTruck(truckId);

      // Assert
      Assert.Equal(truckId, truck.Id);
      Assert.NotEqual(DateTime.Now.Year, truck.ManufactureYear);
    }

    [Fact]
    public void EditTruck_ShouldEditTruck_When_Exists()
    {
      var truckId = 99999;

      var truckDto = new TruckTransient
      {
        Id = truckId,
        ManufactureYear = 2021,
        ModelYear = 2021,
        Name = "Truck unit test",
        TruckModelId = 1
      };

      var serviceTruckMock = new Mock<ITruckService>();

      serviceTruckMock.Setup(m => m.GetTruck(truckId)).Returns(truckDto);

      var serviceTruckMockObject = serviceTruckMock.Object;

      // Act
      var ss = serviceTruckMockObject.Edit(
     new TruckTransient
     {
       ManufactureYear = 2022,
       ModelYear = 2022,
       Name = "Truck unit test edited",
       TruckModelId = 2
     }, truckId);


      var truck = serviceTruckMockObject.GetTruck(truckId);

      // Assert
      Assert.Equal(truckId, truck.Id);
      Assert.NotEqual(truckDto.Name, truck.Name);
      Assert.NotEqual(truck.ModelYear, truck.ModelYear);
      Assert.NotEqual(truck.ManufactureYear, truck.ManufactureYear);
      Assert.Equal(truck.TruckModelId, truck.TruckModelId);
    }
  }
}
