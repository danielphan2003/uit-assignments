#include <cmath>
#include <iomanip>
#include <iostream>

int main() {
  double dToan, dLy, dHoa;
  std::cin >> dToan >> dLy >> dHoa;
  double dtb = (dToan + dLy + dHoa)/3.0;
  std::string xeploai = "KEM";
  if (dtb >= 9 && dtb <= 10) {
    xeploai = "XUAT SAC";
  } else if (dtb >= 8 && dtb < 9) {
    xeploai = "GIOI";
  } else if (dtb >= 7 && dtb < 8) {
    xeploai = "KHA";
  } else if (dtb >= 6 && dtb < 7) {
    xeploai = "TB KHA";
  } else if (dtb >= 5 && dtb < 6) {
    xeploai = "TB";
  } else if (dtb >= 4 && dtb < 5) {
    xeploai = "YEU";
  }
  if (trunc(dtb) != dtb)
    std::cout << std::fixed << std::showpoint << std::setprecision(2);
  std::cout << "DTB = " << dtb << "\n";
  std::cout << "Loai: " << xeploai;
}
