// ProblemSolver.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <list>
#include <iostream>
#include "FactorialProblem.h"
using namespace std;

int main(int number, list<int> *myList)

{
	FactorialProblem *fp = new FactorialProblem();
	unsigned int number;
	std::cout << "Please enter a number: ";

	
	std::cout << "The Fac " << number << "is" << fp->fak(number) << "!" std::endl;

	int count = 0;
	cout << "Insert 10 elements into the list" << endl;
	
	for (int i = 1; i < number;i++)
	{
		count++;

		cout << "Which element are you looking for?" << endl;

		cout << "You are looking for element" << number << "." << endl;

		


	}

    return 0;
}

