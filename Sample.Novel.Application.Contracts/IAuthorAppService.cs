using Sample.Novel.Application.Contracts.Dtos.Author;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Sample.Novel.Application.Contracts;

public interface IAuthorAppService:IApplicationService
{
    Task<AuthorDto> CreateAsync(CreateAuthorDto input);
    Task<AuthorDto> GetAsync(Guid id);
    Task<PagedResultDto<AuthorDto>> GetListAsync(PagedAndSortedResultRequestDto input);
    
}