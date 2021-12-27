#include <iostream>

void Input(int &N) { std::cin >> N; }

const int MAXN = 100;

void NhapMang(int (&arr)[MAXN], int n) {
  for (int i = 0; i < n; ++i) {
    std::cin >> arr[i];
  }
}

void SoLonNhat(const int (&arr)[MAXN], int n, int &max) {
  max = arr[0];
  for (int i = 1; i < n; ++i)
    if (max < arr[i])
      max = arr[i];
}

int main() {
  int a[MAXN], n, max;
  Input(n);
  NhapMang(a, n);
  SoLonNhat(a, n, max);
  std::cout << max;
  return 0;
}
