﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NameToStructureApplication.Classes
{
    public static class Generic_PepsiLite
    {
        private static int _userid = 0;
        public static int UserID
        {
            get
            {
                return _userid;
            }
            set
            {
                _userid = value;
            }
        }

        private static string _username = "";
        public static string UserName
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        private static string _userrole = "";
        public static string UserRole
        {
            get
            {
                return _userrole;
            }
            set
            {
                _userrole = value;
            }
        }
    }
}
