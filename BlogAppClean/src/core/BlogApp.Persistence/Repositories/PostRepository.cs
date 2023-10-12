using BLOGAPP.Application.Contracts.Persistence;
using BLOGAPP.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOGAPP.Persistence.Repositories;
public class PostRepository : GenericRepository<Post>, IPostRepository
{
    private readonly BLOGAPPDbContext _dbContext;

    public PostRepository(BLOGAPPDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Post>> GetPostsWithDetails()
    {
        return _dbContext.Posts.Include(p => p.Comments).ToList();
    }
}