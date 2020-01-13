using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace API_Test.Models
{
    public class Login
    {
            public static readonly string Name = "API";
            public ObjectId? id { get; set; }
            public string cpr { get; set; }
            public string password { get; set; }
            public int customer_number { get; set; }
            public bool loginBan { get; set; }
            public string loginStatusBanTimer { get; set; }

            // Constructor
        public Login(ObjectId? id, string cpr, string password, int customer_number, bool loginBan, string loginStatusBanTimer)
            {
                this.id = id;
                this.cpr = cpr;
                this.password = password;
                this.customer_number = customer_number;
                this.loginBan = loginBan;
            this.loginStatusBanTimer = loginStatusBanTimer;
            }
        }
    }


