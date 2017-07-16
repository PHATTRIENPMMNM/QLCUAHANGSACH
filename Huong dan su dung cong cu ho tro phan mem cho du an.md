











## 1.Hướng dẫn thao tác CSDL  IBM- DB2<br>
-	Link download : <br>https://www.ibm.com/developerworks/downloads/im/db2express/ 
-	Sau khi download thực hiện quá trình cài đặt <br>
+ Giao diện cài đặt – click vào Install a product – Next –Next . <br>
 
+ Tới phần này điền User và mật khẩu ( cần phải ghi nhớ để sử dụng về sau) <br>
 
+ Cuối cùng đợi Finish hoàn thành cài đặt<br>
 
-	Tiếp theo khởi động DB2 Commad Line sẽ ra giao diện <br>

-	Tạo CSDL Quản Lí Nhà Sách( Create database QLTL) đợi khoảng 5-7 phút<br>

-	Sau đó thực hiện connect với CSDL QLTL (connect to QLTL user (tên đăng nhập)  và mật khẩu) <br>
 
Tiếp theo tiến hành tạo các bảng cơ sở dự liệu cần có của dự án: <br>
Ví du : tạo bảng CSDL bảng tài khoản<br>

	Trên đây là toàn bộ hướng dẫn về CSDL DB2 liên quan đến những công cụ hỗ trợ xây dựng dự án , các thắc mắc các bạn có thể truy cập link bên dưới để biết thêm kiến thức về CSDL DB2<br>
https://www.ibm.com/developerworks/vn/library/contest/dw-freebooks/Nhap_Mon_DB2_ExpressC/Nhap_mon_DB2_ExpressC_v9.7.pdf 
## 2.Hướng dẫn cài đặt Web Server (Apache) trong bộ cài đặt Xampp<br>
-	Cần lưu ý cài đặt xampp và bản vá hỗ trợ IBM DB2 tương ứng <br>
https://sourceforge.net/projects/xampp/files/XAMPP%20Windows/5.5.38/ <br>
http://php.net/manual/en/book.ibm-db2.php  <br>
-	Sau khi cài đặt xampp đừng vội khởi động sớm trước tiên hãy giải nén file IBM ra trước<br>
-	Bỏ file vừa gải nén vào c:/xampp/php/etc,  sau đó thêm dòng này extension = php_ibm_db2.dll vào dưới dòng extension=php_gettext.dll của file c:/xampp/php/php.ini . Do chỉ có bản cũ này mới có link ibm phù hợp.
-	Hãy thử test với đoạn code sau để xem kết nối có thành công không<br>









        
-	Tạo file test.php  trong htdocs với nội dung code như trên , sau đó khởi động xampp , start Apache . <br>
-	Mở trình duyệt web lên truy cập ( localhost/test.php) nếu thành công có nghĩa là xampp đã kết nối với CSDL DB2 . <br>
-	Sau đó Download source Code của Web đã cung cấp bỏ vào htdocs , chạy localhost/WebSach/login . Tiếp tục với các tính năng của trang Web



