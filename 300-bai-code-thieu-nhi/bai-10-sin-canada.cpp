#include <bits/stdc++.h>

int main() {
  std::string s;
  do {
    std::cout << "SIN (0 de thoat): ";
    std::cin >> s;

    int s1 = 0, s2 = 0;

    for (int i = 0; i < s.length() - 1; i += 2) {
      s1 = s1 + (int(s[i]) - int('0'));
    }

    for (int i = 1; i < s.length(); i += 2)
      s2 = s2 + (int(s[i]) - int('0'))*2;

    if (s2 / 10 >= 1) s2 = (s2 % 10) + (s2 / 10);

    if ((s1 + s2 + int(s[s.length() - 1])) % 10 != 0)
      std::cout << "SIN khong hop le!\n";
    else
      std::cout << "SIN hop le!\n";

  } while (s != "0");
}