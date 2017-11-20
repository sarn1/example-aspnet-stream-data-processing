# example-aspnet-streams-data-processing
#### Example console app written in C# focusing on C# Streams & Data Processing ####

C# Streams and Data Processing
https://teamtreehouse.com/library/c-streams-and-data-processing
 
**Program.cs**
1. Output all available files
2. Output content from a text file.
3. Output all data from a CSV.
4. Using example objects and parsing though different data types.
5. Using JSON NuGet to serialize/deserialize data
6. Write to file.

**General Notes**
- Create new text file by adding to solution, but then pull it out of "Solution Files" into root.  Then you can right click and go to property to set `Copy to Output Directory` to `copy if newer`
- UTF-8 for text, UTF-16 when creating within .NET.
- Use `ref` and `out` for pass by reference and pass by value.  Reference is 2-way, while out is out-only.
```csharp
public void test (ref string str)
```
- Enum example below:
```csharp
public class WeatherForecast
    {
        public string WeatherStationId { get; set; }
        public DateTime TimeOfDay { get; set; }
        public Condition Condition { get; set; }
    }

    public enum Condition
    {
        Rain = 10,
        Cloudy = 11,
        PartlyCloudy = 12,
        PartlySunny = 13,
        Sunny = 14,
        Clear = 15
    }
```
- `int.MinValue` , `intMaxValue`, uint.MinValue`, `short.MaxValue`, `ushort.MaxValue`, `long.MaxValue`
- JSON is becoming the standard serialization format for .NET.
- Copy a JSON/XML file into clipboard, then in a class Edit > Paste Special > Paste JSON As Class.  This will create a class that represents the JSON data.
- `Newtonsoft.Json` is a NuGet.  
- http://newtonsoft.com/json/help/html/SerializingJSON.htm
- [Google: `json serialize property to different name` basicaly when you want to rename the attribute differently from what's in the file.](https://stackoverflow.com/questions/8796618/how-can-i-change-property-names-when-serializing-with-json-net)
