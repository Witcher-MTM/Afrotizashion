using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations;
namespace Authentication
{
    public class User
    {
        public string Login { get; set; }
        public string Pass { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime dateRegistr { get; set; }
        public User()
        {
            Login = String.Empty;
            Pass = String.Empty;
            BirthDay = DateTime.MinValue;
            Email = String.Empty;
        }

        public User(string login, string pass, DateTime BD, string email, DateTime registr)
        {
            this.Login = login;
            this.Pass = pass;
            this.BirthDay = BD;
            this.Email = email;
            this.dateRegistr = registr;
        }
        public void GenToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            this.Token = Convert.ToBase64String(time.Concat(key).ToArray());
        }
        public bool ValidDates()
        {
            if (ValidPass() && ValidEmail() && ValidLogin())
            {
                return true;
            }
            return false;
        }
        private bool ValidPass()
        {
            if (Pass.Length > 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ValidLogin()
        {
            if (Login.Length > 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ValidEmail()
        {
            var checkEmail = new EmailAddressAttribute();
            if (checkEmail.IsValid(Email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
