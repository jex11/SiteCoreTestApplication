using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteCoreTestApplication.Models.ViewModels
{
    public class HomeViewModel
    {
        public bool IsAuthenticated { get; set; } = false;

        public User AuthorizedUser { get; set; }
    }
}