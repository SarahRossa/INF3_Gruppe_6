// ProblemSolver.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <list>
#include <iostream>
#include "FactorialProblem.h"
using namespace std;

int main(int number, list<int> myList)

{
	FactorialProblem fp;
	unsigned int number;
	std::cout << "Please enter a number: ";

	std::cin >> number;
	std::cout << "The Fac " << number << "is" << fp.fak(number) << "!" std::endl;

	int count = 0;
	cout << "Insert 10 elements into the list" << endl;
	for (int i = 0; i < 10; i++)
	{
		cin >> myList = ;
	}

	for (int i = 0; i < 10;i++)
	{
		count++;

		cout << "Which element are you looking for?" << endl;
		cin >> number;
		cout << "You are looking for element" << number << "." << endl;

		if (number = myList);
		{
			cout << "Your element is at index " << count << "." << endl;
		}

		else
		{
			cout << "Element" << number << "is not in the list" << endl;
		}


	}

    return 0;
}

