using System;
using System.Linq.Expressions;

namespace Synergy.Recruitment.Business.Factories
{
    public static class GenericFactory<T>
    {
        public static Expression<Func<T, bool>> GetAll
            => model
                => true;
    }
}
