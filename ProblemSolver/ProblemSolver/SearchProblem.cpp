#include "stdafx.h"
#include "SearchProblem.h"
#include "Problem.h"
#include "Solution.h"
#include "SearchSolution.h"
#include <list>

using namespace std;

class SearchProblem : Problem, Solution
{
protected:
	SearchSolution solution;
	int find;
	list<int> list;
public:
	SearchSolution solution()
	{
		return solution;
	}

	/*compares value with search value*/
	void checkSolvability()
	{
		if (list.size != NULL)
		{

			setDirectlySolvable(true);
		}
		else
		{
			setDirectlySolvable(false);
		}
			
	}

	/*parts the list*/
	void part()
	{
		if()
	}

	void setList(vector<int> number)
	{
		int i;
		
		for(int i = 0; i >= number.size; i++)
		{
			list.insert(number);
		}
		computeSolution();

		if ()
		
	}
};