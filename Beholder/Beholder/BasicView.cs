using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Beholder
{
  public partial class BasicView : Form
  {
    public EventHandler SelectionChanged;

    public BasicView()
    {
      InitializeComponent();
      InitializeComponent_();
    }

    protected virtual void InitializeComponent_()
    { 
    }

    public virtual void TreeSelectionChangedHandler(Object Sender, EventArgs arg)
    {
    }


    public void OnSkinChanged()
    {
      OnBackColorChanged(new EventArgs());
      this.BackColor = MainWindow.skinFramework.GetColor(XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE);
    }
 
    private void BasicView_VisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible)
      {
        MainWindow.ApplySkinWindow(this);
      }
    }
  }
}
