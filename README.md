[![Devart MCP Server for Salesforce](https://github.com/devart-ai-connectivity/.github/blob/main/assets/cover-banner-mcp-server-for-salesforce.webp?raw=true)](https://www.devart.com/mcp/)

# Devart MCP Server for Salesforce

Devart MCP Server for Salesforce enables AI clients to interact with your data through a secure server running in your environment. It turns a regular AI chat into a practical way to work with real-world business data — and it is faster than conventional export or manual querying.

## Key benefits

Devart MCP Server for Salesforce allows you to:

* Work with data intuitively through natural language.
* Retrieve the required data for analysis within minutes.
* Report on your data faster with AI-powered assistance.
* Minimize manual data handling and integration maintenance.

## How it works

Devart MCP Server for Salesforce helps AI clients communicate directly with Salesforce databases using natural-language prompts. It translates AI requests into structured queries, executes them through Devart connectivity drivers, and returns clean, structured results for seamless AI-powered data access.

![Devart MCP Server architecture](https://github.com/devart-ai-connectivity/.github/blob/main/assets/how_mcp_works_single.webp?raw=true)

## Quick start

To get started with Devart MCP Server for Salesforce:

1\. [Download](https://www.devart.com/odbc/salesforce/download.html) and [install](https://docs.devart.com/odbc-driver-for-salesforce/installation/) Devart ODBC Driver for Salesforce.

2\. [Download](https://www.devart.com/mcp/download.html) and [install](https://docs.devart.com/mcp/installation.html) Devart MCP Server for Salesforce.

3\. In Devart MCP Server for Salesforce, [configure your data connection and integration settings](https://docs.devart.com/mcp/connection-configuration.html).

![Devart MCP Server configuration](https://github.com/devart-ai-connectivity/.github/blob/main/assets/mcp-servers-gui.webp?raw=true)

4\. Run your first natural-language query.

[![Need an MCP Server for multiple data sources?](https://github.com/devart-ai-connectivity/.github/blob/main/assets/need-mcp-server-universal.webp?raw=true)](https://www.devart.com/mcp/universal/)


## Manual installation and configuration 

**Prerequisites** 

Before building and running Devart MCP Server for Salesforce, ensure the following components are installed:

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* **ADO.NET connection** — **Devart.AI.McpServer.AdoNet.Salesforce.csproj** Devart dotConnect for Salesforce (installed automatically via NuGet during build)
* **ODBC connection** — **Devart.AI.McpServer.Odbc.Salesforce.csproj** [Devart ODBC Driver for Salesforce](https://www.devart.com/odbc/salesforce/download.html) (requires manual download and installation)

**Step 1: Clone the repository**

Clone the project repository and navigate to the project directory:

1\. Open **Command Prompt**.

2\. Enter the following command:

```cmd
git clone https://github.com/devart-ai-connectivity/devart-mcp-server-salesforce.git
cd devart-mcp-server-salesforce
```

**Step 2: Build the MCP Server from source**

You can build Devart MCP Server for Salesforce from source using either of the supported database connectivity technologies: ADO.NET or ODBC.

* To build the MCP server with ADO.NET, run the following command:

```cmd
dotnet publish Devart.AI.McpServer.AdoNet/Devart.AI.McpServer.AdoNet.Salesforce/Devart.AI.McpServer.AdoNet.Salesforce.csproj -c ReleaseSalesforce /p:TargetFramework=net8.0
```
The Devart dotConnect for Salesforce NuGet package is downloaded and restored automatically.

* To build the MCP server with ODBC, select the command based on the bitness of your data source.

For 64-bit data source, run the following command:

```cmd
dotnet publish Devart.AI.McpServer.Odbc/Devart.AI.McpServer.Odbc.Salesforce/Devart.AI.McpServer.Odbc.Salesforce.csproj -c ReleaseSalesforce -r "win-x64" /p:TargetFramework=net8.0
```

For 32-bit data source, run the following command:

```cmd
dotnet publish Devart.AI.McpServer.Odbc/Devart.AI.McpServer.Odbc.Salesforce/Devart.AI.McpServer.Odbc.Salesforce.csproj -c ReleaseSalesforce -r "win-x86" /p:TargetFramework=net8.0
```
>**Note**
>
>The target platform must match the bitness of your ODBC data source.

**Step 3: Configure the database connection for the MCP Server**

1\. Create an `mcpserver.json` configuration file in the directory containing the built MCP Server executable.

2\. In the file, configure the database connection.

* Configure a connection with ADO.NET.

Add the following configuration to the `mcpserver.json` file:

```json
{
  "Connections": [
    {
      "Name": "my_salesforce",
      "ConnectionString": "Server=localhost;User Id=salesforce;Password=your_password;Database=your_database;",
      "ProtocolType": "stdio"
    }
  ]
}
```

* Configure a connection with ODBC.

Add the following configuration to the `mcpserver.json` file:

```json
{
  "Connections": [
    {
      "Name": "my_salesforce",
      "DsnName": "your_dsn_name",
      "ProtocolType": "stdio"
    }
  ]
}
```

* Configure a connection with ODBC using a connection string.

Add the following configuration to the `mcpserver.json` file:

```json
{
  "Connections": [
    {
      "Name": "my_salesforce",
      "ConnectionString": "Driver={Devart ODBC Driver for Salesforce};Server=localhost;User ID=salesforc;Password=your_password;Database=your_database;",
      "ProtocolType": "stdio"
    }
  ]
}
```
where:

* `Name` — The connection name.

* `ConnectionString` (applies to ADO.NET) — A database-specific connection string used to establish a connection to the target database.

* `DsnName` (applies to ODBC) — The name of your data source.

* `ProtocolType` — A transport protocol. The possible options are: `stdio` or `http`.

* `HttpPort` (required if `ProtocolType` is set to `http`) — The port number for the `http` protocol. 

**Step 4: Run the MCP server**

After you configure the MCP Server, you can start it. 

>**Note**
>
>This step is required only when `ProtocolType` is configured as `http`. If you use the `stdio` transport protocol, your AI client starts the server automatically.

* To start the server with ADO.NET, run the following command:

```cmd
Devart.AI.McpServer.AdoNet.Salesforce.exe run my_salesforce
```

* To start the server with ODBC, run the following command:

```cmd
Devart.AI.McpServer.Odbc.Salesforce.exe run my_salesforce
```

where `my_salesforce` is the name of the ODBC connection.

**Step 5: Integrate with Claude Desktop**

1\. Open `claude_desktop_config.json`, the Claude configuration file.

>**Tip**
>
>If you can't locate the configuration file, it may not exist yet. To create it, open Claude Desktop and navigate to **File** > **Settings** > **Developer**, then click **Edit Config**. The folder with the `claude_desktop_config.json` file opens.

2\. Add one of the following objects, depending on the transport protocol used by MCP Server:

* STDIO

```json
{
  "mcpServers": {
    "devart": {
      "command": "C:\\path\\to\\Devart.AI.McpServer.AdoNet.Salesforce.exe",
      "args": [
        "run",
        "my_salesforcee"
      ]
    }
  }
}
```

 where:

  * `devart` is the connector name that will appear in Claude Desktop.
  * `C:\\path\\to\\Devart.AI.McpServer.AdoNet.Salesforce.exe` is the path to the executable file. For an ODBC connection, use `Devart.AI.McpServer.Odbc.Salesforce.exe`.
  * `my_salesforce` is the connection name specified in the `mcpserver.json` configuration file.

* **HTTP**

  ```json
    "mcpServers": {
      "devart": {
        "command": "npx",
        "args": [
          "-y",
          "mcp-remote",
          "http://localhost:5000/sse"
        ]
      }
    }
  ```

  where:

  * `devart` is the connector name that will appear in Claude Desktop.
  * `5000` is the MCP Server listening port.

3\. Save the file.

4\. Restart Claude Desktop.

Devart MCP Server for Salesforce is now integrated with Claude, and **devart** appears in the Claude Desktop app in **Customize** > **Connectors**.

You can also [integrate](https://docs.devart.com/mcp/ai-integration/) Devart MCP Server for Salesforce with other AI clients such as Cline, Codex, Cursor, Visual Studio Code, Windsurf, Zed.

## Supported clients

Devart MCP Server for Salesforce supports integration with the following AI clients: 
 
* Claude Desktop
* Visual Studio Code
* Cursor
* Codex
* Windsurf
* Cline
* Zed
* ...and other MCP-compatible AI clients

## Typical use cases

Devart MCP Server for Salesforce is a practical fit for teams working with Salesforce as their primary data source.

* **Pipeline and revenue forecasting**  
  Let sales leaders query opportunity stages, weighted pipeline values, historical close rates, and forecast accuracy directly from Salesforce.

* **Account and contact intelligence**  
  Access account hierarchies, contact roles, interaction histories, and engagement timelines from Salesforce for account planning and research.

* **Service cloud case analysis**  
  Query Salesforce Service Cloud case volumes, escalation rates, resolution times, and customer satisfaction scores in natural language.

* **Lead and opportunity conversion analysis**  
  Analyze lead sources, conversion rates, stage progression, and win/loss patterns across Salesforce opportunity data.

* **Activity and engagement tracking**  
  Retrieve call logs, email activity, task completions, and event histories from Salesforce to understand rep activity and customer engagement.

* **Custom object and field exploration**  
  Use AI to explore custom Salesforce objects, managed package data, and complex schema relationships in heavily customized Salesforce orgs.

## Licensing and activation

Devart MCP Server for Salesforce is distributed as a free single-source MCP server.

To connect to Salesforce, the server requires the corresponding [Devart ODBC Driver for Salesforce](https://www.devart.com/odbc/salesforce/), which is a paid product.

A 30-day free trial is available for the Devart ODBC Driver for Salesforce.

See the product page and documentation for the latest installation and activation details.

## Support

* [Documentation](https://docs.devart.com/mcp/)
* [Submit a request](https://www.devart.com/company/contactform.html)
* [Suggest a feature](https://devart.uservoice.com/)
* [Join our forum](https://support.devart.com/portal/en/community)

## Other Devart connectivity solutions

* [MCP Server Universal](https://github.com/devart-ai-connectivity/devart-mcp-server-universal)
* [ODBC Driver for Salesforce](https://www.devart.com/odbc/salesforce/)
* [dotConnect ADO.NET Provider for Salesforce](https://www.devart.com/dotconnect/salesforce/)
