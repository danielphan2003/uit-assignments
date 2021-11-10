#include <cmath>
#include <iostream>

int main() {
  double a, b, c, delta;
  std::cin >> a >> b >> c;
  delta = b*b-4*a*c;
  if (delta < 0) {
    std::cout << "Vo nghiem";
    return 0;
  }
  double
    x1 = (-b+sqrt(delta))/(2*a),
    x2 = (-b-sqrt(delta))/(2*a);
  if (x1 > x2) std::swap(x1, x2);
  std::cout << "(" << x1 << ", " << x2 << ")";
}
