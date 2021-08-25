using System.Collections.Generic;
using Northwind.Application.Products.Queries.GetProductsFile;

namespace SchoolMngr.Services.Academe.Application.Common.Abstractions
{
    public interface ICsvFileBuilder
    {
        byte[] BuildProductsFile(IEnumerable<ProductRecordDto> records);
    }
}
