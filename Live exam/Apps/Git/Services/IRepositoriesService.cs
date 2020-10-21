using Git.Data;
using Git.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        void Create(string name, string repositoryType, string creatorName);

        IEnumerable<AllRepositoriesViewModel> GetAll();

        void Delete(string repositoryId);

        List<string> GetRepositoriesIdsByUserId(string userId);

        string GetRepositoryNameById(string repositoryId);
    }
}
