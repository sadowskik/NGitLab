using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NGitLab.Models
{
	using System.Runtime.Serialization;

	[DataContract]
	public class Note
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "title")]
		public string Title { get; set; }

		[DataMember(Name = "author")]
		public User Author { get; set; }

		[DataMember(Name = "updated_at")]
		public DateTime CreatedAt { get; set; }

		/*
		 {
		  "id": 52,
		  "title": "Snippet",
		  "author": {
			"id": 1,
			"username": "pipin",
			"email": "admin@example.com",
			"name": "Pip",
			"state": "active",
			"created_at": "2013-09-30T13:46:01Z"
		  },
		  "created_at": "2013-10-02T07:34:20Z"
		}
		 */
	}
}
