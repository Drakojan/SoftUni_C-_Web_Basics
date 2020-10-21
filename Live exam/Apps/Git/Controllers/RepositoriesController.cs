using Git.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }
        public HttpResponse All()
        {
            var repositories = this.repositoriesService.GetAll();
            
            return this.View(repositories);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, string repositoryType)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (repositoryType!="Public" && repositoryType!="Private")
            {
                return this.Error("Repositories have to be either Public or Private");
            }

            if (string.IsNullOrWhiteSpace(name) || name.Length<3 || name.Length>10)
            {
                return this.Error("Repository name has to be between 3 and 10 symbols long");
            }

            var creatorId = this.GetUserId();

            this.repositoriesService.Create(name, repositoryType, creatorId);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse Delete(string repositoryId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            List<string> userRepositoriesIds = this.repositoriesService.GetRepositoriesIdsByUserId(this.GetUserId());
            
            if (!userRepositoriesIds.Contains(repositoryId))
            {
                return this.Error("You can only delete your own repositories");
            }
            
            this.repositoriesService.Delete(repositoryId);
            
            return this.Redirect("/Repositories/All");
        }
    }
}
