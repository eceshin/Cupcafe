using Cupcafe.Service.Data;
using Cupcafe.Service.Models;
using CupCafe.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupCafe.Service.Core
{
    public class LoginService
    {

        CafeDbContext _db=new CafeDbContext();


  
        public Kullanici CheckUser(LoginViewModel viewModel) {
            var user = _db.Kullanicilar.FirstOrDefault(p => p.Email == viewModel.Email && p.Sifre == viewModel.Sifre);
            return user;
        }


    }

}