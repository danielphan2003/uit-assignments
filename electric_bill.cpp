#include <cmath>
#include <iostream>
#include <vector>

const int VAT_TAX = 10;

int main() {
  int total_consumption;
  std::cin >> total_consumption;

  if (total_consumption < 0) {
    std::cout << "Khong hop le.";
    exit(0);
  }

  std::vector<int>
    prices { 1549, 1600, 1858, 2340, 2615 },
    ranges {
      50, // level 1
      50, // level 2
    }
  ;

  int
    price,
    range,
    bill = 0,
    default_price = 2701,
    default_range = 100,
    level = -1,
    recalc_consumption = 0
  ;

  while (total_consumption != recalc_consumption) {
    if (level == -1 || level < prices.size()) level += 1;

    if (level < ranges.size()) {
      range = ranges[level];
    } else {
      range = default_range;
    }

    if (level < prices.size()) {
      price = prices[level];
    } else {
      price = default_price;
    }

    if (total_consumption - recalc_consumption < range
      && (range == ranges[level] || level > ranges.size() - 1))
    {
      range = total_consumption - recalc_consumption;
    }

    recalc_consumption += range;
    bill += range * price;
  }

  bill = round((double) bill * (100 + VAT_TAX)/100);

  std::cout << bill;
}
