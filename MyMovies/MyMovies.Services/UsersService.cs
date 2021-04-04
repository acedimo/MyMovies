using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.DtoModels;
using MyMovies.Services.Interfaces;
using System.Collections.Generic;

namespace MyMovies.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public List<User> GetAll()
        {
            return _usersRepository.GetAll();
        }

        public User GetDetails(string userId)
        {
            return _usersRepository.GetById(int.Parse(userId));
        }

        public StatusModel ToggleAdminRole(int id)
        {
            var response = new StatusModel();

            var user = _usersRepository.GetById(id);

            if (user == null)
            {
                response.IsSuccessful = false;
                response.Message = "User was not found";
            }
            else
            {
                user.IsAdmin = !user.IsAdmin;

                _usersRepository.Update(user);
            }

            return response;
        }

        public StatusModel Delete(int id)
        {
            var response = new StatusModel();

            var user = _usersRepository.GetById(id);

            if (user == null)
            {
                response.IsSuccessful = false;
                response.Message = "User was not found";
            }
            else
            {

                _usersRepository.Delete(user);
            }

            return response;
        }
    }
}
