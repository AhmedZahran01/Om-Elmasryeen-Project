using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Om_Elmasryeen_Project.Languages_And_Themes
{ 
    public static class UserContext
    {
        public static UserType CurrentUserType { get; set; }
    }

    public enum UserType
    {
        MANAGER ,   DOCTOR ,    NURSE
    }

}
