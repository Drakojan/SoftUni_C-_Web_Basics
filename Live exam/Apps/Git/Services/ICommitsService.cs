using Git.Data;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface ICommitsService
    {
        void Create(string description, string creatorId, string repositoryId);

        IEnumerable<CommitViewModelAll> GetAll(string userId);
    }
}
