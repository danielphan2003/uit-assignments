#include <iostream>

const int MAXR = 100;
const int MAXC = 100;

void NhapMaTran(int (&arr)[MAXR][MAXC], int &n) {
  std::cin >> n;
  for (int i = 0; i < n; ++i)
    for (int j = 0; j < n; ++j)
      std::cin >> arr[i][j];
}

bool isMaTranDonVi(const int (&arr)[MAXR][MAXC], int n) {
  for (int i = 0; i < n; ++i)
    for (int j = 0; j < n; ++j)
      if ((i == j && arr[i][j] != 1) || (i != j && arr[i][j] != 0))
        return false;
  return n > 0;
}

int main() {
  int a[MAXR][MAXC], n;
  NhapMaTran(a, n);
  std::cout << std::boolalpha << isMaTranDonVi(a, n);
  return 0;
}
