#include <cmath>
#include <iomanip>
#include <iostream>

int main() {
  double a, b, c, expr;
  std::cin >> a >> b >> c;
  expr = pow(a, 5.0) - 2*sqrt(fabs(b)) + a*b*c;
  std::cout << std::fixed << std::showpoint << std::setprecision(2);
  std::cout << expr;
}
