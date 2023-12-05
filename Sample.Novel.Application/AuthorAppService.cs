using Sample.Novel.Application.Contracts;
using Sample.Novel.Application.Contracts.Dtos.Author;
using Sample.Novel.Domain.AuthorAggregate;
using Sample.Novel.Domain.AuthorAggregate.Entities;
using System.Linq;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Sample.Novel.Application
{
    public class AuthorAppService : ApplicationService, IAuthorAppService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorAppService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task CreateAsync(CreateAuthorDto input)
        {
            var author = ObjectMapper.Map<CreateAuthorDto, Author>(input);
            await _authorRepository.InsertAsync(author);
        }

        public async Task<AuthorDto> GetAsync(Guid id)
        {
            var author = await _authorRepository.GetAsync(id);
            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        public async Task<PagedResultDto<AuthorDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var count = await _authorRepository.CountAsync();
            var list = await _authorRepository.GetPagedListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting);
                //.OrderBy(input.Sorting)
                //.PageBy(input)
                //.ToListAsync();
            return new PagedResultDto<AuthorDto>
            {
                TotalCount = count,
                Items = ObjectMapper.Map<List<Author>, List<AuthorDto>>(list)
            };
        }
    }
}
}
