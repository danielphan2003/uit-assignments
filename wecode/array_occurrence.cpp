#include <iostream>

const int MAXN = 100;

void NhapMang(int (&arr)[MAXN], int &n) {
  std::cin >> n;
  for (int i = 0; i < n; ++i) {
    std::cin >> arr[i];
  }
}

int SoLonNhat(const int (&arr)[MAXN], int n) {
  int max = arr[0];
  for (int i = 1; i < n; ++i)
    if (max < arr[i])
      max = arr[i];
  return max;
}

int SoNhoNhat(const int (&arr)[MAXN], int n) {
  int min = arr[0];
  for (int i = 1; i < n; ++i)
    if (min > arr[i])
      min = arr[i];
  return min;
}

void DemSoLanXuatHien(const int (&arr)[MAXN], int n) {
  int max = SoLonNhat(arr, n), min = SoNhoNhat(arr, n), range = max - min;
  int dem[range + 1];
  bool output[range + 1];

  for (int i = 0; i < n; ++i) {
    dem[arr[i] - min] = 0;
    output[arr[i] - min] = false;
  }

  for (int i = 0; i < n; ++i)
    ++dem[arr[i] - min];

  for (int i = 0; i < n; ++i)
    if (!output[arr[i] - min]) {
      std::cout << arr[i] << " xuat hien " << dem[arr[i] - min] << " lan\n";
      output[arr[i] - min] = true;
    }
}

int main() {
  int a[MAXN], n;
  NhapMang(a, n);
  DemSoLanXuatHien(a, n);
  return 0;
}
