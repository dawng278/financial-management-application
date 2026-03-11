using System;
using System.Collections.Generic;
using System.Text;

namespace SpendingManagement.UI.Mock
{
    public class TransactionMock
    {
        public string Id { get; set; }
        public string Ngay { get; set; }
        public string MoTa { get; set; }
        public double SoTien { get; set; }
        public string Loai { get; set; }
    }

    // Lớp cung cấp dữ liệu ảo
    public static class MockTransactionService
    {
        public static List<TransactionMock> GetData()
        {
            return new List<TransactionMock>
            {
                new TransactionMock { Id = "1", Ngay = "10/03/2026", MoTa = "Ăn sáng", SoTien = -30000, Loai = "Chi" },
                new TransactionMock { Id = "2", Ngay = "10/03/2026", MoTa = "Lương Part-time", SoTien = 2000000, Loai = "Thu" },
                new TransactionMock { Id = "3", Ngay = "11/03/2026", MoTa = "Mua trà sữa", SoTien = -55000, Loai = "Chi" }
            };
        }
    }
}
