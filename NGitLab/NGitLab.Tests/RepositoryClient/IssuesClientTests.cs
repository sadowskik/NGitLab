// -----------------------------------------------------------------------
// <copyright file="IssuesClientTests.cs"  company="One Call Care Management, Inc.">
// Copyright (c) One Call Care Management, Inc. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace NGitLab.Tests.RepositoryClient
{
	using System;
	using System.Linq;
	using NGitLab.Impl;
	using NGitLab.Models;
	using NUnit.Framework;

	public class IssuesClientTests
	{
		private readonly IIssuesClient _issuesClient;

		public IssuesClientTests()
		{
			_issuesClient = _RepositoryClientTests.RepositoryClient.Issues;
		}

		[Test]
		public void GetAll()
		{
			var test = _issuesClient.All.ToList();
			Assert.NotNull(test);
		}

		[Test]
		public void Create()
		{
			var initialCount = _issuesClient.All.Count();
			_issuesClient.Create(new Issue
			{
				Title = "test created",
				Labels = new String[] { "test", "test1" }
			});
			
			var afterCreateCount = _issuesClient.All.Count();
			Assert.IsTrue(initialCount < afterCreateCount);
			Assert.IsTrue(initialCount + 1 == afterCreateCount);
		}

		[Test]
		public void Update()
		{
			var issue = _issuesClient.All.Last();
			var initialDescription = issue.Description;
			var initialLabels = issue.Labels;
			issue.Description = initialDescription + "added";
			issue.Labels = new [] {"test","test1"};
			_issuesClient.Update(issue);
			var updatedIssue = _issuesClient.All.Last();
			Assert.IsTrue(initialDescription != updatedIssue.Description);
			Assert.IsTrue(updatedIssue.Description.Contains("added"));
			Assert.IsTrue(updatedIssue.Labels.Count() == 2);
			updatedIssue.Description = initialDescription;
			_issuesClient.Update(issue);
		}
	}
}