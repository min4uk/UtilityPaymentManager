using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtilityPaymentManager.Models
{
	public class Payment
	{
		public int PaymentId { get; set; }
		//мб тут потрібен атрибут?
		public DateTime PaymentDate { get; set; } = DateTime.Now;
		[Column(TypeName = "decimal(10,2)")]
		public decimal Sum { get; set; }
		public List<PaidCounter> PaidCounters { get; set; } = new List<PaidCounter>();
	}
}