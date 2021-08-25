namespace SchoolMngr.Services.Academe.Application.Student.Queries.GetStudentsList
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Codeit.NetStdLibrary.Base.Abstractions.BusinessLogic;
    using Codeit.NetStdLibrary.Base.BusinessLogic;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using SchoolMngr.Services.Academe.Application.Common.Abstractions;
    using SchoolMngr.Services.Academe.Application.Student.Models;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetStudentsListHandler : IRequestHandler<GetStudentsListQuery, IBLListResponse<StudentDto>>
    {
        private readonly IAcademeDbContext _context;
        private readonly IMapper _mapper;

        public GetStudentsListHandler(IAcademeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IBLListResponse<StudentDto>> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
        {
            var students = await _context.Subjects
                .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
                .OrderBy(p => p.ProfileId)
                .ToListAsync(cancellationToken);

            return new BLListResponse<StudentDto>(students);
        }
    }
}