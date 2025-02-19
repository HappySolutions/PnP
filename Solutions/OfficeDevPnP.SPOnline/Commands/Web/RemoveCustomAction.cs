﻿using OfficeDevPnP.SPOnline.Commands.Base;
using OfficeDevPnP.SPOnline.Commands.Base.PipeBinds;
using Microsoft.SharePoint.Client;
using System.Management.Automation;

namespace OfficeDevPnP.SPOnline.Commands
{
    [Cmdlet(VerbsCommon.Remove, "SPOCustomAction", ConfirmImpact = ConfirmImpact.High)]
    public class RemoveCustomAction : SPOWebCmdlet
    {
        [Parameter(Mandatory = true)]
        public GuidPipeBind Identity;

        [Parameter(Mandatory = false)]
        public SwitchParameter Force;

        protected override void ExecuteCmdlet()
        {
            if (Identity != null)
            {
                if (Force || ShouldContinue(Properties.Resources.RemoveCustomAction, Properties.Resources.Confirm))
                {
                    SPOnline.Core.SPOWeb.DeleteCustomAction(Identity.Id, this.SelectedWeb, ClientContext);
                }
            }
        }
    }
}
