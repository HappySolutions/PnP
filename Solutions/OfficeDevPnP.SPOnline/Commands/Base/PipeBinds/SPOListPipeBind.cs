﻿using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDevPnP.SPOnline.Commands.Base.PipeBinds
{
    public sealed class SPOListPipeBind
    {
        private SPOList _onlineList;
        private List _list;
        private Guid _id;
        private string _name;

        public SPOListPipeBind()
        {
            _onlineList = null;
            _list = null;
            _id = Guid.Empty;
            _name = string.Empty;
        }

        public SPOListPipeBind(SPOList list)
        {
            this._onlineList = list;
        }

        public SPOListPipeBind(List list)
        {
            this._list = list;
        }

        public SPOListPipeBind(Guid guid)
        {
            this._id = guid;
        }

        public SPOListPipeBind(string id)
        {
            if (!Guid.TryParse(id, out _id))
            {
                this._name = id;
            }
        }

        public Guid Id
        {
            get { return _id; }
        }

        public List List
        {
            get
            {
                if (_onlineList != null)
                {
                    return _onlineList.ContextObject;
                }
                else
                {
                    return _list;
                }
            }
        }

        public string Title
        {
            get { return _name; }
        }
    }
}
