#include <algorithm>
#include <iostream>
#include <cmath>

struct PhanSo {
  int tu;
  int mau;
};

int ucln(int a, int b) {
  if (b == 0) return a;
  return ucln(b, a % b);
}

void PhanSoToiGian(PhanSo &p) {
  int _ucln = std::abs(ucln(p.tu, p.mau));
  if (p.tu != 0 && p.mau < 0) _ucln = -_ucln;
  p.tu /= _ucln;
  p.mau /= _ucln;
}

void Nhap(PhanSo *&ps, int &n) {
  std::cin >> n;
  ps = new PhanSo[n];
  for (int i = 0; i < n; ++i) {
    std::cin >> ps[i].tu >> ps[i].mau;
    PhanSoToiGian(ps[i]);
  }
}

void Xuat(PhanSo p) {
  std::cout << p.tu;
  if (std::abs(p.mau) != 1 && std::abs(p.tu) >= 0)
    std::cout << "/" << p.mau;
}

void Xuat(const PhanSo *ps, int n) {
  for (int i = 0; i < n; ++i) {
    Xuat(ps[i]);
    if (i < n - 1) std::cout << "\n";
  }
}

bool SoSanhPhanSo(PhanSo a, PhanSo b) {
  return a.tu * 1.0 / a.mau > b.tu * 1.0 / b.mau;
}

void SapXepGiamDan(PhanSo *&ps, int n) {
  std::sort(ps, ps + n, SoSanhPhanSo);
}

int main() {
    PhanSo *a;
    int n;
    Nhap(a, n);
    SapXepGiamDan(a, n);
    Xuat(a, n);
    return 0;
}
