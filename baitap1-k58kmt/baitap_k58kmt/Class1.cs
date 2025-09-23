// MultiTool.cs (.NET Framework 2.0 compatible)
using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace MultiToolLib
{
    public class MultiTool
    {
        private const string Watermark = "— Văn Song Nguyễn";

        // 1) Giải biểu thức toán học
        public string SolveExpression(string expr)
        {
            if (string.IsNullOrEmpty(expr))
                return MakeResult(false, "Empty expression");

            try
            {
                expr = expr.Replace("^", "**");
                if (expr.Contains("**"))
                {
                    string[] parts = expr.Split(new string[] { "**" }, StringSplitOptions.None);
                    if (parts.Length == 2)
                    {
                        double a = Convert.ToDouble(new DataTable().Compute(parts[0], ""));
                        double b = Convert.ToDouble(new DataTable().Compute(parts[1], ""));
                        double r = Math.Pow(a, b);
                        return MakeResult(true, r.ToString(), "Expr=" + expr + " " + Watermark);
                    }
                }

                object value = new DataTable().Compute(expr, "");
                return MakeResult(true, value.ToString(), "Expr=" + expr + " " + Watermark);
            }
            catch (Exception ex)
            {
                return MakeResult(false, "Error: " + ex.Message);
            }
        }

        // 2) ASCII Signature
        public string GenerateSignature(string name)
        {
            if (string.IsNullOrEmpty(name)) name = "ANONYMOUS";
            name = name.Trim().ToUpper();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("╔" + new string('═', name.Length + 10) + "╗");
            sb.AppendLine("║  ► " + name + " - UNIQUE TOOL  ◄  ║");
            sb.AppendLine("║  " + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "  " + Watermark + "  ║");
            sb.AppendLine("╚" + new string('═', name.Length + 10) + "╝");
            sb.AppendLine();
            for (int i = 0; i < name.Length; i++)
            {
                sb.Append(new string(' ', i));
                sb.AppendLine("* " + name[i] + " *");
            }
            return sb.ToString();
        }

        // 3) SongCipher
        public string SongCipher(string input, string key)
        {
            if (input == null) input = "";
            if (string.IsNullOrEmpty(key)) key = "SONGDEFAULT";

            byte[] inBytes = Encoding.UTF8.GetBytes(input);
            byte[] kBytes = Encoding.UTF8.GetBytes(key);
            byte[] outBytes = new byte[inBytes.Length];

            for (int i = 0; i < inBytes.Length; i++)
            {
                byte b = inBytes[i];
                byte k = kBytes[i % kBytes.Length];
                byte r = (byte)((b ^ k) & 0xFF);
                int shift = k % 8;
                outBytes[i] = (byte)(((r << shift) | (r >> (8 - shift))) & 0xFF);
            }

            return Convert.ToBase64String(outBytes);
        }

        // 4) Process JSON input (tối giản, chỉ parse key-value string)
        public string ProcessJsonInput(string json)
        {
            if (string.IsNullOrEmpty(json))
                return MakeResult(false, "Empty json");

            try
            {
                Dictionary<string, string> obj = ParseSimpleJson(json);

                string action = obj.ContainsKey("action") ? obj["action"] : "";
                if (action == "solve" && obj.ContainsKey("payload"))
                {
                    return SolveExpression(obj["payload"]);
                }
                else if (action == "sig" && obj.ContainsKey("payload"))
                {
                    string sig = GenerateSignature(obj["payload"]);
                    return MakeResult(true, sig);
                }
                else if (action == "cipher" && obj.ContainsKey("payload") && obj.ContainsKey("key"))
                {
                    string res = SongCipher(obj["payload"], obj["key"]);
                    return MakeResult(true, res);
                }
                else
                {
                    return MakeResult(false, "Unknown action or missing payload");
                }
            }
            catch (Exception ex)
            {
                return MakeResult(false, "JSON parse error: " + ex.Message);
            }
        }

        // Helper JSON parser (very simple, chỉ xử lý string key-value)
        private Dictionary<string, string> ParseSimpleJson(string json)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            json = json.Trim().Trim('{', '}').Trim();

            string[] parts = json.Split(',');
            foreach (string part in parts)
            {
                string[] kv = part.Split(':');
                if (kv.Length == 2)
                {
                    string key = kv[0].Trim().Trim('"');
                    string val = kv[1].Trim().Trim('"');
                    dict[key] = val;
                }
            }
            return dict;
        }

        // Helper result (manual JSON build)
        private string MakeResult(bool ok, string message, string note = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"success\":\"").Append(ok ? "true" : "false").Append("\",");
            sb.Append("\"message\":\"").Append(EscapeJson(message)).Append("\",");
            sb.Append("\"note\":\"").Append(EscapeJson(note ?? Watermark)).Append("\"");
            sb.Append("}");
            return sb.ToString();
        }

        private string EscapeJson(string s)
        {
            if (s == null) return "";
            return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
        }
    }
}
