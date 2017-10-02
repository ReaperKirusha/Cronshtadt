#pragma once
#include <iostream>

template <typename T>
class SmartPointer {
private:
	//bool* arrayOrNot;
	T* Point;
	unsigned int* PointsCount;

	void DeletePoint() {
		(*PointsCount) -= 1;
		if (*PointsCount == 0) {
			if (arrayOrNot) {
				delete[] Point;
			}
			else {
				delete Point;
			}
			free(PointsCount);
			free(arrayOrNot);
			Point = NULL;
			PointsCount = NULL;
		}
	}


	
public:
	SmartPointer(T* Tobj, bool _arrayOrNot) {

		Point = Tobj;
		PointsCount = (unsigned*)malloc(sizeof(unsigned));
		*PointsCount = 1;
		//arrayOrNot = (bool*)malloc(sizeof(bool));
		//*arrayOrNot = _arrayOrNot;
		std::cout << "Умный указатель приветсвует тебя" << std::endl;
	}

	SmartPointer(SmartPointer<T> & SPobj) {
		Point = SPobj.Point;
		PointsCount = SPobj.PointsCount;
		//arrayOrNot = SPobj.arrayOrNot;
		*PointsCount += 1;
		std::cout << "Я лишь тень" << std::endl;
		
	}
	
	T operator*() {
		return *Point;
	}

	T* operator->() { 
		return Point; 
	}

	SmartPointer & operator=(SmartPointer & SPobj) {
		if (*PointsCount > 0) {
			DeletePoint();
		}
		if (this != &SPobj) {
			Point = SPobj.Point;
			PointsCount = SPobj.PointsCount;
			//arrayOrNot = SPobj.arrayOrNot;
			++(*PointsCount);
		}

		return *this;
	}

	~SmartPointer() {
		DeletePoint();
		std::cout << "Да сын мой" << std::endl;
	}

};

class CFool {
public:
	CFool() {
		a = 3;
		std::cout << "Я родился" << std::endl;
	}
	~CFool() {
		std::cout << "Отец, все позади?" << std::endl;
	}

	int a;
};