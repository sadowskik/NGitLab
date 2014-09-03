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

		[Test]
		public void Update()
		{
			var milestone = _milestoneClient.All.Last();
			var initialDescription = milestone.Description;
			milestone.Description = "added";
			_milestoneClient.Update(milestone);
			var updatedMilestone = _milestoneClient[milestone.Id];
			Assert.IsTrue(updatedMilestone.Description == "added");
			updatedMilestone.Description = initialDescription;
			_milestoneClient.Update(updatedMilestone);
		}

		[Test]
		public void CloseActivate()
		{
			var milestone = _milestoneClient.All.Last();
			if (milestone.State == "closed")
			{
				_milestoneClient.Activate(milestone);
				Assert.IsTrue(_milestoneClient[milestone.Id].State == "active");
				_milestoneClient.Close(milestone);
				Assert.IsTrue(_milestoneClient[milestone.Id].State == "closed");
			}
			else
			{
				_milestoneClient.Close(milestone);
				Assert.IsTrue(_milestoneClient[milestone.Id].State == "closed");
				_milestoneClient.Activate(milestone);
				Assert.IsTrue(_milestoneClient[milestone.Id].State == "active");
			}
		}
	}
}