using System;
using System.Collections.Generic;
using System.Text;
using namespace BLOGAPP.Domain,Common;

namespace BLOGAPP.Domain;

public abstract class Comment: BaseDomainEntity
{
        public int PostId { get; set; } = null!;
        public string Text { get; set; } = null!;
        public virtual Post Post { get; set; } = null!;
}