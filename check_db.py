import sqlite3
import os

db_path = r'd:\XML\PersonalFinanceManager\PersonalFinanceManager.UI\bin\Debug\PersonalFinance.db'
if not os.path.exists(db_path):
    # Try current directory or other possible locations
    db_path = r'd:\XML\PersonalFinanceManager\PersonalFinance.db'

print(f"Checking DB at: {db_path}")

try:
    conn = sqlite3.connect(db_path)
    cursor = conn.cursor()
    
    cursor.execute("SELECT name FROM sqlite_master WHERE type='table';")
    tables = cursor.fetchall()
    print(f"Tables: {tables}")
    
    if ('Users',) in tables:
        cursor.execute("SELECT Id, Username, Email, PasswordHash, IsActive FROM Users")
        users = cursor.fetchall()
        print("\n--- Users Table ---")
        for u in users:
            print(u)
    else:
        print("Users table not found!")
        
    conn.close()
except Exception as e:
    print(f"Error: {e}")
