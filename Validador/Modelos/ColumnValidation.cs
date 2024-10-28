using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validador.Modelos
{
    public class ColumnValidation
    {
        public int NumColum { get; set; }
        public string ColumnName { get; set; }
        public string Type { get; set; }
        public int MaxLength { get; set; }
        public bool IsRequired { get; set; }
    }
}
