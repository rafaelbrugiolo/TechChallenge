﻿namespace FidelityCard.Domain.Entities;

public class Customer : BaseEntity
{
    public string Name { get; set; }
    public string? Email { get; set; }
    public DateTime? Birthdate { get; set; }
    public string? ContactPhone { get; set; }
}