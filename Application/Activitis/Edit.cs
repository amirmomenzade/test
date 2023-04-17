using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activitis
{
    public class Edit
    {
        public class Comment : IRequest
        {
            public Activity activity { get; set; }
        }

        public class Handler : IRequestHandler<Comment>
        {
            private readonly DataContext _db;
            private readonly IMapper _mapper;
            public Handler(DataContext db,IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Comment request, CancellationToken cancellationToken)
            {
                var act = await _db.Activities.FindAsync(request.activity.Id);
                if (act != null)
                {
                    _mapper.Map(request.activity,act);
                    //act.Title = request.activity.Title;
                    await _db.SaveChangesAsync();
                    return Unit.Value;
                }

                return Unit.Value;
            }
        }
    }
}

