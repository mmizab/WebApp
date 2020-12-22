using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.DTO;
using WebApp.Mapper;
using WebApp.Models;

namespace WebApp.Service
{
    public class JobService
    {
        public WebAppContext Context { get; set; }
        public JobMapper JobMapper { get; set; }
        public JobService(WebAppContext context)
        {
            Context = context;
        }
        public List<Job> GetJobs() {
            List<Job> jobs = Context.Job.ToList();
            return jobs;
        }

        public void SaveJob(JobDto dto) {
            User user = Context.User.FirstOrDefault(o => o.Email == dto.User.Email);
            Job job = new Job { Company = dto.Company, CreateDate = dto.CreateDate, Description = dto.Description, Id = dto.Id, Localization = dto.Localization, Title = dto.Title, User = user };
            Context.Add(job);
            Context.SaveChanges();
            if (job.Id == 0)
            {
                throw new Exception("Erro saving new job");
            }
        }
    }
}
