﻿using Core.Persistence.Extensions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechCareer.Service.Abstracts;

namespace TechCareer.Service.Concretes
{
    public class InstructorService : IInstructorService
    {


        public Task<Instructor> AddAsync(Instructor Instructor)
        {
            throw new NotImplementedException();
        }

        public Task<Instructor> DeleteAsync(Instructor Instructor, bool permanent = false)
        {
            throw new NotImplementedException();
        }

        public Task<Instructor?> GetAsync(Expression<Func<Instructor, bool>> predicate, bool include = false, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<Instructor>> GetListAsync(Expression<Func<Instructor, bool>>? predicate = null, Func<IQueryable<Instructor>, IOrderedQueryable<Instructor>>? orderBy = null, bool include = false, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Paginate<Instructor>> GetPaginateAsync(Expression<Func<Instructor, bool>>? predicate = null, Func<IQueryable<Instructor>, IOrderedQueryable<Instructor>>? orderBy = null, bool include = false, int index = 0, int size = 10, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Instructor> UpdateAsync(Instructor Instructor)
        {
            throw new NotImplementedException();
        }
    }
}