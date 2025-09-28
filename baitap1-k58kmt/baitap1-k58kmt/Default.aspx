<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="utf-8" />
    <title>MultiTool Web - Văn Song Nguyễn</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #6a11cb, #2575fc);
            color: #fff;
            margin: 0;
            padding: 0;
            min-height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .container {
            background: rgba(255, 255, 255, 0.1);
            padding: 30px;
            border-radius: 15px;
            box-shadow: 0 8px 20px rgba(0,0,0,0.3);
            width: 480px;
            text-align: center;
        }

        h2 {
            margin-bottom: 20px;
            font-size: 22px;
            font-weight: bold;
            text-shadow: 1px 1px 3px rgba(0,0,0,0.4);
        }

        input[type="text"] {
            width: 90%;
            padding: 12px;
            margin: 10px 0;
            border-radius: 8px;
            border: none;
            outline: none;
            font-size: 14px;
        }

        .radio-group {
            margin: 15px 0;
            text-align: left;
            padding-left: 20px;
        }

        .radio-group label {
            margin-right: 15px;
            font-size: 14px;
        }

        button {
            background: linear-gradient(90deg, #ff512f, #dd2476);
            border: none;
            padding: 12px 25px;
            margin: 8px;
            border-radius: 25px;
            color: white;
            font-size: 14px;
            font-weight: bold;
            cursor: pointer;
            transition: all 0.3s ease;
            box-shadow: 0 4px 10px rgba(0,0,0,0.3);
        }

        button:hover {
            transform: scale(1.08);
            background: linear-gradient(90deg, #dd2476, #ff512f);
        }

        h3 {
            margin-top: 20px;
            font-size: 18px;
            border-bottom: 1px solid rgba(255,255,255,0.4);
            padding-bottom: 5px;
        }

        pre {
            background: rgba(0,0,0,0.4);
            padding: 15px;
            border-radius: 10px;
            white-space: pre-wrap;
            word-wrap: break-word;
            text-align: left;
            max-height: 200px;
            overflow-y: auto;
        }
    </style>

    <script>
        function callApi() {
            var payload = document.getElementById("txtInput").value;
            var key = document.getElementById("txtKey").value;

            // Lấy action được chọn từ radio
            var action = document.querySelector('input[name="action"]:checked');
            if (!action) {
                document.getElementById("output").innerText = "⚠ Vui lòng chọn thao tác!";
                return;
            }
            action = action.value;

            var xhr = new XMLHttpRequest();
            xhr.open("POST", "api.aspx", true);
            xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            xhr.onreadystatechange = function () {
                if (xhr.readyState === 4 && xhr.status === 200) {
                    try {
                        var res = JSON.parse(xhr.responseText);
                        if (res.success) {
                            document.getElementById("output").innerText = res.result;
                        } else {
                            document.getElementById("output").innerText = "❌ " + res.message;
                        }
                    } catch (e) {
                        document.getElementById("output").innerText = xhr.responseText;
                    }
                }
            };
            xhr.send("action=" + action + "&payload=" + encodeURIComponent(payload) + "&key=" + encodeURIComponent(key));
        }
    </script>
</head>
<body>
    <div class="container">
        <h2>MultiTool Web - Văn Song Nguyễn</h2>
        <input type="text" id="txtInput" placeholder="Nhập dữ liệu" />
        <input type="text" id="txtKey" placeholder="Nhập key (cho Cipher)" />

        <div class="radio-group">
            <label><input type="radio" name="action" value="solve" /> Solve</label>
            <label><input type="radio" name="action" value="sig" /> Signature</label>
            <label><input type="radio" name="action" value="cipher" /> Cipher</label>
        </div>

        <button onclick="callApi()">Kết quả</button>

        <h3>Kết quả:</h3>
        <pre id="output"></pre>
    </div>
</body>
</html>
