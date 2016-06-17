#include "stdafx.h"
#include "Problem.h"

class Problem
{
	/*varibale directlySolvable*/
public:
	bool directlySolvable;
public:
	/* virtual methods checkSolvability and divide*/
	virtual void checkSolvability() const = 0;
	virtual void part() const = 0;
	
	/* return the value directlySolvable*/
	void setDirectlySolvable(bool b)
	{
		directlySolvable = b;
	}
	 /* stops when directlySolvable is true
	 Solution is found
	 if Solution is not yet found, methods checkSolvability and part are called*/
	void computeSolution()
	{
		bool stop = false;

		do
		{
			checkSolvability();
			if (directlySolvable)
			{
				stop = true ;
			}
			part();
			} while (!stop);
	}
	

	}

};


