using MyMovies.Common.Models;

namespace MyMovies.Common.Services
{
    public interface ILogService
    {
        void Log(LogData logData);
    }
}
