namespace NGitLab.Models
{
	using System;
	using System.Runtime.Serialization;

	[DataContract]
	public class MilestoneUpsert
	{
		[DataMember(Name = "title")]
		public string Title { get; set; }

		[DataMember(Name = "description")]
		public string Description { get; set; }

		[DataMember(Name = "due_date")]
		public DateTime DueDate { get; set; }

		[DataMember(Name = "state_event")]
		public string StateEvent { get; set; }

		/*
		title (optional) - The title of a milestone
		description (optional) - The description of a milestone
		due_date (optional) - The due date of the milestone
		state_event (optional) - The state event of the milestone (close|activate)
		 */
	}
}