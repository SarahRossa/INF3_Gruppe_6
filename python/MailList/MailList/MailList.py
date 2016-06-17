'''
Date: 12.06.2016
@author: group 6
'''

import glob#importblock
import threading

#global variables
list = []
lock = threading.Lock()
worker = True

#first thread read mails in mails1.txt and the second thread read mails in mails2.txt
def reader():
    global worker 
    with lock:
        if worker:
            file = 'mails1.txt'
            worker = False
        else:
            file = 'mails2.txt'
    
    emailFile = glob.glob(file) #mit glob können Platzhalter für Dateinamen verwendet werden
    for fileName in sorted(emailFile):
        with open(fileName) as f:
            for line in f:
                with lock:
                    list.append(line.rstrip()) #append is like the method 'push'


#def counter looking for mails with ending .edu and print the number out
def counter():
    counter = 0
    for x in range(len(list)):
       if (str(list[x]).endswith('.edu')):
           counter += 1
    print(counter)
    return

#defines threads
if __name__ == '__main__':
    print("The number of e-mails with the ending .edu are :")
    a = threading.Thread(target=reader)
    b = threading.Thread(target=reader)
    a.start()
    b.start()
    a.join()
    b.join()
    c = threading.Thread(target=counter)
    c.start()