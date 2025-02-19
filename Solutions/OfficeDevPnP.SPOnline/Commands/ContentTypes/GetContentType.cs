﻿using OfficeDevPnP.SPOnline.Commands.Base;
using OfficeDevPnP.SPOnline.Commands.Base.PipeBinds;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDevPnP.SPOnline.Commands
{
    [Cmdlet(VerbsCommon.Get, "SPOContentType")]
    public class GetContentType : SPOWebCmdlet
    {
        [Parameter(Mandatory = false)]
        public SPOContentTypePipeBind Identity;

        protected override void ExecuteCmdlet()
        {

            if (Identity != null)
            {
                ContentType ct = null;
                if (!string.IsNullOrEmpty(Identity.Id))
                {
                    ct = this.SelectedWeb.GetContentTypeById(Identity.Id);
                }
                else
                {
                    ct = this.SelectedWeb.GetContentTypeByName(Identity.Name);
                }
                if (ct != null)
                {
                    WriteObject(ct);
                }
            }
            else
            {
                var cts = from ct in SPOnline.Core.SPOContentType.GetContentTypes(this.SelectedWeb, ClientContext)
                          select new SPOContentType(ct);
                WriteObject(cts, true);
            }
        }
    }
}
