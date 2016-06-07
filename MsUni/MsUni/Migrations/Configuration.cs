namespace MsUni.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MsUni.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MsUni.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        bool AddUserAndRole(MsUni.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "wengui.lin@live.com",
                EmailConfirmed = true,
            };
            ir = um.Create(user, "Aa123456!");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }

        protected override void Seed(MsUni.Models.ApplicationDbContext context)
        {
            AddUserAndRole(context);

            context.Contacts.AddOrUpdate(p => p.Name,
                   new Contact
                   {
                       Name = "Debra Garcia",
                       Address = "1234 Main St",
                       City = "Redmond",
                       Age = 20,
                       Mobile = "13888888888",
                       University = "UCL",
                       Email = "debra@example.com",
                       Vote = 0,
                   },
                    new Contact
                    {
                        Name = "Thorsten Weinrich",
                        Address = "5678 1st Ave W",
                        City = "Redmond",
                        Age = 20,
                        Mobile = "13888888888",
                        University = "UCL",
                        Email = "thorsten@example.com",
                        Vote = 0,
                    },
                    new Contact
                    {
                        Name = "Yuhong Li",
                        Address = "9012 State st",
                        City = "Redmond",
                        Age = 20,
                        Mobile = "13888888888",
                        University = "UCL",
                        Email = "yuhong@example.com",
                        Vote = 0,
                    },
                    new Contact
                    {
                        Name = "Jon Orton",
                        Address = "3456 Maple St",
                        City = "Redmond",
                        Age = 20,
                        Mobile = "13888888888",
                        University = "UCL",
                        Email = "jon@example.com",
                        Vote = 0,
                    },
                    new Contact
                    {
                        Name = "Diliana Alexieva-Bosseva",
                        Address = "7890 2nd Ave E",
                        City = "Redmond",
                        Age = 20,
                        Mobile = "13888888888",
                        University = "UCL",
                        Email = "diliana@example.com",
                        Vote = 0,
                    }
                    );
        }
    }
}
