﻿using Gitea.VisualStudio.Shared;
using Gitea.VisualStudio.Shared.Controls;
using Microsoft.TeamFoundation.Controls;
using System.ComponentModel.Composition;
using System.Windows.Media;

namespace Gitea.TeamFoundation.Home
{
    [TeamExplorerNavigationItem(Settings.BuildsNavigationItemId, Settings.Builds)]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BuildsNavigationItem : GiteaNavigationItem
    {
        private readonly ITeamExplorerServices _tes;

        [ImportingConstructor]
        public BuildsNavigationItem(IGitService git, IShellService shell, IStorage storage, ITeamExplorerServices tes, IWebService ws)
           : base(Octicon.fold, git, shell, storage, tes, ws)
        {
            _tes = tes;
            Text = Strings.Items_builds;
        }

        public override void Invalidate()
        {
            base.Invalidate();
            IsVisible = IsVisible && _tes.Project != null && _tes.Project.BuildsEnabled;
        }


        public override void Execute()
        {
            OpenInBrowser("builds");
        }
    }
}
      