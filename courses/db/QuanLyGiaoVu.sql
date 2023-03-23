-- CREATE DATABASE QuanLyGiaoVu
-- use master
-- alter database QuanLyGiaoVu set single_user with rollback immediate
-- drop DATABASE QuanLyGiaoVu
USE QuanLyGiaoVu
-- I.1.

CREATE TABLE KHOA
(
    MAKHOA varchar(4),
    TENKHOA varchar(40),
    NGTLAP smalldatetime,
    TRGKHOA char(4),
    CONSTRAINT PK_KHOA PRIMARY KEY (MAKHOA),
)

CREATE TABLE MONHOC
(
    MAMH varchar(10),
    TENMH varchar(40),
    TCLT tinyint,
    TCTH tinyint,
    MAKHOA varchar(4),
    CONSTRAINT PK_MONHOC PRIMARY KEY (MAMH),
)

CREATE TABLE DIEUKIEN
(
    MAMH varchar(10),
    MAMH_TRUOC varchar(10),
    CONSTRAINT PK_DIEUKIEN PRIMARY KEY (MAMH, MAMH_TRUOC),
)

CREATE TABLE GIAOVIEN
(
    MAGV char(4),
    HOTEN varchar(40),
    HOCVI varchar(10),
    HOCHAM varchar(10),
    GIOITINH varchar(3),
    NGSINH smalldatetime,
    NGVL smalldatetime,
    HESO numeric(4,2),
    MUCLUONG money,
    MAKHOA varchar(4),
    CONSTRAINT PK_GIAOVIEN PRIMARY KEY (MAGV),
)

CREATE TABLE HOCVIEN
(
    MAHV char(5),
    HO varchar(40),
    TEN varchar(10),
    NGSINH smalldatetime,
    GIOITINH varchar(3),
    NOISINH varchar(40),
    MALOP char(3),
    CONSTRAINT PK_HOCVIEN PRIMARY KEY (MAHV),
)

CREATE TABLE LOP
(
    MALOP char(3),
    TENLOP varchar(40),
    TRGLOP char(5),
    SISO tinyint,
    MAGVCN char(4),
    CONSTRAINT PK_LOP PRIMARY KEY (MALOP),
)

CREATE TABLE GIANGDAY
(
    MALOP char(3),
    MAMH varchar(10),
    MAGV char(4),
    HOCKY tinyint,
    NAM tinyint,
    TUNGAY smalldatetime,
    DENNGAY smalldatetime,
    CONSTRAINT PK_GIANGDAY PRIMARY KEY (MALOP, MAMH),
)

CREATE TABLE KETQUATHI
(
    MAHV char(5),
    MAMH varchar(10),
    LANTHI tinyint,
    NGTHI smalldatetime,
    DIEM numeric(4,2),
    KQUA varchar(10),
    CONSTRAINT PK_KETQUATHI PRIMARY KEY (MAHV, MAMH, LANTHI),
)

ALTER TABLE LOP
    ADD CONSTRAINT FK_TRGLOP FOREIGN KEY (TRGLOP) REFERENCES HOCVIEN(MAHV)

ALTER TABLE LOP
    ADD CONSTRAINT FK_MAGVCN FOREIGN KEY (MAGVCN) REFERENCES GIAOVIEN(MAGV)

ALTER TABLE HOCVIEN
    ADD CONSTRAINT FK_LOP FOREIGN KEY (MALOP) REFERENCES LOP(MALOP)

ALTER TABLE GIAOVIEN
    ADD CONSTRAINT FK_MAKHOA FOREIGN KEY (MAKHOA) REFERENCES KHOA(MAKHOA)

ALTER TABLE GIANGDAY
    ADD CONSTRAINT FK_MAMH FOREIGN KEY (MAMH) REFERENCES MONHOC(MAMH)

ALTER TABLE MONHOC
    ADD CONSTRAINT FK_MAKHOA_2 FOREIGN KEY (MAKHOA) REFERENCES KHOA(MAKHOA)

ALTER TABLE DIEUKIEN
    ADD CONSTRAINT FK_MAMH_TRUOC FOREIGN KEY (MAMH_TRUOC) REFERENCES MONHOC(MAMH)

