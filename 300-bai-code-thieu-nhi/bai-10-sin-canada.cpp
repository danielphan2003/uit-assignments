#include <bits/stdc++.h>

int main() {
  while (1) {
    std::string s;
    std::cout << "SIN (0 de thoat): ";
    std::cin >> s;

    if (s == "0") break;

    int s1 = 0, s2 = 0;

    for (int i = 0; i < s.length() - 1; i += 2)
      s1 += (s[i] - '0');

    for (int i = 1; i < s.length(); i += 2) {
      int _s2 = (s[i - 1] - '0')*2;
      if (_s2 / 10 >= 1) _s2 = (_s2 % 10) + (_s2 / 10);
      s2 += _s2;
    }

    if ((s1 + s2 + (s.back() - '0')) % 10 == 0)
      std::cout << "SIN hop le!\n";
    else
      std::cout << "SIN khong hop le!\n";
  };
}