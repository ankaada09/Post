using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.DTO;
using Aplication.Exeption;
using Aplication.ICommand;
using Aplication.Interface;
using DataAcess;

namespace EFCommand
{
    public class EFAddUser : BaseEFCommand, IAddUser
    {
        private readonly IEmailSender _emailSender;
        public EFAddUser(PostContext context, IEmailSender emailSender) : base(context)
        {
            _emailSender = emailSender;
        }

       

        public void Execute(AddUserDto request)
        {
            if (Context.Users.Any(c => c.Username == request.UserName))
            {
                throw new EntityAlreadyExists();
            }

            Context.Add(new Domen.User
            {
                
                Username=request.UserName,
                Email=request.Email,
                Password=request.Password,
                UserTypeId=request.userType

            });



            Context.SaveChanges();
            var email = request.Email;

            _emailSender.Subject = "Uspesna registracija";
            _emailSender.Body = "Uspesno ste se registrovali.";
            _emailSender.ToEmail = email;
            _emailSender.Send();

        }
    }
}
