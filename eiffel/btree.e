note
	description: "b-tree application root class"
	author: "Gruppe 6"
	date: "13.05.2016"
	revision: "$Revision$"

class
	BTREE [G->COMPARABLE]

create
	make

feature
	root: detachable NODE
	degree: INTEGER
	height: INTEGER

feature
	--Constructor
	make (degree: INTEGER)

		require
			degree >=2
		do
			create root.make (degree)

			ensure
				current.getRoot/=void
		end

feature
	--insert

	insert (key:INTEGER; pointer: detachable NODE)
					--create node with given parameter as value
		require
			NOT has(key)
					--no duplicate values
		local
			oldRoot: detachable NODE
		do
			if NOT current.getRoot.maxEntries then
				insertNonFull(current.getRoot, key,pointer)
			else
				oldRoot:= current.getRoot
				create root.make(degree)
				root.child.add(oldRoot)
				splitChild(root, 0, oldRoot)
				insertNonFull(current.getRoot, key, pointer)
				height+1
			end
			ensure
				has(key)

		end

feature
	--delete

	delete(key: INTEGER)

		require
			has(key)
		do
			deleteInnerNode(root,key)

			if root.entries.count = 0 AND if NOT root.isLeaf then
				root := current.getRoot.child.single
				height--
			end
			ensure NOT has(key)
		end

feature
	--deleteInnerNode

	deleteInnerNode(node: detachable NODE, key: INTEGER)
		local
			i:INTEGER

		do
			i := node.entry

			if i< node.entry.count AND if node.entry.item(i).key.is_equal then
					--look for key and delete
			end
				deleteFromNode(node, key, i)
			else if NOT node.isLeaf then
				deleteFromSubtree(node, key,i)
			end
		end

feature
	--deleteFromSubtree

	deleteFromSubtree(pNode:detachable NODE, key:INTEGER, i:INTEGER)
		local
			cNode: detachable NODE
			leftIndex: INTEGER
			leftSibling: detachable NODE
			rightIndex: INTEGER
			rightSibling: detachable NODE
			oldEntries
		do
			cNode := pNode.child.index_of(i)

			if cNode.maxEntries then
				leftIndex := i-1
				if i > 0 then
					pNode.child.item(leftIndex) := Void
					leftSibling := i
				end
				rightIndex:= i+1

				if i < pNode.child.count -1 then
					pNode.child.item(rightIndex) := Void
				end

				if leftSibling /= Void AND leftSibling.enrty.count > degree -1 then
					cNode.entry.insert(0, pNode.entry.item(i))
					pNode.entry.item(i) := leftSibling.entry.last
					leftSibling.entry.remove(leftSibling.entry.count - 1)

						if NOT leftSibling.isLeaf then
							cNode.child.insert(0, leftSibling.child.last)
							leftSibling.child.remove(leftSibling.child.count -1 )
						end

				else if rightSibling /= Void AND rightSibling.entry.count > degree - 1 then
					cNode.entry.add(pNode.entry.item(i))
					pNode.entry.item(i) := rightSibling.entry.first
					rightSibling.entry.remove(0)

					if NOT rightSibling.isLeaf then
						cNode.child.add(rightSibling.child.first)
						rightSibling.child.remove(0)
					end
				else
					if leftSibling /= Void then
						cNode.entry.insert(0,pNode.entry.item(i))
						oldEntries := cNode.entry
						cNode.entry := leftSibling.entry
						cNode.entry.
					end
				end


				end
			end
		end


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

end
	--class BTREE
