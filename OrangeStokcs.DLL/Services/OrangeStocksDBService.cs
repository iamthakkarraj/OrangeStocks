
using OrangeStocks.DLL.Interfaces;
using OrangeStokcs.DLL.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OrangeStocks.DLL.Services {

    public class OrangeStocksDBService<T> : IOrangeStocksDBService<T> where T : class {

        private OrangeStocksEntities _context = null;
        private DbSet<T> table = null;

        public OrangeStocksDBService() {
            this._context = new OrangeStocksEntities();
            table = _context.Set<T>();  
        }

        IEnumerable<T> IOrangeStocksDBService<T>.Get() {
            return table.ToList();
        }

        T IOrangeStocksDBService<T>.Get(Guid id) {
            return table.Find(id);
        }

        bool IOrangeStocksDBService<T>.Add(T entity) {
            try {
                table.Add(entity);
                return true;
            } catch (Exception e) {
                return false;
            }
        }

        bool IOrangeStocksDBService<T>.Update(T entity) {
            try {
                table.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                return true;
            } catch (Exception e) {
                return false;
            }
        }

        bool IOrangeStocksDBService<T>.Delete(Guid id) {
            try {
                var entity = table.Find(id);
                entity
                    .GetType()
                    .GetProperties()
                    .Where(x=>x.Name == "IsDeleted")
                    .First()
                    .SetValue(entity, true, null);
                table.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                return true;
            } catch (Exception e) {
                return false;
            }
        }

        bool IOrangeStocksDBService<T>.Save() {
            try {
                _context.SaveChanges();
                return true;
            } catch (Exception e) {
                return false;
            }
        }
        
    }

}