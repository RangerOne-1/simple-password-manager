import mysql.connector
import sys
from colorama import Fore
import base64
import codecs

mydb = mysql.connector.connect(
  host="localhost",
  user="root",
  password="toor",
  database="password_manager"
)

mycursor = mydb.cursor()
mycursor.execute("SELECT * FROM manager")

myresult = mycursor.fetchall()

k=[["Name","Value","Id"]]
for x in myresult:
  m = base64.b64decode(x[1]).decode()
  c=[x[0],codecs.decode(m,'rot_13'),x[3]]
  k.append(c)


dash = '-' * 55

for i in range(len(k)):
    if i == 0:
      print(Fore.GREEN+dash)
      print(Fore.BLUE+'{:<25s}{:<40s}{:>20s}'.format(str(k[i][2]),k[i][0],k[i][1]))
      print(Fore.GREEN+dash)
    else:
      print(Fore.WHITE+'{:<25s}{:<40s}{:>20s}'.format(str(k[i][2]),k[i][0],k[i][1]))
      print(dash)