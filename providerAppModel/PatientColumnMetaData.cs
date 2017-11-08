namespace Harvester.Model
{
	public class PatientColumnMetaData
	{
		public int ColumnId { get; set; }
		public string Name { get; set; }
		public string DisplayName { get; set; }
		public PatientColumnType ColumnType { get; set; }
        public string DatabaseName { get; set; }
	}

	public enum PatientColumnType
	{
		Number,
		Image,
		Date,
		Text,
        Icon
	}
}
