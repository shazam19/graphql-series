using System;
using System.Collections;
using System.Collections.Generic;
using GraphQLDotNetCore.Entities;

namespace GraphQLDotNetCore.Contracts
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();

        Owner GetById(Guid id);
    }
}
