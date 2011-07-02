using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beholder
{
  class PlaylistTree : BasicTree
  {
    protected override void InitializeComponent_()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      // 
      // PlaylistTree
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.ClientSize = new System.Drawing.Size(284, 307);
      this.Name = "PlaylistTree";
      this.Text = "Playlist";
      this.ResumeLayout(false);

    }
  }
}
