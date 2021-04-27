using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositorio
{
    public class JogoRepositorio : IJogoRepositorio
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("946c8c00-4aec-412b-84a2-db5bdfd63a1e"), new Jogo { Id = Guid.Parse("946c8c00-4aec-412b-84a2-db5bdfd63a1e"), Nome = "Half Life 3", Produtora = "Valve", Preco = 120, AnoLancamento = 2050} },
            {Guid.Parse("ee1fbeb0-9c9a-431b-a849-ce938a4eaf3e"), new Jogo { Id = Guid.Parse("ee1fbeb0-9c9a-431b-a849-ce938a4eaf3e"), Nome = "Watch Dogs: Legion", Produtora = "Ubisoft", Preco = 120, AnoLancamento = 2021} },
            {Guid.Parse("e0ce41e5-378b-46f5-a1b4-3c76fe4a41bd"), new Jogo { Id = Guid.Parse("e0ce41e5-378b-46f5-a1b4-3c76fe4a41bd"), Nome = "Fifa 21", Produtora = "EA", Preco = 120, AnoLancamento = 2020} },
            {Guid.Parse("e90a98e9-a32f-4602-9bd7-bf6b5388c0ef"), new Jogo { Id = Guid.Parse("e90a98e9-a32f-4602-9bd7-bf6b5388c0ef"), Nome = "Fifa 20", Produtora = "EA", Preco = 80, AnoLancamento = 2019} },
            {Guid.Parse("e8e2aafe-b545-414c-97e8-acc0a1b7c5b7"), new Jogo { Id = Guid.Parse("e8e2aafe-b545-414c-97e8-acc0a1b7c5b7"), Nome = "Fifa 19", Produtora = "EA", Preco = 60, AnoLancamento = 2018} },
            {Guid.Parse("ecbee89d-b90c-4822-a062-4ca6cfe704ba"), new Jogo { Id = Guid.Parse("ecbee89d-b90c-4822-a062-4ca6cfe704ba"), Nome = "Fifa 18", Produtora = "EA", Preco = 40, AnoLancamento = 2017} },
            {Guid.Parse("6dc48939-5dbb-4b44-bb41-858d77ac3481"), new Jogo { Id = Guid.Parse("6dc48939-5dbb-4b44-bb41-858d77ac3481"), Nome = "Fifa 17", Produtora = "EA", Preco = 20, AnoLancamento = 2016} },
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();

            foreach (var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                    retorno.Add(jogo);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            // Fechar conexão DB
        }
    }
}
