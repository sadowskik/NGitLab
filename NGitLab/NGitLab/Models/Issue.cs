using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGitLab.Models
{
	using System.Runtime.Serialization;

	[DataContract]
	public class Issue
	{
		public const string Url = "/issues";

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

		[DataMember(Name = "labels")]
		public IEnumerable<string> Labels { get; set; }

		[DataMember(Name = "milestone")]
		public Milestone Milestone { get; set; }

		[DataMember(Name = "assignee")]
		public User Assignee { get; set; }

		[DataMember(Name = "author")]
		public User Author { get; set; }

		[DataMember(Name = "state")]
		public string State { get; set; }

		[DataMember(Name = "updated_at")]
		public DateTime UpdatedAt { get; set; }

		[DataMember(Name = "created_at")]
		public DateTime CreatedAd { get; set; }

		public IEnumerable<Note> Notes { get; set; }

		/*
	{
		"id": 42,
		"iid": 4,
		"project_id": 8,
		"title": "Add user settings",
		"description": "",
		"labels": [
		  "feature"
		],
		"milestone": {
		  "id": 1,
		  "title": "v1.0",
		  "description": "",
		  "due_date": "2012-07-20",
		  "state": "reopenend",
		  "updated_at": "2012-07-04T13:42:48Z",
		  "created_at": "2012-07-04T13:42:48Z"
		},
		"assignee": {
		  "id": 2,
		  "username": "jack_smith",
		  "email": "jack@example.com",
		  "name": "Jack Smith",
		  "state": "active",
		  "created_at": "2012-05-23T08:01:01Z"
		},
		"author": {
		  "id": 1,
		  "username": "john_smith",
		  "email": "john@example.com",
		  "name": "John Smith",
		  "state": "active",
		  "created_at": "2012-05-23T08:00:58Z"
		},
		"state": "opened",
		"updated_at": "2012-07-12T13:43:19Z",
		"created_at": "2012-06-28T12:58:06Z"
	}
		 */
	}
}
