Add-Type -Path "D:\XML\PersonalFinanceManager\PersonalFinanceManager.UI\bin\Debug\System.Data.SQLite.dll"
$dbPath = "D:\XML\PersonalFinanceManager\PersonalFinanceManager.UI\bin\Debug\PersonalFinance.db"
$connString = "Data Source=$dbPath;Version=3;"
$conn = New-Object System.Data.SQLite.SQLiteConnection($connString)
try {
    $conn.Open()
    $cmd = $conn.CreateCommand()
    $cmd.CommandText = "UPDATE Transactions SET Note = REPLACE(REPLACE(Note, 'Deposit to ', 'Nạp tiền cho mục tiêu '), ' goal', '') WHERE Note LIKE 'Deposit to % goal';"
    $count = $cmd.ExecuteNonQuery()
    Write-Output "Updated $count records."
} catch {
    Write-Error $_.Exception.Message
} finally {
    $conn.Close()
}
