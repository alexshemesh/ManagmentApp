namespace ManagmentApp
{
  partial class MainWindow
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
      this.axSkinFramework1 = new AxXtremeSkinFramework.AxSkinFramework();
      this.axDockingPane1 = new AxXtremeDockingPane.AxDockingPane();
      this.axCommandBars1 = new AxXtremeCommandBars.AxCommandBars();
      ((System.ComponentModel.ISupportInitialize)(this.axSkinFramework1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.axDockingPane1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.axCommandBars1)).BeginInit();
      this.SuspendLayout();
      // 
      // axSkinFramework1
      // 
      this.axSkinFramework1.Enabled = true;
      this.axSkinFramework1.Location = new System.Drawing.Point(249, 258);
      this.axSkinFramework1.Name = "axSkinFramework1";
      this.axSkinFramework1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSkinFramework1.OcxState")));
      this.axSkinFramework1.Size = new System.Drawing.Size(24, 24);
      this.axSkinFramework1.TabIndex = 1;
      // 
      // axDockingPane1
      // 
      this.axDockingPane1.Enabled = true;
      this.axDockingPane1.Location = new System.Drawing.Point(466, 226);
      this.axDockingPane1.Name = "axDockingPane1";
      this.axDockingPane1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axDockingPane1.OcxState")));
      this.axDockingPane1.Size = new System.Drawing.Size(24, 24);
      this.axDockingPane1.TabIndex = 2;
      // 
      // axCommandBars1
      // 
      this.axCommandBars1.Enabled = true;
      this.axCommandBars1.Location = new System.Drawing.Point(632, 258);
      this.axCommandBars1.Name = "axCommandBars1";
      this.axCommandBars1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axCommandBars1.OcxState")));
      this.axCommandBars1.Size = new System.Drawing.Size(24, 24);
      this.axCommandBars1.TabIndex = 3;
      // 
      // MainWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(997, 520);
      this.Controls.Add(this.axCommandBars1);
      this.Controls.Add(this.axDockingPane1);
      this.Controls.Add(this.axSkinFramework1);
      this.IsMdiContainer = true;
      this.Name = "MainWindow";
      this.Text = "Managment";
      ((System.ComponentModel.ISupportInitialize)(this.axSkinFramework1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.axDockingPane1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.axCommandBars1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private AxXtremeSkinFramework.AxSkinFramework axSkinFramework1;
    private AxXtremeDockingPane.AxDockingPane axDockingPane1;
    private AxXtremeCommandBars.AxCommandBars axCommandBars1;
  }
}

