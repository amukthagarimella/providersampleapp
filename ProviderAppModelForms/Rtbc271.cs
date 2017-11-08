namespace Harvester.Model
{
	using System;

	public class Rtbc271
	{
		public string PatientId { get; set; }
		public string ResponseHtml { get; set; }
		public string ResponseX12 { get; set; }
		public DateTime? Date { get; set; }
		public decimal? RemainingBenefits { get; set; }
		public InsuranceIndicator Indicator { get; set; }
	}
}
