using System.Linq;
using VolvoExam.Data.Entities;

namespace VolvoExam.Data
{
  public class DataSeed
  {
    public static void Initialize(VolvoExamDbContext context)
    {
      context.Database.EnsureCreated();

      //verifica se existem registros na tabela "Modelo"
      if (!context.TruckModel.Any())
        LoadTruckModels(context);
    }
    public static void LoadTruckModels(VolvoExamDbContext ctx)
    {
      ctx.TruckModel.AddRange(
        new TruckModel() { Id = 1, Name = "FH", Active = true },
        new TruckModel() { Id = 2, Name = "FM", Active = true },
        new TruckModel() { Id = 3, Name = "FV", Active = false },
        new TruckModel() { Id = 4, Name = "WG", Active = false });

      ctx.SaveChanges();
    }
  }
}