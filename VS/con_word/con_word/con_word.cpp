// con_word.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <iostream>
#include <string>
using namespace std;

int main()
{
	string a;
	int result;
	
	while (1)
	{
		cin >> a;
		result = a.length();
		cout << result<<endl;
	}
	
	system("pause");
    return 0;
}

