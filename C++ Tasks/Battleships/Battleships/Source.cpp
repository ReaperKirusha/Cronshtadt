#include "Header.h"
#include <iostream>
void main() {
	setlocale(LC_ALL, "ru-ru");

	Player Pobj(10,10, "Agri");
	  
	std::cout << Pobj.SetShips_InShips(cell(0,1), cell(3, 1 ), 4) << std::endl;
	std::cout << Pobj.SetShips_InShips(cell(0, 1), cell(3, 1), 4) << std::endl;
	PrintField(Pobj, "Ships");


	system("pause");
}