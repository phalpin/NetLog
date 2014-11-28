using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetLog.Server.Entities
{
    public abstract class BaseEntity
    {
        public bool IsNew
        {
            get
            {
                return Id == default(int);
            }
        }

        public int Id { get; set; }
    }
}