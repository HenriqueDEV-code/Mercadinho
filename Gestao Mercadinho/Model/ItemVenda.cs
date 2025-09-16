using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Mercadinho.Model
{
    internal class ItemVenda
    {
        
         public string Codigo { get; set; } = "";
            public string Nome { get; set; } = "";
            public int Quantidade { get; set; }
            public decimal PrecoUnitario { get; set; }
            public decimal TotalItem { get; set; }
    }
}
