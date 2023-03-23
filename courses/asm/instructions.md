
# Bài tập

Xem https://courses.uit.edu.vn/pluginfile.php/341583/mod_folder/content/0/3.%20Bai_Tap_Assembly_ko%20dap%20an.pdf?forcedownload=1

1.1.1.

a)
```mips
add f, g, h
add f, f, i
add f, f, j
```

b)
```mips
add f, g, h
addi f, f, 5
```

1.1.2.

a) 3

b) 2

1.1.3.

a) 14

b) 10

1.2.4.

a)
```c
f = g + h
```

b)
```c
f = f + 1
f = g + h
```

1.2.5.

a) 5

b) 5

2.1.1.

a)
```mips
lw $s0, 16($s7)
add $s0, $s0, $s1
add $s0, $s0, $s2
```

b)
```mips
lw $s0, 16($s7)
sll $s0, $s0, 2
add $s0, $s0, $s6
sub $s0, $s1, $s0
```

2.1.2.

a) 3

b) 4

2.1.3.

a) 3

b) 4

2.2.4.

a)
```c
f = f + g + h + i + j
```

b)
```c
f = A[1]
```

2.2.5.

a) Không thể

b) Không thể

2.2.6.
a) Không thể

b) Không thể

3.1.

a)
```mips
lw $s0, 4($s7)
add $s0, $s0, $2
sub $s0, $s0, $s1
```

b)
```mips
sll $s0, $s1, 2
add $s0, $s0, $s7
lw $s0, 0($s0)
add $s0, $s0, 1
sll $s0, $s0, 2
add $s0, $s0, $s6
lw $s0, 0($s0)
```

3.2.

a) 3

b) 7

3.3.

a) 4

b) 5

4.1.

a) 2147483647. Đúng. Không tràn số.

b) 2147483648. Đúng. Không tràn số.

4.2.

a) 1610612737. Đúng. Không tràn số.

b) 0. Đúng. Không tràn số.

4.3.

a) 4026531839. Đúng. Không tràn số.

b) 3221225472. Đúng. Không tràn số.

5.1. & 5.1.1. & 5.1.2.

a) `101011_10000_01011_0000'0000'0000'0100`

opcode = $101011_2 = 2b_{16},$
rs = $10000_2 = 16_{10},$
rt = $01011_2 = 11_{10}$
$\Rightarrow$ lệnh `sw`
```mips
sw $s0, 4($t3)
```

b) `100011_01000_01000_0000'0000'0100'0000`

opcode = $100011_2 = 23_{16},$
rs = $01000_2 = 8_{10},$
rt = $01000_2 = 8_{10},$
imm = $100'0000_2 = 64_{10}$
$\Rightarrow$ lệnh `lw`
```mips
lw $t0, 64($t0)
```

5.1.3.

a) 0xae0b0004

b) 0x8d080040

5.2.4. & 5.2.5.

a) `100000_01000_00000_01000_00000_000000`

b) `100011_01001_10011_0000'0000'0000'0100`

5.2.6.

a) 0x81004000

b) 0x8d330004

6.1.

a) 0x57755778

b) 0xfefffede

6.2.

a) 0xaaaa

b) 0xbfcd

7.1.

a) 2

b) 2

7.2.

a) `1010_1101_0001_0000_0000_0000_0000_0000_0011`

b) Không có

7.3.

# Bài tập thêm

Xem https://courses.uit.edu.vn/pluginfile.php/341583/mod_folder/content/0/4.%20BaiTap_Assembly_them.pdf?forcedownload=1

1.a. `0000'00_10'000_1'0010'_0101'1_000'00_10'0100 = 0x02125824`

- opcode = $0_{16}$ = $000000_2$
- rs = \$s0 = 16 = $10000_2$
- rt = \$s2 = 18 = $10010_2$
- rd = \$t3 = 11 = $01011_2$
- shamt = $00000_2$
- funct = $24_{16}$ = $100100_2$

1.b. `0000'00_00'000_0'1101'_0100'1_001'11_00'0000 = 0x000d49c0`

- opcode = $0_{16}$ = $000000_2$
- rs = $00000_2$
- rt = \$t5 = 13 = $01101_2$
- rd = \$t1 = 9 = $01001_2$
- shamt = 7 = $00111_2$
- funct = $0_{16}$ = $000000_2$

