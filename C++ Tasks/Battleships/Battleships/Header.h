#pragma once
#include <iostream>
#include <string>
#include <math.h>
// o - путсая клетка
// s - клетка с кораблем
// v - клетка на которой не может быть корабля

struct cell {
	int x, y;
	cell(int _x, int _y) {
		x = _x;
		y = _y;
	}
};

class Player {
private:
	std::string PlayerName;
	int rows, collumns;
	char ShipsField[100][100];
	char ShotsField[100][100];

	bool StatusForSetting(int row, int collumn) {
		if (((row < rows) && (collumn < collumns))&& ((-1 < row) && (-1 < collumn))) {
			return (ShipsField[rows - row - 1][collumn] == 'o');
		}
		else {
			return true;
		}
	}
public:
	Player(int _rows, int _collumns,std::string _PlayerName) {
		PlayerName = _PlayerName;
		rows = _rows;
		collumns = _collumns;	
		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < collumns; j++) {
				ShipsField[i][j] = 'o';				
			}			
		}

		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < collumns; j++) {
				ShotsField[i][j] = 'o';
			}
		}
	}

	char TellCellStatus_InShips(int row, int collumn) {
		if ((row < rows) && (collumn < collumns)) {
			return ShipsField[row][collumn];
		}
		else {
			try {
				throw std::string("ошибка колонок");
			}
			catch(std::string a){
				std::cout << a << std::endl;
			}
		}
	}

	bool SetCellStatus_InShips(int row, int collumn, char Status) {
		if ((row < rows) && (collumn < collumns) && ((-1 < row) && (-1 < collumn)) ) {
			ShipsField[rows - row - 1][collumn] = Status;
			return true;
		}
		else {
			return false;
		}
	}

	bool SetShips_InShips(cell first, cell second, int TypeOfShip) {
		char Axis;
		if ((first.x != second.x) && (first.y != second.y)) {
			return false;
		}else {
			if ((first.x != second.x)) {
				Axis = 'x';
			}
			else {
				Axis = 'y';
			}
		}

		if (Axis == 'x') {
			if ((abs(first.x - second.x) + 1) != TypeOfShip) {
				return false;
			}

			int y = first.y;
			int x1, x2;

			if (first.x < second.x) {
				x1 = first.x;
				x2 = second.x;
			}
			else {
				x2 = first.x;
				x1 = second.x;
			}

			for (int i = x1; i < TypeOfShip; i++) {
				if (i == x1) {
					if (!(StatusForSetting(y, i - 1) && StatusForSetting(y - 1, i - 1) && StatusForSetting(y + 1, i - 1))) {
						return false;
					}
				}
				if (i == x2) {
					if (!(StatusForSetting(y, i + 1) && StatusForSetting(y - 1, i + 1) && StatusForSetting(y + 1, i + 1))) {
						return false;
					}
				}
				if (!(StatusForSetting(y + 1, i) && StatusForSetting(y - 1, i))) {
					return false;
				}
			}

			for (int i = x1; i < TypeOfShip; i++) {
				if (i == x1) {
					SetCellStatus_InShips(y, i - 1, 'v');
					SetCellStatus_InShips(y - 1, i - 1,'v');
					SetCellStatus_InShips(y + 1, i - 1,'v');
				}
				if (i == x2) {
					SetCellStatus_InShips(y, i + 1, 'v');
					SetCellStatus_InShips(y - 1, i + 1, 'v');
					SetCellStatus_InShips(y + 1, i + 1, 'v');
				}
				SetCellStatus_InShips(y - 1, i , 'v');
				SetCellStatus_InShips(y + 1, i , 'v');
				SetCellStatus_InShips(y, i, 's');

			}
			
			return true;

		}

		if (Axis == 'y') {
			if ( int((abs(first.y - second.y ) + 1)) != TypeOfShip) {
				std::cout << TypeOfShip  << std::endl;
				std::cout << abs(first.y - second.y ) + 1<< std::endl;
				return false;
			}

			int x = first.x;
			int y1, y2;

			if (first.y < second.y) {
				y1 = first.y;
				y2 = second.y;
			}
			else {
				y2 = first.y;
				y1 = second.y;
			}

			for (int i = y1; i <= TypeOfShip; i++) {
				if (i == y1) {
					if (!(StatusForSetting(i - 1, x - 1) && StatusForSetting(i - 1, x + 1) && StatusForSetting(i - 1, x ))) {
						return false;
					}
				}
				if (i == y2) {
					if (!(StatusForSetting(i + 1, x - 1) && StatusForSetting(i + 1, x + 1) && StatusForSetting(i + 1, x))) {
						return false;
					}
				}
				if (!(StatusForSetting(i , x + 1) && StatusForSetting(i, x - 1))) {
					return false;
				}
			}

			for (int i = y1; i <= TypeOfShip; i++) {
				if (i == y1) {
					SetCellStatus_InShips(i - 1, x - 1, 'v');
					SetCellStatus_InShips(i - 1, x, 'v');
					SetCellStatus_InShips(i - 1, x + 1, 'v');
				}
				if (i == y2) {
					SetCellStatus_InShips(i + 1, x - 1, 'v');
					SetCellStatus_InShips(i + 1, x, 'v');
					SetCellStatus_InShips(i + 1, x + 1, 'v');
				}
				SetCellStatus_InShips(i, x - 1, 'v');
				SetCellStatus_InShips(i, x + 1, 'v');
				SetCellStatus_InShips(i, x, 's');

			}

			return true;

		}


	}

	friend void PrintField(Player Pobj, std::string FieldName);
};

void PrintField(Player Pobj, std::string FieldName) {
	if (FieldName == "Ships") {
		std::cout << "Поле " << FieldName << ", Игрока " << Pobj.PlayerName << std::endl;
		for (int i = 0; i < Pobj.rows; i++) {
			for (int j = 0; j < Pobj.collumns; j++) {
				std::cout << Pobj.ShipsField[i][j] << " ";
			}
			std::cout << std::endl;
		}
		std::cout << std::endl;
	}
	if (FieldName == "Shots") {
		std::cout << "Поле " << FieldName << ", Игрока " << Pobj.PlayerName << std::endl;
		for (int i = 0; i < Pobj.rows; i++) {
			for (int j = 0; j < Pobj.collumns; j++) {
				std::cout << Pobj.ShotsField[i][j] << " ";
			}
			std::cout << std::endl;
		}
		std::cout << std::endl;
	}
}

class Game {
private:
	Player First;
	Player Second;
public:

};

