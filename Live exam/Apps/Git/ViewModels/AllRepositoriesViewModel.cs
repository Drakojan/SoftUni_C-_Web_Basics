using System;
using System.Collections.Generic;
using System.Text;

namespace Git.ViewModels
{
    public class AllRepositoriesViewModel
    {
        public string Name { get; set; }

        public string Owner { get; set; }

        public string CreatedOn { get; set; }

        public string Count { get; set; }

        public string repositoryId { get; set; }
    }
}
