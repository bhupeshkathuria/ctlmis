using System;
using System.Collections.Generic;
using System.Text;

namespace Clay.Invoice.Bll
{
    public class ConvertName
    {
        public string ConvertNameAll(string myName)
        {
            myName = myName.Trim();
            if (myName.ToUpper() == "USAGE")
            {
                myName = myName + "_";
            }
            myName = myName.Replace(" ", "_");
            myName = myName.Replace("-", "_");
            myName = myName.Replace(".", "_");
            myName = myName.Replace("#", "_");
            myName = myName.Replace("/", "_");
            myName = myName.Replace("\\", "_");
            return myName;

        }
    }
}
