using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VolvoExam.Data.Entities
{
  public class TruckModel
  {
    [Key]
    public long Id { get; set; }
    public string Name { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Truck> Truck { get; set; }
  }
}
