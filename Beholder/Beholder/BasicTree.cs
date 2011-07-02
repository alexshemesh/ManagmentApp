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
  public partial class BasicTree : Form
  {
    public EventHandler SelectionChanged;

    public BasicTree()
    {
      InitializeComponent();
      InitializeComponent_();
    }

    public virtual void TreeSelectionChangedHandler(Object Sender, EventArgs arg)
    {
    }


    protected virtual void InitializeComponent_()
    {
    }
  }
}
