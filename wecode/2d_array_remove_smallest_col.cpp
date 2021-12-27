#include <iostream>

const int MAXR = 100;
const int MAXC = 100;

void NhapMaTran(int (&arr)[MAXR][MAXC], int &r, int &c) {
  std::cin >> r >> c;
  for (int i = 0; i < r; ++i)
    for (int j = 0; j < c; ++j)
      std::cin >> arr[i][j];
}

void XuatMaTran(const int (&mat)[MAXR][MAXC], int m, int n) {
  for (int i = 0; i < m; ++i) {
    for (int j = 0; j < n; ++j) {
      std::cout << mat[i][j];
      if (j < n - 1) {
        std::cout << " ";
      }
    }
    if (i < m - 1) {
      std::cout << "\n";
    }
  }
}

int SoNhoNhat(const int (&arr)[MAXR][MAXC], int m, int n) {
  int min_el = arr[0][0];
  for (int i = 0; i < m; ++i)
    for (int j = 0; j < n; ++j)
      if (min_el > arr[i][j])
        min_el = arr[i][j];
  return min_el;
}

int CotSoDauTienNhoNhat(const int (&arr)[MAXR][MAXC], int m, int n) {
  int min_el = SoNhoNhat(arr, m, n);
  for (int i = 0; i < m; ++i)
    for (int j = 0; j < n; ++j)
      if (min_el == arr[i][j])
        return j;
  return 0;
}

void XoaCotChuaSoNhoNhat(int (&arr)[MAXR][MAXC], int &m, int &n) {
  int col = CotSoDauTienNhoNhat(arr, m, n);
  for (int i = 0; i < m; ++i)
    for (int j = 0; j < n; ++j)
      if (j >= col)
        arr[i][j] = arr[i][j + 1];
  --n;
}

int main(){
  int a[MAXR][MAXC], r, c;
  NhapMaTran(a, r, c);
  XoaCotChuaSoNhoNhat(a, r, c);
  XuatMaTran(a, r, c);
  return 0;
}
