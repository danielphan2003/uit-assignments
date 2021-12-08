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

void InDuongCheoChinh(const int (&arr)[MAXR][MAXC], int n) {
  for (int i = 0; i < n; ++i) {
    std::cout << arr[i][i];
    if (i < n - 1) std::cout << " ";
  }
}

int main(){
  int a[MAXR][MAXC], n;
  NhapMaTran(a, n);
  InDuongCheoChinh(a, n);
  return 0;
}
