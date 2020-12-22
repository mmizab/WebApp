using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.DTO;
using WebApp.Models;

namespace WebApp.Mapper
{
    public class JobMapper
    {
        UserMapper UserMapper = new UserMapper();
        public JobDto JobToDto(Job job) {
            JobDto dto = new JobDto { User = UserMapper.UserToDto(job.User), Company = job.Company, CreateDate = job.CreateDate, Description = job.Description, Id = job.Id, Localization = job.Localization, Title = job.Title};
            return dto;
        }
    }
}
