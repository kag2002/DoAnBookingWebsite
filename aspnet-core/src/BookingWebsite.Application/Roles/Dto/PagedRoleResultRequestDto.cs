﻿using Abp.Application.Services.Dto;

namespace BookingWebsite.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

