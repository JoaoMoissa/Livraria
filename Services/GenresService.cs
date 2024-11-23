﻿using Bookstore.Data;
using Bookstore.Models;
using Bookstore.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Data;

//save

namespace Bookstore.Services
{
    public class GenresService
    {
        private readonly BookstoreContext _context;

        public GenresService(BookstoreContext context)
        {
            _context = context;
        }

        public async Task<List<Genre>> FindAllAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task InsertAsync(Genre genre)
        {
            _context.Add(genre);
            await _context.SaveChangesAsync();
        }
        public async Task<Genre?> FindByIdAsync(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Genres.FindAsync(id);
                _context.Genres.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new IntegrityException(ex.Message);
            }
        }
        public async Task UpdateAsync(Genre genre)
        {
            bool hasAny = await _context.Genres.AnyAsync(x => x.Id == genre.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(genre);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }
    }
}