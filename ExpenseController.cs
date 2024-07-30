using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ExpenseController : Controller
    {
        
        private readonly ExpenseDbContext _DbContext;
        public IActionResult Index()
        {
            return View();
        }
        public ExpenseController(ExpenseDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public JsonResult AllExpenses()
        {
            var expenseList = _DbContext.Expenses.ToList();
            return Json(expenseList);
        }
        public JsonResult Find(string desc)
        {
            var exp = _DbContext.Expenses.Where(m => m.Description.Contains(desc)).ToList();
            return Json(exp);
        }
        public string AddExpenses(Expense expense)
        {
            _DbContext.Expenses.Add(expense);
            
            _DbContext.SaveChanges();
            return "Expense added to the database";

        }
        [HttpPut]
        public string UpdateExpense(Expense expense)
        {
            var found = _DbContext.Expenses.Where(m => m.Description == expense.Description).FirstOrDefault();
            if (found == null)
            {
                throw new Exception("Expense not found");
            }
           
            found.Amount=expense.Amount;
            found.Description=expense.Description;
            found.Date=expense.Date;
            _DbContext.SaveChanges();
            return "Expense updated successfully";

        }
    }
}
