using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.ViewModels
{
    public class AddDotaAccountViewModel
    {
        public string AccountId { get; set; }

        public AddDotaAccountViewModel()
        { }

        public AddDotaAccountViewModel(string accountId)
        {
            AccountId = accountId;
        }
    }
}