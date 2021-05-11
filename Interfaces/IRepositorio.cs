using System.Collections.Generic;

namespace CadastroDeSeries
{
    interface IRepositorio<T>
    {
        List<T> RetornarLista();
        T BuscarPorId(int id);
        void Adicionar(T item);
        void Excluir(int id);
        void Recuperar(int id);
        void Atualizar(int id);
        int NovoId();
    }
}