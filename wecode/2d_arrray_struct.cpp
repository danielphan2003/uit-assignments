
#include <iomanip>
#include <iostream>
#include <stdio.h>
using namespace std;
#define MAXN 100

struct SinhVien {
  char MASV[10];
  char HoTen[100];
  char NgaySinh[12];
  char GioiTinh;
  float DiemToan, DiemLy, DiemHoa, DTB;
};



void Nhap(SinhVien &sv) {
  cin >> sv.MASV;
  cin.ignore();
  cin.getline(sv.HoTen, 100);
  cin >> sv.NgaySinh;
  cin >> sv.GioiTinh;
  cin >> sv.DiemToan >> sv.DiemLy >> sv.DiemHoa;
  sv.DTB = (sv.DiemToan + sv.DiemLy + sv.DiemHoa) / 3.0;
}

void Xuat(SinhVien sv) {
  cout << sv.MASV << "\t"
       << sv.HoTen << "\t"
       << sv.NgaySinh << "\t"
       << sv.GioiTinh << "\t"
       << sv.DiemToan << "\t"
       << sv.DiemLy << "\t"
       << sv.DiemHoa << "\t"
       << setprecision(3) << sv.DTB
       ;
}

void Nhap(SinhVien (&A)[MAXN], int &n) {
  cin >> n;
  for (int i = 0; i < n; ++i)
    Nhap(A[i]);
}

void Xuat(const SinhVien A[MAXN], int n) {
  for (int i = 0; i < n; ++i) {
    Xuat(A[i]);
    if (i < n - 1) cout << "\n";
  }
}

int main() {
  SinhVien A[MAXN];
  int n;
  Nhap(A, n);
  Xuat(A, n);
  return 0;
}
