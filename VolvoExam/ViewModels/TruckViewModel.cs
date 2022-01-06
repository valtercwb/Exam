using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VolvoExam.ViewModels
{
  public class TruckViewModel
  {
    public long Id { get; set; }

    [Required(ErrorMessage = "Truck Model is required")]
    [DisplayName("Truck Model")]
    public long TruckModelId { get; set; }
    public TruckModelViewModel TruckModel { get; set; }


    [Required(ErrorMessage = "Truck name is required")]
    [DisplayName("Truck name")]
    public string Name { get; set; }

    [DisplayName("Manufacture year")]
    public int ManufactureYear { get; set; }

    [Required(ErrorMessage = "Model year is required")]
    [DisplayName("Model year")]
    public int ModelYear { get; set; }
  }
}
