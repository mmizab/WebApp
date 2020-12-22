using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.DTO;
using WebApp.Models;

namespace WebApp.Mapper
{
    public class UserMapper
    {
        public UserDto UserToDto(User user) {
            UserDto dto = new UserDto { Email = user.Email, Enabled = user.Enabled, Name = user.Name, Role = user.Role, Surname = user.Surname };
            return dto;
        }
    }
}
