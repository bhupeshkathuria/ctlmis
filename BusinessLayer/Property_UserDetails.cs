using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using BL;


namespace BL
{
    public class Property_UserDetails
    {
        private int UserId;

        public int PUserId
        {
            get { return UserId; }
            set { UserId = value; }
        }
        private string UsersName;

        public string PUsersName
        {
            get { return UsersName; }
            set { UsersName = value; }
        }
        private string UsersPwd;

        public string PUsersPwd
        {
            get { return UsersPwd; }
            set { UsersPwd = value; }
        }

        private string UsersNewPwd;

        public string PUsersNewPwd
        {
            get { return UsersNewPwd; }
            set { UsersNewPwd = value; }
        }
    }
}
