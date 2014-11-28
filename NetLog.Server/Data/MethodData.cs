using NetLog.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetLog.Server.Data
{
    public class MethodData : BaseData<Entities.Method>
    {
        public Entities.Method GetByNameAndClassId(int classId, string methodName)
        {
            using(var db = this.db())
            {
                return byNameAndClassQuery(db, classId, methodName).FirstOrDefault();
            }
        }

        private IQueryable<Entities.Method> byNameAndClassQuery(DataModelContainer db, int classId, string methodName)
        {
            return (
                from Q in db.Methods
                where Q.ClassId == classId && Q.Name.Equals(methodName, StringComparison.InvariantCultureIgnoreCase)
                select Q
            );
        }
    }
}