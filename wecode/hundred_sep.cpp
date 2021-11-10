#include <iostream>

int main() {
  int n;
  std::cin >> n;
  std::cout << (n / 100) << " " << ((n / 10) % 10) << " " << ((n % 100) % 10) << " ";
}
