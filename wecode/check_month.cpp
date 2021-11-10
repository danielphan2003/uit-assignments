#include <iostream>

int main() {
  int month;
  std::cin >> month;
  if (month > 12 || month < 1) {
    std::cout << "Thang khong hop le.";
  } else {
    std::cout << "Thang hop le.";
  }
}