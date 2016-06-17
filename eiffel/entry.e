note
	description: "Summary description for {ENTRY}."
	author: "Gruppe 6"
	date: "$13.05.2016$"
	revision: "$Revision$"

class
	ENTRY[G->COMPARABLE]

create
	make

feature
	--equals
	equals(other: Entry [G]):BOOLEAN

		do
			Result:= current.getKey.is_equal(other)
		end

feature
	--getter & setter for key and pointer

	getKey: INTEGER
	do
		Result:= key
 	end

end
