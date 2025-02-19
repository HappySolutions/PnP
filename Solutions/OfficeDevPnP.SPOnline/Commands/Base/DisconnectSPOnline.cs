﻿using OfficeDevPnP.SPOnline.CmdletHelpAttributes;
using System;
using System.Management.Automation;

namespace OfficeDevPnP.SPOnline.Commands.Base
{
    [Cmdlet("Disconnect", "SPOnline")]

    [CmdletHelp("Disconnects the context")]
    [CmdletExample(
        Code = @"PS:> Disconnect-SPOnline")]
    public class DisconnectSPOnline : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            if (!DisconnectSPOnline.DisconnectCurrentService())
                throw new InvalidOperationException(OfficeDevPnP.SPOnline.Commands.Properties.Resources.NoConnectionToDisconnect);
        }

        internal static bool DisconnectCurrentService()
        {
            if (SPOnlineConnection.CurrentConnection == null)
                return false;
            SPOnlineConnection.CurrentConnection = (SPOnlineConnection)null;
            return true;
        }
    }
}
