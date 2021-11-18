using System.ComponentModel;

namespace VolvoExam.ViewModels
{
  public class TruckModelViewModel
  {
    public long Id { get; set; }

    [DisplayName("Model name")]
    public string Name { get; set; }
    public bool Active { get; set; }

  }
}
