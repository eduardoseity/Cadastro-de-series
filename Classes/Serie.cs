namespace CadastroDeSeries
{
    class Serie : Temporadas
    {
        public Serie(int id, string nome, Categoria categoria, int ano, string descricao, int temporadas)
        {
            this.id = id;
            this.nome = nome;
            this.categoria = categoria;
            this.ano = ano;
            this.descricao = descricao;
            this.temporadas = temporadas;
        }
    }
}