using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClayBillingLibrary.UserClass
{
    public class Module
    {
        int _moduleId;

        public int ModuleId
        {
            get { return _moduleId; }
            set { _moduleId = value; }
        }

        string _moduleName;

        public string ModuleName
        {
            get { return _moduleName; }
            set { _moduleName = value; }
        }
    }
}
