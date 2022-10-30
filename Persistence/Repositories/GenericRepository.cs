﻿using Microsoft.EntityFrameworkCore;
using socialNetwork.source.Core.Application.Interfaces.repositoriesInterfaces;
using socialNetwork.source.Core.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialNetwork.source.Core.Persistence.Repositories
{
    public class GenericRepository<Entity> : IGeneryRepositories<Entity> where Entity : class
    {

        private readonly ApplicationContext _contex;

        public GenericRepository(ApplicationContext c) 
        {
            _contex = c;
        }


        public virtual async Task<Entity> add(Entity entity)
        {
            await _contex.Set<Entity>().AddAsync(entity);
            await _contex.SaveChangesAsync();
            return entity;
        }

        public virtual async Task delete(Entity entity)
        {
            _contex.Set<Entity>().Remove(entity);
            await _contex.SaveChangesAsync();
        }

        public virtual async Task<List<Entity>> getAll()
        {
            return await _contex.Set<Entity>().ToListAsync();
        }

        public virtual async Task<List<Entity>> getAllByInclude(List<string> properties)
        {
            var query = _contex.Set<Entity>().AsQueryable();

            foreach (var i in properties)
            {
                query = query.Include(i);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<Entity> getOne(int id)
        {
            return await _contex.Set<Entity>().FindAsync(id);
        }

        public virtual async Task update(Entity entity)
        {
            _contex.Entry(entity).State = EntityState.Modified;
            await _contex.SaveChangesAsync();
        }
    }
}
