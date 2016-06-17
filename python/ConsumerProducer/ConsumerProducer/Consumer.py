'''
Created on: 03.06.16
@author: Group 6
'''
from Buffer import Buffer
from Lock import lock

class Consumer():
    b = None
    
    def __init__(self, buffer):
        assert not (buffer is None)
        self.b = buffer
     
        
        
    def consume(self): 
        while True:
           lock.acquire()
           if not self.b.isEmpty():
               print("Consumer consumed", self.b.pop())
               #time.sleep(random.random())
           lock.release()
     
    '''
    consumer consumes as long as the buffer is not empty ,
    when this happens the lock object gets locked so only one thread at
    a time will be able to access the buffer. Afterwards the lock gets released.
    '''
