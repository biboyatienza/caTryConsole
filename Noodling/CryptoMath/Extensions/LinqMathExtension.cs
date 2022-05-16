namespace Noodling.CryptoMath.Extensions
{
  public static class LinqMathExtension
  {
    public static IEnumerable<double> MovingAverage(this IEnumerable<double> source, int windowSize)
    {
      var queue = new Queue<double>(windowSize);
      foreach (double d in source)
      {
        if (queue.Count == windowSize) queue.Dequeue();
        queue.Enqueue(d);
        yield return queue.Average();
      }
    }
  }
}