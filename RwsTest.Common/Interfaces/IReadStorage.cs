using RwsTest.Common.Parameters;
using System.Threading.Tasks;

namespace RwsTest.Common.Interfaces
{
    public interface IReadStorage
    {
        Task<string> ReadAsync(ParameterBase source);
    }
}
