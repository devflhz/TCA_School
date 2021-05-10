using Blazorise;
using Data.Constants;
using System;

namespace WebApp.Services
{
    public class ValidationService
    {
        public void ValidateEmail(ValidatorEventArgs e)
        {
            var email = Convert.ToString(e.Value);

            e.Status = string.IsNullOrEmpty(email) ? ValidationStatus.None :
                 Patterns.Email.Match(email).Success ? ValidationStatus.Success : ValidationStatus.Error;
        }

        public void ValidatePhone(ValidatorEventArgs e)
        {
            var phone = Convert.ToString(e.Value);

            e.Status = string.IsNullOrEmpty(phone) ? ValidationStatus.None :
                 Patterns.Phone.Match(phone).Success ? ValidationStatus.Success : ValidationStatus.Error;
        }

        public void ValidateZip(ValidatorEventArgs e)
        {
            var zip = Convert.ToString(e.Value);

            e.Status = string.IsNullOrEmpty(zip) ? ValidationStatus.None :
                 Patterns.ZipCode.Match(zip).Success ? ValidationStatus.Success : ValidationStatus.Error;
        }

        public void ValidateText(ValidatorEventArgs e)
        {
            var text = Convert.ToString(e.Value);

            e.Status = string.IsNullOrEmpty(text) ? ValidationStatus.None :
                 Patterns.Text.Match(text).Success ? ValidationStatus.Success : ValidationStatus.Error;
        }

        public void ValidateNumbers(ValidatorEventArgs e)
        {
            var text = Convert.ToString(e.Value);

            e.Status = string.IsNullOrEmpty(text) ? ValidationStatus.None :
                 Patterns.Numbers.Match(text).Success ? ValidationStatus.Success : ValidationStatus.Error;
        }

        public void ValidateTextNumSym(ValidatorEventArgs e)
        {
            var text = Convert.ToString(e.Value);

            e.Status = string.IsNullOrEmpty(text) ? ValidationStatus.None :
                 Patterns.TextNumSym.Match(text).Success ? ValidationStatus.Success : ValidationStatus.Error;
        }
    }
}