ALTER TABLE DIEUKIEN
    ADD CONSTRAINT FK_MAMH_2 FOREIGN KEY (MAMH) REFERENCES MONHOC(MAMH)

ALTER TABLE KETQUATHI
    ADD CONSTRAINT FK_MAHV FOREIGN KEY (MAHV) REFERENCES HOCVIEN(MAHV)

ALTER TABLE HOCVIEN
    ADD GHICHU varchar(50), DIEMTB numeric(4,2), XEPLOAI varchar(10)

-- I.3.

ALTER TABLE HOCVIEN
    ADD CONSTRAINT CHK_GTHV CHECK (GIOITINH IN ('Nam', 'Nu'))

ALTER TABLE GIAOVIEN
    ADD CONSTRAINT CHK_GTGV CHECK (GIOITINH IN ('Nam', 'Nu'))

-- I.4.

ALTER TABLE KETQUATHI
    ADD CONSTRAINT CHK_DIEM CHECK
    (
        (DIEM BETWEEN 0 AND 10)
        AND RIGHT(CAST(DIEM AS varchar), 3) LIKE '.__'
    )

-- I.5.

ALTER TABLE KETQUATHI
    ADD CONSTRAINT CHK_KETQUA CHECK
    (
        (KQUA = 'Dat' AND (DIEM BETWEEN 5 AND 10))
        OR (KQUA = 'Khong dat' AND DIEM < 5)
    )

-- I.6.

ALTER TABLE KETQUATHI
    ADD CONSTRAINT CHK_LANTHI CHECK (LANTHI <= 3)

-- I.7.

ALTER TABLE GIANGDAY
    ADD CONSTRAINT CHK_HOCKY CHECK (HOCKY BETWEEN 1 AND 3)

-- I.8.

ALTER TABLE GIAOVIEN
    ADD CONSTRAINT CHK_HOCVI CHECK (HOCVI IN ('CN', 'KS', 'Ths', 'TS', 'PTS'))

-- I.9.

CREATE TRIGGER trg_ins_udt_TRGLOP ON LOP
FOR INSERT, UPDATE
AS
BEGIN
    IF NOT EXISTS
    (SELECT *
    FROM INSERTED I, HOCVIEN HV
    WHERE I.TRGLOP = HV.MAHV
        AND I.MALOP = HV.MALOP)
	BEGIN
        PRINT 'Error: Lop truong cua mot lop phai la hoc vien cua lop do.'
        ROLLBACK TRANSACTION
    END
END

CREATE TRIGGER trg_del_TRGLOP ON HOCVIEN
FOR DELETE
AS
BEGIN
    IF EXISTS (SELECT *
    FROM DELETED D, LOP L
    WHERE D.MAHV = L.TRGLOP
        AND D.MALOP = L.MALOP)
	BEGIN
        PRINT 'Error: Hoc vien hien tai dang la lop truong.'
        ROLLBACK TRANSACTION
    END
END

-- I.11.

ALTER TABLE HOCVIEN
    ADD CONSTRAINT CHK_MATURE CHECK (GETDATE() - NGSINH = 18)

-- I.12.

ALTER TABLE GIANGDAY
    ADD CONSTRAINT CHK_DURATION CHECK (TUNGAY < DENNGAY)

-- I.13.

ALTER TABLE GIAOVIEN
    ADD CONSTRAINT CHK_WORK_AGE CHECK (NGVL - NGSINH >= 22)

-- I.14.

ALTER TABLE MONHOC
    ADD CONSTRAINT CHK_TC CHECK (ABS(TCLT - TCTH) <= 3)

-- III.15.
SELECT DISTINCT
    (Ho + ' ' + Ten) HoTen
FROM
    HocVien, KetQuaThi
WHERE
    HocVien.MaHV = KetQuaThi.MaHV
    AND MaLop = 'K11'
    AND (
        (LanThi = 2 AND Diem = 5)
        OR HocVien.MaHV IN (
            SELECT DISTINCT MaHV
            FROM KetQuaThi
            WHERE KQua = 'Khong Dat'
            GROUP BY
                MaHV, MaMH
            HAVING COUNT(*) > 3
        )
    )

