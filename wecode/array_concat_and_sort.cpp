#include <iostream>

const int MAXN = 100;

void NhapMang(int A[], int N) {
  for (int i = 0; i < N; i++)
    std::cin >> A[i];
}

void XuatMang(int A[], int N) {
  std::cout << N << '\n';
  for (int i = 0; i < N; i++)
    std::cout << A[i] << " ";
  std::cout << std::endl;
}

void TronMang(int (&kq)[MAXN], int &n_kq, const int (&arr)[MAXN], int &i) {
  kq[n_kq] = arr[i];
  ++i;
  ++n_kq;
}

void TronMangTangDan(int (&kq)[MAXN], int &n_kq, const int (&arr1)[MAXN], int n1, const int (&arr2)[MAXN], int n2) {
  int i1 = 0, i2 = 0;
  n_kq = 0;
  while (i1 < n1 && i2 < n2) {
    if (arr1[i1] < arr2[i2])
      TronMang(kq, n_kq, arr1, i1);
    else
      TronMang(kq, n_kq, arr2, i2);
  }
  while (i1 < n1) TronMang(kq, n_kq, arr1, i1);
  while (i2 < n2) TronMang(kq, n_kq, arr2, i2);
}

int main() {
  int a[MAXN], na, b[MAXN], nb, c[MAXN], nc;
  std::cin >> na;
  std::cin >> nb;
  NhapMang(a, na);
  NhapMang(b, nb);
  TronMangTangDan(c, nc, a, na, b, nb);
  XuatMang(c, nc);
  return 0;
}