1.c. `0010'00_10'011_0'1000_0000_0000_0001_1001 = 0x22680019`

- opcode = $8_{16}$ = $001000_2$
- rs = \$s3 = 19 = $10011_2$
- rt = \$t0 = 8 = $01000_2$
- imm = 25 = $0000\_0000\_0001\_1001_2$

1.d. `0010'00_10'011_0'1000_1111_1111_1110_1000 = 0x2268ffe8`

- opcode = $8_{16}$ = $001000_2$
- rs = \$s3 = 19 = $10011_2$
- rt = \$t0 = 8 = $01000_2$
- imm = -25 = $1111\_1111\_1110\_1000_2$

1.e. `1000'11_10'000_0'1000_0000_0000_0001_1000 = 0x8e080018`

- opcode = $23_{16}$ = $100011_2$
- rs = \$s0 = 16 = $10000_2$
- rt = \$t0 = 8 = $01000_2$
- imm = 24 = $0000\_0000\_0001\_1000_2$

1.f. `1000'11_10'000_0'1000_1111_1111_1110_1001 = 0x8e08ffe9`

- opcode = $23_{16}$ = $100011_2$
- rs = \$s0 = 16 = $10000_2$
- rt = \$t0 = 8 = $01000_2$
- imm = 24 = $1111\_1111\_1110\_1001_2$

1.g. `1010'11_10'000_0'1010_0000_0000_0011_0000 = 0xae0a0030`

- opcode = $2b_{16}$ = $101011_2$
- rs = \$s0 = 16 = $10000_2$
- rt = \$t2 = 10 = $01010_2$
- imm = 48 = $0000\_0000\_0011\_0000_2$

1.h. `1010'11_10'000_0'1010_1111_1111_1101_0001 = 0xae0affd1`

- opcode = $2b_{16}$ = $101011_2$
- rs = \$s0 = 16 = $10000_2$
- rt = \$t2 = 10 = $01010_2$
- imm = -48 = $1111\_1111\_1101\_0001_2$

2.a. `0x01304024 = 0000'00_01'001_1'0000_0100'0_000'00_10'0100`

```mips
and $t0, $t1, $s0
```

- opcode = $000000_2$ = $0_{16}$
- rs = $01001_2$ = 9 = \$t1
- rt = $10000_2$ = 16 = \$s0
- rd = $01000_2$ = 8 = \$t0
- shamt = $00000_2$ = 0
- func = $100100_2$ = $24_{16}$

2.b. `0x2128fff3 = 0010'00_01'001_0'1000_1111'1111'1111'0011`

```mips
addi $t0, $t1, -14
```

- opcode = $001000_2$ = 8
- rs = $01001_2$ = 9 = \$t1
- rt = $01000_2$ = 8 = \$t0
- imm = $1111\_1111\_1111\_0011\_2$ = $-0000\_0000\_0000\_1110_2$ = -14

2.c. `0xad28fffc = 1010'11_01'001_0'1000_1111'1111'1111'1100`

```mips
sw $t0, 65532($t1)
```

- opcode = $101011_2$ = $2b_{16}$
- rs = $01001_2$ = 9 = \$t1
- rt = $01000_2$ = 8 = \$t0
- imm = $1111\_1111\_1111\_1100_2$ = 65532

3.a.

\$s0 = 0x12345678, \$s1 = 0x00000007

- `and $t0, $s0, $s1`: \$t0 = 0x12345678 & 0x00000007 = 0x0
- `or $t1, $s0, $s1`: \$t1 = 0x12345678 | 0x00000007 = 0x1234567f
- `nor $t0, $t0, $t1`: \$t0 = ~(0x0 | 0x1234567f) = 0xedcba980
- `sll $t0, $t0, 3`: \$t0 = $t0 << 3 = $1110\_1101\_1100\_1011\_1010\_1001\_1000\_0000_2$ << 3 = $0110\_1110\_0101\_1101\_0100\_1100\_0000\_0000_2$ = 0x6e5d4c00

3.b.

\$s0 = 0xf

- `andi $t0, $s0, 12`: \$t0 = 0xf & 0xc = 0xc
- `nor $t0, $t0, $zero`: \$t0 = ~(0xc | 0x0) = 0xfffffff3
- `ori $t0, $t0, 3`: \$t0 = 0xfffffff3 | 0x3 = 0xfffffff3
- `srl $t0, $t0, 2`: \$t0 = 0xfffffff3 >> 2 = 0x3ffffffc

