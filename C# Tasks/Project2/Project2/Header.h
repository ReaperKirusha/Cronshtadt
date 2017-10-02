#pragma once
#include <iostream>
using namespace std;

class NewClass2 {
public:
	NewClass2(const NewClass2 &objNC2) {
		cout << "constructor" << endl;
		a = objNC2.a;
		b = objNC2.b;
	}
	NewClass2(int _a, int _b) {
		cout << "destructor" << endl;
		a = _a;
		b = _b;

		//NewClass2 NC2 = NewClass2();
			// при таком вызове будет вызвано 2 контсруктора
			// стоит писать так "NewClass2 NC2()"
			//при реализации конструктора переменные обь€вл€ютс€ до вызова конструктора,
			// поэтому дефолтные параметры следует указывать через ":" в реализации
	}
	~NewClass2() {
		cout << "destructor" << endl;
	}

	NewClass2& operator=(const NewClass2 &objNC2) {
		a = objNC2.a;
		b = objNC2.b;
		return *this;
	}

	friend ostream& operator<<(ostream& stream, const NewClass2& objNC2);

private:
	int a, b;
};

ostream& operator<<(ostream& stream, const NewClass2& objNC2) {
	stream << objNC2.a << endl;
	return stream;
}

class CFoo{
private:
	int a;
public:
	~CFoo() {
		cout << "CFoo destructor" << endl;
	}
};

class PointCFoo{
public:

	CFoo* pCf;
	~PointCFoo() {
		cout << "PointCFoo destructor" << endl;
		delete pCf;
	}
};

CFoo operator*(PointCFoo objF) {
	return *(objF.pCf);
}