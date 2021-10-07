#include <iostream>

int main() {
  int n;
  std::cin >> n;
  if (n < 3 || n > 20) {
    std::cout << "Khong thoa dieu kien nhap.";
    exit(0);
  }
  for (int r = 1; r <= n; ++r) {
    for (int c = 1; c <= n; ++c) {
      if (r == 1 || r == n) {
        std::cout << "*";
        if (c < n) std::cout << " ";
      } else {
        if (c == 1 || c == n) {
          std::cout << "*";
        } else {
          if (r == c || (n + 1 - r) == c || (n + 1 - c) == r) {
            std::cout << " *";
          } else {
            std::cout << "  ";
          }
          if (c == n - 1) std::cout << " ";
        }
      }
    }
    if (r < n) std::cout << "\n";
  }
}
