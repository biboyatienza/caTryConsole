namespace Noodling.CryptoMath.Model.MarketChart
{
  // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
  public class Root
  {
      public List<List<double>> prices { get; set; }
      public List<List<double>> market_caps { get; set; }
      public List<List<double>> total_volumes { get; set; }
  }
}

