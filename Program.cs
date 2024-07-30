builder.Services.AddDbContext<ExpenseDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("myConnection"));
});
