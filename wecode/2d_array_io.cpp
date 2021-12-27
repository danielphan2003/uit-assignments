
#include <iostream>

const int MAXR = 100;
const int MAXC = 100;

void NhapMaTran(int (&mat)[MAXR][MAXC], int &r, int &c) {
  std::cin >> r >> c;
  for (int i = 0; i < r; ++i) {
    for (int j = 0; j < c; ++j) {
      std::cin >> mat[i][j];
    }
  }
}

void XuatMaTran(const int (&mat)[MAXR][MAXC], int m, int n) {
  for (int i = 0; i < m; ++i) {
    for (int j = 0; j < n; ++j) {
      std::cout << mat[i][j];
      if (j < n - 1) {
        std::cout << "\t";
      }
    }
    if (i < m - 1) {
      std::cout << "\n";
    }
  }
}

int main() {
  int a[MAXR][MAXC], r, c;
  NhapMaTran(a, r, c);
  XuatMaTran(a, r, c);
  return 0;
}
