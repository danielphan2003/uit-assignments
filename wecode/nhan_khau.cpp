#include <iostream>

int main() {
  int age, type;
  char gender;
  std::cin >> age >> gender;
  gender = tolower(gender);
  if (gender != 'm' && gender != 'f') {
    std::cout << "I do not know why";
    return 0;
  }
  // avoid branching like this
  if (gender == 'm') {
    if (age >= 21) {
      type = 1;
    } else {
      type = 3;
    }
  } else {
    if (age >= 21) {
      type = 2;
    } else {
      type = 4;
    }
  }

  std::cout << type;
}