import mysql.connector
import sys 
from colorama import Fore
mydb = mysql.connector.connect(
  host="localhost",
  user="root",
  password="toor",
  database="password_manager"
)

name = sys.argv[1]
mycursor = mydb.cursor()
sql = "DELETE FROM manager WHERE id='"+name+"'"
mycursor.execute(sql)

mydb.commit()
print(Fore.RED+"[-] record deleted")
print(Fore.WHITE)

