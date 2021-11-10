#include <iostream>

int main() {
  double a, b, c;
  std::cin >> a >> b >> c;
  // good enough, but still too hacky
  if (a > b) std::swap(a, b);
  if (a > c) std::swap(a, c);
  if (b > c) std::swap(b, c);
  std::cout << a << " " << b << " " << c;
}
