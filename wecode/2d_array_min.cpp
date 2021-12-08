#include <climits>
#include <iostream>

const int MAXR = 100;
const int MAXC = 100;

void NhapMaTran(int (&arr)[MAXR][MAXC], int &r, int &c) {
  std::cin >> r >> c;
  for (int i = 0; i < r; ++i)
    for (int j = 0; j < c; ++j)
      std::cin >> arr[i][j];
}

int SoNhoNhat(const int (&arr)[MAXR][MAXC], int m, int n) {
  long min = (long) INT_MAX + 1;
  for (int i = 0; i < m; ++i)
    for (int j = 0; j < n; ++j)
      if (min > arr[i][j])
        min = arr[i][j];
  return min;
}

int main(){
  int a[MAXR][MAXC], r, c;
  NhapMaTran(a, r, c);
  std::cout << SoNhoNhat(a, r, c);
  return 0;
}
