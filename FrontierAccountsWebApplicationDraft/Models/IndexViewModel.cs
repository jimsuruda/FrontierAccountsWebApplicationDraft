using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontierAccountsWebApplicationDraft.Models
{
    public class IndexViewModel
    {
        /// <summary>
        /// Holds the info we need to display accounts
        /// </summary>
        public IndexViewModel()
        {
            this.ActiveAccounts = new List<Account>();
            this.InactiveAccounts = new List<Account>();
            this.OverdueAccounts = new List<Account>();
        }
        public List<Account> ActiveAccounts { get; set; }
        public List<Account> OverdueAccounts { get; set; }
        public List<Account> InactiveAccounts { get; set; }
    }
}
