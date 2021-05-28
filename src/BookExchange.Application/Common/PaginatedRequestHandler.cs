using BookExchange.Domain.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookExchange.Application.Common
{
     public abstract class PaginatedRequestHandler<TQuery, TResponseDto> : IRequestHandler<TQuery, PagedResponse<TResponseDto>> where TQuery : IRequest<PagedResponse<TResponseDto>>
     {
          public abstract Task<PagedResponse<TResponseDto>> Handle(TQuery request, CancellationToken cancellationToken);
     }
}
