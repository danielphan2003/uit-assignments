#include <iostream>

int main() {
  int n;
  std::cin >> n;
  if (n < 3 || n > 10) {
    std::cout << "Khong thoa dieu kien nhap.";
    exit(0);
  }
  for (int r = 1; r <= n; ++r) {
    for (int c = 1; c <= n; ++c) {
      std::cout << "*";
      if (c < n) std::cout << " ";
    }
    if (r < n) std::cout << "\n";
  }
}
