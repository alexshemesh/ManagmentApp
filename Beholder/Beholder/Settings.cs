using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Beholder
{
  /// <summary>
  /// This class provides configuration information for whole application
  /// </summary>

  public class Settings
  {
    [XmlRoot("ControlCenter")]

    public class SettingsData
    {
      /// <summary>
      /// Address for Control center server, same as addres for signaling service , and db
      /// </summary>
      [XmlAttribute("ServerIP")]
      public String ServerIP_ = "192.168.1.10";
     
      /// <summary>
      /// folder to store log files.
      /// </summary>
      [XmlAttribute("LogsFolder")]

      public String Logs_ = "c:\\_TRACER_\\controlcenterlog";

      [XmlAttribute("DBName")]
      public String DBName_ = "StationDB1";
    }
    SettingsData data_ = new SettingsData();
    #region Properties
    public String ServerIP
    {
      get { return data_.ServerIP_; }
      set { data_.ServerIP_ = value; }
    }

   

    public String Logs
    {
      get { return data_.Logs_; }
      set { data_.Logs_ = value; }
    }

    public String DBName
    {
      get { return data_.DBName_; }
      set { data_.DBName_ = value; }
    }
    #endregion
    static private Settings This_ = null;

    static public Settings Instance
    {
      get
      {
        if (This_ == null)
        {
          This_ = new Settings();
        }
        return This_;
      }
    }


    /// <summary>
    /// Serializes settings
    /// </summary>
    /// <param name="FileName">FileName to save settings to</param>
    /// <param name="SaveLoad">true save, false load</param>
    /// <return>true of succesful, false otherwise</return>
    public bool Serialize(String FileName, bool SaveLoad)
    {
      XmlSerializer s = new XmlSerializer(typeof(SettingsData));

      if (SaveLoad)
      {
        TextWriter w = new StreamWriter(FileName);
        s.Serialize(w, data_);
        w.Close();
      }
      else
      {
        try
        {
          TextReader r = new StreamReader(FileName);
          data_ = (SettingsData)s.Deserialize(r);

          r.Close();
        }
        catch (FileNotFoundException)
        {
          return false;
        }
      }
      return true;


    }
    /// <summary>
    /// encrypt application configuration settings
    /// </summary>
    /// <returns>true on success, false otherwise</returns>
    private bool encrypt_()
    {

      Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
      string provider = "DataProtectionConfigurationProvider";
      //userSettings
      ConfigurationSectionGroup group = config.GetSectionGroup("userSettings");
      ConfigurationSection section = null;
      if (group != null)
      {
        section = group.Sections[0];
        section.SectionInformation.ProtectSection(provider);
      }

      //applicationSettings
      group = config.GetSectionGroup("applicationSettings");
      if (group != null)
      {
        section = group.Sections[0];
        section.SectionInformation.ProtectSection(provider);
      }

      section.SectionInformation.ForceSave = true;
      config.Save(ConfigurationSaveMode.Full);
      return true;
    }

    /// <summary>
    /// decrypts application settings
    /// </summary>
    /// <returns>true success false otherwise</returns>
    private bool decrypt_()
    {

      Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

      //userSettings
      ConfigurationSectionGroup group = config.GetSectionGroup("userSettings");
      ConfigurationSection section = null;
      if (group != null)
      {
        section = group.Sections[0];
        section.SectionInformation.UnprotectSection();
      }

      //applicationSettings
      group = config.GetSectionGroup("applicationSettings");
      if (group != null)
      {
        section = group.Sections[0];
        section.SectionInformation.UnprotectSection();
      }

      section.SectionInformation.ForceSave = true;
      config.Save(ConfigurationSaveMode.Full);
      return true;
    }


    public void ReadSettings()
    {
      decrypt_();
    }

    public void WriteSettings()
    {
      encrypt_();
    }
  }
}

