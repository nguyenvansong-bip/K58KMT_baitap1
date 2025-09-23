using System;
using System.Web;
using System.Web.UI;
using MultiToolLib;  // dùng DLL bạn đã tạo

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
            string key = Request["key"];https://localhost:44350/Default.aspx.cs

            string result = "";

            if (action == "solve")
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
                result = "{ \"success\": false, \"message\": \"Unknown action\" }";
            }

            Response.Write(result);
        }
        catch (Exception ex)
        {
            Response.Write("{ \"success\": false, \"message\": \"Error: " + ex.Message + "\" }");
        }
    }
}
