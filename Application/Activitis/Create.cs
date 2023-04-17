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
    public class Create
    {

        public class Comment : IRequest
        {
            public Activity activity { get; set; }
        }

        public class Handler : IRequestHandler<Comment>
        {
            private readonly DataContext _db;
            public Handler(DataContext db)
            {
                _db = db;
            }

            public async Task<Unit> Handle(Comment request, CancellationToken cancellationToken)
            {
                 _db.Activities.Add(request.activity);
                await _db.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}

