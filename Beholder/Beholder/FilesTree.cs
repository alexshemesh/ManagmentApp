﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beholder
{
  class FilesTree:BasicTree
  {
    protected override void InitializeComponent_()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      // 
      // FilesTree
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.ClientSize = new System.Drawing.Size(284, 268);
      this.Name = "FilesTree";
      this.Text = "Files";
      this.ResumeLayout(false);

    }

  }
}
