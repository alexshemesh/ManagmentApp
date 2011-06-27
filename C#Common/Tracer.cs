using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace Common
{
    public abstract class ITracer
    {
        /// <summary>
        /// Insert trace record to log 
        /// </summary>
        /// <param name="Component">Component that post the message</param>
        /// <param name="Message">Log message</param>
        public abstract void Trace(Object Component, String Message);
        /// <summary>
        /// Insert trace record to log
        /// </summary>
        /// <param name="Component">Component that post the message</param>
        /// <param name="Format">Format of the message</param>
        /// <param name="Par">arguments of message</param>
        public abstract void Trace(Object Component, String Format, Object[] Par);      
    }

    class TracerFile : ITracer
    {
      /// <summary>
      /// File name that was passed to Initialize function
      /// </summary>
      private String OriginalFileName_;
      /// <summary>
      /// Current file name
      /// </summary>
      private String FileName_="";
      /// <summary>
      /// MaxLen of file in bytes.0 Means unlimited
      /// </summary>
      private int MaxLen_;
      /// <summary>
      /// Number of hours to include in single log.0 - means unlimited
      /// </summary>
      private int HoursInterval_;
      /// <summary>
      /// In case MaxLen_ or HoursInterval_ reached, tracer will create new file or flush old one and start over
      /// </summary>
      private bool RolloverOrMoveToNext_;
      /// <summary>
      /// In case RolloverOrMoveToNext_ is true this order number of log file part.
      /// </summary>
      private int FileNumber_=0;
      /// <summary>
      /// Current file creation time
      /// </summary>
      private DateTime FileCreationTime_;
      /// <summary>
      /// Basicaly time when Initialize function was called last time
      /// </summary>
      private DateTime OriginalFileCreationTime_;
      /// <summary>
      /// Number of bytes writen to file
      /// </summary>
      private Int64 NumOfBytesInFile_ = 0;
      /// <summary>
      /// Initializes object
      /// </summary>
      /// <param name="FileName">Full path to log file, folder should exist otherwise log will not be created</param>
      /// <param name="MaxLen">Maximum lenght of log file in megabytes. 0-unlimited</param>
      /// <param name="HoursInterval">Number of hours to log</param>
      /// <param name="RolloverOrMoveToNext">In case MaxLen or HoursInterval limit reached. True if tracer should trunctae current file, False if Tracer should create new log file </param>
      public void Initialize(String FileName, int MaxLen, int HoursInterval, bool RolloverOrMoveToNext)
      {
          OriginalFileCreationTime_ = DateTime.Now;
          OriginalFileName_ = FileName;
          MaxLen_ = MaxLen;
          HoursInterval_ = HoursInterval;
          RolloverOrMoveToNext_ = RolloverOrMoveToNext;
          CreateFile(FileName);
          Trace(this,Assembly.GetExecutingAssembly().FullName);
      }
      /// <summary>
      /// Delegate for asynchornous trace call. Used by Trace function
      /// </summary>
      /// <param name="Message">Trace message</param>
      private delegate void TraceDelegate(String Message);
      /// <summary>
      /// This callback function will be called by sytsem when asynchornous message append is complete , it will simply call EndInvoke
      /// </summary>
      /// <param name="ar"></param>
      public void FireEventCallback(IAsyncResult ar)
      {
          // Because you passed your original delegate in the asyncState parameter
          // of the Begin call, you can get it back here to complete the call.
          TraceDelegate dlgt = (TraceDelegate)ar.AsyncState;
          // Complete the call.
          dlgt.EndInvoke(ar);
      }

      

      public override void Trace(Object Component, String Message)
      {
      
          String MessageToAdd = String.Format("[{0}\t] {1} ",Component.GetType().Name, Message);
          TraceDelegate dlgt = new TraceDelegate(Trace);

          AsyncCallback ac = new AsyncCallback(FireEventCallback);

          dlgt.BeginInvoke(MessageToAdd, ac, dlgt);

      }

      public override void Trace(Object Component, String Format, Object[] Par)
      {
          String Message = String.Format(Format, Par);
          Trace(Component, Message);
      }

      /// <summary>
      /// Appends line to the end of log file
      /// </summary>
      /// <param name="Message">message to put to log file</param>
      private void Trace(String Message)
      {
          lock (FileName_)
          {
              String CurrentTimePlusMessage = DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString() + " " + Message;
              Console.WriteLine(CurrentTimePlusMessage);
              try
              {
                StreamWriter tw = File.AppendText(FileName_);

                tw.WriteLine(CurrentTimePlusMessage);

                NumOfBytesInFile_ = NumOfBytesInFile_ + CurrentTimePlusMessage.Length + 2;
                tw.Close();
              }
              catch (System.Exception )
              {
                if (_CheckFile())
                {
                  StreamWriter tw = File.AppendText(FileName_);

                  tw.WriteLine(CurrentTimePlusMessage);

                  NumOfBytesInFile_ = NumOfBytesInFile_ + CurrentTimePlusMessage.Length + 2;
                  tw.Close();
                }
                else
                  Console.WriteLine("Cant write to log file " + FileName_ + ".File does not exist.");
              }
          }
      }

      /// <summary>
      /// Checks if file exist,and not reached limits of MaxLen or Hours, recreates file if needed
      /// </summary>
      /// <returns>True if file is ok, false if file cant be found</returns>
      private bool _CheckFile()
      {
          if(!File.Exists(FileName_))
              return false;
          TimeSpan span = DateTime.Now.Subtract ( FileCreationTime_ );
          bool ReCreateFile = false;
          if (HoursInterval_ != 0 && span.Hours >= HoursInterval_)
              ReCreateFile = true;
          //MaxLen_ is in megabytes
          if (MaxLen_ != 0 && NumOfBytesInFile_/(1024*1024) >= MaxLen_)
              ReCreateFile = true;

          if (ReCreateFile)
          {
              //if we increase FileNumber_ counter, CreateFile will create new file and will not truncate old file
              if (!RolloverOrMoveToNext_)
                  FileNumber_++;
              CreateFile(OriginalFileName_);
          }
          return true;
      }
      /// <summary>
      /// Creates file
      /// </summary>
      /// <param name="FileName"></param>
      private void CreateFile(String FileName)
      {
        lock (FileName_)
        {
          try
          {
            FileCreationTime_ = DateTime.Now;
            NumOfBytesInFile_ = 0;
            FileName_ = String.Format("{0}_{1}-{2}-{3} {4}_{5}_{6}({7}).txt",
                                    FileName,
                                    OriginalFileCreationTime_.Year,
                                    OriginalFileCreationTime_.Month,
                                    OriginalFileCreationTime_.Day,
                                    OriginalFileCreationTime_.Hour,
                                    OriginalFileCreationTime_.Minute,
                                    OriginalFileCreationTime_.Second,
                                    FileNumber_);
            FileStream fs = File.Create(FileName_);
            fs.Close();
          }
          catch (System.Exception )
          {
          }             
        }
      }

    }

    public class Tracer
    {
        private static ITracer Tracer_ = null;
        /// <summary>
        /// helper function , simply redirects call to Instance interface
        /// </summary>
        /// <param name="Component"></param>
        /// <param name="Message"></param>
        public static void Trace(Object Component, String Message)
        {
          Instance.Trace(Component, Message);
        }
        /// <summary>
        /// helper function , simply redirects call to Instance interface
        /// </summary>
        /// <param name="Component"></param>
        /// <param name="Format"></param>
        /// <param name="Par"></param>
        public static void Trace(Object Component, String Format, Object[] Par)
        {
          Instance.Trace(Component, Format, Par);
        }

        public static ITracer Instance
        {
          get
          {
            if (Tracer_ == null)
                Tracer_ = new TracerFile();
            return Tracer_;
          }
        }
    }


}
