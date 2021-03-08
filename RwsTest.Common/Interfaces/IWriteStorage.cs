using RwsTest.Common.Parameters;
using System.Threading.Tasks;

namespace RwsTest.Common.Interfaces
{
    public interface IWriteStorage
    {
        Task WriteAsync(ParameterBase target, string input);
    }
}
