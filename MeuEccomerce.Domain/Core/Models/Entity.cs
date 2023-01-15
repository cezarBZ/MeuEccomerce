using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuEccomerce.Domain.Core.Models;

public abstract class Entity<TKey>
{
    public TKey Id { get;  protected set; }
}
