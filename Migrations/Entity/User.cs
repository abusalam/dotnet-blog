using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyBlogAPI8.Migrations.Entity;

[Table("users")]
public partial class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string? Name { get; set; }

    [Column("password")]
    [StringLength(50)]
    public string? Password { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; }

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
