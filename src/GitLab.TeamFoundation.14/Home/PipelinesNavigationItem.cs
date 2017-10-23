﻿using Gitea.VisualStudio.Shared;
using Gitea.VisualStudio.Shared.Controls;
using Microsoft.TeamFoundation.Controls;
using System.ComponentModel.Composition;
using System.Windows.Media;

namespace Gitea.TeamFoundation.Home
{
    [TeamExplorerNavigationItem(Settings.AttachmentsNavigationItemId, Settings.Attachments)]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PipelinesNavigationItem : GiteaNavigationItem
    {
        [ImportingConstructor]
        public PipelinesNavigationItem(IGitService git, IShellService shell, IStorage storage, ITeamExplorerServices tes, IWebService ws)
           : base(Octicon.zap, git, shell, storage, tes, ws)
        {
            Text = Strings.Items_Pipeline;
            _tes = tes;
        }
        private readonly ITeamExplorerServices _tes;
        public override void Invalidate()
        {
            base.Invalidate();

            IsVisible = IsVisible && _tes.Project != null && _tes.Project.BuildsEnabled;
        }
        public override void Execute()
        {
            OpenInBrowser("pipelines");
        }
    }
}
