using MirtesenDataGenerator;
using System.Text.Json;

string folder = @"D:\Github\Tests\";
string fileName = "siteData.json";
string fileEditedName = "siteEditedData.json";

Console.Write("Write Site domain: ");
string siteDomain = Console.ReadLine();
Console.Write("Write Site name: ");
string siteName = Console.ReadLine();
Console.Write("Write Site descr: ");
string siteDesc = Console.ReadLine();

List<Site> _data = new List<Site>();
_data.Add(new Site(domain: siteDomain, name: siteName, desc: siteDesc, keyWords: "key"));
string json = JsonSerializer.Serialize(_data);
File.WriteAllText(folder + fileName, json);

Console.Write("Write Site edited name: ");
string siteEditedName = Console.ReadLine();
Console.Write("Write Site edited descr: ");
string siteEditedDesc = Console.ReadLine();
List<Site> _editedData = new List<Site>();
_editedData.Add(new Site(domain: siteDomain, name: siteEditedName, desc: siteEditedDesc, keyWords: "key"));

string editedJson = JsonSerializer.Serialize(_editedData);

File.WriteAllText(folder + fileEditedName, editedJson);