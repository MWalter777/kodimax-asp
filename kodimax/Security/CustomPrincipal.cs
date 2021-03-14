using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using kodimax.Models;

namespace kodimax.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private Model1 db = new Model1();

        public IIdentity Identity
        {
            get;
            set;
        }

        private USUARIO account;

        public CustomPrincipal(USUARIO account)
        {
            this.account = account;
            this.Identity = new GenericIdentity(account.EMAIL);
        }


        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            ROL rol = db.ROL.Find(account.ID_ROL);
            if (rol != null)
            {
               return roles.All(r => rol.NOMBRE_ROL == r);
            }
            return false;
        }
    }
}