#include <iostream>

int main() {
  int a, b;
  std::cin >> a >> b;
  double d = (double) a / b;
  int r = a % b;
  std::cout << d << "\n";
  std::cout << r;
}
