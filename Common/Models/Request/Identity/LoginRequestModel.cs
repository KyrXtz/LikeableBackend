﻿namespace SharedKernel.Models.Request.Identity
{
    public class LoginRequestModel
    {
        //[Required]
        public string Username { get; set; }
        //[Required]
        public string Password { get; set; }
    }
}
