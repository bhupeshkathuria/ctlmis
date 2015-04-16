using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLCommon
{
    static public class Common
    {
        static int insertuserID;
        static string insertipAddress;
        static int edituserID;
        static string editipAddress;
        static int deleteFlag;
        static int rcode;
        static int loginId;
        static public int PRcode
        {
            get { return Common.rcode; }
            set { Common.rcode = value; }
        }


        static public int LoginId
        {
            get { return Common.loginId; }
            set { Common.loginId = value; }
        }

        static public int InsertUserID
        {
            get
            {
                return insertuserID;
            }
            set
            {
                insertuserID = value;
            }
        }

        static public string InsertIpAddress
        {
            get
            {
                return insertipAddress;
            }
            set
            {
                insertipAddress = value;
            }
        }

        static public int EditUserID
        {
            get
            {
                return edituserID;
            }
            set
            {
                edituserID = value;
            }
        }

        static public string EditIpAddress
        {
            get
            {
                return editipAddress;
            }
            set
            {
                editipAddress = value;
            }
        }

        static public int DeleteFlag
        {
            get
            {
                return deleteFlag;
            }
            set
            {
                deleteFlag = value;
            }
        }

        static private string createQuery;

        static public string PCreateQuery
        {
            get { return createQuery; }
            set { createQuery = value; }
        }

        static private string insertQuery;

        static public string PInsertQuery
        {
            get { return insertQuery; }
            set { insertQuery = value; }
        }

        static private string _itemName;

        static public string PItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        static private string _subItemName;

        static public string PSubItemName
        {
            get { return _subItemName; }
            set { _subItemName = value; }
        }

        static private int statusFlag;

        public static int PStatusFlag
        {
            get { return Common.statusFlag; }
            set { Common.statusFlag = value; }
        }



    }

}
