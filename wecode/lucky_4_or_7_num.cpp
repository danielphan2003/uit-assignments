#include <iostream>
#include <vector>

int main() {
  std::string N;
  std::cin >> N;
  std::vector<int> occurences(11, 0);
  for (int i = 0; i < N.length(); ++i) {
    ++occurences[N[i] - '0'];
  }
  if (occurences[4] + occurences[7] == N.length()) {
    std::cout << "YES";
  } else {
    std::cout << "NO";
  }
}
