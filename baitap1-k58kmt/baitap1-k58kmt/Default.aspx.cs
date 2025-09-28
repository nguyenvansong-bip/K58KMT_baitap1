using System;
using System.Web;
using System.Web.UI;
using MultiToolLib;  // DLL của bạn

public partial class api : Page
{
    private MultiTool tool = new MultiTool();

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentType = "application/json";

        try
        {
            string action = Request["action"];
            string payload = Request["payload"];
            string key = Request["key"];

            string result = "";
            bool success = true;

            if (string.IsNullOrEmpty(action))
            {
                success = false;
                result = "No action specified";
            }
            else if (action == "solve")
            {
                result = tool.SolveExpression(payload);
            }
            else if (action == "sig")
            {
                result = tool.GenerateSignature(payload);
            }
            else if (action == "cipher")
            {
                result = tool.SongCipher(payload, key);
            }
            else
            {
                success = false;
                result = "Unknown action";
            }

            string safeResult = JsonEscape(result);

            Response.Write("{ \"success\": " + success.ToString().ToLower() +
                           ", \"result\": \"" + safeResult + "\" }");
        }
        catch (Exception ex)
        {
            string safeError = JsonEscape(ex.Message);
            Response.Write("{ \"success\": false, \"message\": \"" + safeError + "\" }");
        }
    }

    // Hàm escape JSON cho .NET 2.0
    private string JsonEscape(string s)
    {
        if (s == null) return "";
        return s.Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\r", "\\r")
                .Replace("\n", "\\n");
    }
}
