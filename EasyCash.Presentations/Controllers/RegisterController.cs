using EasyCash.DTO.Dtos.AppUserDtos;
using EasyCash.Entities.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EasyCash.Presentations.Controllers;
    public class RegisterController : Controller
    {
    private readonly UserManager<AppUser> _userManager;

    public RegisterController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(AppUserRegisterDto  appUserRegisterDto)
    {
        if(ModelState.IsValid)
        {
            Random random = new Random();
            int confirmCodeSend;
            confirmCodeSend = random.Next(100000 , 1000000);
            AppUser appUser = new AppUser()
            {  UserName = appUserRegisterDto.Username,
               Name = appUserRegisterDto.Name,
               Surname = appUserRegisterDto.Surname,
               Email = appUserRegisterDto.Email,
               City = "aaaa",
               District = "bbbb",
               ImageUrl = "cccc",
               ConfirmCode = confirmCodeSend

            };
            var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
            if(result.Succeeded)
            {
                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("Orospu kaan selam" , "hbilalcinal@gmail.com" );
                MailboxAddress mailboxAddressTo = new MailboxAddress("User" , appUser.Email);
                
                mimeMessage.From.Add(mailboxAddressFrom);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz: " + confirmCodeSend;
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                mimeMessage.Subject = "Eash Cash onay kodu";
                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587 ,false);
                client.Authenticate("hbilalcinal@gmail.com", "zbbonqxhypsbxcok");
                client.Send(mimeMessage);
                client.Disconnect(true);
                return RedirectToAction("Index", "ConfirmMail");
            }
            else 
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
        }
        return View();
    }

       
    }
