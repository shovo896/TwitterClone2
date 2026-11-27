using TwitterClone.Application;
using TwitterClone.Application.Dtos;

namespace Twitter_Clone.TwitterClone.Application.services;

public class UserServices
{
    public interface UserServices: IUserService
    {
        private readonly IuserRepository _userRepository; 
        

        public class UserService(IuserRepository.IUserRepository repository)
        {
            _userRepository = userRepository; 
            

        }
        userDtos CreateUserDto(CreateUserDtos createUserDtos);{ 
            
            [HttpPost]
            [AllowAnonymous]
            public IActionResult CreateUser([FromBody] CreateUserDtos request)
            {
                if (string.IsNullOrWhiteSpace(request.FirstName) ||
                    string.IsNullOrWhiteSpace(request.LastName) ||
                    string.IsNullOrWhiteSpace(request.Email))
                {
                    return null;
                } CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
            }

            if (userRepository.GetUserByEmail(request.Email) is not null)
                return null; 

            var user = new User
            {
                FirstName = request.FirstName.Trim(),
                LastName = request.LastName.Trim(),
                Email = request.Email.Trim()
            };

            userRepository.AddUser(user);
            return  ;
            var existingUser = _userRepository.GetUserEmail(CreateUserDtos.Email);
            if (existingUser != null)
            {
                return null; 
            }
            var createUser =_userRepository.AddUser(new User())
            {
                FirstName = CreateUserDtos.FirstName;
                LastName = createUserDtos.LastName;
                Email = createUserDtos.Email;
            }
            return new UserDtos
            {
                Id = createUser.Id,
                FirstName = createUser.FirstName,
                LastName = createUser.LastName;
                Email = createUser.Email;

            }; 
            





        }
        userDtos GetUserDtoById(Guid  id); 
        
        userDtos UpdateUserDto(UpdateUserDtos updateUserDtos); {
            var user = _userRepository.GetUserById(); 
            return new UserDtos(
            {
                Id = createUser.Id,
                FirstName = createUser.FirstName,
                LastName = createUser.LastName;
                Email = createUser.Email;

            }); 
            
        }
        userDtos DeleteUserDto(Guid id);
        
    }
    
    
}