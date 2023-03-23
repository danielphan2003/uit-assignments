# Định nghĩa

- Phép hội: $R \cup S = \{ t | t \in R \lor t \in S\}$

- Phép giao: $R \cap S = \{t | t \in R \land t \in S\}$

- Phép trừ: $R - S = \{t | t \in R \land t \notin S\}$

- Phép chọn dùng để lọc các bộ $t$ thoả điều kiện $P$: $\sigma_P(R) = \{t | t \in R \land P(t)\}$ hoặc $R: P$

  - R là một quan hệ

  - P là biểu thức điều kiện. Ví dụ: (LOP = 'MMT') $\land$ (KHOA > 2020)

  - Giao hoán: $\sigma_{P1}(\sigma_{P2}(R)) = \sigma_{P2}(\sigma_{P1}(R)) = \sigma_{(P1 \land P2)}(R)$

  Ví dụ:

    $\sigma_{Gioitinh = 'Nam'}(HOCVIEN)$

    $\sigma_{(Gioitinh = 'Nam') \land (Noisinh = 'TpHCM')}(HOCVIEN)$

- Phép chiếu lấy các cột $A_1, A_2, ..., A_k$ của quan hệ $R$: $\pi_{A_1, A_2, ..., A_k}(R) = \{t[A_1, A_2, ..., A_k] | t \in R\}$ hoặc $R[A_1, A_2, ..., A_k]$

  - Không giao hoán: $\pi_{A_1, A_2, ..., A_k}(\pi_{A_1, A_2, ..., A_l}(R)) = \pi_{A_1, A_2, ..., A_k}(R), k \le l$

  Ví dụ: $\pi_{Mahv, HoTen}(HOCVIEN)$

- Kết hợp phép chiếu và phép chọn. Ví dụ tìm mã số, họ tên những học viên 'Nam' có nơi sinh ở 'TpHCM':

  $\pi_{Mahv,Hoten}\sigma_{(Gioitinh = 'Nam') \land (Noisinh = 'TpHCM')}(HOCVIEN)$

- Phép gán dùng gán kết quả vào biến: $\leftarrow$

  Ví dụ:

    $S \leftarrow \sigma_P(R)$
    
    $KQ \leftarrow \pi_{A_1, A_2, ..., A_k}(S)$

- Phép đổi tên:

  - Theo quan hệ: $\rho_S(R)$ đổi tên R thành S.

  - Theo thuộc tính: $\rho_{X, C, D}(R)$ đổi tên thuộc tính B trong quan hệ R thành X.

  - Theo quan hệ và thuộc tính: $\rho_{S(X, C, D)}(R)$ đổi tên quan hệ R thành S và thuộc tính B thành X.

  Ví dụ:

    $R(HO, TEN, LUONG) \leftarrow \pi_{HONV, TENNV, LUONG}(NHANVIEN)$

- Phép tích kết hợp các bộ $t$ của hai quan hệ với nhau (như nhân hai ma trận): $R \times S$

- Phép kết tổ hợp 2 bộ liên quan từ hai quan hệ thành 1 bộ: $R \bowtie S$

  - Phép kết theta là phép kết có điều kiện $P$: $R \bowtie^P S$

  - Phép kết bằng khi P là điều kiện so sánh bằng.

  - Phép kết tự nhiên: $R * A$

- Phép chia dùng để lấy các bộ trong quan hệ $R$ thoả tất cả các bộ trong quan hệ $S$: $R \div S$

# Bài tập

1. Xem https://courses.uit.edu.vn/pluginfile.php/343652/mod_resource/content/3/BAITAP_GK.pdf

1.2.1.

```sql
UPDATE KHACHHANG
SET kwdinhmuc = kwdinhmuc * 110 / 100
WHERE makh = 'KH001'
```

1.2.2.

a. $\pi_{manv, hoten} \sigma_{YEAR(ngayvaolam) \ge 2015}(NHANVIEN)$

b.

  $\pi_{sohdong, ngayky, tenkh} \sigma_{kwdinhmuc \ge 200}(HOPDONG)$

c.

  $R \leftarrow$ HOADON $\bowtie^{sohdong}$ HOPDONG

  $P_1 \leftarrow \pi_{makh} (R)$

  $P_2 \leftarrow \pi_{makh} \sigma_{sotien < 1.000.000}(R)$

  KQ $\leftarrow P_1 - P_2$

d.

  $R \leftarrow$ HOADON $\bowtie^{manv}$ NHANVIEN

  $P_1 \leftarrow \sigma_{nam = 2014}(R)$

  $P_2 \leftarrow _{manv}\mathcal{J}_{COUNT(sohdon)}(P_1)$

  $P_3 \leftarrow P_2 \bowtie^{manv}$ NHANVIEN

  KQ $\leftarrow \pi_{manv, hoten} \sigma_{(P_3)$