#include <cmath>
#include <iostream>
#include <iomanip>

int main() {
  double r;
  std::cin >> r;
  double p = 2*M_PI*r, s = M_PI*r*r;
  std::cout << std::fixed << std::showpoint << std::setprecision(14) << p << "\n" << std::setprecision(3) << s;
}
