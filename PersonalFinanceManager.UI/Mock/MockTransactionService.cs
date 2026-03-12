using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonalFinanceManager.UI.Mock
{
    public class TransactionMock
    {
        public string Id { get; set; }
        public string Ngay { get; set; }
        public string MoTa { get; set; }
        public double SoTien { get; set; }
        public string Loai { get; set; }
    }

    public static class MockTransactionService
    {
        // Sử dụng biến static để dữ liệu không bị reset khi chuyển form
        private static List<TransactionMock> _data = new List<TransactionMock>
        {
            new TransactionMock { Id = "1", Ngay = "10/03/2026", MoTa = "Ăn sáng", SoTien = -30000, Loai = "Chi" },
            new TransactionMock { Id = "2", Ngay = "10/03/2026", MoTa = "Lương Part-time", SoTien = 2000000, Loai = "Thu" },
            new TransactionMock { Id = "3", Ngay = "11/03/2026", MoTa = "Mua trà sữa", SoTien = -55000, Loai = "Chi" }
        };

        public static List<TransactionMock> GetData()
        {
            return _data;
        }

        public static void Add(TransactionMock item)
        {
            _data.Add(item);
        }
        public static void Update(TransactionMock updatedItem)
        {
            var index = _data.FindIndex(t => t.Id == updatedItem.Id);
            if (index != -1)
            {
                _data[index] = updatedItem;
            }
        }

        public static void Delete(string id)
        {
            var item = _data.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                _data.Remove(item);
            }
        }
    }
}