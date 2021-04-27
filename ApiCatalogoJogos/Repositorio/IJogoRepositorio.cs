using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositorio
{
    public interface IJogoRepositorio : IDisposable
    {
        Task<List<Jogo>> Obter(int pagina, int quantidade);

        Task<Jogo> Obter(Guid id);

        Task<List<Jogo>> Obter(string nome, string produtora);

        Task Inserir(Jogo jogo);

        Task Atualizar(Jogo jogo);

        Task Remover(Guid id);
    }
}
