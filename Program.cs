// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

Console.Write("Enter input: ");
string userInput = Console.ReadLine();


var apiKey = "";
var model = "text-davinci-003";
var prompt = userInput;
var maxTokens = 100;
var temperature = 0;

var request = (HttpWebRequest)WebRequest.Create("https://api.openai.com/v1/completions");
request.Method = "POST";
request.ContentType = "application/json";
request.Headers.Add("Authorization", "Bearer " + apiKey);

using (var streamWriter = new StreamWriter(request.GetRequestStream()))
{
    string json = "{\"model\":\"" + model + "\",\"prompt\":\"" + prompt + "\",\"max_tokens\":" + maxTokens + ",\"temperature\":" + temperature + "}";
    streamWriter.Write(json);
}

var response = (HttpWebResponse)request.GetResponse();

using (var streamReader = new StreamReader(response.GetResponseStream()))
{
    var result = streamReader.ReadToEnd();
   
    dynamic jsonObj = JsonConvert.DeserializeObject(result);
    string text = jsonObj.choices[0].text;
    Console.WriteLine(text);
}

Console.ReadLine();

