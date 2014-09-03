// -----------------------------------------------------------------------
// <copyright file="IssuesClientTests.cs"  company="One Call Care Management, Inc.">
// Copyright (c) One Call Care Management, Inc. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace NGitLab.Tests.RepositoryClient
{
	using System.Linq;
	using NGitLab.Impl;
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
	}
}