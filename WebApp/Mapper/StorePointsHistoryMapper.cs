using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.DTO;
using WebApp.Models;

namespace WebApp.Mapper
{
    public class StorePointsHistoryMapper
    {
        private StorePointsMapper StorePointsMapper = new StorePointsMapper();

        public StorePointsHistoryDto StorePointsHistoryToDto(StorePointsHistory  history) {

            StorePointsDto storePointsDto = StorePointsMapper.StorePointsToDto(history.StorePoints);

            StorePointsHistoryDto dto = new StorePointsHistoryDto { StorePoints = storePointsDto, CreateTime = history.CreateTime, Operation = history.Operation, Points = history.Points};

            return dto;
        }
    }
}
