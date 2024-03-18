using BirthdayParty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BirthdayParty.DAL.Validate
{
    public class ValidateUser
    {
        public bool ValidateUsername(string username)
        {
            // Kiểm tra xem username có chứa kí tự đặc biệt hay không
            return !Regex.IsMatch(username, "[^a-zA-Z0-9]");
        }

        public bool ValidatePassword(string password)
        {
            // Kiểm tra xem password có đủ 10 kí tự không
            if (password.Length != 10)
                return false;

            // Kiểm tra xem password có ít nhất một kí tự hoa và một kí tự đặc biệt
            return Regex.IsMatch(password, "[A-Z]") && Regex.IsMatch(password, "[^a-zA-Z0-9]");
        }

        public bool ValidateFullName(string fullName)
        {
            // Kiểm tra xem fullName không chứa số và không chứa kí tự đặc biệt
            return !Regex.IsMatch(fullName, "[0-9]") && !Regex.IsMatch(fullName, "[^a-zA-Z0-9]");
        }

        public bool ValidateEmail(string email, List<User> userList)
        {
            // Kiểm tra định dạng email
            if (!email.EndsWith("@gmail.com"))
                return false;

            // Kiểm tra xem email có trùng với email của user nào khác không
            foreach (User user in userList)
            {
                if (user.Email == email)
                    return false;
            }

            return true;
        }

        public bool ValidatePhone(string phone)
        {
            // Kiểm tra xem phone có đúng định dạng và không chứa chữ hoặc kí tự đặc biệt
            return Regex.IsMatch(phone, @"^\d{10}$");
        }
    }
}
