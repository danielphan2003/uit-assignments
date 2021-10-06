#include <iostream>

int main() {
  int a = 5;
  int d = a;
  int &g = a;
  g = 7;
  int *p = &a;
  a = 10;
  g = 15;
  (*p) = 20;
  std::cout << "hi";
}
