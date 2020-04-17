using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostWebsite.Models.Interfaces
{
    public interface ICommentRepository
    {
        List<Comment> GetCommentByPostId(int postId);
    }
}