-- III.16.
SELECT HoTen
FROM
    GiaoVien, GiangDay
WHERE
    GiaoVien.MaGV = GiangDay.MaGV
    AND MaMH = 'CTRR'
GROUP BY
    GiaoVien.MaGV, HoTen, HocKy
HAVING
    COUNT(*) >= 2

-- III.17.
SELECT
    HocVien.*, Diem AS 'Điểm thi CSDL sau cùng'
FROM
    HocVien, KetQuaThi
WHERE
    HocVien.MaHV = KetQuaThi.MaHV
    AND MaMH = 'CSDL'
    AND LanThi = (
        SELECT MAX(LanThi)
        FROM KetQuaThi
        WHERE
            MaMH = 'CSDL'
            AND KetQuaThi.MaHV = HocVien.MaHV
        GROUP BY MaHV
    )

-- III.18.
SELECT
    HocVien.*, Diem AS 'Điểm thi CSDL cao nhất'
FROM
    HocVien, KetQuaThi, MonHoc
WHERE
    HocVien.MaHV = KetQuaThi.MaHV
    AND KetQuaThi.MaMH = MonHoc.MaMH
    AND TenMH = 'Co So Du Lieu'
    AND Diem = (
        SELECT MAX(Diem)
        FROM
            KetQuaThi, MonHoc
        WHERE
            KetQuaThi.MaMH = MonHoc.MaMH
            AND MaHV = HocVien.MaHV
            AND TenMH = 'Co So Du Lieu'
        GROUP BY MaHV
    )

-- III.19.
SELECT MaKhoa, TenKhoa
FROM Khoa
WHERE NgTLap = (SELECT MIN(NgTLap) FROM Khoa)

-- III.20.
SELECT COUNT(*) 'Số giáo viên có học hàm GS hoặc PGS'
FROM GiaoVien
WHERE HocHam IN ('GS', 'PGS')

-- III.21.
SELECT
    MaKhoa, HocVi, COUNT(*) 'Số giáo viên'
FROM GiaoVien
GROUP BY
    MaKhoa, HocVi
ORDER BY MaKhoa

-- III.22.
SELECT
    MaMH, KQua, COUNT(*) 'Số học viên'
FROM KetQuaThi
GROUP BY
    MaMH, KQua
ORDER BY MAMH

-- III.23.
SELECT DISTINCT
    GiaoVien.MaGV, HoTen
FROM
    GiaoVien, Lop, GiangDay
WHERE
    GiangDay.MaLop = Lop.MaLop
    AND GiangDay.MaGV = GiaoVien.MaGV
    AND GiaoVien.MaGV = Lop.MaGVCN

-- III.24.
SELECT
    Ho + ' ' + Ten AS 'Họ tên lớp trưởng của lớp có sỉ số cao nhất'
FROM
    HocVien, Lop
WHERE
    HocVien.MaHV = Lop.TrgLop
    AND Lop.SiSo = (SELECT MAX(SiSo) FROM Lop)

-- III.25.
SELECT Ho + ' ' + Ten 'Họ tên trưởng lớp thi không đạt quá 3 môn'
FROM
    HocVien, Lop, KetQuaThi
WHERE
    HocVien.MAHV = Lop.TrgLop
    AND HocVien.MaHV = KetQuaThi.MaHV
    AND KQua = 'Khong Dat'
GROUP BY
    TrgLop, Ho, Ten
HAVING
    COUNT(*) > 3

-- III.26.
SELECT TOP 1 WITH TIES
    HocVien.MaHV, (Ho + ' ' + Ten) AS HoTen
FROM
    HocVien, KetQuaThi
WHERE
    HocVien.MaHV = KetQuaThi.MaHV
    AND Diem >= 9
GROUP BY
    HocVien.MaHV, Ho, Ten
ORDER BY
    COUNT(*) DESC

-- III.27.
SELECT
    MaLop, MaHV, HoTen
