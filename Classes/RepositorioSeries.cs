using System.Collections.Generic;

namespace CadastroDeSeries
{
    class RepositorioSeries : IRepositorio<Serie>
    {
        private List<Serie> lista = new List<Serie>();
        public void Adicionar(Serie item)
        {
            lista.Add(item);
        }

        public void Atualizar(int id)
        {
            throw new System.NotImplementedException();
        }

        public Serie BuscarPorId(int id)
        {
            if (id > lista.Count - 1)
            {
                throw new System.IndexOutOfRangeException();
            }
            return lista[id];
        }

        public void Excluir(int id)
        {
            lista[id].excluido = true;
        }

        public List<Serie> RetornarLista()
        {
            return lista;
        }

        public int NovoId()
        {
            return lista.Count;
        }

        public void Recuperar(int id)
        {
            lista[id].excluido = false;
        }
    }
}