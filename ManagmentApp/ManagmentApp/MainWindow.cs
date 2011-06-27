using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;

namespace ManagmentApp
{
  public partial class MainWindow : Form
  {
    static public AxXtremeSkinFramework.AxSkinFramework skinFramework;
    static public MainWindow This_ = null;
    string skinFolder;
    public XtremeCommandBars.StatusBar StatusBar;
   



    public MainWindow()
    {
      if (!Settings.Instance.Serialize("CCSettings.xml", false))
      {
        Settings.Instance.Serialize("CCSettings.xml", true);
      }
      registerXtremeSuiteComponents_();
      InitializeComponent();

      skinFramework = new AxXtremeSkinFramework.AxSkinFramework();
      skinFramework.BeginInit();
      this.Controls.Add(skinFramework);
      skinFramework.EndInit();
      //   Tracer.Instance.Trace(this, "Loading Skins");

      skinFolder = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\..\\Skins\\";

      bool res = skinFramework.LoadSkin(skinFolder + "Vista.cjstyles", "NormalBlack.ini");
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
  }
}
