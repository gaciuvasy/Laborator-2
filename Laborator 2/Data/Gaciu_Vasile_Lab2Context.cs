using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Laborator_2.Models;

namespace Gaciu_Vasile_Lab2.Data
{
    public class Gaciu_Vasile_Lab2Context : DbContext
    {
        public Gaciu_Vasile_Lab2Context (DbContextOptions<Gaciu_Vasile_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<Laborator_2.Models.Publisher> Publisher { get; set; } = default!;
    }
}
