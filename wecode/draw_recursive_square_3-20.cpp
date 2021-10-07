#include <iostream>

// void draw_row(int r, int c, int max) {
  
// }

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
          
        }
      }
    }
    if (r < n) std::cout << "\n";
  }
}
