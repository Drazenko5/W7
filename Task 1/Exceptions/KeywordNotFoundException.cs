using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Exceptions
{
    [Serializable]
    public class KeywordNotFoundException : Exception
    {
        public KeywordNotFoundException(string keyword) : base(string.Format("Keyword '{0}' not found", keyword)) { }
    }
}
