#include <iostream>

void Input(int &N) { std::cin >> N; }

#include <climits>

const int MAXN = 100;

void NhapMang(int (&arr)[MAXN], int n) {
  for (int i = 0; i < n; ++i) {
    std::cin >> arr[i];
  }
}

void SoLonNhat(const int (&arr)[MAXN], int n, int &max) {
  long lMax = (long) INT_MIN - 1;
  for (int i = 0; i < n; ++i) {
    if (lMax < arr[i]) {
      lMax = arr[i];
    }
  }
  max = lMax;
}

int main() {
  int a[MAXN], n, max;
  Input(n);
  NhapMang(a, n);
  SoLonNhat(a, n, max);
  std::cout << max;
  return 0;
}
