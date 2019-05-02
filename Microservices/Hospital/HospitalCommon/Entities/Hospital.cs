using System;
using System.ComponentModel.DataAnnotations;

public class Hospital
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}
