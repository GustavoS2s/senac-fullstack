using MeuCorre.Domain.Entities;
using MeuCorre.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Domain.Interfaces.Repositories
{
    public interface ITagRepository
    {
        //Retorna do banco de dados os dados de uma Tag que possua o Id informado
        Task<Tag?> ObterPorIdAsync(Guid tagId);

        //Retorna do banco de dados todas as Tags que pertençam ao usuário informado
        Task<IList<Tag>> ListarTodasPorUsuarioAsync(Guid usuarioId);

        //Verificar se uma Tag existe no banco de dados com o Id informado
        //SELECT * FROM Tags WHERE Id = 5
        Task<bool> ExisteAsync(Guid tagId);

        //Verifica se já existe uma Tag com o mesmo
        //nome e tipo para o usuário informado
        //nome e tipo para o usuário informado
        Task<bool> NomeExisteParaUsuarioAsync(string nome, Guid usuarioId);
        /// <summary>
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>

        //Adiciona uma nova Tag no banco de dados
        Task AdicionarAsync(Tag tag);

        //Atualiza os dados de uma Tag no banco de dados
        Task AtualizarAsync(Tag tag);

        //Remove uma Tag do banco de dados
        Task RemoverAsync(Tag tag);
    }
}
