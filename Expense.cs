using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("ExpensesTable")]
    public class Expense
    {
        [Key]
        public int SlNo { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
      
    }
    public class ExpenseDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }


        private readonly IConfiguration configurationRoot;
        public ExpenseDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
