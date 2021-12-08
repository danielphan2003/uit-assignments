#include <iostream>

const int MAXN = 100;

void NhapMang(int (&arr)[MAXN], int &n) {
  std::cin >> n;
  for (int i = 0; i < n; ++i)
    std::cin >> arr[i];
}

int DemMangConBang(const int (&arr)[MAXN], int n) {
  int dem = 0, i = 0, eq, len;
  bool init = false;

  do {
    if (!init) {
      eq = arr[i];
      len = 1;
      init = true;
    }
    ++i;
    if (eq == arr[i]) {
      ++len;
    } else {
      if (len >= 3) ++dem;
      init = false;
    }
  }
  while (eq != arr[i] || i < n);

  return dem;
}

int main() {
  int a[MAXN], n;
  NhapMang(a, n);
  std::cout << DemMangConBang(a, n);
  return 0;
}
