using BLOGAPP.Application.Persistence.contracts;
using BLOGAPP.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOGAPP.Persistence.Repositories;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    private readonly BLOGAPPDbContext _dbContext;

    public CommentRepository(BLOGAPPDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<List<Comment>> GetPostComments(int postId)
    {
        var comments = await _dbContext.Comments.Where(q=> q.Postid == postId)
            .ToListAsync();
        return comments;
    }

}