// -----------------------------------------------------------------------
// <copyright file="MilestoneClientTests.cs"  company="One Call Care Management, Inc.">
// Copyright (c) One Call Care Management, Inc. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace NGitLab.Tests.RepositoryClient
{
	using System;
	using System.Linq;
	using NGitLab.Models;
	using NUnit.Framework;

	public class MilestoneClientTests
	{
		private readonly IMilestoneClient _milestoneClient;

		public MilestoneClientTests()
		{
			_milestoneClient = _RepositoryClientTests.RepositoryClient.Milestones;
		}

		[Test]
		public void All()
		{
			var milestones = _milestoneClient.All.ToList();
			Assert.IsTrue(milestones != null);
		}

		[Test]
		public void CreateMilestone()
		{
			var milestone = new Milestone
			{
				Title = "test",
				Description = "test",
				DueDate = DateTime.Now,
			};

			var initialMilestones = _milestoneClient.All.ToList();
			_milestoneClient.Create(milestone);
			var createdMilestones = _milestoneClient.All.ToList();
			Assert.IsTrue(initialMilestones.Count < createdMilestones.Count);
		}
	}
}