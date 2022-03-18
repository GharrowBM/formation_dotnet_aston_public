namespace C05_EFCore.Datas
{
    public class BaseRepository
    {
        protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
