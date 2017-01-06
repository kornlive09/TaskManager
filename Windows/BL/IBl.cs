using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBl : IDisposable
    {
        void Delete(long id);
        void Add(long? parent, string name);
        void Rename(long id, string newName);
        void Copy(long id);
        void Cut(long id);
        void Insert(long? parent, int position);
    }
}
