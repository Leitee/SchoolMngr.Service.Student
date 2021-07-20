/// <summary>
/// 
/// </summary>
namespace SchoolMngr.Microservices.Academe.Domain
{
    using Pandora.NetStdLibrary.Base.DomainModel;
    using System;

    public class Student : EFEntity
    {
        public string Adress { get; set; }

        public string Obs { get; set; }
    }
}
