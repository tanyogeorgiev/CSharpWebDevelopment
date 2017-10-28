﻿using SimpleMvc.Framework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.App.Infrastructure.Validations.Games
{
    public class VideoIdAttribute : PropertyValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var videoId = value as string;

            if (videoId == null)
            {
                return true;
            }

            return videoId.Length == 11;
        }
    }
}
