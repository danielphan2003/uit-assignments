#include <iostream>

const int MAXN = 100;

void Input(int &n) {
  std::cin >> n;
}

void NhapMang(int (&arr)[MAXN], int n) {
  for (int i = 0; i < n; ++i) {
    std::cin >> arr[i];
  }
}

void SapXepGiamDan(int (&arr)[MAXN], int n) {
  for (int i = 0; i < n - 1; ++i) {
    for (int j = i + 1; j < n; ++j) {
      if (arr[i] < arr[j]) {
        std::swap(arr[i], arr[j]);
      }
    }
  }
}

void XuatMang(const int (&arr)[MAXN], int n) {
  for (int i = 0; i < n; ++i) {
    std::cout << arr[i];
    if (i < n - 1) std::cout << "\t";
  }
}

int main() {
  int a[MAXN], n;
  Input(n);
  NhapMang(a, n);
  SapXepGiamDan(a, n);
  XuatMang(a, n);
  return 0;
}
