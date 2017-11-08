using System;
using System.Collections.Generic;

namespace Harvester.Model
{
	public class ImageExam
	{
		public string ExamID { get; set; }
		public string ExamName { get; set; }
		public DateTime ExamDateTime { get; set; }
		public ImageType ExamType { get; set; }
		public bool FullMouth { get; set; }
		public bool Bitewings { get; set; }
		public bool Panoramic { get; set; }
		public bool IsExamActive { get; set; }

		public List<Picture> Images { get; set; }
	}
}

