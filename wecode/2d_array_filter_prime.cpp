#include <iostream>
#include <cmath>

const int MAXR = 100;
const int MAXC = 100;

bool KtNgto(int n) {
  if (n <= 1) return false;
  if (n == 2) return true;
  for (int i = 2; i <= trunc(sqrt(n)); ++i) {
    if (n % i == 0) return false;
  }
  return true;
}

void NhapMaTran(int (&arr)[MAXR][MAXC], int &r, int &c) {
  std::cin >> r >> c;
  for (int i = 0; i < r; ++i) {
    for (int j = 0; j < c; ++j) {
      std::cin >> arr[i][j];
    }
  }
}

void TimSoNguyenTo(const int (&arr)[MAXR][MAXC], int m, int n, int lower_bound, int upper_bound) {
  for (int i = 0; i < m; ++i) {
    for (int j = 0; j < n; ++j) {
      if (arr[i][j] <= lower_bound || arr[i][j] >= upper_bound) continue;
      if (KtNgto(arr[i][j])) {
        std::cout << arr[i][j];
        if (i <= m - 1 || j <= n - 1) std::cout << "\t";
      }
    }
  }
}

int main() {
  int a[MAXR][MAXC], r, c;
  NhapMaTran(a, r, c);
  TimSoNguyenTo(a, r, c, 5, 100);
  return 0;
}
