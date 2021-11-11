#include <iostream>
#include <vector>

void exit_or_print_space_if(bool cond) {
  if (cond) {
    std::cout << " ";
  } else {
    exit(0);
  }
}

int main() {
  int N;
  std::cin >> N;
  if (N < 100 || N > 999) {
    std::cout << "NULL";
    return 0;
  }

  std::vector<std::string> num_str{"", "mot", "hai", "ba", "bon", "nam", "sau", "bay", "tam", "chin"};

  int first = N / 100, second = (N / 10) % 10, last = N % 10;

  std::cout << num_str[first] << " tram";

  exit_or_print_space_if(second != 0 || last != 0);

  switch (second) {
    case 0:
      std::cout << "le";
      break;
    case 1:
      std::cout << "muoi";
      break;
    default:
      std::cout << num_str[second] << " muoi";
      break;
  }

  exit_or_print_space_if(last != 0);

  if (second != 0) num_str[5] = "lam";
  std::cout << num_str[last];
}
