﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skillServices.BOL.Models
{
    public class UsersRegBOL
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string contact_no { get; set; }
        public string password { get; set; }
        public int usrtypid { get; set; }
    }
}
