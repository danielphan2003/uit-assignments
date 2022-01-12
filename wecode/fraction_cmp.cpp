#include <iostream>

struct PhanSo {
  int tu;
  int mau;
};

void Nhap(PhanSo &p) {
  std::cin >> p.tu >> p.mau;
}

PhanSo Nhap() {
  PhanSo p;
  Nhap(p);
  return p;
}

int SoSanh(PhanSo a, PhanSo b) {
  double _a = a.tu * 1.0 / a.mau,
    _b = b.tu * 1.0 / b.mau;
  if (_a == _b)
    return 0;
  else if (_a > _b)
    return 1;
  return -1;
}

int main() {
    PhanSo a, b;
    Nhap(a);
    b = Nhap();
    int kq = SoSanh(a, b);
    if (kq == 0)
        std::cout << "Hai phan so bang nhau.";
    else if (kq > 0)
        std::cout << "Phan so thu nhat LON hon phan so thu hai.";
    else
        std::cout << "Phan so thu nhat NHO hon phan so thu hai.";
    return 0;
}
