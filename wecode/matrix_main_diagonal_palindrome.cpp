#include <iostream>

const int MAXR = 100;
const int MAXC = 100;

void NhapMaTran(int (&arr)[MAXR][MAXC], int &n) {
  std::cin >> n;
  for (int i = 0; i < n; ++i)
    for (int j = 0; j < n; ++j)
      std::cin >> arr[i][j];
}

bool DoiXungQuaDuongCheoChinh(const int (&arr)[MAXR][MAXC], int n) {
  for (int i = 0; i < n; ++i)
    for (int j = 0; j < n; ++j)
      if (arr[i][j] != arr[j][i])
        return false;
  return n > 0;
}

int main() {
  int a[MAXR][MAXC], n;
  NhapMaTran(a, n);
  std::cout << std::boolalpha << DoiXungQuaDuongCheoChinh(a, n);
  return 0;
}
