namespace VolvoExam.Application.Transients
{
  public class TruckTransient
  {
    public long Id { get; set; }
    public string Name { get; set; }

    public long TruckModelId { get; set; }
    public TruckModelTransient TruckModel { get; set; }
    public int ManufactureYear { get; set; }
    public int ModelYear { get; set; }
  }
}