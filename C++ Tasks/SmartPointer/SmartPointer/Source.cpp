#include <iostream>
#include "Header.h"

int Func1() {
	SmartPointer<CFool> SPCFool1(new CFool(),true);
	//SmartPointer<CFool> SPCFool2(SPCFool1);
	//SmartPointer<CFool> SPCFool3(new CFool());
	//SPCFool3 = SPCFool1;

	//std::cout << SPCFool1->a << std::endl;
	return 1;
}

void main() {
	setlocale(LC_ALL, "ru-ru");

	char *bionk = new char[10] ;
	for (int i = 0; i < 10; i++) {

		bionk[i] = 'b';
		if (i == 1) {
			bionk[i] = 'x';
		}
	}
	char  a = 'a';
	std::cout << sizeof(*bionk) << std::endl;
	std::cout << sizeof(a) << std::endl;
	std::cout << *bionk << std::endl;
	delete[] bionk;

	//Func1();

	//std::cout << *NewP << std::endl;

	system("pause");
}