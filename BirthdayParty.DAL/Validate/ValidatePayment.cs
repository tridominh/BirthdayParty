using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BirthdayParty.DAL.Validate
{
    public class ValidatePayment
    {
        public bool ValidateTotalPrice(decimal totalPrice)
        {
            // Kiểm tra xem totalPrice là một số và không phải là chữ hoặc kí tự đặc biệt
            return decimal.TryParse(totalPrice.ToString(), out _) && !Regex.IsMatch(totalPrice.ToString(), "[^0-9.]");
        }

        public bool ValidateDepositMoney(decimal depositMoney)
        {
            // Kiểm tra xem depositMoney là một số và không phải là chữ hoặc kí tự đặc biệt
            return decimal.TryParse(depositMoney.ToString(), out _) && !Regex.IsMatch(depositMoney.ToString(), "[^0-9.]");
        }
    }
}
