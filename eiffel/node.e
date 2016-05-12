note
	description: "Summary description for {NODE}."
	author: ""
	date: "$Date$"
	revision: "$Revision$"

class
	NODE[G->LIST]

create
	make

feature
	-- variables
	degree: INTEGER_32
	entry: G
	child: G


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
	getEntry: LIST
		do
			Result:= entry
		end

	setEntry(newEntry: LIST)
		do
			entry:= newEntry
		end

	getChild: LIST
		do
			Result:= child
		end

	setChild(newChild: LIST)
		do
			child:= newChild
		end
end



