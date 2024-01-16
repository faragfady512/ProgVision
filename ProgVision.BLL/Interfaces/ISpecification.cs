using ProgVision.DAL.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace ProgVision.BLL.Interfaces
{
    public interface ISpecification<T> where T : BaseEntity
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }

        List<Expression<Func<T, object>>> ThenIncludes { get; }


        public Expression<Func<T, object>> OrderBy { get; }

        public Expression<Func<T, object>> OrderByDescending { get; }

        public int Take { get; }
        public int Skip { get; }

        public bool IsPagingEnabled { get; }
    }
}