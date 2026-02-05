using MediatR;
using MeuCorre.Application.UseCases.Categorias.Commands;
using MeuCorre.Domain.Enums;
using MeuCorre.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Application.UseCases.Tags.Commands
{
    public class CriarTagCommand : IRequest<(string, bool)>
    {
        [Required(ErrorMessage = "E necessário informar o id do usuário")]
        public required Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "Nome da tag é obrigatório")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "Cor da tag é obrigatório")]
        public required string Cor { get; set; }

    }

    internal class CriarTagCommandHandler : IRequestHandler<CriarTagCommand, (string, bool)>
    {
        public Task<(string, bool)> Handle(CriarTagCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
