namespace MsUni.Migrations
{
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

        protected override void Seed(MsUni.Models.ApplicationDbContext context)
        {
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
                    }
                    );
        }
    }
}
