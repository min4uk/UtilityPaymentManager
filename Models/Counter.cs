using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtilityPaymentManager.Models
{
	public class Counter
	{
        public int CounterId { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public string Name { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		[Column(TypeName = "decimal(5,3)")]
		public decimal CurrentNumber { get; set; }
		[Column(TypeName = "decimal(10,2)")]
		public decimal Price { get; set; }

    }
}
