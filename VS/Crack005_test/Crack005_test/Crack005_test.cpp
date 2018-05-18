// Crack005_test.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include<iostream>
#include<string>
using namespace std;




int main()
{
	int b, c;
	long long int temp1 = 0, temp2 = 0;
	string a = "dfgh321";
	for (int i = 0; i < a.length(); i++)
	{
		for (int j = 0; j < a.length(); j++)
		{
			temp1 += (int(a.at(i)))*(int(a.at(j)));//004429A8算法中循环相乘
		}
	}
	for (int m = 0; m < a.length() - 1; m++)
		temp2 += (int(a.at(m + 1)) % 17 + 1)*(int(a.at(m)));
	temp2 = temp2 + 891;//这里是产生相乘的系数
	cout << "EDI="<<temp2 << endl;
//	cout << "EBX*EDX="<<(temp1 * temp2) << endl;
	temp1 = (temp1 * temp2) % 666666;//temp2根据不同输入的用户名改变，这个在上面循环相乘本来要每次乘这个，但是在这里提出来了，然后取余
	cout << "EBX="<<temp1 << endl;
	for (int k = 0; k < 100000000; k++)
	{
		b =k / 89 + k % 80 + 1;//ECX
		if (temp1 == b)
			cout << k << endl;
	}
	system("pause");
    return 0;
}

