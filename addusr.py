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

name = sys.argv[1]
code = codecs.encode(sys.argv[2], 'rot_13')

password =base64.b64encode(code.encode('ascii'))
mycursor = mydb.cursor()
sql = "INSERT INTO manager (name, value,user_id) VALUES (%s, %s,%s)"
val = (name,password,'1')
mycursor.execute(sql, val)



mydb.commit()

print(Fore.GREEN+"\n[+] Password added.")
print(Fore.WHITE)


