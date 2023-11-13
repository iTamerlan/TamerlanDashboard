using Engine.Contracts.Attachment;
using Engine.Contracts.Attributes;
using Engine.Contracts.Base;
using Engine.ModelProperties.Base;
using System.ComponentModel.DataAnnotations;

namespace Dashboard.Contracts.Post;

/// <summary>
/// Объявление.
/// </summary>
public class CreatePostDto : IValidatableObject
{
    /// <summary>
    /// Заголовок.
    /// </summary>
    [Required]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Поле {0} должно быть по длине больше {2} и меньше {1} символов")]
    public string Title { get; set; }

    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Наименование категории.
    /// </summary>
    public string CategoryName { get; set; }

    /// <summary>
    /// Цена.
    /// </summary>
    [Range(0, 10_000_000, ErrorMessage = "Поле {0} должно быть больше {2} и меньше {1}")]
    public decimal Price { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var validationResult = new List<ValidationResult>();

        var badWordsVocalbulary = new string[]
        {
            "блин",
            "котлета",
            "оладушек",
        };

        if (badWordsVocalbulary.Any(x => Description.Contains(x)))
        {
            validationResult.Add(new ValidationResult("Поле Description содержит плохие слова."));
        }

        return validationResult;
    }
}