import sqlite3
import os

db_path = r'd:\XML\PersonalFinanceManager\PersonalFinanceManager.UI\bin\Debug\PersonalFinance.db'
if not os.path.exists(db_path):
    db_path = r'd:\XML\PersonalFinanceManager\PersonalFinance.db'

print(f"Checking DB at: {db_path}")

try:
    conn = sqlite3.connect(db_path)
    cursor = conn.cursor()
    
    cursor.execute("SELECT Id, Username, Email, PasswordHash FROM Users")
    users = cursor.fetchall()
    print("\n--- Users Table ---")
    for u in users:
        print(f"ID: {u[0]}, Username: [{u[1]}], Email: [{u[2]}], Pass: [{u[3]}]")
        
    conn.close()
except Exception as e:
    print(f"Error: {e}")
