using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Models
{
    public class LoginPageModel
    {
            public string ValidPassword { get; set; }
            public string ValidEmail { get; set; }
            public string InvalidEmail { get; set; }
            public string InvalidPassword { get; set; }
            public string EmptyEmailWarningMessage { get; set; }
            public string EmptyPasswordWarningMessage { get; set; }
            public string InvalidEmailWarningMessage { get; set; }
            public string IncorrectPasswordWarningMessage { get; set; }
            public string SuccessfulLogInMessage { get; set; }

    }
}
