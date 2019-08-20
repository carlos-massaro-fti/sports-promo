using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Comum.Dados
{
    public abstract class PaginadoOrdenadoAbstrato<T>
    {
        public virtual int ContagemDeLinhas { get; set; }
        public virtual int ContagemDePaginas { get; set; }
        public virtual int ItensPorPagina { get; set; } = 12;
        public virtual int PaginaAtual { get; set; } = 1;
        public virtual T Model { get; }
        public virtual IEnumerable<T> Itens { get; set; }
        public virtual string OrdemNome { get; set; }
        public virtual int OrdemDirecao { get; set; }
    }
    public class PaginadoOrdenado<T> : PaginadoOrdenadoAbstrato<T> where T : class, new()
    {
       /* public string OrdemNome { get; set; }
        public int OrdemDirecao { get; set; }
        public int ContagemDeLinhas { get; set; }
        public int ContagemDePaginas { get; set; }
        public int ItensPorPagina { get; set; } = 12;
        public int PaginaAtual { get; set; } = 1;
        public IEnumerable<T> Itens { get; set; }*/
        public new T Model
        {
            get
            {
                return new T();
            }
        }
        public void SetTotalDeLinhas(int contagemDeLinhas)
        {
            ContagemDeLinhas = contagemDeLinhas;
            ContagemDePaginas = (int)Math.Ceiling((double)ContagemDeLinhas / (double)ItensPorPagina);
            if (PaginaAtual < 1)
            {
                PaginaAtual = 1;
            }
            if (PaginaAtual > ContagemDePaginas)
            {
                PaginaAtual = ContagemDePaginas;
            }
        }
    }
}
