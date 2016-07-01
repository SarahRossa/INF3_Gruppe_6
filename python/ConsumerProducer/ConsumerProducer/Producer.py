'''
Created on: 03.06.16
@author: Group 6
'''
from Buffer import Buffer
from random import randint
from Lock import lock

class Producer():
    b = None
    
    def __init__(self, buffer):
        assert not (buffer is None)
        self.b = buffer
     
    

    def produce(self):  
        while True:
            lock.acquire()
            if not self.b.isFull():
                self.b.push(randint(1,100))
                print ("Producer produced")
                #time.sleep(random.random())
            lock.release()
    '''
    produce generates random numbers as long as the buffer is not full,
    when this happens the lock object gets locked so only one thread at
    a time will be able to access the buffer. Afterwards the lock gets released.
    '''