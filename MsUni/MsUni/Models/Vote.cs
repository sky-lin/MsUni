using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MsUni.Models
{
    public class Vote
    {
        public int VoteId { get; set; }

        public string UserName { get; set; }

        public string UserIP { get; set; }

        public DateTime VoteTime { get; set; }
    }
}