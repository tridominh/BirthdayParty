using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BirthdayParty.DAL.Validate
{
    public class ValidatePackage
    {
        public bool ValidatePackageName(string packageName)
        {
            // Kiểm tra xem packageName chỉ chứa chữ và không là số hoặc kí tự đặc biệt
            return Regex.IsMatch(packageName, "^[a-zA-Z]+$");
        }

        public bool ValidatePrice(decimal price)
        {
            // Kiểm tra xem price là một số và không phải là chữ hoặc kí tự đặc biệt
            return decimal.TryParse(price.ToString(), out _) && !Regex.IsMatch(price.ToString(), "[^0-9.]");
        }
    }
}
