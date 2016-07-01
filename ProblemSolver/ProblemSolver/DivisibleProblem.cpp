#include "stdafx.h"
#include "DivisibleProblem.h"

using namespace std;

class DivisibleProblem
{
public:
	virtual bool isDirectlySolvable() const = 0;

	virtual void checkSolvability() const = 0;

	virtual void part() const =0;

	virtual void solve() const=0;


};

