using System;

namespace Graph.Data.Entity
{
    public interface IDbItem
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
