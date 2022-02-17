namespace SchoolMngr.Services.Academe.Domain.Entities
{
    using Codeit.Enterprise.Base.Abstractions.DomainModel;
    using Codeit.Enterprise.Base.DomainModel;

    public class Subject : EFEntity, IDeleteableEntity
    {
        public string Name { get; set; }
        public string Grade { get; set; }
        public string ShiftTime { get; set; }
        public bool Deleted { get; set; }
    }
}
