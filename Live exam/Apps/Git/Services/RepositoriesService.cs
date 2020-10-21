using Git.Data;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(string repositoryName, string repositoryType, string creatorName)
        {
            bool repositoryBool;

            if (repositoryType == "Public")
            {
                repositoryBool = true;
            }
            else
            {
                repositoryBool = false;
            }

            var newRepository = new Repository
            {
                Name = repositoryName,
                IsPublic = repositoryBool,
                CreatedOn = DateTime.UtcNow,
                OwnerId = creatorName
            };

            this.db.Repositories.Add(newRepository);
            this.db.SaveChanges();
        }

        public void Delete(string repositoryId)
        {
            var repositoryToDelete = this.db.Repositories.FirstOrDefault(r => r.Id == repositoryId);
            this.db.Repositories.Remove(repositoryToDelete);
            this.db.SaveChanges();
        }

        public IEnumerable<AllRepositoriesViewModel> GetAll()
        {
            var repositories = this.db.Repositories.Where(x=>x.IsPublic)
                .Select(x=> new AllRepositoriesViewModel 
                {
                    CreatedOn=x.CreatedOn.ToString(),
                    Count=x.Commits.Count().ToString(),
                    Name=x.Name,
                    Owner=x.Owner.Username,
                    repositoryId = x.Id
                })
                .ToList();

            return repositories;
        }

        public List<string> GetRepositoriesIdsByUserId(string userId)
        {
            return this.db.Repositories.Where(r => r.OwnerId == userId).Select(x=>x.Id).ToList();
        }

        public string GetRepositoryNameById(string repositoryId)
        {
            return this.db.Repositories.Where(r => r.Id == repositoryId).Select(x => x.Name).FirstOrDefault();
        }
    }
}
