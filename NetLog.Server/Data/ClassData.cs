using NetLog.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetLog.Server.Data
{
    public class ClassData : BaseData<Entities.Class>
    {

        public List<Class> GetClassesByName(string name)
        {
            using (var db = this.db())
            {
                var query = byNameQuery(db, name);
                return query.ToList();
            }
        }

        public Class GetClassByNameAndNamespace(string name, string nameSpace){
            using (var db = this.db())
            {
                var query = byNameAndNamespaceQuery(db, name, nameSpace);
                return query.FirstOrDefault();
            }
        }

        private IQueryable<Class> byNameQuery(dbNetLogEntities db, string name)
        {
            return (
                from Q in db.Classes
                where Q.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)
                select Q
            );
        }

        private IQueryable<Class> byNameAndNamespaceQuery(dbNetLogEntities db, string name, string nameSpace)
        {
            return byNameQuery(db, name).Where(d => d.Namespace.Equals(nameSpace, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}