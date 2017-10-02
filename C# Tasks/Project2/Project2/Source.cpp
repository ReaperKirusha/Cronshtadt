#include <iostream>
#include <fstream>
#include <vector>
#include <map>
#include <string>
#include <set>
#include "Header.h"
using namespace std;

int CountInStr(string MainStr, char MainChar) {
	int Count = 0;
	for (int i = 0; i < MainStr.size(); i++) {
		if (MainStr.at(i) == MainChar) {
			Count++;
		}
	}
	return Count;
}

class InI_Reader {
private:
	//секция, переменная, значения
	map<string, map<string, vector<string>>> Main_map;
	vector<vector<string>> TempVector_ForReadInI;
	set<char> DivisionChars;
	set<char> CommentaryChars;
	set<char> SpaceChars;
	void SetSpaceChars() {
		SpaceChars.insert('\t');
		SpaceChars.insert(' ');
	}
	void SetCommentaryChars() {

	}
	void SetDivisionChars() {
		
		DivisionChars.insert('\t');
		DivisionChars.insert(' ');
		DivisionChars.insert(';');
		DivisionChars.insert('\n');
		DivisionChars.insert('\r');
		DivisionChars.insert('=');
		DivisionChars.insert(',');
	}

	
public:
	InI_Reader() {
		SetDivisionChars();
		SetSpaceChars();
		SetCommentaryChars();
	}

	//считывает InI заполняя мапу секциями
	void Read_InI(string FileName) {
		TempVector_ForReadInI.clear();

		ifstream NewTxT("new.txt");
		vector<string> TempVector;
		string TempString;
		bool currentWord = false;
		int FirstCharForWord = 0, LastCharForWord = 0;
		while (getline(NewTxT, TempString)) {
			TempVector.clear();
			
			//отбрасывает коммнтарий
			for (int i = 0; i < TempString.length(); i++) {

				if (TempString.at(i) == ';') {

					TempString = TempString.substr(0, i);
					break;
				}
			}

			cout << TempString << "%проверка"<<endl;

			for (int i = 0; i < TempString.length(); i++) {
				if (DivisionChars.count(TempString.at(i)) == 0) {
					if (!currentWord) {
						FirstCharForWord = i;
						LastCharForWord = i;
						currentWord = true;
					}
					else {
						LastCharForWord++;

					}

				}
				else {
					if (currentWord) {
						currentWord = false;
						TempVector.push_back(TempString.substr(FirstCharForWord, LastCharForWord - FirstCharForWord + 1));
					}

					if (SpaceChars.count(TempString.at(i)) == 0) {
						char c[1] = { TempString.at(i) };
						TempVector.push_back(string(c, sizeof(c)));
					}
				}
			}


			if (currentWord) {
				currentWord = false;
				TempVector.push_back(TempString.substr(FirstCharForWord, LastCharForWord - FirstCharForWord + 1));
			}

			TempVector_ForReadInI.push_back(TempVector);
			
		
		}

	}
	void BuildSections() {
		string TempStr;
		bool BuildingSection = false;
		string SectionName;
		vector<string> TempVectorForVariables;
		int VariavlesInSection = 0;
		for (int i = 0; i < TempVector_ForReadInI.size(); i++) {
			for (int j = 0; j < TempVector_ForReadInI.at(i).size(); j++) {
				TempStr = TempVector_ForReadInI.at(i).at(j);
				if (!BuildingSection) {
					if (TempStr[0] == '[' && TempStr[TempStr.size() - 1] == ']') {
						if ((CountInStr(TempStr, ' ') == 0) && (TempVector_ForReadInI.at(i).size() == 1)) {
							BuildingSection = true;

						}
						else {
							if (CountInStr(TempStr, ' ') != 0) {
								cout << "Ошибка имени секции в строке: " << i << endl;
							}
							if (TempVector_ForReadInI.at(i).size() != 1) {
								cout << "Ошибка формата строки имени секции в строке: " << i << endl;
							}
						}
					}
				}
				else {
					if (TempStr[0] == '[' && TempStr[TempStr.size() - 1] == ']') {

					}

					if (CountInStr(TempVector_ForReadInI.at(i).at(2), '=') == 1) {
						
						if (i == 2) continue;
						TempVectorForVariables.push_back(TempStr);
					}
				}
			}
		}
	}
	map<string, vector<string>> Get_Section_InI(string Section_name) {
		return Main_map[Section_name];
	}

	vector<string> Get_Var_by_Section(string Section_name, string Var_name) {
		return Main_map[Section_name][Var_name];
	}

};




void main() {
	setlocale(LC_ALL, "rus");

	//streambuf

	//int StartOfSpaces = 0;
	//bool ThisStreamOfSpaces = false;

	/*for (int i = 0; i < abc.length(); i++) {

	if (!ThisStreamOfSpaces && (abc.at(i) == ' ')) {
	StartOfSpaces = i;
	ThisStreamOfSpaces = true;
	}
	else {
	if (abc.at(i) != ' ') {
	ThisStreamOfSpaces = false;
	}
	}
	}
	if (ThisStreamOfSpaces) {
	abc = abc.substr(0, StartOfSpaces);
	}*/




	system("pause");
}