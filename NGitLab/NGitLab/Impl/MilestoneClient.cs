namespace NGitLab.Impl
{
	using System.Collections.Generic;
	using NGitLab.Models;

	public class MilestoneClient : IMilestoneClient
	{
		private readonly API _api;
		private readonly string _projectPath;

		public MilestoneClient(API api, string projectPath)
		{
			_api = api;
			_projectPath = projectPath;
		}

		public IEnumerable<Milestone> All
		{
			get { return _api.Get().GetAll<Milestone>(_projectPath + "/" + Milestone.Url); }
		}

		public Milestone this[int id]
		{
			get { return _api.Get().To<Milestone>(string.Format("{0}/{1}/{2}", _projectPath, Milestone.Url, id)); }
		}

		public void Create(Milestone milestone)
		{
			var upsert = new MilestoneUpsert()
			{
				Title = milestone.Title,
				Description = milestone.Description,
				DueDate = milestone.DueDate,
				StateEvent = milestone.State,
			};

			_api.Post().With(upsert).Stream(_projectPath + "/" + Milestone.Url, s => { });
		}

		public void Update(Milestone milestone)
		{
			var upsert = new MilestoneUpsert()
			{
				Title = milestone.Title,
				Description = milestone.Description,
				DueDate = milestone.DueDate,
				StateEvent = milestone.State,
			};

			_api.Put().With(upsert).Stream(_projectPath + "/" + Milestone.Url + "/" + milestone.Id, s => { });
		}
	}
}