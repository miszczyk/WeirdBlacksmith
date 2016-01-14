using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace WeirdBlacksmith.Models
{
    public class TitleModels
    {
        public int Id { get; set; }
        public string AspNetUsersId { get; set; }
        public string OwnedBy { get; set; }
        public string Title { get; set; }
        public string CurrentUserRole { get; set; }
        public int WeaponsCount { get; set; }

        
    }
}