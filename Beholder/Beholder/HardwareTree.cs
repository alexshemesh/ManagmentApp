using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beholder
{
  class HardwareTree:BasicTree
  {
    private System.Windows.Forms.TextBox textBox1;

    protected override void InitializeComponent_()
    {
      InitializeComponent();
    }

    protected void InitializeComponent()
    {
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(95, 311);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(100, 20);
      this.textBox1.TabIndex = 1;
      // 
      // HardwareTree
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.ClientSize = new System.Drawing.Size(284, 456);
      this.Controls.Add(this.textBox1);
      this.Name = "HardwareTree";
      this.Text = "Hardware";
      this.Controls.SetChildIndex(this.textBox1, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }
  }
}
