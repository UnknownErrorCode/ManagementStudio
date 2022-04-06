#pragma once
#ifndef CMapHelp
#define CMapHelp

#include<string>
#include<iostream>
#include<cstdlib>
#include<cstdio>
#include<cstring>
#include<array>

using namespace std;

extern "C" {
#ifdef OPERATIONS_EXPORTS
#define CMapHelper __declspec(dllexport)
#else
#define CMapHelper __declspec(dllimport)
#endif

	int CMapHelper HoverXHelper(int x, int pictureSize, int viewpointX, float locX);
	int CMapHelper HoverZHelper(int y, int pictureSize, int viewpointY, float locZ);
}

#endif // !CMapHelp
