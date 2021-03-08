using Microsoft.Extensions.DependencyInjection;
using RwsTest.Common.Interfaces;
using RwsTest.Common.Parameters;
using RwsTest.Convertors;
using RwsTest.Storages;
using System;
using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;

namespace RwsTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var source = new ParameterBase
            //{
            //    Path = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml")
            //};
            var source = new ParameterRest
            {
                Path = "https://gorest.co.in/public-api/users.xml",
                Url = "https://gorest.co.in/",
            };
            var target = new ParameterBase
            {
                Path = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json")
            };

            var serviceProvider = new ServiceCollection()
                .AddTransient<IReadStorage, RestReadStorage>()
                .AddTransient<IWriteStorage, FileSystemWriteStorage>()
                .AddTransient<IFormatConverter, XmlToJsonConverter>()

                .AddTransient<IFileSystem, FileSystem>()
                .AddHttpClient()
                .BuildServiceProvider();

            var sourceStorage = serviceProvider.GetService<IReadStorage>();
            var targetStorage = serviceProvider.GetService<IWriteStorage>();
            var conv = serviceProvider.GetService<IFormatConverter>();

            var input = await sourceStorage.ReadAsync(source);

            var serializedDoc = conv.Convert(input);


            await targetStorage.WriteAsync(target, serializedDoc);
        }
    }
}
