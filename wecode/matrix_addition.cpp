#include <iostream>
#define MAXR 100
#define MAXC 100

void XuatMaTran(int A[][MAXC], int ar, int ac) {
    for (int i = 0; i < ar; i++) {
        for (int j = 0; j < ac; j++)
            std::cout << A[i][j] << "\t";
        std::cout << "\n";
    }
    std::cout << "\n";
}

void NhapMaTran(int (&mat)[MAXR][MAXC], int &r, int &c) {
  std::cin >> r >> c;
  for (int i = 0; i < r; ++i) {
    for (int j = 0; j < c; ++j) {
      std::cin >>mat[i][j];
    }
  }
}

void Cong2MaTran(const int (&matA)[MAXR][MAXC], int matA_m, int matA_n,
                 const int (&matB)[MAXR][MAXC], int matB_m, int matB_n,
                 int (&matAns)[MAXR][MAXC], int &matAns_m, int &matAns_n)
{
  matAns_m = matA_m;
  matAns_n = matA_n;
  for (int i = 0; i < matAns_m; ++i) {
    for (int j = 0; j < matAns_n; ++j) {
      matAns[i][j] = matA[i][j] + matB[i][j];
    }
  }
}

int main() {
  int a[MAXR][MAXC], ar, ac, // Mảng a có (ar dòng x ac cột)
      b[MAXR][MAXC], br, bc, // Mảng a có (br dòng x bc cột)
      c[MAXR][MAXC], cr, cc; // Mảng a có (cr dòng x cc cột)
  NhapMaTran(a, ar, ac);
  NhapMaTran(b, br, bc);
  Cong2MaTran(a, ar, ac, b, br, bc, c, cr, cc);
  XuatMaTran(c, cr, cc);
  return 0;
}
