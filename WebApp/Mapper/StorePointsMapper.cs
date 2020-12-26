using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.DTO;
using WebApp.Models;

namespace WebApp.Mapper
{
    public class StorePointsMapper
    {
        UserMapper UserMapper = new UserMapper();
        StoreMapper StoreMapper = new StoreMapper();
        public StorePointsDto StorePointsToDto(StorePoints points) {

            UserDto user = UserMapper.UserToDto(points.User);
            StoreDto store = StoreMapper.StoreToDto(points.Store);

            StorePointsDto dto = new StorePointsDto { Store = store, User = user, CreateTime = DateTime.Now, Points = points.Points, UpdateTime = points.UpdateTime};

            return dto;
        }
    }
}
