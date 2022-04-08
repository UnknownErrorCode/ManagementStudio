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

bool ExceedViewX(int panelPointX, int pictureSize, int width)
{
	return panelPointX < -pictureSize * 256 + width;
}
bool ExceedViewY(int panelPointY, int pictureSize, int higth)
{
	return panelPointY < -pictureSize * 128 + higth;
}

float GetSroPosX(int x, int pictureSize, int viewpointX, int clickPointX)
{
	return roundf(((x * pictureSize + (viewpointX - clickPointX)) * -1) * (1920.0f / pictureSize));
}

float GetSroPosY(int z, int pictureSize, int viewpointY, int clickPointY)
{
	return roundf(((128 * pictureSize) + (viewpointY - clickPointY)) - (z * pictureSize)) * (1920.0f / pictureSize);
}