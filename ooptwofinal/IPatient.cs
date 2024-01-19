using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptwofinal
{
    public interface IPatient : IPerson
    {
        int Age { get; }
        string Gender { get; }
        string Address { get; }
    }
}
