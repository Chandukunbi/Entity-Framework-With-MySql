if you Nuget references in an EntityFramework project that uses MySql.Data.Entity (latest version is 6.10.X) and MySql.Data (latest version is 8.0.X). Those version numbers should match. You should use the MySql.Data.EntityFrameworkpackage with MySql.Data version 8.0 and after, and the MySql.Data.Entity package with versions 6.10 and before.

Create a New Project => New Project => Select MVC Project Template

Authentication => No Authentication

Install MySql.Data package using Package Manager Console

Install MySql.Data.EntityFramework package using Package Manager Console

Add Connectionstring in WebConfig
<add name="DefaultConnection" connectionString="server=localhost;userid=uid;password=pwd;database=dbName;persistsecurityinfo=true" providerName="MySql.Data.MySqlClient" />

Add New Class In Models Folder
[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext()
            :base("DefaultConnection")
        {

        }
    }    



Add New Class File In Models Folder 
public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]        
        public string Name { get; set; }
    }


Go to Package Manage Console
Execute Command => Enable-migrations
Execute Command => add-migration InitialModel
Execute Command => update-database

Done We Successfully connected MySql Database with EntityFramework

Add New API Controller and Add Following code to in.
private static ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET /api/products
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        //GET /api/products/idf
        public Product GetProducts(int id)
        {
            return _context.Products.SingleOrDefault(p => p.Id == id);
        }
}
Compile your application and test your api entering following url:
url : http:localhost:port/api/products

you can also test your api using postman or any other restclient

Thank you






