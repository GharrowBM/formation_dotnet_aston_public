namespace EX04_API.Datas
{
    public abstract class BaseRepository
    {
        protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
