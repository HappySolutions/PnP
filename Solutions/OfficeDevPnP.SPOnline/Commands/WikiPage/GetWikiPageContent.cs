﻿using OfficeDevPnP.SPOnline.Commands.Base;
using Microsoft.SharePoint.Client;
using System.Management.Automation;
using Microsoft.SharePoint.Client.WebParts;

namespace OfficeDevPnP.SPOnline.Commands
{
    [Cmdlet(VerbsCommon.Get, "SPOWikiPageContent")]
    public class GetWikiPageContent : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        public string PageUrl = string.Empty;

        protected override void ExecuteCmdlet()
        {
            WriteObject(SPOnline.Core.SPOWikiPage.GetWikiPageContent(PageUrl, SelectedWeb, ClientContext));
        }
    }
}
