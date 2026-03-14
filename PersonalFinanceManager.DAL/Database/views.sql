-- B6: Advanced query support views for reporting

CREATE VIEW IF NOT EXISTS vw_transaction_monthly_summary AS
SELECT
    UserId,
    strftime('%Y-%m', TransactionDate) AS YearMonth,
    Type,
    SUM(Amount) AS TotalAmount,
    COUNT(*) AS TransactionCount
FROM Transactions
GROUP BY UserId, strftime('%Y-%m', TransactionDate), Type;

CREATE VIEW IF NOT EXISTS vw_transaction_category_summary AS
SELECT
    t.UserId,
    t.CategoryId,
    c.Name AS CategoryName,
    t.Type,
    SUM(t.Amount) AS TotalAmount,
    COUNT(*) AS TransactionCount
FROM Transactions t
LEFT JOIN Categories c ON c.Id = t.CategoryId
GROUP BY t.UserId, t.CategoryId, c.Name, t.Type;
