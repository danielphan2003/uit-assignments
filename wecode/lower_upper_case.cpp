#include <iostream>

int main() {
  char c;
  std::cin >> c;
  // if (!isalpha(c)) {
  //   std::cout << "Khong phai ky tu Alphabet.";
  //   return 0;
  // }
  // if (islower(c)) {
  //   c = toupper(c);
  // } else {
  //   c = tolower(c);
  // }
  // std::cout << c;
  std::cout <<
    (!isalpha(c)
      ? std::string("Khong phai ky tu Alphabet.")
      // char only has 1 character
      : std::string(1, (char)
        (islower(c)
          ? toupper(c)
          : tolower(c))));
}
