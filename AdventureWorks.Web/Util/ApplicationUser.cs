using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorks.Web.Util
{
    public class ApplicationUser
    {
        private static ApplicationUser _instance;

        public string UserName { get; set; }
        public List<string> Roles { get; set; }
        public bool IsAuthentificated { get; set; }

        public ApplicationUser()
        {

        }

        public static ApplicationUser GetInstance()
        {
            if(_instance == null)
            {
                _instance = new ApplicationUser();
                return _instance;
            }
            else
            {
                return _instance;
            }
        }

        public static void Initialize()
        {
            _instance = new ApplicationUser();
        }
    }
}