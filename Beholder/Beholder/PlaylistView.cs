using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beholder
{
  class PlaylistView:BasicView
  {
    protected override void InitializeComponent_()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      // 
      // PlaylistView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.ClientSize = new System.Drawing.Size(838, 532);
      this.Name = "PlaylistView";
      this.Text = "Playlist";
      this.ResumeLayout(false);

    }
  }
}
