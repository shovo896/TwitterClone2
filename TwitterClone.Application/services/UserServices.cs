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
                    return BadRequest("All fields are required.");
                } CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
            }

            if (userRepository.GetUserByEmail(request.Email) is not null)
                return Conflict("A user with this email already exists.");

            var user = new User
            {
                FirstName = request.FirstName.Trim(),
                LastName = request.LastName.Trim(),
                Email = request.Email.Trim()
            };

            userRepository.AddUser(user);
            return;





        }
        userDtos GetUserDtoById(Guid  id); 
        
        userDtos UpdateUserDto(UpdateUserDtos updateUserDtos); 
        userDtos DeleteUserDto(Guid id);
        
    }
    
    
}