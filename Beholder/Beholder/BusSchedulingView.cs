﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beholder
{
  class BusSchedulingView:BasicView
  {
    protected override void InitializeComponent_()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      // 
      // BusSchedulingView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.ClientSize = new System.Drawing.Size(854, 537);
      this.Name = "BusSchedulingView";
      this.Text = "Bus Scheduling";
      this.ResumeLayout(false);

    }
  }
}
