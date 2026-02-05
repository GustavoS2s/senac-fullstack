using MediatR;
using MeuCorre.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Application.UseCases.Tags.Commands
{
    public class DeletarTagCommand : IRequest<(string, bool)>
    {
        [Required(ErrorMessage = "Id do usuario é obrigatório")]
        public required Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "Id da tag é obrigatório")]
        public required string TagId { get; set; }

    }

    internal class DeletarTagCommandHandler : IRequestHandler<DeletarTagCommand, (string, bool)>
{
        Task<(string, bool)> IRequestHandler<DeletarTagCommand, (string, bool)>.Handle(DeletarTagCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
