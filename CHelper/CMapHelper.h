#pragma once
using namespace std;

extern "C" {

#ifdef BUILD_MY_DLL
#define CMapHelper __declspec(dllexport)
#else
#define CMapHelper __declspec(dllimport)
#endif 

	int CMapHelper Add_INT(int addint1, int addint2);
	int CMapHelper Sub_INT(int subint1, int subint2);
	int CMapHelper Mul_INT(int mulint1, int mulint2);
	int CMapHelper Div_INT(int divint1, int divint2);
}

