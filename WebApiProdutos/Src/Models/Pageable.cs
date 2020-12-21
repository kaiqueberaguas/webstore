using System;
using System.Collections.Generic;

namespace WebApiProdutos.Src.Models
{
    public class Pageable<T> : List<T> where T : Entity
    {

        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public Pageable(List<T> itens, int totalItens, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(totalItens / (double)pageSize);
            AddRange(itens);
        }
    }
}
