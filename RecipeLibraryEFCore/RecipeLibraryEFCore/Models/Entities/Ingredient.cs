﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RecipeLibraryEFCore.Models.Entities;

public class Ingredient
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = "";

    //Navigation property
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public List<RecipeIngredient> RecipeIngredients { get; set; } = [];

}