using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Application.Contracts.Dtos.Author;

public class CreateAuthorDto:EntityDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    
}