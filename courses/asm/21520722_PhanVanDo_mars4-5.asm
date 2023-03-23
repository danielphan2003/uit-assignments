.data
  input: .space 256
  output: .space 256
  upper_msg: .asciiz "So chu cai hoa: "
  lower_msg: .asciiz "So chu cai thuong: "
  numeric_msg: .asciiz "So chu cai so: "
  newline_char: .asciiz "\n"
.text

main:
  li $v0, 8
  la $a0, input
  li $a1, 256
  syscall

reverse:
  li $t0, 0
  li $s0, 0
  li $s1, 0
  li $s2, 0
  li $s3, 0

  jal strlen
  move $t1, $a0
  move $t2, $v0

  reverse_loop:
    add $t3, $t1, $t0
    lb $t4, 0($t3)
    beqz $t4, exit

    move $a0, $t4
    jal is_alphanum
    move $s3, $v0

    move $a1, $t2
    jal capitalize
    move $t4, $v0
    sb $t4, output($t2)

    subi $t2, $t2, 1
    addi $t0, $t0, 1

    move $a0, $s3
    jal count_alphanum

    j reverse_loop

exit:
  print_reversed:
    li $v0, 4
    la $a0, output
    syscall

    li $v0, 4
    la $a0, newline_char
    syscall

  check_upper:
    li $v0, 4
    la $a0, upper_msg
    syscall

    li $v0, 1
    move $a0, $s1
    syscall

    li $v0, 4
    la $a0, newline_char
    syscall

  check_lower:
    li $v0, 4
    la $a0, lower_msg
    syscall

    li $v0, 1
    move $a0, $s2
    syscall

    li $v0, 4
    la $a0, newline_char
    syscall

  check_numeric:
    li $v0, 4
    la $a0, numeric_msg
    syscall

    li $v0, 1
    move $a0, $s0
    syscall

    li $v0, 4
    la $a0, newline_char
    syscall

  li $v0, 10
  syscall

count_alphanum:
  li $s3, -1
  beq $a0, $s3, count_num

  li $s3, 1
  beq $a0, $s3, count_upper

  li $s3, 0
  beq $a0, $s3, count_lower

  j return

  count_num:
    addi $s0, $s0, 1
    j return

  count_upper:
    addi $s1, $s1, 1
    j return

  count_lower:
    addi $s2, $s2, 1
    j return

is_alphanum:
  li $t5, '0'
  bltu $a0, $t5, return

  li $t5, '9'
  bgtu $a0, $t5, is_upper

  li $v0, -1

  j return

is_upper:
  li $t5, 'A'
  bltu $a0, $t5, return

  li $t5, 'Z'
  bgtu $a0, $t5, is_lower

  li $v0, 1

  j return

is_lower:
  li $t5, 'a'
  bltu $a0, $t5, return

  li $t5, 'z'
  bgtu $a0, $t5, return

  li $v0, 0

  j return

capitalize:
  move $v0, $a0

  andi $t5, $a1, 1
  bne $t5, $zero, return

  li $t5, 'a'
  bltu $a0, $t5, return

  li $t5, 'z'
  bgtu $a0, $t5, return

  addi $v0, $v0, -32 # 'a' - 'A' = 32

  j return

strlen:
  li $t0, 0
  li $t2, 0

  strlen_loop:
    add $t2, $a0, $t0
    lb $t1, 0($t2)
    beqz $t1, strlen_exit
    addiu $t0, $t0, 1
    j strlen_loop

  strlen_exit:
    subi $t0, $t0, 1
    add $v0, $zero, $t0
    add $t0, $zero, $zero
    j return

print:
  li $v0, 4
  syscall
  j return

printi:
  li $v0, 1
  syscall
  j return

newline:
  la $a0, newline_char
  jal print
  j return

return:
  jr $ra
