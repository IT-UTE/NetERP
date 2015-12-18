using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.Entity.Validation;
using Model.Repository;
using System.Linq;

namespace Model.UnitOfWork
{

    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        #region Private member variables

        private ApiContext context;

        private readonly Dictionary<Type, object> repositories;
        private readonly object lockObject = new object();

        public IRepository<T> Repository<T>() where T : class
        {
            lock (lockObject)
            {
                if (repositories.Keys.Contains(typeof(T)))
                {
                    return repositories[typeof(T)] as IRepository<T>;
                }
                var repo = new Repository<T>(context);
                repositories.Add(typeof(T), repo);
                return repo;
            }
        }

        #endregion


        public UnitOfWork()
        {
            context = new ApiContext();
            repositories = new Dictionary<Type, object>();
        }

        #region Public member methods
        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);
                throw;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}