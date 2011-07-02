using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using System.Collections;
using XtremeDockingPane;
using XtremeCommandBars;

namespace Beholder
{
  public partial class MainWindow : Form
  {
    static public AxXtremeSkinFramework.AxSkinFramework skinFramework;
    static public MainWindow This_ = null;
    string skinFolder;
    public XtremeCommandBars.StatusBar StatusBar;
    private Dictionary<Type,ArrayList> windows_ =  new Dictionary<Type,ArrayList>();
    private Dictionary<int, Form> DockingQueue_ = new Dictionary<int, Form>();

    public MainWindow()
    {
      InitializeComponent();
      if (!Settings.Instance.Serialize("CCSettings.xml", false))
      {
        Settings.Instance.Serialize("CCSettings.xml", true);
      }
      registerXtremeSuiteComponents_();

      skinFramework = new AxXtremeSkinFramework.AxSkinFramework();
      skinFramework.BeginInit();
      this.Controls.Add(skinFramework);
      skinFramework.EndInit();
      //   Tracer.Instance.Trace(this, "Loading Skins");

      skinFolder = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\..\\Skins\\";

      bool res = skinFramework.LoadSkin(skinFolder + "Vista.cjstyles", "NormalBlack.ini");
      This_ = this;
    }

    public void OnSkinChanged()
    {
      OnBackColorChanged(new EventArgs());
      this.BackColor = MainWindow.skinFramework.GetColor(XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE);
    }



    /// <summary>
    /// registers licence information in xtreme controls
    /// </summary>
    private void registerXtremeSuiteComponents_()
    {
      try
      {

        XtremeCommandBars.CommandBarsGlobalSettingsClass CommandBarsSettings =

        new XtremeCommandBars.CommandBarsGlobalSettingsClass();
        CommandBarsSettings.License =
        "CommandBars Control Copyright (c) 2003-2010 Codejock Software\r\n" +
        "PRODUCT-ID: Codejock.CommandBars.ActiveX.v13.3\r\n" +
        "VALIDATE-CODE: QQS-PNF-OJV-VBX";

        XtremeSkinFramework.SkinFrameworkGlobalSettings SkinFrameWorkSettings = new XtremeSkinFramework.SkinFrameworkGlobalSettings();
        SkinFrameWorkSettings.License =
        "Skin Framework Control Copyright (c) 2003-2010 Codejock Software\r\n" +
        "PRODUCT-ID: Codejock.SkinFramework.ActiveX.v13.3\r\n" +
        "VALIDATE-CODE: GGE-OLD-QQR-EJS";



        XtremeDockingPane.DockingPaneGlobalSettings DockingPaneWorkSettings = new XtremeDockingPane.DockingPaneGlobalSettings();
        DockingPaneWorkSettings.License =
        "Docking Panes Control Copyright (c) 2003-2010 Codejock Software\r\n" +
        "PRODUCT-ID: Codejock.DockingPane.ActiveX.v13.3\r\n" +
        "VALIDATE-CODE: UCY-KMS-CII-OCF";

        /*XtremeReportControl.ReportControlGlobalSettings ReportControlWorkSettings = new XtremeReportControl.ReportControlGlobalSettings();
        ReportControlWorkSettings.License =
        "Report Control Copyright (c) 2003-2010 Codejock Software\r\n" +
        "PRODUCT-ID: Codejock.ReportControl.ActiveX.v13.3\r\n" +
        "VALIDATE-CODE: HIF-MPA-DRR-OPF";

          
          XtremePropertyGrid.PropertyGridGlobalSettings PropertyGridWorkSettings = new XtremePropertyGrid.PropertyGridGlobalSettings();
        PropertyGridWorkSettings.License =
        "Property Grid Control Copyright (c) 2003-2010 Codejock Software\r\n" +
        "PRODUCT-ID: Codejock.PropertyGrid.ActiveX.v13.3\r\n" +
        "VALIDATE-CODE: HVN-LFW-DIX-XRR";

         XtremeSyntaxEdit.SyntaxEditGlobalSettings SyntaxEditWorkSettings = new XtremeSyntaxEdit.SyntaxEditGlobalSettings();
        SyntaxEditWorkSettings.License =
        "Syntax Edit Copyright (c) 2003-2010 Codejock Software\r\n" +
        "PRODUCT-ID: Codejock.SyntaxEdit.ActiveX.v13.3\r\n" +
        "VALIDATE-CODE: DPV-TGO-RWX-NGL";
        
             XtremeSuiteControls.SuiteControlsGlobalSettings SuiteControlsWorkSettings = new XtremeSuiteControls.SuiteControlsGlobalSettings();
             SuiteControlsWorkSettings.License =
             "Suite Controls Copyright (c) 2003-2010 Codejock Software\r\n" +
             "PRODUCT-ID: Codejock.Controls.ActiveX.v13.3\r\n" +
             "VALIDATE-CODE: NSR-VTA-EXQ-TPT";

          XtremeShortcutBar.ShortcutBarGlobalSettings ShortcutBarWorkSettings = new XtremeShortcutBar.ShortcutBarGlobalSettings();
             ShortcutBarWorkSettings.License =
             "ShortcutBar Control Copyright (c) 2003-2010 Codejock Software\r\n" +
             "PRODUCT-ID: Codejock.ShortcutBar.ActiveX.v13.3\r\n" +
             "VALIDATE-CODE: REV-QAQ-QMJ-ETA";
         */
      }
      catch (System.Exception e)
      {
        Tracer.Instance.Trace(this, "registering of CodeJock failed:" + e.Message);
      }
    }

