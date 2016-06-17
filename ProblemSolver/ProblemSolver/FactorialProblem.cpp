#include "stdafx.h"
#include "FactorialProblem.h"
#include "Problem.h"
#include "FactorialSolution.h"

class FactorialProblem:Problem, FactorialSolution
{
protected:
	FactorialSolution solution;
	int n, sol;

public:
	FactorialSolution solution()
	{
		return solution;
	}
	
	void checkSolvability()
	{
		/*when value is 0 or 1 the solution is found*/
		if (n == 0 || n == 1)
		{
			directlySolvable(true);
			solution.setFactorial(1);
		}
	}
	/*create solution*/
	void part()
	{
		sol = n*sol;
		n = n - 1;
	}

	/*get value n*/
	int getSol()
	{
		return this->n;
	}

	/*set the value n*/
	void setSol(int i)
	{
		n = i - 1;
		sol = i;
		setDirectlySolvable(false);
		computeSolution();
	}

	unsigned int fak(unsigned int number)
	{
		if (number <= 1)
		{
			return 1;
		}

		return fak(number - 1)*number;
	}

};
