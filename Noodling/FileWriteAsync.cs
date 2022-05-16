public class FileWriteAsync
{
  public async Task FileWriteLineAsync(string lineToWrite, string fileWhereToWrite)
  {
      // Always new file:
      // using StreamWriter file = new(fileWhereToWrite);
      // Create new file or Append if exists:
      using StreamWriter file = new(fileWhereToWrite, append: true);

      await file.WriteLineAsync(lineToWrite);
  }

}
