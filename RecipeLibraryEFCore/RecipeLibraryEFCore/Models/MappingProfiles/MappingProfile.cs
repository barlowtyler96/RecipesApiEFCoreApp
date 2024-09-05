﻿using AutoMapper;
using RecipeLibraryEFCore.Models.Dtos;
using RecipeLibraryEFCore.Models.Entities;

namespace RecipeLibraryEFCore.Models.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Recipe, RecipeDto>()
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.RecipeIngredients.Select(ri => new IngredientDto
            {
                Id = ri.IngredientId,
                Name = ri.Ingredient.Name,
                Amount = ri.Amount,
                Unit = ri.Unit
            }).ToList()));

        CreateMap<RecipeDto, Recipe>()
            .ForMember(dest => dest.RecipeIngredients, opt => opt.MapFrom(src => src.Ingredients.Select(ri => new RecipeIngredient
            {
                IngredientId = ri.Id,
                Amount = ri.Amount,
                Unit = ri.Unit,
                Ingredient = new Ingredient { Id = ri.Id, Name = ri.Name }
            }).ToList()));

        CreateMap<Ingredient, IngredientDto>();
        CreateMap<IngredientDto, Ingredient>();

        CreateMap<UserDto, User>();
        CreateMap<User, UserDto>();
    }
}
