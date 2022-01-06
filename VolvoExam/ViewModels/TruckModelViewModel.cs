using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VolvoExam.ViewModels
{
  public class TruckModelViewModel
  {
    public long Id { get; set; }

    [Required(ErrorMessage = "Truck Model is required")]
    [DisplayName("Model name")]
    public string Name { get; set; }
    public bool Active { get; set; }

  }
}
