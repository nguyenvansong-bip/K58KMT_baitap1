<%@ Page Language="C#" AutoEventWireup="true" %>
<!DOCTYPE html>
<html>
<head>
    <title>MultiTool Web - Văn Song Nguyễn</title>
    <script type="text/javascript">
        function callApi(action) {
            var payload = document.getElementById("txtInput").value;
            var key = document.getElementById("txtKey").value;

            var xhr = new ActiveXObject("Microsoft.XMLHTTP");
            xhr.open("POST", "api.aspx", true);
            xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    document.getElementById("output").innerText = xhr.responseText;
                }
            };
            xhr.send("action=" + action + "&payload=" + escape(payload) + "&key=" + escape(key));
        }
    </script>
</head>
<body>
    <h2>MultiTool Web - Văn Song Nguyễn</h2>
    <input type="text" id="txtInput" placeholder="Nhập dữ liệu" />
    <input type="text" id="txtKey" placeholder="Nhập key (cho Cipher)" />
    <br /><br />
    <button onclick="callApi('solve')">Solve</button>
    <button onclick="callApi('sig')">Signature</button>
    <button onclick="callApi('cipher')">Cipher</button>

    <h3>Kết quả:</h3>
    <pre id="output"></pre>
</body>
</html>
