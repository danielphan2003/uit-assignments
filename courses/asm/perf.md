# Định nghĩa

- Chu kì xung clock - clock cycle: $T$

- Tần số xung clock - clock rate: $f$

  $f = \frac{1}{T}$

- Số chu kỳ xung clock chương trình cần: $Count_T$

- Số lệnh chương trình cần: $Count_I$

- Số chu kỳ xung clock cần để thực thi _một_ lệnh: $CPI$

  $Count_T = Count_I \cdot CPI$

- Số lệnh thực thi được trong _một_ chu kì: $IPC$

  $IPC = \frac{1}{CPI} = \frac{Count_I}{Count_T}$

- Thời gian thực thi chương trình: $t$

  $t = Count_T \cdot T = Count_I \cdot CPI \cdot T$

  $t = \frac{Count_T}{f} = \frac{Count_I \cdot CPI}{f}$

- Hiệu năng: $P$

  $P=\frac{1}{t}$

- Số lệnh trên _một_ giây: $IPS$

  $IPS = \frac{Count_I}{t}$

- Số lượng triệu lệnh trên _một_ giây: $MIPS$

  $MIPS = \frac{Count_I}{t \cdot 10^6} = \frac{1}{CPI \cdot T \cdot 10^6}$
  $= \frac{f}{CPI \cdot 10^6}$

# Ví dụ

1.

$t_A = 10$ s $, f_A = 2$ Ghz $, t_B = 6$ s $, Count_TB = 1.2 \cdot Count_TA$

$t_A = 10 \Rightarrow Count_TA = t_A \cdot f_A = 10 \cdot 2 \cdot 10^9 = 2 \cdot 10^{10}$

$Count_TB = 1.2 \cdot Count_TA = 2.4 \cdot 10^{10}$

$\Rightarrow f_B = \frac{Count_TB}{t_B} = 4 \cdot 10^9 = 4$ Ghz

2.

$T_A = 250$ ps $, CPI_A = 2, T_B = 500$ ps $, CPI_B = 1.2$

$P_A = \frac{1}{t_A} = \frac{1}{Count_I \cdot CPI_A \cdot T_A}$

$P_B = \frac{1}{Count_I \cdot CPI_B \cdot T_B}$

$\Rightarrow \frac{P_A}{P_B} = \frac{CPI_B \cdot T_B}{CPI_A \cdot T_A} = \frac{1.2 \cdot 500}{2 \cdot 250} = 1.2$

Vậy máy A nhanh hơn máy B 1.2 lần

3. [Tuan2_Hieu_suat.pdf - Page 13](https://courses.uit.edu.vn/pluginfile.php/341582/mod_folder/content/0/Tuan2_Hieu_suat.pdf?forcedownload=1)

$Count_I1 = 2 + 1 + 2 = 5$

$Count_I2 = 4 + 1 + 1 = 6$

$Count_T1 = Count_IA_1 \cdot CPI_A + Count_IB_1 \cdot CPI_B + Count_IC_1 \cdot CPI_C$
$ = 2 \cdot 1 + 1 \cdot 2 + 2 \cdot 3 = 10$

$Count_T2 = 4 \cdot 1 + 1 \cdot 2 + 1 \cdot 3 = 9$

$CPI_1 = \frac{Count_T1}{Count_I1} = \frac{10}{2 + 1 + 2} = 2$

$CPI_2 = \frac{9}{4 + 1 + 1} = 1.5$

Vậy đoạn code 2 tốn nhiều lệnh hơn ($Count_I2 > Count_I1$),
đoạn code 2 thực thi nhanh hơn ($Count_T2 < Count_T1$),
CPI đoạn code 1 là 2, CPI đoạn code 2 là 1.5.

# Bài tập

Xem https://courses.uit.edu.vn/pluginfile.php/341583/mod_folder/content/0/2.%20BaiTap_Hieu%20suat_ko%20dap%20an%20cap%20nhat%202021.pdf?forcedownload=1

1.1.

$IPS_{P1} = \frac{f_{P1}}{CPI_{P1}} = \frac{2 \cdot 10^9}{1.5} = 1.(3) \cdot 10^9$

$IPS_{P2} = \frac{1.5 \cdot 10^9}{1} = 1.5 \cdot 10^9$

$IPS_{P3} = \frac{3 \cdot 10^9}{2.5} = 1.2 \cdot 10^9$

$MIPS_{P1} = \frac{IPS_{P1}}{10^6} = 1.(3) \cdot 10^3$

$MIPS_{P2} = 1.5 \cdot 10^3$

$MIPS_{P3} = 1.2 \cdot 10^3$

Vậy P2 nhanh hơn.

1.2.

$Count_TP1 = t \cdot f_{P1} = 10 \cdot 2 \cdot 10^9 = 2 \cdot 10^{10}$ chu kì

$Count_IP1 = \frac{Count_TP1}{CPI_{P1}} = 1.(3) \cdot 10^{10}$ lệnh

$Count_TP2 = 10 \cdot 1.5 \cdot 10^9 = 1.5 \cdot 10^{10}$ chu kì

$Count_IP2 = 1.5 \cdot 10^{10}$ lệnh

$Count_TP3 = 10 \cdot 3 \cdot 10^9 = 3 \cdot 10^{10}$ chu kì

$Count_IP3 = 1.2 \cdot 10^{10}$ lệnh

1.3.

$f_{P1} = \frac{Count_IP1 \cdot CPI^{'}_{P1}}{t} = \frac{1.(3) \cdot 10^{10} \cdot 1.5 \cdot 120\%}{10*70\%} \approx 3.4$ Ghz

$f_{P2} = \frac{1.5 \cdot 10^{10} \cdot 1 \cdot 120\%}{10*70\%} \approx 2.6$ Ghz

$f_{P3} = \frac{1.2 \cdot 10^{10} \cdot 2.5 \cdot 120\%}{10*70\%} \approx 5.2$ Ghz

1.4.

$IPC_{P1} = \frac{Count_IP1}{Count_TP1} = \frac{Count_IP1}{t_{P1} \cdot f_{P1}} = \frac{20 \cdot 10^9}{7 \cdot 2 \cdot 10^9} \approx 1.4$ lệnh/chu kì

$IPC_{P2} = \frac{30 \cdot 10^9}{10 \cdot 1.5 \cdot 10^9} = 2$ lệnh/chu kì

$IPC_{P1} = \frac{20 \cdot 10^9}{7 \cdot 2 \cdot 10^9} \approx 3.4$ lệnh/chu kì

1.5.

$\frac{t_{P2}}{t^{'}_{P2}} = \frac{10}{7} = \frac{Count_IP2 \cdot CPI_{P2} \cdot f^{'}_{P2}}{Count_IP2 \cdot CPI^{'}_{P2} \cdot f_{P2}} = \frac{f^{'}_{P2}}{3 \cdot 10^9 \cdot CPI^{'}_{P2}}$

$\Rightarrow f^{'}_{P2} \approx 4.3 \cdot CPI^{'}_{P2} = \frac{4.3}{IPC^{'}_{P2}} = $

1.6.


