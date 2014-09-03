// -----------------------------------------------------------------------
// <copyright file="IIssuesClient.cs"  company="One Call Care Management, Inc.">
// Copyright (c) One Call Care Management, Inc. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace NGitLab
{
	using System.Collections;
	using System.Collections.Generic;
	using NGitLab.Models;

	public interface IIssuesClient
	{
		IEnumerable<Issue> All { get; }
		IEnumerable<Issue> Opened { get; }
		IEnumerable<Issue> Closed { get; }

		Issue this[int id] { get; }

		void Create(Issue issue);
		void Update(Issue issue);
		void Delete(int id);
		void AddComment(int issueId, Note note);
	}
}