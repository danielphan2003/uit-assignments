#include <iostream>

int main() {
  double a, b, x;
  std::cin >> a >> b;
  if (a == 0) {
    if (b == 0) {
      std::cout << "Vo so nghiem";
    } else {
      std::cout << "Vo nghiem";
    }
    return 0;
  }
  x = -b/a;
  if (x == -0.0) x = 0;
  std::cout << x;
}
