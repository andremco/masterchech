using MasterChechBot.Core.Models;
using System;

namespace MasterChechBot.Core.Repositories
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

        private GenericRepository<Recipe> _recipeRepository;

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

        public GenericRepository<Recipe> RecipeRepository
        {
            get
            {
                if (_recipeRepository == null)
                {
                    _recipeRepository = new GenericRepository<Recipe>(_context);
                }
                return _recipeRepository;
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

        public Context.Context GetContext()
        {
            return _context;
        }
    }
}
