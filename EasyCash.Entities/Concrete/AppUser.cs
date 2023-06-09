using Microsoft.AspNetCore.Identity;

namespace EasyCash.Entities.Concrete;

    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public int ConfirmCode { get; set; }
        public virtual List<CustomerAccount> CustomerAccounts { get; set; }


    }
