namespace Beholder
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
      this.axDockingPane = new AxXtremeDockingPane.AxDockingPane();
      this.axCommandBars = new AxXtremeCommandBars.AxCommandBars();
      
      ((System.ComponentModel.ISupportInitialize)(this.axDockingPane)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.axCommandBars)).BeginInit();
      this.SuspendLayout();
      // 
      // axDockingPane
      //
      this.axDockingPane.Enabled = true;
      this.axDockingPane.Location = new System.Drawing.Point(211, 319);
      this.axDockingPane.Name = "axDockingPane";
      this.axDockingPane.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axDockingPane.OcxState")));
      this.axDockingPane.Size = new System.Drawing.Size(24, 24);
      this.axDockingPane.TabIndex = 2;
      this.axDockingPane.AttachPaneEvent += new AxXtremeDockingPane._DDockingPaneEvents_AttachPaneEventHandler(this.axDockingPane_AttachPaneEvent);
      // 
      // axCommandBars
      // 
      this.axCommandBars.Enabled = true;
      this.axCommandBars.Location = new System.Drawing.Point(376, 243);
      this.axCommandBars.Name = "axCommandBars";
      this.axCommandBars.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axCommandBars.OcxState")));
      this.axCommandBars.Size = new System.Drawing.Size(24, 24);
      this.axCommandBars.TabIndex = 1;
       
     
      // 
      // MainWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(963, 483);
      this.Controls.Add(this.axCommandBars);
      this.Controls.Add(this.axDockingPane);      
      this.IsMdiContainer = true;
      this.Name = "MainWindow";
      this.Text = "Form1";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
      this.Load += new System.EventHandler(this.MainWindow_Load);
      this.VisibleChanged += new System.EventHandler(this.MainWindow_VisibleChanged);
      ((System.ComponentModel.ISupportInitialize)(this.axDockingPane)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.axCommandBars)).EndInit();
    
      this.ResumeLayout(false);

    }

    #endregion

    private AxXtremeCommandBars.AxCommandBars axCommandBars;
    private AxXtremeDockingPane.AxDockingPane axDockingPane;
  }
}

