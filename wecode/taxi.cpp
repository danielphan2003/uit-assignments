// Tien cuoc TAXI Mai Linh (9/2015)

#include <iostream>
#include <iomanip>

int main() {
    int loaiXe;
    float khoangCach, thanhTien;

    enum LoaiXe {TVios, HVera, NSunny,
                 TInovaJ, KCaren, NLivina,
                 TInovaG, TInovaE, TInovaJ2014,
                 Morning, Hyundai_i10};

    //std::cout << "Nhap loai xe (Tu 0->10): ";
    std::cin >> loaiXe;
    //std::cout << "Nhap khoang cach (km): ";
    std::cin >> khoangCach;

    switch(loaiXe) {
      // Is there a reason why this is desired?
      // Having switch-case within switch-case seems arkward,
      // but I rather do that than repeating myself.
      default:
        int opening_price, next_to30, above31;
        double opening_range;
        switch (loaiXe) {
          case TVios: case HVera: case NSunny:
            opening_price = 11000;
            opening_range = 0.775;
            next_to30 = 14200;
            above31 = 11200;
            break;
          case TInovaJ: case KCaren: case NLivina:
            opening_price = 11000;
            opening_range = 0.738;
            next_to30 = 14900;
            above31 = 12800;
            break;
          case TInovaG: case TInovaE: case TInovaJ2014:
            opening_price = 12000;
            opening_range = 0.745;
            next_to30 = 16100;
            above31 = 13800;
            break;
          case Morning: case Hyundai_i10:
            opening_price = 10000;
            opening_range = 0.781;
            next_to30 = 12800;
            above31 = 10200;
            break;
        }
        thanhTien = opening_price;
        if (khoangCach > opening_range) {
          if (khoangCach < 30) {
            thanhTien = thanhTien + (khoangCach - opening_range) * next_to30;
          } else if (khoangCach > 30) {
            thanhTien = thanhTien + (30 - opening_range) * next_to30 + (khoangCach - 30.0) * above31;
          }
        }
        break;
    }
    std::cout << std::setprecision(1) << std::fixed << thanhTien;
    return 0;
}
