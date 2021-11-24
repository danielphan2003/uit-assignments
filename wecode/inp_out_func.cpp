#include <iostream>

void input(int &a) {
  std::cin >> a;
}

void output(int a) {
  std::cout << a;
}

int main(){
  int a;
  input(a);
  output(a);
  return 0;
}
