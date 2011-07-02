using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beholder
{
  class HardwareView:BasicView
  {
    private System.Windows.Forms.ListView listView1;
  
    protected override void InitializeComponent_()
    {
      InitializeComponent();
    }

    private void InitializeComponent()
    {
      this.listView1 = new System.Windows.Forms.ListView();
      this.SuspendLayout();
      // 
      // listView1
      // 
      this.listView1.Location = new System.Drawing.Point(344, 196);
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(121, 97);
      this.listView1.TabIndex = 0;
      this.listView1.UseCompatibleStateImageBehavior = false;
      // 
      // HardwareView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.ClientSize = new System.Drawing.Size(859, 537);
      this.Controls.Add(this.listView1);
      this.Name = "HardwareView";
      this.Text = "Hardware";
      this.ResumeLayout(false);

    }
  }
}
