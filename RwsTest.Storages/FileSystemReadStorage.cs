using RwsTest.Common.Interfaces;
using RwsTest.Common.Parameters;
using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;

namespace RwsTest.Storages
{
    public class FileSystemReadStorage : IReadStorage
    {
        private readonly IFileSystem _fileSystem;

        public FileSystemReadStorage(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        /// <summary>
        /// Reads data from a file system
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public async Task<string> ReadAsync(ParameterBase source)
        {
            if (!_fileSystem.File.Exists(source.Path))
            {
                throw new FileNotFoundException("Source file not found", source.Path);
            }

            return await _fileSystem.File.ReadAllTextAsync(source.Path);
        }
    }
}
