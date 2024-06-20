namespace MyMvcApp.Data;

using Microsoft.EntityFrameworkCore;
using MyMvcApp.Models;

public class ApplicationDbContext : DbContext{
    public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){

    }

    public DbSet<BooksEntity> Books{get; set;}
}