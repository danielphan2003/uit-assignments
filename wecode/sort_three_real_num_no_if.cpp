#include <iostream>

int swap(double &f, double &p) {
  return f > p ? (p = f, f) : p;
}

int main() {
  double a, b, c;
  std::cin >> a >> b >> c;
  a = swap(a, b);
  a = swap(a, c);
  b = swap(b, c);
  std::cout << c;
}
