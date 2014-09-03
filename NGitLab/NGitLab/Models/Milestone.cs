using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NGitLab.Models
{
	using System.Runtime.Serialization;

	[DataContract]
	public class Milestone
	{
		public const string Url = "/milestones";

		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "iid")]
		public int IId { get; set; }

		[DataMember(Name = "project_id")]
		public int ProjectId { get; set; }

		[DataMember(Name = "title")]
		public string Title { get; set; }

		[DataMember(Name = "description")]
		public string Description { get; set; }

		[DataMember(Name = "due_date")]
		public DateTime DueDate { get; set; }

		[DataMember(Name = "state")]
		public string State { get; set; }

		[DataMember(Name = "updated_at")]
		public DateTime UpdatedAt { get; set; }

		[DataMember(Name = "created_at")]
		public DateTime CreatedAt { get; set; }

		/*
		"id": 12,
		"iid": 3,
		"project_id": 16,
		"title": "10.0",
		"description": "Version",
		"due_date": "2013-11-29",
		"state": "active",
		"updated_at": "2013-10-02T09:24:18Z",
		"created_at": "2013-10-02T09:24:18Z"
		*/
	}
}
