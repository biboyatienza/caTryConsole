public class ListManipulation
{
  public void ShowListOfList_01()
  {
    List<List<string>> products = new List<List<string>>{ 
      new List<string> { "10", "sale", "january-sale"},
      new List<string> { "200", "sale", "10"},
    };

    List<List<string>> discounts = new List<List<string>>{ 
      new List<string> { "sale", "0", "10"},
      new List<string> { "january-sale", "1", "10"},
    };

    foreach (var product in products)
    {
      foreach (var item in product)
      {
        Console.WriteLine(item);
      }
      Console.WriteLine();
    }

    foreach (var discount in discounts)
    {
      if(discount.Contains("sale"))
      {
          Console.WriteLine(discount[0]);
        // foreach (var item in discount)
        // {
        //   Console.WriteLine(item);
        // }
      }  
      Console.WriteLine();
    }
  }

  public async void FileIOwithLINQ_GenerateIPTVListingByCountry()
  {
    const string FILE_PATH = "./Data/country.oneliner.m3u.txt";
    const string ODD_EVEN_SEPERATOR = "~";
    // const string OUTPUT_FILE_PATH = "./Output/country.oneliner.m3u.txt";
    const string OUTPUT_FILE_PATH = "./Output/caFilteredChannels.m3u";

    string[] lines = System.IO.File.ReadAllLines(FILE_PATH);
    // string FilterBy = "tvg-country=\"INT\" tvg-language=\"English\"";
    string[] FilterBys = {
      "tvg-country=\"US\"",
      "tvg-country=\"UK\" tvg-language=\"English\"",
      "tvg-country=\"CA\" tvg-language=\"English\"",
      "tvg-country=\"EUR\" tvg-language=\"English\"",
      "tvg-country=\"AU\" tvg-language=\"English\"",
      "tvg-country=\"FR\" tvg-language=\"English\"",
      "tvg-country=\"IT\"",
      "tvg-country=\"PH\""
    };
    string[] ExcludesBy = {"[Geo-Blocked]", "[Geo-blocked]"};

    // Display the file contents by using a foreach loop.
    System.Console.WriteLine("Contents of {0}; ", FILE_PATH);


    // // Write new Data to use: 
    // var combinedOneLiners = combineOddEvenLine_into_OneLiner(lines, ODD_EVEN_SEPERATOR);
    // foreach (string line in combinedOneLiners)
    // {
    //       await fileWriteLineAsync(line, OUTPUT_FILE_PATH);
    // }



    // Filter as string[] by .Any<>;
    Console.WriteLine("\n\n" + FilterBys);
    var linesToWrite = lines.Where(x => FilterBys.Any(f => x.Contains(f) && !ExcludesBy.Any(e => x.Contains(e))));
    foreach (string line in linesToWrite)
    {
      Console.WriteLine("ExcludesBy found! \t" + line);
      string[] lineSplits = line.Split(ODD_EVEN_SEPERATOR);
      foreach (var lineSplit in lineSplits)
      {
        await new FileWriteAsync().FileWriteLineAsync(lineSplit, OUTPUT_FILE_PATH);
      }
    }


    // Keep the console window open in debug mode.
    Console.WriteLine("Press any key to exit.");
    System.Console.ReadKey();


  }

  string[] combineOddEvenLine_into_OneLiner(string[] lines, string seperator)
  {
    List<string> oneLiners = new List<string>();
    const string MARKER_AS_ODD = "#EXTINF:";
    string oddValue = string.Empty;
    foreach (var line in lines)
    {
      if(line.Contains(MARKER_AS_ODD))
      {
        oddValue = line;
        continue;
      }

      oneLiners.Add(oddValue + seperator + line);        
    }
    return oneLiners.ToArray();
  }



}