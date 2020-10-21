using Git.Services;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;
        private readonly IRepositoriesService repositoriesService;

        public CommitsController(ICommitsService commitsService, IRepositoriesService repositoriesService)
        {
            this.commitsService = commitsService;
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            var commits = this.commitsService.GetAll(userId);
            
            return this.View(commits);
        }

        public HttpResponse Create(string repositoryId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var repositoryName = this.repositoriesService.GetRepositoryNameById(repositoryId);
            
            return this.View(new CreateCommitViewModel { Id=repositoryId,Name=repositoryName});
        }

        [HttpPost]
        public HttpResponse Create(string repositoryId, string description)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(description) || description.Length<5)
            {
                return this.Error("Description must be longer than 5 symbols");
            }

            this.commitsService.Create(description, this.GetUserId(), repositoryId);

            return this.Redirect("/Repositories/All");
        }


    }
}
