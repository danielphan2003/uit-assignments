#include <iostream>

const int MAXR = 100;
const int MAXC = 100;

void NhapMaTran(int (&arr)[MAXR][MAXC], int &n) {
  std::cin >> n;
  for (int i = 0; i < n; ++i) {
    for (int j = 0; j < n; ++j) {
      std::cin >> arr[i][j];
    }
  }
}

int TongNuaTrenDuongCheoChinh(const int (&arr)[MAXR][MAXC], int n) {
  int sum = 0;
  for (int i = 0; i < n; ++i)
    for (int j = i + 1; j < n; ++j)
      sum += arr[i][j];
  return sum;
}

int main() {
  int a[MAXR][MAXC], n;
  NhapMaTran(a, n);
  std::cout << TongNuaTrenDuongCheoChinh(a, n);
  return 0;
}

