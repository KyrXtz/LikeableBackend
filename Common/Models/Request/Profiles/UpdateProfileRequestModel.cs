﻿namespace SharedKernel.Models.Request.Profiles
{
    public class UpdateProfileRequestModel
    {
        //[MaxLength(MaxNameLength)]
        public string? Name { get; set; }
        public string? MainPhotoUrl { get; set; }
    }
}
