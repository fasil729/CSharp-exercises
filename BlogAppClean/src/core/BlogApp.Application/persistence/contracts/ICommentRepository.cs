using BLOGAPP.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLOGAPP.Application.Contracts.Persistence;

public interface ICommentRepository: IGenericRepository<Comment>
{
    Task<List<Comment>> GetpostComments(int postId);
}