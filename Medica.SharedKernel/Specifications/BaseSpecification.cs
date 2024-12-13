using System.Linq.Expressions;
using Medica.SharedKernel.Interfaces;

namespace Medica.SharedKernel.Specifications;

/// <summary>
///     The base specification.
/// </summary>
public class BaseSpecification<T> : ISpecifications<T>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="BaseSpecification" /> class.
    /// </summary>
    public BaseSpecification()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="BaseSpecification" /> class.
    /// </summary>
    /// <param name="criteria">The criteria.</param>
    public BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    /// <summary>
    ///     Gets the criteria.
    /// </summary>
    public Expression<Func<T, bool>> Criteria { get; }

    /// <summary>
    ///     Gets the includes.
    /// </summary>
    public List<Expression<Func<T, object>>> Includes { get; }
        = [];

    /// <summary>
    ///     Gets the order by.
    /// </summary>
    public Expression<Func<T, object>> OrderBy { get; private set; }

    /// <summary>
    ///     Gets the order by descending.
    /// </summary>
    public Expression<Func<T, object>> OrderByDescending { get; private set; }

    /// <summary>
    ///     Gets the take.
    /// </summary>
    public int Take { get; private set; }

    /// <summary>
    ///     Gets the skip.
    /// </summary>
    public int Skip { get; private set; }

    /// <summary>
    ///     Gets a value indicating whether paging is enabled.
    /// </summary>
    public bool IsPagingEnabled { get; private set; }

    /// <summary>
    ///     Adds the include.
    /// </summary>
    /// <param name="includeExpression">The include expression.</param>
    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    /// <summary>
    ///     Adds the order by.
    /// </summary>
    /// <param name="orderByexpression">The order byexpression.</param>
    public void AddOrderBy(Expression<Func<T, object>> orderByexpression)
    {
        OrderBy = orderByexpression;
    }

    /// <summary>
    ///     Adds the order by decending.
    /// </summary>
    /// <param name="orderByDecending">The order by decending.</param>
    public void AddOrderByDecending(Expression<Func<T, object>> orderByDecending)
    {
        OrderByDescending = orderByDecending;
    }

    /// <summary>
    ///     Applies the pagging.
    /// </summary>
    /// <param name="take">The take.</param>
    /// <param name="skip">The skip.</param>
    public void ApplyPagging(int take, int skip)
    {
        Take = take;
        Skip = skip;
        IsPagingEnabled = true;
    }
}