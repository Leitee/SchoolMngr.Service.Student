namespace SchoolMngr.Services.Academe.Domain.Entities
{
    using Codeit.NetStdLibrary.Base.Abstractions.DomainModel;
    using Codeit.NetStdLibrary.Base.DomainModel;
    using SchoolMngr.Services.Academe.Entities.Enums;

    public class Subject : EFEntity, IDeleteableEntity
    {
        public string Name { get; set; }
        public string Grade { get; set; }
        public ShiftTimeEnum ShiftTime { get; set; }
        public bool Deleted { get; set; }
    }
}
