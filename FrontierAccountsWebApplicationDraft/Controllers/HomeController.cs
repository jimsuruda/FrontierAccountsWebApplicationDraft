using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FrontierAccountsWebApplicationDraft.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace FrontierAccountsWebApplicationDraft.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();

            // Grab the accounts from wherever we are getting them
            List<Account> accounts = GetAccounts();

            // Sort by status.  We could filter in the UI if we wanted
            if (accounts != null)
            {
                foreach(Account account in accounts)
                {
                    if (account.AccountStatusId == (int)AccountStatus.Active)
                        model.ActiveAccounts.Add(account);
                    if (account.AccountStatusId == (int)AccountStatus.Inactive)
                        model.InactiveAccounts.Add(account);
                    if (account.AccountStatusId == (int)AccountStatus.Overdue)
                        model.OverdueAccounts.Add(account);
                    // todo: if an account has an unknown status we lose it here.   Handle this?
                }
            }
            ViewResult result =  View(model);
            
            return result;
        }

        public List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();
            // grab the data from the REST endpoint
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(@"http://frontiercodingtests.azurewebsites.net/api/accounts/getall").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                if (responseContent != null)
                {
                    accounts = JsonConvert.DeserializeObject<List<Account>>(responseContent);
                }
            }

            return accounts;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
