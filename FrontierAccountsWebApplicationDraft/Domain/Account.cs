using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontierAccountsWebApplicationDraft
{
    /// <summary>
    /// Container for account information with innapropriately located UI formatting properties
    /// </summary>
    public class Account
    {
        public int AccountStatusId { get; set; }
        public decimal AmountDue { get; set; }

        public string Email { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public string PhoneNumber { get; set; }
        

        /// <summary>
        /// todo: would it be better to do the formatting in the UI?   
        /// </summary>
        public string PhoneNumberFormatted
        {
            get
            {
                if (PhoneNumber == null)
                    return null;

                string result = String.Format("{0:(###) ###-####}", Convert.ToInt64(this.PhoneNumber));
                return result;
            }
        }
        public DateTime? PaymentDueDate { get; set; }
        public string PaymentDueDateFormatted
        {
            get
            {
                string result = String.Format("{0:d}", this.PaymentDueDate);
                return result;
            }
        }

        public string AmountDueFormatted
        {
            get
            {
                string result = String.Format("{0:c}",AmountDue);
                return result;
            }
        }
        public override string ToString()
        {
            string result = $"{FirstName} {LastName} - {AmountDue} - {AccountStatusId}";
            return result;

        }
    }

    public enum AccountStatus
    {
        Active = 0,
        Inactive = 1,
        Overdue = 2
    }
}

