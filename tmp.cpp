#include <iostream>

int main()
{
    std::cin.tie(NULL);
    std::ios_base::sync_with_stdio(false);

    double x, y;

    double tmp = y;
    y = x;
    x = tmp;

    std::cout << x << std::endl << y;
    return 0;
}
