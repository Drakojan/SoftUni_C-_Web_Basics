using Git.Data;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(string description, string creatorId, string repositoryId)
        {
            var newCommit = new Commit
            {
                CreatedOn = DateTime.UtcNow,
                CreatorId = creatorId,
                RepositoryId = repositoryId,
                Description = description
            };
            this.db.Commits.Add(newCommit);
            this.db.SaveChanges();
        }

        public IEnumerable<CommitViewModelAll> GetAll(string userId)
        {
            return this.db.Commits.Where(x => x.CreatorId == userId)
                .Select(x => new CommitViewModelAll
                {
                    CreatedOn = x.CreatedOn.ToString(),
                    Description=x.Description,
                    RepositoryName=x.Repository.Name
                })
                .ToList();
        }

    }
}
