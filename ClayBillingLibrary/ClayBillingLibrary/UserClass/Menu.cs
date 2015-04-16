using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClayBillingLibrary.UserClass
{
    public class Menu
    {
        int _menuId;
        string _menuText;
        int _parentId;
        int _moduleId;
        string _url;

        public int MenuId
        {
            get { return _menuId; }
            set { _menuId = value; }
        }

        public string MenuText
        {
            get { return _menuText; }
            set { _menuText = value; }
        }

        public int ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }

        public int ModuleId
        {
            get { return _moduleId; }
            set { _moduleId = value; }
        }

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
    }
}
