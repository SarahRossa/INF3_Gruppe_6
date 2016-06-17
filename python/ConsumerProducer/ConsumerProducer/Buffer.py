'''
Created on: 03.06.16
@author: Group 6
'''

from Lock import mutex

class Buffer():
    list = [None] * 1
    
    #Constructor of buffer
    def __init__(self, size):
        assert not (size is None)
        self.list =[None]*size
        
    #Adds an element to buffer   
    def push(self, a):
        assert not (a is None)
        saved = False
        for index, elem in enumerate(self.list):
            if elem == None and not saved:
                self.list[index] = a
                saved=True

    
    #Returns oldest element in buffer :FIFO
    def pop(self):
        for index, elem in enumerate(self.list):
            if elem != None:
                    tmp = self.list[index]
                    self.delElement()
                    return tmp
            return None
    
    #Moves every element one position up
    def delElement(self):
        for i in range(len(self.list)-1):
            self.list[i] = self.list[i+1]
            self.list[i+1] = None
     
    #Returns true when buffer is full       
    def isFull(self):
        full=True
        for index, elem in enumerate(self.list):
            if self.list[index] == None:
                full = False
        return full
    #Returns true when buffer is empty
    def isEmpty(self):
        empty=True
        for index, elem in enumerate(self.list):
            if self.list[index] != None:
                empty = False
        return empty
    #Returns size of buffer
    def getSize(self):
        return len(self.list)
   