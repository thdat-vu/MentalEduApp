﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MentalEdu.Repositories.Models;

public partial class Specialization
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? ActiveFlag { get; set; }

    public virtual ICollection<PsychologistSpecialization> PsychologistSpecializations { get; set; } = new List<PsychologistSpecialization>();
}