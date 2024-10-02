using System.ComponentModel.DataAnnotations;

namespace OnlineStoreManagementSystem.Models;

public class BaseCollectionVM<T> where T : class
{
    [Required] public IQueryable<T> Items { get; set; } = null!;
    
    [Required] public int Count { get; set; }
}