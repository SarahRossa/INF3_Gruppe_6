note
	description: "b-tree application root class"
	date: "$Date$"
	revision: "$Revision$"

class
	BTREE [G->COMPARABLE]
	inherit CONTAINER[INTEGER]
			redefine is_empty, linear_representation end

create
	make

feature
	root: detachable NODE
	degree: INTEGER_32
	height: INTEGER_32

feature
	-- Constructor

	make (degree: INTEGER_32)

		require
			degree >=2
		do
			create root.make (degree)

			ensure
				current.getRoot/=void
		end

feature
	--insert

	insert (key:INTEGER_32; pointer: detachable NODE)
					--create node with given parameter as value
		require
			NOT has(key)
					--no duplicate values
		local
			oldRoot: detachable NODE
		do
			if not current.getRoot.maxEntries then
				insertNonFull(current.getRoot, key,pointer)
			else
				oldRoot:= current.getRoot
				create root.make(degree)
				root.children.add(oldRoot)
				splitChild(root, 0, oldRoot)
				insertNonFull(current.getRoot, key, pointer)
				height+1
			end
			ensure
				has(key)

		end

feature
	--delete

	delete(key)

		require
			has(key)
		do
			deleteInnerNode(root,key)

			if root.entries.count = 0 && !root.isLeaf then
				current.getRoot := root.children.single
				height--
			end
			ensure NOT has(key)
		end

feature
	--deleteInnerNode

	deleteInnerNode(node, key)



feature
	--getter & setter for root

		getRoot: detachable NODE
					--returns root of tree
			do
				Result:= root
			end

		setRoot(newRoot: detachable NODE)
					--sets root of tree; new root as parameter
			do
				root:= newRoot
			end

feature
	--redefine
		is_empty:BOOLEAN
					--returns whether tree is empty or not
			do
				Result:= Root := Void
					--no root means no tree
			end

		linear_representation: LINEAR [INTEGER]
			do
				Result := linear_representation
			end

end
	--class BTREE
