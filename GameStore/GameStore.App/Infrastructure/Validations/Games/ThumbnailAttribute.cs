using Microsoft.EntityFrameworkCore.Internal;
using SimpleMvc.Framework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.App.Infrastructure.Validations.Games
{
    public class ThumbnailAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var thumbnailUrl = value as string;
            if (thumbnailUrl == null)
            {
                return true;
            }


            return thumbnailUrl.StartsWith("http://")
                    || thumbnailUrl.StartsWith("https://");
        }
    }
}
