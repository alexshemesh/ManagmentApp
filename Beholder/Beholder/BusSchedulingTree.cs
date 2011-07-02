using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beholder
{
  class BusSchedulingTree:BasicTree
  {
    
    protected override void InitializeComponent_()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      // 
      // BusSchedulingTree
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.ClientSize = new System.Drawing.Size(284, 272);
      this.Name = "BusSchedulingTree";
      this.Text = "Bus Scheduling";
      this.ResumeLayout(false);

    }
  }
}
