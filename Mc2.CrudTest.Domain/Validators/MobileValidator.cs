
using PhoneNumbers;

namespace Mc2.CrudTest.Domain.Validators
{
    public static class MobileValidator
    {
        private static readonly PhoneNumberUtil PhoneUtil = PhoneNumberUtil.GetInstance();
        
        public static bool TryParse(string phoneNumberString, out PhoneNumber phoneNumber)
        {
            try
            {
                phoneNumber = PhoneUtil.Parse(phoneNumberString, null);
                if (PhoneUtil.GetNumberType(phoneNumber) == PhoneNumberType.MOBILE)
                {
                    return true;
                }

                return true;
            }
            catch
            {
                phoneNumber = null;
                return false;
            }
        }
        
        public static bool Validate(string phoneNumberString)
        {
            if (TryParse(phoneNumberString, out PhoneNumber phoneNumber))
            {
                return true;
            }

            return false;
        }
    }
}