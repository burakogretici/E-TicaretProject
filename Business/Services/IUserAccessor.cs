using Entities.Dtos.Users;

namespace Business.Services
{
    public interface IUserAccessor
    {
        bool IsLogined { get; }
        UserDto User { get; set; }
        string ClientIP { get; }
        string RequestLink { get; }

        void Store<T>(string key, T data);
        T Get<T>(string key);
        void Clear(string key = null);
    }
}
