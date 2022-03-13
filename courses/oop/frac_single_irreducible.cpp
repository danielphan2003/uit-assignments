#include <iostream>
#include <cmath>

class PhanSo
{
public:
    PhanSo() {}

    void nhap()
    {
        do
        {
            std::cin >> mTu >> mMau;
        }
        while (mMau == 0);
    }

    void rut_gon()
    {
        int mauChung = gcd(mTu, mMau);
        if (mTu > 0 && mMau < 0 || mTu < 0 && mMau > 0)
            mauChung = -mauChung;
        mTu = mTu / mauChung;
        mMau = mMau / mauChung;
    }
    
    void xuat()
    {
        std::cout << mTu << "/" << mMau << "\n";
    }

protected:
    static int gcd(int p1, int p2)
    {
        if (std::abs(p1) < std::abs(p2))
            std::swap(p1, p2);
        if (p2 == 0)
            return p1;
        return gcd(p2, p1 % p2);
    }

private:
    int mTu;
    int mMau;
};


int main()
{
    PhanSo* p = new PhanSo();
    p->nhap();
    p->rut_gon();
    p->xuat();
    return 0;
}
