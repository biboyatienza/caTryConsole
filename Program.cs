// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using Noodling.CryptoMath.Models.MarketChart;
using Noodling.CryptoMath.Extensions;

Console.WriteLine("Hello, World!");

// From a Job Test:
//new ListManipulation().ShowListOfList_01();

// I just need FREE IPTV for my MXQ Pro:
//new ListManipulation().FileIOwithLINQ_GenerateIPTVListingByCountry();


/* Math! - Moving Average, applied a json file with value
   1. How to read json data from a file, result is a string
   2. Create json schema, using https://json2csharp.com/
   3. Create an object using json schema and convert the string to class object
   4. Show content of the object
   5. Create Extension method for Moving Average 
*/

const string JSON_DATA_PATH = "./Noodling/CryptoMath/Data/btc.json";
var cryptoData = new Root();
using (StreamReader r = new StreamReader(JSON_DATA_PATH))
{
    string json = r.ReadToEnd();
    // Console.WriteLine(json);
    cryptoData = JsonSerializer.Deserialize<Root>(json);
    Console.WriteLine(cryptoData);
}

    var dailyPrices = cryptoData.prices.Select(p => p[1]);

	// var results = dailyPrices.Take(10);
	var results = dailyPrices.Take(10).MovingAverage(2);
	Console.WriteLine(results);
    foreach (var result in results)
    {
        Console.WriteLine(result);
    }


// foreach (var day in dailyPrice)
// {
//     // {
//         Console.WriteLine(dayPrice);
//         Console.WriteLine(dayPrice);
//     // }
// }
