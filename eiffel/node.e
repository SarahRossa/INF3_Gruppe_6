note
	description: "Summary description for {NODE}."
	author: ""
	date: "$Date$"
	revision: "$Revision$"

class
	NODE[G->COMPARABLE]

create
	make

feature
	-- variables
	degree: INTEGER_32
	entry: ENTRY[G]
	child: NODE[G]


feature
	make (degree: INTEGER_32)
		do
			create node.make (degree)
		end

feature

	isLeaf :BOOLEAN
		do
			Result:= current.getChild.count = 0
		end

feature

	maxEntries: BOOLEAN
		do
			Result:= current.getEntry.count = (2* degree) -1
		end

feature

	minEntries: BOOLEAN
		do
			Result:= current.getEntry.count = degree -1
		end

feature
	getEntry: G
		do
			Result:= entry
		end

	setEntry(newEntry: ENTRY[G])
		do
			entry:= newEntry
		end

feature
	getChild: G
		do
			Result:= child
		end

	setChild(newChild: NODE[G])
		do
			child:= newChild
		end
end



