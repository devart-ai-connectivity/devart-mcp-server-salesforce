// --------------------------------------------------------------------------
// <copyright file="AdoNetSalesforceAppSettings.cs" company="Devart">
//
// Copyright (c) Devart. ALL RIGHTS RESERVED
// Use of the source code is permitted under the license.
// </copyright>
// --------------------------------------------------------------------------

namespace Devart.AI.McpServer.AdoNet.Salesforce
{
  internal sealed class AdoNetSalesforceAppSettings : McpAppSettings
  {
    public override string ServerName => $"Devart {Properties.ProductInfo.ProductFullName}";

    public override string SourceName => "Salesforce";

    public override bool OnPremise => true;
  }
}
