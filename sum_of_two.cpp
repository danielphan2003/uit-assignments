#include <algorithm>
#include <bits/stdc++.h>

long x;

void announce_impossible() {
  std::cout << "IMPOSSIBLE";
  exit(0);
}

void print_ans(int a, int b) {
  std::cout << a << " " << b;
}

int cmp(std::pair<int, int> a, std::pair<int, int> b) {
  return a.first < b.first;
}

int pred_unique_intersect(std::pair<int, int> a, std::pair<int, int> b) {
  // remove duplicates if one.first equals x/2
  // or when one.second (original index) is higher than other
  return a.first == b.first && (a.first == (double) x/2 || a.second < b.second);
}

std::vector< std::pair<long, int> >
intersection(std::vector< std::pair<long, int> > &v1,
            std::vector< std::pair<long, int> > &v2) {
    std::vector< std::pair<long, int> > v3;

    std::sort(v1.begin(), v1.end(), cmp);
    std::sort(v2.begin(), v2.end(), cmp);

    std::set_intersection(v1.begin(),v1.end(),
                          v2.begin(),v2.end(),
                          back_inserter(v3), cmp);
    return v3;
}

int main() {
  std::ios_base::sync_with_stdio(false);
  std::cin.tie(nullptr);
  std::cout.tie(nullptr);

  size_t n;
  int min_el = -1;
  std::cin >> n >> x;

  std::vector< std::pair<long, int> > arr(n), neg, dup;
  for (size_t i = 0; i < n; ++i) {
    long first;
    int second = i;
    std::cin >> first;
    arr[i] = std::make_pair(first, second);
    if (first < min_el) min_el = first;
  }

  if (min_el > x) announce_impossible();

  std::sort(arr.begin(), arr.end(), cmp);

  while (arr[arr.size() - 1].first > x) arr.pop_back();

  neg = arr;
  for (size_t i = 0; i < neg.size(); ++i)
    neg[i].first = x - neg[i].first;

  auto intersect = intersection(arr, neg);

  if (intersect.size() < 2) announce_impossible();

  for (size_t i = 0; i < intersect.size(); ++i) {
    if (intersect[i].first == (double) x/2)
      dup.push_back(intersect[i]);
  }

  if (dup.size() > 1) {
    int min_dup_idx = 2e5 + 1, max_dup_idx = -1;
    for (size_t i = 0; i < dup.size(); ++i) {
      if (dup[i].second < min_dup_idx) min_dup_idx = dup[i].second + 1;
      if (dup[i].second > max_dup_idx) max_dup_idx = dup[i].second + 1;
    }
    print_ans(min_dup_idx, max_dup_idx);
    auto last = std::unique(intersect.begin(), intersect.end(), pred_unique_intersect);
    intersect.erase(last, intersect.end());
    if (intersect.size() >= 2) std::cout << "\n";
  }

  for (size_t i = 0; i < intersect.size() - 1; ++i) {
    for (size_t j = i + 1; j < intersect.size(); ++j) {
      if (intersect[i].first + intersect[j].first == (double) x) {
        print_ans(intersect[i].second + 1, intersect[j].second + 1);
        if (j < intersect.size()) std::cout << "\n";
      }
    }
  };
}
