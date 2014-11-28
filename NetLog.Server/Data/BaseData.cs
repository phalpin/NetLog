using NetLog.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetLog.Server.Data
{
    public class BaseData<T> where T : BaseEntity
    {
        protected DataModelContainer db()
        {
            return new DataModelContainer();
        }

        public T Get(int id)
        {
            using (var db = this.db())
            {
                var query = (
                    from Q in db.Set<T>()
                    where Q.Id == id
                    select Q
                );

                return query.FirstOrDefault();
            }
        }

        public T Save(T entity)
        {
            using (var db = this.db())
            {
                //Create
                if (entity.Id == default(int))
                {
                    db.Set<T>().Add(entity);
                }
                //Update
                else
                {
                    db.Set<T>().Attach(entity);
                }

                db.SaveChanges();
                return entity;
            }
        }

        public void Delete(T entity)
        {
            T existingEnt = Get(entity.Id);

            if(existingEnt != null)
            {
                using (var db = this.db())
                {
                    db.Set<T>().Remove(existingEnt);
                    db.SaveChanges();
                }
            }
        }
    }
}