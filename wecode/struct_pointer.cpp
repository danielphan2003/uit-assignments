#include <iomanip>
#include <iostream>
#include <stdio.h>
#include <string.h>
using namespace std;

struct SinhVien {
  char *MASV;
  char *HoTen;
  char NgaySinh[12];
  char GioiTinh;
  float DiemToan, DiemLy, DiemHoa, DTB;
};

void Nhap (SinhVien *&sv){
  sv = new SinhVien;
  sv->MASV = new char[10];
  sv->HoTen = new char[100];

  cin >> sv->MASV;
  cin.ignore();
  cin.getline(sv->HoTen, 100);
  cin >> sv->NgaySinh;
  cin >> sv->GioiTinh;
  cin >> sv->DiemToan >> sv->DiemLy >> sv->DiemHoa;
  sv->DTB = (sv->DiemToan + sv->DiemLy + sv->DiemHoa) / 3.0;
}

void Xuat (SinhVien sv){
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

int main() {
  SinhVien *A;
  Nhap(A);
  Xuat(*A);
  return 0;
}
