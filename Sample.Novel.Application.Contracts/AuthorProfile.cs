using AutoMapper;
using Sample.Novel.Application.Contracts.Dtos.Author;
using Sample.Novel.Domain.AuthorAggregate.Entities;
using Volo.Abp.AutoMapper;

namespace Sample.Novel.Application.Contracts;

public class AuthorProfile:Profile
{
    public AuthorProfile()
    {
        CreateMap<CreateAuthorDto, Author>()//將用於創建方法的輸入DTO映射到實體
            .Ignore(Author=>Author.Id);//忽略Id屬性
        CreateMap<Author, AuthorDto>();//將應用方法返回值類型是基礎DTO時，將Author實體映射到DTO
    }
}