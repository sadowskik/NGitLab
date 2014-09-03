// -----------------------------------------------------------------------
// <copyright file="IssueUpsert.cs"  company="One Call Care Management, Inc.">
// Copyright (c) One Call Care Management, Inc. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace NGitLab.Models
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	[DataContract]
	public class IssueUpsert
	{
		[DataMember(Name = "issue_id")]
		public int Id { get; set; }

		[DataMember(Name = "title")]
		public string Title { get; set; }

		[DataMember(Name = "description")]
		public string Description { get; set; }

		[DataMember(Name = "labels")]
		public string Labels { get; set; }

		[DataMember(Name = "milestone_id")]
		public int MilestoneId { get; set; }

		[DataMember(Name = "assignee_id")]
		public int AssigneeId { get; set; }

		[DataMember(Name = "state_event")]
		public string State { get; set; }

		/*
		id (required) - The ID of a project
		issue_id (required) - The ID of a project's issue
		title (optional) - The title of an issue
		description (optional) - The description of an issue
		assignee_id (optional) - The ID of a user to assign issue
		milestone_id (optional) - The ID of a milestone to assign issue
		labels (optional) - Comma-separated label names for an issue
		state_event (optional) - The state event of an issue ('close' to close issue and 'reopen' to reopen it)
		 */
	}
}