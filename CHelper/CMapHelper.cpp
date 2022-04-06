#include "pch.h"
#include "CMapHelper.h"

int HoverXHelper(int x, int pictureSize, int viewpointX, float locX)
{
	return (x * pictureSize + viewpointX) + (locX / (1920 / pictureSize));
}

int  HoverZHelper(int y, int pictureSize, int viewpointZ, float locY)
{
	return ((((y * pictureSize - 128 * pictureSize) * -1) + viewpointZ) + (locY / (1920 / pictureSize)) * -1);
}

bool