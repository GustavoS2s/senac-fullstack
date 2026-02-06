using MeuCorre.Domain.Entities;
using MeuCorre.Domain.Enums;
using MeuCorre.Domain.Interfaces.Repositories;
using MeuCorre.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Infra.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly MeuDbContext _meuDBContext;

        public TagRepository(MeuDbContext meuDBContext)
        {
            _meuDBContext = meuDBContext;
        }
        public async Task AdicionarAsync(Tag tag)
        {
            _meuDBContext.Tags.Add(tag);
            await _meuDBContext.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Tag tag)
        {
            _meuDBContext.Tags.Update(tag);
            await _meuDBContext.SaveChangesAsync();
        }

        public  Task<bool> ExisteAsync(Guid tagId)
        {
            var existe = _meuDBContext.Tags
                .AnyAsync(t => t.Id == tagId);
            return existe;
        }

        public async Task<IList<Tag>> ListarTodasPorUsuarioAsync(Guid usuarioId)
        {
            var listaDeTags = _meuDBContext.Tags
                .Where(t => t.UsuarioId == usuarioId);
            return await listaDeTags.ToListAsync();
        }

        public Task<bool> NomeExisteParaUsuarioAsync(string nome,Guid usuarioId)
        {
            var existe = _meuDBContext.Tags
                .AnyAsync(
                            t => t.Nome == nome &&
                            t.UsuarioId == usuarioId
                        );
            return existe;
        }

        public async Task<Tag?> ObterPorIdAsync(Guid tagId)
        {
            var tag = _meuDBContext.Tags.FirstOrDefaultAsync(t => t.Id == tagId);
            return await tag;
        }

        public Task RemoverAsync(Tag tag)
        {
            _meuDBContext.Tags.Remove(tag);
            return Task.CompletedTask;
        }
    }
}
