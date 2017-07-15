//tao csdl
create database QLCHS

//Tao bang Nhan vien<br>
CREATE TABLE NHANVIEN(MANV VARGRAPHIC(10) NOT NULL PRIMARY KEY, HONV VARGRAPHIC(30) NOT NULL, TENNV VARGRAPHIC(30),DIACHI VARGRAPHIC(70),GIOITINH SMALLINT NOT NULL, SDT VARCHAR(15) NOT NULL)

//Tao bang Khach hang<br>
CREATE TABLE KHACHHANG(MAKH VARGRAPHIC(10) NOT NULL PRIMARY KEY, TENKH VARGRAPHIC(30) NOT NULL, DIACHIKH VARGRAPHIC(70) NOT NULL, SDTKH VARCHAR(15) NOT NULL)

//Tao bang Nha xuat ban<br>
CREATE TABLE NXB(MANXB VARGRAPHIC(10) NOT NULL PRIMARY KEY, TENNXB VARGRAPHIC(30) NOT NULL, DIACHINXB VARGRAPHIC(70) NOT NULL, SDTNXB VARCHAR(15) NOT NULL)

//Tao bang Loai sach<br>
CREATE TABLE LOAISACH(MASACH VARGRAPHIC(10) NOT NULL PRIMARY KEY, TENSACH VARGRAPHIC(30) NOT NULL, SOLUONGNHAP INTEGER NOT NULL,GIABAN INTEGER CHECK(GIABAN>=), MANXB VARGRAPHIC(10) FOREIGN REFERENCES NXB(MANXB)ON DELETE CASCADE)

//Tao bang Hoa don<br>
CREATE TABLE HOADON(MAHD VARGRAPHIC(10) NOT NULL PRIMARY KEY, MAKH VARGRAPHIC(10) NOT NULL FOREIGNA REFERENCES KHACHHANG(MAKH),MANV VARGRAPHIC(10) NOT NULL FOREIGNC REFERENCES NHANVIEN(MANV) ON DELETE CASCADE, NGAYLAPHD DATE)

//Tao bang Chi tiet hoa don<br>
CREATE TABLE CTHD(MACTHD VARGRAPHIC(10) NOT NULL PRIMARY KEY, MAHD VARGRAPHIC(10) NOT NULL FOREIGNA REFERENCES HOADON(MAHD), MASACH VARGRAPHIC(10) NOT NULL FOREIGNB REFERENCES LOAISACH(MASACH)ON DELETE CASCADE, SOLUONG INTEGER NOT NULL)

//Tao bang tai khoan<br>
CREATE TABLE TAIKHOAN(TENDN VARGRAPHIC(10) NOT NULL PRIMARY KEY, MATKHAU VARGRAPHIC(10) NOT NULL)

//Mot vai vi du ve them du lieu vao bang(vi du bang nhan vien, may bang kia lam tuong tu)<br>
INSERT INTO LONG.NHANVIEN values('nv1','Le','Nga''Nha Trang','0','0123464568')
INSERT INTO LONG.NHANVIEN values('nv2','Tran','Hang''Phu Yen','0','0123156563')
INSERT INTO LONG.NHANVIEN values('nv3','Huynh','Khang','Nha Trang','1','093565325')