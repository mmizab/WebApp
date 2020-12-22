using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.DTO;
using WebApp.Mapper;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Service
{
    public class JobService
    {
        public WebAppContext Context { get; set; }
        public JobMapper JobMapper = new JobMapper();
        public JobService(WebAppContext context)
        {
            Context = context;
        }
        public List<JobDto> GetJobs() {
            List<JobDto> dto = new List<JobDto>();
            List<Job> jobs = Context.Job.Include(o => o.User).ToList();
            foreach (var item in jobs)
            {
                dto.Add(JobMapper.JobToDto(item));
            }
            return dto;
        }

        public JobDto GetJob(int id) {
            Job job = Context.Job.Include( o => o.User).FirstOrDefault(o => o.Id == id);
            JobDto dto = JobMapper.JobToDto(job);
            return dto;
        }

        public void SaveJob(JobDto dto, User user) {
            Job job = new Job { Company = dto.Company, CreateDate = DateTime.Now, Description = dto.Description, Id = dto.Id, Localization = dto.Localization, Title = dto.Title, User = user };
            Context.Add(job);
            Context.SaveChanges();
            if (job.Id == 0)
            {
                throw new Exception("Error saving new job");
            }
        }
    }
}
