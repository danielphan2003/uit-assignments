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

int len(const char *s) {
  int dem = 0;
  while (s[dem++] != '\0');
  return dem;
}

bool eosubstr(char c) {
  return c == ' ' || c == '\0';
}

void ChuanHoaXauDon(char *s, int &oldHead, int &newHead) {
  // skip beginning whitespace
  while (s[oldHead++] == ' ');

  // substring.begin()
  s[newHead++] = toupper(s[oldHead - 1]);

  // substring.begin() + 1 .. substring.end() - 1
  while (!eosubstr(s[oldHead]))
    s[newHead++] = tolower(s[oldHead++]);

  // strings.end()
  while (eosubstr(s[oldHead]))
    if (s[++oldHead] == '\0') {
      s[newHead] = '\0';
      return;
    }

  // substring.end()
  s[newHead++] = ' ';
}

void ChuanHoaXau(char *s) {
  int len_s = len(s);
  for (int oldHead = 0, newHead = 0; oldHead < len_s;)
    ChuanHoaXauDon(s, oldHead, newHead);
}

void Nhap(SinhVien &sv) {
  cin >> sv.MASV;
  cin.ignore();
  cin.getline(sv.HoTen, 100);
  cin >> sv.NgaySinh;
  cin >> sv.GioiTinh;
  cin >> sv.DiemToan >> sv.DiemLy >> sv.DiemHoa;
  sv.DTB = (sv.DiemToan + sv.DiemLy + sv.DiemHoa) / 3.0;
  ChuanHoaXau(sv.HoTen);
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
