import sqlite3
import os

db_path = "d:\\XML\\PersonalFinanceManager\\PersonalFinanceManager.UI\\bin\\Debug\\PersonalFinance.db"
conn = sqlite3.connect(db_path)
cursor = conn.cursor()

print("User and Transactions:")
cursor.execute("SELECT Id, Username FROM Users")
print("Users:", cursor.fetchall())

cursor.execute("SELECT CategoryId, UserId, Amount, Type FROM Transactions")
print("Transactions:", cursor.fetchall())

conn.close()
