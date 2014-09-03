// -----------------------------------------------------------------------
// <copyright file="IssuesClient.cs"  company="One Call Care Management, Inc.">
// Copyright (c) One Call Care Management, Inc. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NGitLab.Impl
{
	#region Using

	using System;
	using System.Collections.Generic;
	using NGitLab.Models;

	#endregion

	public class IssuesClient : IIssuesClient
	{
		private readonly API _api;
		private readonly int _projectId;
		private readonly string _projectPath;

		public IssuesClient(API api, int projectId)
		{
			_projectId = projectId;
			_api = api;
			_projectPath = string.Format("/projects/{0}/", _projectId);
		}

		#region IIssuesClient Members

		public IEnumerable<Issue> All
		{
			get { return _api.Get().GetAll<Issue>(_projectPath + "/" + Issue.Url); }
		}

		public IEnumerable<Issue> Opened
		{
			get { return _api.Get().GetAll<Issue>(_projectPath + "/" + Issue.Url + "?state=opened"); }
		}

		public IEnumerable<Issue> Closed
		{
			get { return _api.Get().GetAll<Issue>(_projectPath + "/" + Issue.Url + "?state=closed"); }
		}

		public Issue this[int id]
		{
			get { return _api.Get().To<Issue>(string.Format("{0}/{1}/{2}", _projectPath, Issue.Url, id)); }
		}

		public void Create(Issue issue)
		{
			_api.Post().With(issue).Stream(_projectPath + "/" + Issue.Url, s => { });
		}

		public void Update(Issue issue)
		{
			_api.Put().With(issue).Stream(_projectPath + "/" + Issue.Url, s => { });
		}

		public void Delete(int id)
		{
			_api.Delete().With(this[id]).Stream(_projectPath + "/" + Issue.Url, s => { });
		}

		public void AddComment(int issueId, Note note)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}