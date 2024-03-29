﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PontoCerto.Domain.Repositories;

namespace PontoCerto.WebApplication.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<T?> FirstAsync(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, Func<T, object>>? include)
    {
        var query = _dbSet.AsQueryable();

        if(expression != null)
        {
            query = query.Where(expression);
        }

        if(include != null)
        {
            query = include(query) as IIncludableQueryable<T,object>;
        }
            
        return query != null ? await query.FirstOrDefaultAsync() : null;
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.CountAsync(expression);
    }

    public async Task<List<T>> GetDataAsync(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, Func<T, object>>? include, int? skip = null, int? take = null)
    {
        var query = _dbSet.AsQueryable();

        if(expression != null)
        {
            query = query.Where(expression);
        }

        if(include != null)
        {
            query = include(query) as IIncludableQueryable<T,object>;
        }

        if (skip.HasValue)
        {
            query = query?.Skip(skip.Value);
        }

        if (take.HasValue)
        {
            query = query?.Take(take.Value);
        }

        return query != null ? await query.ToListAsync() : new List<T>();
    }
}