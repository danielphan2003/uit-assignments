#include <iostream>

const int MAXN = 100;

void NhapMang(int (&arr)[MAXN], int &n) {
  std::cin >> n;
  for (int i = 0; i < n; ++i) {
    std::cin >> arr[i];
  }
}

void XuatMang(const int (&arr)[MAXN], int n) {
  std::cout << "Mang co " << n << " phan tu";
  if (n > 0) {
    std::cout << ": {";
    for (int i = 0; i < n; ++i) {
      std::cout << arr[i];
      if (i < n - 1) {
        std::cout << ", ";
      }
    }
    std::cout << "}";
  }
  std::cout << ".";
}

int main() {
    int a[MAXN], n;
    NhapMang(a, n);
    XuatMang(a, n);
    return 0;
}
