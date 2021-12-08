#include <iostream>

const int MAXN = 100;

void NhapMang(int (&arr)[MAXN], int &n) {
  std::cin >> n;
  for (int i = 0; i < n; ++i)
    std::cin >> arr[i];
}

bool is_MangDoiXung(const int (&arr)[MAXN], int n) {
  for (int i = 0; i < n/2; ++i)
    if (arr[i] != arr[n-i-1])
      return false;
  return n > 0;
}

int main() {
  int a[MAXN], n;
  NhapMang(a, n);
  if (is_MangDoiXung(a, n) == true)
    std::cout << "Mang doi xung.";
  else
    std::cout << "Mang khong doi xung.";
  return 0;
}
