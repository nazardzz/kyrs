#pragma once
class Plural
{
	int * arr;
	int n;

public:

	void showPlural();

	Plural &operator = (const Plural &);
	friend Plural operator +(const Plural &, const Plural &);
	friend Plural operator &(Plural &, Plural &);
	Plural &operator + (int);
	Plural & operator -(int);


	Plural(int *, int);
	Plural(const Plural &);
	Plural();
	~Plural();
};


