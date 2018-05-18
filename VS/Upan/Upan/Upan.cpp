// Upan.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include<iostream>
#include<string>
using namespace std;


int main()
{
	int temp;
	string input="E3A0A812D00294";
	for (int ebx = 1;ebx <=  input.length(); ebx++)
	{
		temp =  (ebx * 2 + 1) + int(input.at(ebx - 1)) + 1 ;
		if (((temp<58)&&(temp>47)) || ((temp<91) && (temp>64)))
		{
			cout << char(temp) ;
		}
	}
	cout << endl;
	system("pause");


    return 0;
}