    private void MainWindow_VisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible)
      {
        skinFramework.ApplyWindow(this.Handle.ToInt32());
      }
    }

    /// <summary>
    /// checks if skinframework is alive and applys skin to window
    /// </summary>
    /// <param name="ctrl"></param>
    public static void ApplySkinWindow(Control ctrl)
    {
      if (skinFramework != null)
      {
        MainWindow.skinFramework.ApplyWindow(ctrl.Handle.ToInt32());
        ctrl.BackColor = MainWindow.skinFramework.GetColor(XtremeSkinFramework.XTPColorManagerColor.STDCOLOR_BTNFACE);
      }
    }


    private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.Controls.Remove(skinFramework);
      skinFramework = null;
    }

    private void MainWindow_Load(object sender, EventArgs e)
    {
      foreach (Control ctrl in this.Controls)
      {
        if (ctrl is MdiClient)
        {
          axDockingPane.SetMDIClient(ctrl.Handle.ToInt32());
        }
      }
      axDockingPane.Options.LunaColors = true;
      axDockingPane.VisualTheme = VisualTheme.ThemeOffice2003;
      axDockingPane.TabPaintManager.OneNoteColors = false;
      axDockingPane.PanelPaintManager.OneNoteColors = false;
      axDockingPane.TabPaintManager.ClientFrame = XtremeDockingPane.XTPTabClientFrame.xtpTabFrameNone;
      axDockingPane.Options.ShowDockingContextStickers = true;
      axDockingPane.Options.AlphaDockingContext = true;
      axDockingPane.Options.ShowCaptionMaximizeButton = true;
      axDockingPane.Options.CloseGroupOnButtonClick = true;
      axDockingPane.Options.HideGroupOnButtonClick = true;
      Tracer.Instance.Trace(this, "Before Invokin AfterLoadInit");
      Invoke(new EventHandler<EventArgs>(AfterLoadInit), new object[] { this, null });
    }

    Form addSubfomHelper_(Form par)
    {
      if(!windows_.ContainsKey(par.GetType()))
      {
        windows_.Add(par.GetType(),new ArrayList());
      }
      ArrayList storage = windows_[par.GetType()];
      storage.Add(par);
      return par; 

    }

    /// <summary>
    /// Add new form as docking pane
    /// </summary>
    /// <param name="NewObject">Form to add</param>
    private Pane CreateDockingPane_(Form NewObject)
    {
      Pane RetVal;
      lock (DockingQueue_)
      {
        DockingQueue_.Add(NewObject.GetHashCode(), NewObject);
        RetVal = axDockingPane.CreatePane(NewObject.GetHashCode(), 200, 120, DockingDirection.DockLeftOf, null);
        RetVal.Title = NewObject.Text;
      }
      return RetVal;
    }

    private void axDockingPane_AttachPaneEvent(object sender, AxXtremeDockingPane._DDockingPaneEvents_AttachPaneEvent e)
    {
      lock (DockingQueue_)
      {
        Form NewObject = DockingQueue_[e.item.Id];
        DockingQueue_.Remove(e.item.Id);
        e.item.Handle = NewObject.Handle.ToInt32();
      }
    }

    Form configureMDIView_(BasicView view, BasicTree linkedtree)
    {
      view.SelectionChanged += linkedtree.TreeSelectionChangedHandler;
      linkedtree.SelectionChanged += view.TreeSelectionChangedHandler;

      view.MdiParent = this;
      view.WindowState = FormWindowState.Maximized;
      view.Show();
      return view;
    }


    /// <summary>
    /// Creates link beetween forms and tree views, whenever Form1 or Form2 selected by user, 
    /// appointed form will be activated 
    /// </summary>
    /// <param name="Form1TreePane">Form of the tree view control</param>
    /// <param name="Form1Pane">Pane that corresponds with tree view control</param>
    /// <param name="Form2">Form that shows data from tree view</param>
    private void interlinkSelection_(Form Form1TreePane, Pane Form1TreePanePane, Form Form2View)
    {
      Form2View.Activated += new EventHandler((Object sender, EventArgs arg) =>
      {
        try
        {
          Form1TreePanePane.Select();
        }
        catch (Exception)
        {
        }
      });

      Form1TreePane.LostFocus += new EventHandler((Object sender, EventArgs arg) =>
      {
        try
        {

        }
        catch (Exception)
        {
        }

      });

      Form1TreePane.GotFocus += new EventHandler((Object sender, EventArgs arg) =>
      {
        try
        {
          Form2View.BringToFront();
        }
        catch (Exception)
        {
        }

      });

    }

    /// <summary>
    /// This function will be called after Load function exits, we cant call it from Load directly because we need
    /// valid Handle object
    /// </summary>
    /// <param name="Sender"></param>
    /// <param name="a"></param>
    private void AfterLoadInit(object Sender, EventArgs a)
    {
      try
      {

        Form currentTree = addSubfomHelper_(new HardwareTree());
        Pane hardwareTreePane = CreateDockingPane_(currentTree);
        Form currentView = addSubfomHelper_(new HardwareView());
        configureMDIView_((BasicView)currentView, (BasicTree)currentTree);
        interlinkSelection_(currentTree, hardwareTreePane, currentView);

        currentTree = addSubfomHelper_(new PlaylistTree());
        Pane playlistTreePane = CreateDockingPane_(currentTree);
        currentView = addSubfomHelper_(new PlaylistView());
        configureMDIView_((BasicView)currentView, (BasicTree)currentTree);
        interlinkSelection_(currentTree, playlistTreePane, currentView);

        currentTree = addSubfomHelper_(new BusSchedulingTree());
        Pane busSchedulingTreePane = CreateDockingPane_(currentTree);
        currentView = addSubfomHelper_(new BusSchedulingView());
        configureMDIView_((BasicView)currentView, (BasicTree)currentTree);
        interlinkSelection_(currentTree, busSchedulingTreePane, currentView);

        currentTree = addSubfomHelper_(new FilesTree());
        Pane filesTreePane = CreateDockingPane_(currentTree);
        currentView = addSubfomHelper_(new FilesView());
        configureMDIView_((BasicView)currentView, (BasicTree)currentTree);
        interlinkSelection_(currentTree, filesTreePane, currentView);
        
        axDockingPane.AttachPane(playlistTreePane, hardwareTreePane);
        axDockingPane.AttachPane(busSchedulingTreePane, hardwareTreePane);
        axDockingPane.AttachPane(filesTreePane, hardwareTreePane);

        InitializeCommandBars();

      }
      catch (Exception ex)
      {

      }
    }

     /// <summary>
    /// Goes through all child controls and finds MDI client container
    /// </summary>
    /// <returns>MDIClient container</returns>
    MdiClient FindMDIClient()
    {
      for (int i = 0; i < this.Controls.Count; i = i + 1)
      {
        if (this.Controls[i] is MdiClient)
        {
          return (MdiClient)this.Controls[i];
        }
      }
      return null;
    }
    /// <summary>
    /// Initializes command bars, adds all comands menus etc
    /// </summary>
    private void InitializeCommandBars()
    {
      axCommandBars.SetMDIClient(FindMDIClient().Handle.ToInt32());
      axCommandBars.ShowTabWorkspace(true);
      axDockingPane.SetCommandBars(axCommandBars.GetDispatch());
    }

   
  }

   
}
