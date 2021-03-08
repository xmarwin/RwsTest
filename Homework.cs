using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml.Linq;

namespace Moravia.Homework
{
    public class Document
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml");
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json");
            string input; // variable input should be declared outside of the try statement to be visible here
            try
            {
                FileStream sourceStream = File.Open(sourceFileName, FileMode.Open); // missing validation that the file exists
                var reader = new StreamReader(sourceStream); // use using statement
                input = reader.ReadToEnd(); // use await reader.ReadToEndAsync()
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); // use throw only, otherwise losing stack. In this case - do not use at all because it does not bring any value.
            }

            var xdoc = XDocument.Parse(input);
            var doc = new Document
            {
                Title = xdoc.Root.Element("title").Value,
                Text = xdoc.Root.Element("text").Value
            };

            var serializedDoc = JsonConvert.SerializeObject(doc);

            var targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write);
            var sw = new StreamWriter(targetStream); // use using statement
            sw.Write(serializedDoc); // use await sw.WriteAsync(serializedDoc)
        }
    }
}