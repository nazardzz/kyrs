#include "stdafx.h"
#include "Plural.h"
#include <iostream>

using namespace std;

void Plural::showPlural()
{
	cout << endl;
	for (int i = 0; i < n; i++)
		cout << arr[i] << "  ";
	cout << endl;
}

Plural & Plural::operator=(const Plural & p)
{

	this->n = p.n;
	if (arr == NULL)
		delete[] this->arr;

	this->arr = new int[this->n];
	for (int i = 0; i < this->n; i++)
		this->arr[i] = p.arr[i];

	return *this;
}

Plural &Plural::operator+(int num)
{

	int * arrTmp = new int[n];
	for (int i = 0; i < n; i++)
		arrTmp[i] = arr[i];
	n++;

	if (arr == NULL)
		delete[] arr;

	arr = new int[n];
	for (int i = 0; i < n - 1; i++) {
		arr[i] = arrTmp[i];
	}
	arr[n - 1] = num;
	delete[] arrTmp;

	return *this;
}

Plural & Plural::operator-(int num)
{
	bool isThere = false;
	int * arrTmp = new int[n];
	for (int i = 0; i < n; i++) {
		arrTmp[i] = arr[i];
		if (arr[i] == num)
			isThere = true;
	}
	delete[] arr;
	n--;
	arr = new int[n];
	if (isThere) {
		for (int i = 0, j = 0; i < n + 1 && j < n; i++) {
			if (arrTmp[i] != num) {
				arr[j] = arrTmp[i];
				j++;
			}
		}
	}
	else {
		cout << "this element is not exists." << endl;
	}

	delete[] arrTmp;
	return *this;
}

Plural::Plural(int * arr, int n)
{
	this->n = n;
	this->arr = new int[n];
	for (int i = 0; i < n; i++)
		this->arr[i] = arr[i];
}

Plural::Plural(const Plural & p)
{
	arr = new int[p.n];
	n = p.n;
	for (int i = 0; i < n; i++)
		arr[i] = p.arr[i];
}

Plural::Plural()
{
	cout << "enter n, count of the plural: "; cin >> n;
	arr = new int[n];

	cout << "enter elements:" << endl;
	for (int i = 0; i < n; i++) {
		cout << "arr[" << i << "] = "; cin >> arr[i];
	}
}


Plural::~Plural()
{
	if (arr != NULL)
		delete[] arr;
}

Plural operator+(const Plural & p1, const Plural & p2)
{
	int n = p1.n + p2.n;
	int * arr = new int[n];
	for (int i = 0; i < p1.n; i++)
		arr[i] = p1.arr[i];
	for (int i = p1.n, j = 0; i < n && j < p2.n; j++, i++)
		arr[i] = p2.arr[j];

	return Plural(arr, p1.n + p2.n);
}

Plural operator&(Plural & p1, Plural & p2)
{
	int count = 0;
	for (int i = 0; i < p1.n; i++) {
		for (int j = 0; j < p2.n; j++) {
			if (p1.arr[i] == p2.arr[j])
				count++;
		}
	}
	int *arrLoc = new int[count];

	for (int i = 0, k = 0; i < p1.n && k < count; i++) {
		for (int j = 0; j < p2.n; j++) {
			if (p1.arr[i] == p2.arr[j]) {
				arrLoc[k] = p1.arr[i];
				k++;
			}
		}
	}

	return Plural(arrLoc, count);
}