FROM
    (
        SELECT
            MaLop,
            HocVien.MaHV,
            (Ho + ' ' + Ten) HoTen,
            COUNT(*) SoLuongDiem,
            RANK() OVER (
                PARTITION BY MaLop
                ORDER BY
                    COUNT(*) DESC
            ) AS XepHang
        FROM
            HocVien, KetQuaThi
        WHERE
            HocVien.MaHV = KetQuaThi.MaHV
            AND Diem >= 9
        GROUP BY
            MaLop, HocVien.MaHV, Ho, Ten
    ) AS A
WHERE A.XepHang = 1

-- III.28.
SELECT
    MaGV,
    COUNT(DISTINCT MaMH) 'Số môn học',
    COUNT(DISTINCT MALOP) 'Số lớp'
FROM GiangDay
GROUP BY MaGV

-- III.29.
SELECT
    HocKy, Nam, A.MaGV, HoTen
FROM
    GiaoVien,
    (
        SELECT
            HocKy,
            Nam,
            MaGV,
            RANK() OVER (
                PARTITION BY
                    HocKy, Nam
                ORDER BY COUNT(*) DESC
            ) AS XepHang
        FROM GiangDay
        GROUP BY HocKy, Nam, MaGV
    ) AS A
WHERE
    A.MAGV = GiaoVien.MAGV
    AND XepHang = 1
ORDER BY
    Nam, HocKy

-- III.30.
SELECT TOP 1 WITH TIES
    MonHoc.MaMH, TenMH
FROM
    MonHoc, KetQuaThi
WHERE
    MonHoc.MaMH = KetQuaThi.MaMH
    AND LanThi = 1
    AND KQua = 'Khong Dat'
GROUP BY
    MonHoc.MaMH, TenMH
ORDER BY COUNT(*) DESC

-- III.31.
SELECT DISTINCT
    HocVien.MaHV, (Ho + ' ' + Ten) HoTen
FROM
    HocVien, KetQuaThi
WHERE
    HocVien.MaHV = KetQuaThi.MaHV
    AND NOT EXISTS (
        SELECT *
        FROM KetQuaThi
        WHERE
            LanThi = 1
            AND KQua = 'Khong Dat'
            AND MaHV = HocVien.MaHV
    )

-- III.32.
SELECT DISTINCT
    HocVien.MaHV, (Ho + ' ' + Ten) HoTen
FROM
    HocVien, KetQuaThi
WHERE
    HocVien.MaHV = KetQuaThi.MaHV
    AND NOT EXISTS (
        SELECT *
        FROM KetQuaThi
        WHERE
            LanThi = (
                SELECT MAX(LanThi)
                FROM KetQuaThi
                WHERE MaHV = HocVien.MaHV
                GROUP BY MaHV
            )
            AND KQua = 'Khong Dat'
            AND MaHV = HocVien.MaHV
    )

-- III.33.
SELECT
    MaHV, (Ho + ' ' + Ten) HoTen
FROM HocVien
WHERE
    NOT EXISTS (
        SELECT *
        FROM MonHoc
        WHERE
            NOT EXISTS (
                SELECT *
                FROM KetQuaThi
                WHERE
                    KetQuaThi.MaMH = MonHoc.MaMH
                    AND KetQuaThi.MaHV = HocVien.MaHV
                    AND LanThi = 1 AND KQua = 'Dat'
            )
    )

-- III.35.
SELECT
    MaMH, MaHV, HoTen
FROM
    (
        SELECT
            MaMH,
            HocVien.MaHV,
            (Ho + ' ' + Ten) HoTen,
            RANK() OVER (
                PARTITION BY MaMH
                ORDER BY MAX(Diem) DESC
            ) AS XepHang
        FROM
            HocVien, KetQuaThi
        WHERE
            HocVien.MaHV = KetQuaThi.MaHV
            AND LanThi = (
                SELECT MAX(LanThi)
                FROM KetQuaThi
                WHERE MaHV = HocVien.MaHV
                GROUP BY MaHV
            )
        GROUP BY
            MaMH, HocVien.MaHV, Ho, Ten
    ) AS A
WHERE XepHang = 1
