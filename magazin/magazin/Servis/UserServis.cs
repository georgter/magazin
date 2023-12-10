using magazin.Data;
using magazin.Model;
using magazin.ModelDto.User;
using magazin.Repositories;

namespace magazin.Servis
{
    public class UserServis : IUserServis
    {
        private readonly ApplicationDbContext _context;
        public UserServis(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<GetUserDto>> GetALLUser()
        {
            List<GetUserDto> userDto = new List<GetUserDto>();
            using (var unitOfWork = new UnitOfWork(_context))
            {
                // Создаем репозитории
                var userRepository = unitOfWork.GetRepository<User>();
                var user =userRepository.GetAll();
                foreach (var item in user) 
                {
                 userDto.Add(
                     new GetUserDto()
                     {
                         UserName = item.UserName,
                         Id = item.Id,
                     }
                 );   
                }

                unitOfWork.SaveChanges();
            }

            return userDto;
        }
    }
}
