#include <iostream>

int gcd(int a, int b) {
  a = std::abs(a);
  b = std::abs(b);
  if (a < b) std::swap(a, b);
  if (b == 0) return a;
  return gcd(b, a % b);
}

int lcm(int a, int b, int memo = 0) {
  if (a == 0 || b == 0) return 0;
  if (memo == 0) memo = gcd(a, b);
  return std::abs(a * b) / memo;
}

int main() {
  int a, b, memo;
  std::cin >> a >> b;
  memo = gcd(a, b);
  std::cout << "Uoc chung lon nhat: " << memo << "\n";
  std::cout << "Boi chung nho nhat: " << lcm(a, b, memo) << "\n";
}
