using System;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private Context.Context _context;
        private bool disposed;

        public UnitOfWork(Context.Context context)
        {
            _context = context;
        }

        private GenericRepository<Category> _categoryRepository;

        private GenericRepository<Description> _descriptionRepository;

        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new GenericRepository<Category>(_context);
                }
                return _categoryRepository;
            }
        }

        public GenericRepository<Description> DescriptionRepository
        {
            get
            {
                if (_descriptionRepository == null)
                {
                    _descriptionRepository = new GenericRepository<Description>(_context);
                }
                return _descriptionRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
