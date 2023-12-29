﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SWE.VirtualShelfBrowser.Authors;

public class UpdateAuthorDto
{
    [Required]
    [StringLength(AuthorConsts.MaxNameLength)]
    public string Name { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    public string ShortBio { get; set; }
}
