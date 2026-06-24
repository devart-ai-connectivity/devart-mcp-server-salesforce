// --------------------------------------------------------------------------
// <copyright file="OdbcSalesforceTools.cs" company="Devart">
//
// Copyright (c) Devart. ALL RIGHTS RESERVED
// Use of the source code is permitted under the license.
// </copyright>
// --------------------------------------------------------------------------

using System.Collections.Generic;
using ModelContextProtocol.Server;
using Devart.AI.McpServer.Odbc.Salesforce.Tools;

namespace Devart.AI.McpServer.Odbc.Salesforce
{
  internal static class OdbcSalesforceTools
  {
    public static List<McpServerTool> CreateTools(McpConfiguration configuration)
      => OdbcTools.CreateBuilder(configuration)
        .Add(new OdbcSalesforcePrimaryKeysTool(configuration))
        .Add(new OdbcSalesforceForeignKeysTool(configuration))
        .Build();
  }
}
