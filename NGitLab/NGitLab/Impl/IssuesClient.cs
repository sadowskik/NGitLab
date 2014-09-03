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

		public IssuesClient(API api, string projectPath)
		{
			_api = api;
			_projectPath = projectPath;
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
			var upsert = new IssueUpsert
			{
				Title = issue.Title,
				Description = issue.Description,
				AssigneeId = issue.Assignee != null ? issue.Assignee.Id : 0,
				MilestoneId = issue.Assignee != null ? issue.Milestone.Id : 0,
				Labels = string.Join(",", issue.Labels)
			};

			_api.Post().With(upsert).Stream(_projectPath + "/" + Issue.Url, s => { });
		}

		public void Update(Issue issue)
		{
			var upsert = new IssueUpsert
			{
				Id = issue.Id,
				Title = issue.Title,
				Description = issue.Description,
				AssigneeId = issue.Assignee != null ? issue.Assignee.Id : 0,
				MilestoneId =  issue.Assignee != null ? issue.Milestone.Id : 0,
				Labels = string.Join(",", issue.Labels)
			};

			_api.Put().With(upsert).Stream(_projectPath + "/" + Issue.Url + "/" + issue.Id, s => { });
		}

		public void Close(Issue issue)
		{
			var upsert = new IssueUpsert
			{
				State = "close"
			};
			_api.Put().With(upsert).Stream(_projectPath + "/" + Issue.Url + "/" + issue.Id, s => { });
		}

		public void ReOpen(Issue issue)
		{
			var upsert = new IssueUpsert
			{
				State = "reopen"
			};
			_api.Put().With(upsert).Stream(_projectPath + "/" + Issue.Url + "/" + issue.Id, s => { });
		}

		[Obsolete("Delete is deprecated, close issue with Close method.")]
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