namespace SchoolMngr.Services.Academe.Application.Student.Queries.GetStudentsList
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Codeit.Enterprise.Base.Abstractions.BusinessLogic;
    using Codeit.Enterprise.Base.BusinessLogic;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using SchoolMngr.Services.Academe.Application.Common.Abstractions;
    using SchoolMngr.Services.Academe.Application.Student.Models;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetStudentsListHandler : IRequestHandler<GetStudentByIdQuery, IBLSingleResponse<StudentDto>>
    {
        private readonly IAcademeDbContext _context;
        private readonly IMapper _mapper;

        public GetStudentsListHandler(IAcademeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IBLSingleResponse<StudentDto>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Students
                .Include(x => x.Statuses)
                .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(x => x.Id == request.Id);

            return new BLSingleResponse<StudentDto>(student);
        }
    }
}