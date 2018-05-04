#include "stdafx.h"
#include "Plural.h"
#include <iostream>

using namespace std;

int main()
{
	Plural p1;
	p1.showPlural();
	Plural p2;
	p2.showPlural();


	Plural p3 = p1 + p2;
	cout << "p1 + p2 = " << endl;
	p3.showPlural();

	Plural p4 = p1 & p2;
	cout << "p1 & p2 = " << endl;
	p4.showPlural();

	cout << "p4 + 221 = " << endl;
	p4 + 221;
	p4.showPlural();
	cout << "p4 - 2 = " << endl;
	p4 - 2;
	p4.showPlural();

	system("pause");
	return 0;
}
