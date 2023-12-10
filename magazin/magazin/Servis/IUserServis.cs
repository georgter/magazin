

using magazin.ModelDto.User;

namespace magazin.Servis
{
    public interface IUserServis
    {
        public Task<List<GetUserDto>> GetALLUser();
    }
}
