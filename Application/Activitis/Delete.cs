using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activitis
{
    public class Deletee
    {
        public class Common : IRequest
        {
            public Guid id { get; set; }
        }

        public class Handler : IRequestHandler<Common>
        {
            private readonly DataContext _db;
            public Handler(DataContext db)
            {
                _db = db;
            }

            public async Task<Unit> Handle(Common request, CancellationToken cancellationToken)
            {
                var act = await _db.Activities.FindAsync(request.id);
                if (act != null)
                {
                    _db.Remove(act);
                    await _db.SaveChangesAsync();
                    return Unit.Value;
                }

                return Unit.Value;
            }
        }
    }
}
