#include <iostream>

int main() {
  int month, days_of_month;
  std::cin >> month;
  if (month > 12 || month < 1) {
    std::cout << "Thang khong hop le.";
    return 0;
  }
  switch (month) {
    case 1: case 3: case 5: case 7:
    case 8: case 10: case 12:
      days_of_month = 31;
      break;
    case 2:
      days_of_month = 28;
      break;
    default:
      days_of_month = 30;
      break;
  }
  std::cout << "Thang " << month << " co " << days_of_month << " ngay.";
}