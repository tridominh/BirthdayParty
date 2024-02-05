using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BirthdayParty.DAL.Validate
{
    public class RoomValidate
    {
        public bool ValidateCapacity(int capacity)
        {
            // Kiểm tra xem capacity có phải là số không
            if (!IsNumeric(capacity.ToString()))
                return false;

            // Kiểm tra xem capacity có vượt quá 200 người không
            return capacity >= 0 && capacity <= 200;
        }

        public bool ValidatePrice(int price)
        {
            // Kiểm tra xem price có phải là số không
            return IsNumeric(price.ToString());
        }

        private bool IsNumeric(string input)
        {
            // Sử dụng biểu thức chính quy để kiểm tra xem input có phải là số không
            return Regex.IsMatch(input, @"^\d+$");
        }
    }
}
