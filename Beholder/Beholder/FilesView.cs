using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beholder
{
  class FilesView:BasicView
  {
    protected override void InitializeComponent_()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      // 
      // FilesView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.ClientSize = new System.Drawing.Size(859, 541);
      this.Name = "FilesView";
      this.Text = "Files";
      this.ResumeLayout(false);

    }
  }
}