3.c.

\$t0 = 0x0000008f, \$t1 = 0x0000009f

- `slt $t2, $t0, $t1 `: \$t2 = (0x8f < 0x9f) ? 1 : 0 = 1
- `beq $t2, $zero, ELSE`: skipped
- `add $t2, $t2, $t0`: \$t2 = 0x1 + 0x8f = 0x90
- `j DONE`: done
- `ELSE: add $t2, $t2, $t1`: skipped
- `DONE:`: done

3.d.

- `addi $s0, $zero, 2`: \$s0 = 2
- `addi $t1, $zero, 6`: \$t1 = 6
- `loop: beq $t1, $zero, end`: \$t1 = 6, \$t1 = 5, ..., \$t1 = 0 jump to end.
- `sll $s0, $s0, 1`: \$s0 = 2 << 1 = 4, \$s0 = 4 << 1 = 8, ..., \$s0 = 32 << 1 = 64
- `addi $t1, $t1, -1`: \$t1 = 6 - 1 = 5, \$t1 = 5 - 1 = 4, ..., \$t1 = 1 - 1 = 0
- `j loop`: 
- `end: addi $s1, $s0, 2`: \$s1 = 64 + 2 = 66

4.a.

```mips
    slt $t0, $s0, $s1

    sll $t1, $s0, 2
    add $t1, $t1, $s3
    lw $t2, 0($t1)

    add $t3, $s0, 1
    sll $t3, $t3, 2
    add $t3, $t3, $s3

    beq $t0, $zero, ELSE

    addi $t2, $t2, 1
    addi $t4, $zero, 5

    j EXIT
ELSE:
    addi $t2, $t2, -1
    addi $t4, $zero, 10
    j EXIT
EXIT:
    sw $t2, 0($t1)
    sw $t4, 0($t3)
    addi $s0, $s0, 1
```

4.b.

```mips
    sll $t0, $s0, 2
    add $t0, $t0, $s3

    addi $t1, $s0, 1
    sll $t1, $t1, 2
    add $t1, $t1, $s3
    lw $t1, 0($t1)

    sll $t2, $s1, 2
    add $t2, $t2, $s3
    lw $t2, 0($t2)

    sll $t3, $s1, 2
    add $t3, $t3, $s3

    slt $t4, $s1, $s0
    slti $t5, $s1, 0
    and $t4, $t4, $t5

    beq $t4, $zero, ELSE

    add $t6, $t1, $t2
ELSE:
    sub $t6, $t1, $t2
EXIT:
    sw $t6, 0($t3)
    addi $s0, $s0, 1
```

4.c.

```mips
    j loop
loop:
    slt $t2, $s0, $zero
    beq $t2, $zero, exit

    sll $t0, $s0, 2
    add $t0, $t0, $s3
    lw $t0, 0($t0)
    sll $t0, $t0, 3

    add $t1, $s0, 1
    sll $t1, $t0, 2
    add $t1, $t1, $s3
    sw $t0, 0($t1)

    addi $s0, $s0, -1

    j loop
exit:
    addi $t0, $zero, 5
    sw $t0, 0($s3)
```

4.d.

```mips
    add $s1, $zero, $s5
    addi $s0, $zero, 1
    j loop
loop:
    slt $t0, $s0, $s1
    beq $t0, $zero, exit

    sll $t1, $s0, 2
    add $t2, $t1, $s3
    add $t3, $t1, $s4

    lw $t3, 0($t3)
    sw $t3, 0($t2)

    addi $s0, $s0, 1

    j loop
exit: addi $s1, $zero, $zero
```

4.e.

```mips
    add $s1, $zero, $s5
    add $s4, $zero, $zero
    add $s0, $zero, $zero n
loop:   
    slt $t0, $s0, $s1
    beq $t0, $zero, exit

    sll $t1, $s0, 2
    add $t1, $t1, $s3
    lw $t1, 0($t1)

    slt $t3, $s4, $t1
    bne $t3, $zero, set_max

    addi $s0, $s0, 1
    j loop
set_max:
    add $s4, $zero, $t1
    jr $ra
exit: addi $s1, $zero, $zero
```
