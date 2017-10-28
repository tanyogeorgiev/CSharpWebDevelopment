


namespace GameStore.App.Models.Games
{
    using Infrastructure.Validations.Games;
    using Infrastructure.Validations;
    using SimpleMvc.Framework.Attributes.Validation;
    using System;

    public class GameAdminModel
    {
        [Required]
        [Title]
        public string Title { get; set; }

        [NumberRange(0, double.MaxValue)]
        public decimal Price { get; set; }

        public double Size { get; set; }

        [Required]
        [VideoId]
        public string VideoId { get; set; }

        [Thumbnail]
        public string ThumbnailUrl { get; set; }

        [Required]
        [Description]
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
