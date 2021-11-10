#include <cmath>
#include <iostream>

int main() {
  int deg, region;
  std::cin >> deg;
  while (deg < 0) deg += 360;
  while (deg >= 360) deg -= 360;
  if (deg % 90 == 0) deg += 90;
  region = ceil(deg/90.0);
  std::cout << region;
}
