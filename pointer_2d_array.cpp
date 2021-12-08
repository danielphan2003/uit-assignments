#include <iostream>
#include <cstring> // <string.h>
#define MAXN 1000
using namespace std;
int main() {
    int a[2][4]={76,  87, 40,  331, 456, 23, 174, 56};
    cout << a[0][0] << "\t" << a[0][1] << "\t" << a[0][2] << "\t" << a[0][3] << endl;
    cout << a[1][0] << "\t" << a[1][1] << "\t" << a[1][2] << "\t" << a[1][3] << endl;
    cout << "&a  = " << a << endl;
    cout << "a[0]= " << a[0] << endl;
    cout << "a[1]= " << a[1] << endl;
    cout << &a[0][0] << "\t" <<  &a[0][1] << "\t" <<  &a[0][2] << "\t" <<  &a[0][3] << endl;
    cout << &a[1][0] << "\t" <<  &a[1][1] << "\t" <<  &a[1][2] << "\t" <<  &a[1][3] << endl;
    cout <<  "&a[0][0]+1 = " << &a[0][0]+1 << endl;
    cout <<  "&a[0][3]+1 = " << &a[0][3]+1 << endl;
    return 0;
}