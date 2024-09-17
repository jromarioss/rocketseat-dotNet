using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;
public interface IExpensesWriteOnlyRepository
{
    /// <summary>
    /// This function add one expense
    /// </summary>
    /// <param name="expense"></param>
    /// <returns></returns>
    Task Add(Expense expense);
    /// <summary>
    /// This function returns TRUE if the deletion was successfull otherwise return FALSE
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> Delete(long id);
}
