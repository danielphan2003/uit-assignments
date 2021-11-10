#include <cmath>
#include <iostream>

int main() {
  int deg, region;
  std::cin >> deg;
  deg %= 360; // [0..360) if deg is positive, (-360..0] if negative
  deg += 360; // Back to [0..360)
  region = ((deg % 360) / 90) % 4 + 1; // Quadrant
  std::cout << region;
}
