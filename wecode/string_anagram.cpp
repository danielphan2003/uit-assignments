#include <iostream>

const int MAXN = 100;

int len(const char *s) {
  int dem = 0;
  while (s[dem] != '\0')
    dem++;
  return dem;
}

bool isAnagram(const char *s1, const char *s2) {
  int max = 'z', min = 'A', range = max - min;

  int dem_s1[range], dem_s2[range];

  int len_s1 = len(s1), len_s2 = len(s2);

  if (len_s1 != len_s2) return false;

  for (int i = 0; i < range; ++i) {
    dem_s1[i] = 0;
    dem_s2[i] = 0;
  }
  
  for (int i = 0; i < len_s1; ++i) {
    ++dem_s1[s1[i] - min];
    ++dem_s2[s2[i] - min];
  }

  for (int i = 0; i < range; ++i)
    if (dem_s1[i] != dem_s2[i])
      return false;
  return true;
}

int main() {
  char s1[MAXN], s2[MAXN];
  std::cin.getline(s1, MAXN);
  std::cin.getline(s2, MAXN);
  if (isAnagram(s1, s2))
    std::cout << "YES";
  else
    std::cout << "NO";
}
