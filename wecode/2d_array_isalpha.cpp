#include <iostream>

const int MAXN = 200;

int Input() {
  int inp;
  std::cin >> inp;
  return inp;
}

void NhapMang(char (&arr)[MAXN], int n) {
  for (int i = 0; i < n; ++i)
    std::cin >> arr[i];
}

void XuatMang(const char (&arr)[MAXN], int n) {
  for (int i = 0; i < n; ++i)
    if (!isalpha(arr[i])) {
      std::cout << arr[i];
      if (i < n - 1) std::cout << "\t";
    }
}


int main() {
  char a[MAXN];
  int n;
  n = Input(); // Yêu cầu: n được nhập khi gọi hàm Input!
  NhapMang(a, n);
  XuatMang(a, n);
  return 0;
}
