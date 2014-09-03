// -----------------------------------------------------------------------
// <copyright file="IMilestoneClient.cs"  company="One Call Care Management, Inc.">
// Copyright (c) One Call Care Management, Inc. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace NGitLab
{
	using System.Collections;
	using System.Collections.Generic;
	using NGitLab.Models;

	public interface IMilestoneClient
	{
		IEnumerable<Milestone> All { get; }

		Milestone this[int id] { get; }

		void Create(Milestone milestone);

		void Update(Milestone milestone);

		void Close(Milestone milestone);

		void Activate(Milestone milestone);
	}
}