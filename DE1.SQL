-- Create a new database called 'DE01'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
  SELECT name
    FROM sys.databases
    WHERE name = N'DE01'
)
CREATE DATABASE DE01
GO

USE DE01
set DATEFORMAT dmy
CREATE TABLE TACGIA 
(
  MaTG char(5) NOT NULL,
  HoTen varchar(20),
  DiaChi varchar(50),
  NgSinh smalldatetime,
  SoDT varchar(15),
  CONSTRAINT PK_TACGIA PRIMARY KEY (MaTG),
);

CREATE TABLE SACH 
(
  MaSach char(5) NOT NULL,
  TenSach varchar(25),
  TheLoai varchar(25),
  CONSTRAINT PK_SACH PRIMARY KEY (MaSach),
);

CREATE TABLE TACGIA_SACH 
(
  MaTG char(5) NOT NULL,
  MaSach char(5) NOT NULL,
  CONSTRAINT PK_TACGIA_SACH PRIMARY Key (MaTG,MaSach),
  CONSTRAINT FK_TACGIA FOREIGN KEY (MaTG) REFERENCES TACGIA(MaTG),
  CONSTRAINT FK_SACH FOREIGN KEY (MaSach) REFERENCES SACH(MaSach),
);

CREATE TABLE PHATHANH 
(
  MaPH char(5),
  MaSach char(5),
  NgayPH smalldatetime,
  SoLuong int,
  NhaXuatBan varchar(20),
  CONSTRAINT PK_PHATHANH PRIMARY KEY (MaPH),
  CONSTRAINT FK_TACGIA FOREIGN KEY (MaSach) REFERENCES SACH(MaSach)
);

ALTER TABLE PHATHANH
ADD CONSTRAINT CHECK_21 CHECK (NgPH >

(SELECT NgSinh
From (TACGIA INNER JOIN TACGIA_SACH
ON TACGIA.MaTG = TACGIA_SACH.MaTG)
WHERE PHATHANH.MaSach = MaSach)) 
