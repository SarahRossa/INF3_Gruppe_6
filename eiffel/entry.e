note
	description: "Summary description for {ENTRY}."
	author: ""
	date: "$Date$"
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

	getKey:

end
