using MainApp.Data;
using MainApp.Models;

namespace MainApp.Services;

public class UserService(DataContext<User> context)
{
    private readonly DataContext<User> _context = context;

    public ResponseResult<User> SaveUser(User user)
    {
        try
        {
            if (!_context.Items().Any(x => x.Email == x.Email))
            {
                user.Id = _context.Items().Any() ? _context.Items().Last().Id + 1 : 1;
                _context.Save(user);
                return new ResponseResult<User>
                {
                    Success = true
                };
            }
            else
            {
                return new ResponseResult<User>
                {
                    Success = false,
                    Message = "A user with the same email already exists."
                };
            }
        }
        catch (Exception ex)
        {
            return new ResponseResult<User>
            {
                Success = false,
                Message = $"{ex.Message}"
            };
        }
    }
    public ResponseResult<IEnumerable<User>> GetAllUsers()
    {
        try
        {
            return new ResponseResult<IEnumerable<User>>
            {
                Success = true,
                Result = _context.Items()
            };
        }
        catch (Exception ex)
        {
            return new ResponseResult<IEnumerable<User>>
            {
                Success = false,
                Message = $"{ex.Message}"
            };
        }
    }
}
