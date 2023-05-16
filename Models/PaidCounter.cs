using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtilityPaymentManager.Models
{
	public class PaidCounter
	{
		public int PaidCounterId { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public string PaidCounterName { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		[Column(TypeName = "decimal(5,3)")]
		public decimal PreviousNumber { get; set; }
		[Column(TypeName = "decimal(5,3)")]
		public decimal NewNumber { get; set; }
		[Column(TypeName = "decimal(5,3)")]
		public decimal ChangeAmount { get; set; }
		[Column(TypeName = "decimal(10,2)")]
		public decimal PaidCounterPrice { get; set; }
		[Column(TypeName = "decimal(10,2)")]
		public decimal PaidCounterSum { get; set; }
	}
}
