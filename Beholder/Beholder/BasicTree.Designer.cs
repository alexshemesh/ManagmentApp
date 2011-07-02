namespace Beholder
{
  partial class BasicTree
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.treeView1 = new System.Windows.Forms.TreeView();
      this.SuspendLayout();
      // 
      // treeView1
      // 
      this.treeView1.Location = new System.Drawing.Point(12, 12);
      this.treeView1.Name = "treeView1";
      this.treeView1.Size = new System.Drawing.Size(260, 238);
      this.treeView1.TabIndex = 0;
      // 
      // BasicTtree
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 262);
      this.Controls.Add(this.treeView1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "BasicTtree";
      this.Text = "BasicTtree";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TreeView treeView1;
  }
}