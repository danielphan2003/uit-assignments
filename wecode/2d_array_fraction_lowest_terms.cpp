#include <iostream>
#include <cmath>

const int MAXN = 100;

struct PhanSo {
  int tu;
  int mau;
};

int ucln(int a, int b) {
  if (b == 0) return a;
  return ucln(b, a % b);
}

void InPhanSoToiGian(PhanSo p) {
  int _ucln = std::abs(ucln(p.tu, p.mau));
  if (p.tu != 0 && p.mau < 0) _ucln = -_ucln;
  p.tu /= _ucln;
  p.mau /= _ucln;
  std::cout << p.tu;
  if (std::abs(p.mau) != 1 && std::abs(p.tu) >= 0) std::cout << "/" << p.mau;
}

void Nhap(PhanSo (&ps)[MAXN], int &n) {
  std::cin >> n;
  for (int i = 0; i < n; ++i)
    std::cin >> ps[i].tu >> ps[i].mau;
}

void Xuat(const PhanSo (&ps)[MAXN], int n) {
  for (int i = 0; i < n; ++i) {
    if (ps[i].mau == 0)
      std::cout <<  "Khong thoa yeu cau bai toan";
    else
      InPhanSoToiGian(ps[i]);
    if (i < n - 1) std::cout << "\n";
  }
}

int main() {
    PhanSo a[MAXN];
    int n;
    Nhap(a, n);
    Xuat(a, n);
    return 0;
}
