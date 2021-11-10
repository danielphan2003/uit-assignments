#include <iostream>

int main() {
  int n, first, last, sum_letter;
  std::cin >> n;
  first = n / 1000;
  last = ((n % 1000) % 100) % 10;
  sum_letter = first + ((n % 1000) / 100) + ((n % 100) / 10) + last;
  std::cout << sum_letter << ", " << first << ", " << last;
}
