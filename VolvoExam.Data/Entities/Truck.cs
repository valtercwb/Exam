using System.ComponentModel.DataAnnotations;

namespace VolvoExam.Data.Entities
{
  public class Truck
  {
    [Key]
    public long Id { get; set; }
    public string Name { get; set; }

    public long TruckModelId { get; set; }
    public virtual TruckModel TruckModel { get; set; }
    public int ManufactureYear { get; set; }
    public int ModelYear { get; set; }
  }
}
