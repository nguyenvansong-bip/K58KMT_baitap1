# K58KMT_
TẠO SOLUTION GỒM CÁC PROJECT SAU:

DLL đa năng, keyword: c# window library -> Class Library (.NET Framework) bắt buộc sử dụng .NET Framework 2.0: giải bài toán bất kỳ, độc lạ càng tốt, phải có dấu ấn cá nhân trong kết quả, biên dịch ra DLL. DLL độc lập vì nó ko nhập, ko xuất, nó nhận input truyền vào thuộc tính của nó, và trả về dữ liệu thông qua thuộc tính khác, hoặc thông qua giá trị trả về của hàm. Nó độc lập thì sẽ sử dụng được trên app dạng console (giao diện dòng lệnh - đen sì), cũng sử dụng được trên app desktop (dạng cửa sổ), và cũng sử dụng được trên web form (web chạy qua iis).

Console app, bắt buộc sử dụng .NET Framework 2.0, sử dụng được DLL trên: nhập được input, gọi DLL, hiển thị kết quả, phải có dấu án cá nhân. keyword: c# window Console => Console App (.NET Framework), biên dịch ra EXE

Windows Form Application, bắt buộc sử dụng .NET Framework 2.0**, sử dụng được DLL đa năng trên, kéo các control vào để có thể lấy đc input, gọi DLL truyền input để lấy đc kq, hiển thị kq ra window form, phải có dấu án cá nhân; keyword: c# window Desktop => Windows Form Application (.NET Framework), biên dịch ra EXE

Web đơn giản, bắt buộc sử dụng .NET Framework 2.0, sử dụng web server là IIS, dùng file hosts để tự tạo domain, gắn domain này vào iis, file index.html có sử dụng html css js để xây dựng giao diện nhập được các input cho bài toán, dùng mã js để tiền xử lý dữ liệu, js để gửi lên backend. backend là api.aspx, trong code của api.aspx.cs thì lấy được các input mà js gửi lên, rồi sử dụng được DLL đa năng trên. kết quả gửi lại json cho client, js phía client sẽ nhận được json này hậu xử lý để thay đổi giao diện theo dữ liệu nhận dược, phải có dấu án cá nhân. keyword: c# window web => ASP.NET Web Application (.NET Framework) + tham khảo link chatgpt thầy gửi. project web này biên dịch ra DLL, phải kết hợp với IIS mới chạy được.

1. thư viện MultiToolLib của chương trình:

<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/68bf4df4-4375-4233-bd30-f999e24b4dfb" />

2. trang web HTML tĩnh dùng để tạo giao diện cho ứng dụng MultiTool Web – Văn Song Nguyễn. Nó cho phép người dùng nhập dữ liệu, chọn thao tác, và nhận kết quả xử lý từ phía server thông qua file api.aspx.

🧠 Chức năng của trang web này:
🎨 Giao diện người dùng gồm:
Ô nhập dữ liệu (txtInput)

Ô nhập key (txtKey) – dùng cho mã hóa

3 nút thao tác:

Solve: giải biểu thức toán học

Signature: tạo chữ ký ASCII

Cipher: mã hóa chuỗi bằng thuật toán SongCipher

🔁 Khi người dùng nhấn nút:
Hàm callApi(action) được gọi.

Dữ liệu được gửi đến api.aspx bằng phương thức POST.

Kết quả trả về từ server sẽ hiển thị trong vùng <pre id="output">.

🔧 Kỹ thuật sử dụng:
Dùng JavaScript để gửi yêu cầu AJAX đến api.aspx.

Dùng XMLHttpRequest để tương thích với trình duyệt cũ (phù hợp .NET Framework 2.0).

Dữ liệu được mã hóa bằng encodeURIComponent để tránh lỗi khi gửi tiếng Việt hoặc ký tự đặc biệt.

<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/037f7ac0-4961-4d9a-8a18-1ef17df52bde" />

3. Console ứng dụng đa năng viết bằng C#, hoàn toàn tương thích với .NET Framework 2.0. Đây là phiên bản đơn giản của MultiTool Console, cho phép người dùng thực hiện ba thao tác chính:

🎯 Chức năng chính của chương trình
1. 🔢 Giải biểu thức toán học
Người dùng nhập biểu thức như 2+3*4.

Chương trình dùng DataTable.Compute() để tính toán.


<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/be6db99b-602c-44c6-a4e8-b4de1974f0f2" />

4.Đây là file Form1.Designer.cs, chứa mã do Visual Studio sinh ra để xây dựng giao diện cho cửa sổ Form1. Nó không xử lý logic, mà chỉ định vị trí, kích thước và thuộc tính của các điều khiển như:

TextBox để nhập dữ liệu và khóa

ComboBox để chọn thao tác

Button để thực thi

PictureBox để hiển thị hình ảnh chữ ký (nếu có)

🧩 Các thành phần giao diện
Điều khiển	Mục đích sử dụng
textBoxInput	Nhập dữ liệu đầu vào
textBoxKey	Nhập khóa dùng cho mã hóa
comboBoxAction	Chọn thao tác: Solve, Signature, Cipher
buttonRun	Nhấn để thực hiện thao tác đã chọn
textBoxOutput	Hiển thị kết quả xử lý
pictureBoxSignature	Hiển thị hình ảnh chữ ký (nếu có)

<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/36ad2788-cbf7-4299-8190-31e618b9d9ca" />




