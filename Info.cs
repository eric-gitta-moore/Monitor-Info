// Decompiled with JetBrains decompiler
// Type: monitorinfo.Info
// Assembly: monitorinfo, Version=2.2.1.19629, Culture=neutral, PublicKeyToken=null
// MVID: DFCB46BD-326F-45DA-914E-ACAE15E31A1C
// Assembly location: C:\Users\admin\Downloads\图吧工具箱202502\tools\显示器工具\色域检测\monitorinfo.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

#nullable disable
namespace monitorinfo
{
  internal class Info : INotifyPropertyChanged
  {
    private string monitorDataString;
    private string edidVersion;
    private string productionDate;
    private string manufacturerName;
    private string physicalSize;
    private string ntscGamut;
    private string srgbGamut;
    private string axesRedX;
    private string axesRedY;
    private string axesGreenX;
    private string axesGreenY;
    private string axesBlueX;
    private string axesBlueY;
    private string axesWhiteX;
    private string axesWhiteY;
    private string colorFormat;
    private Dictionary<string, string> manufacturerNameDic = new Dictionary<string, string>();

    public Info() => this.ReadFromTxt();

    public string MonitorDataString
    {
      get => this.monitorDataString;
      set
      {
        this.monitorDataString = value;
        PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if (propertyChanged == null)
          return;
        propertyChanged((object) this, new PropertyChangedEventArgs(nameof (MonitorDataString)));
      }
    }

    public string EDIDVersion
    {
      get => this.edidVersion;
      set
      {
        this.edidVersion = value;
        PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if (propertyChanged == null)
          return;
        propertyChanged((object) this, new PropertyChangedEventArgs(nameof (EDIDVersion)));
      }
    }

    public string ProductionDate
    {
      get => this.productionDate;
      set
      {
        this.productionDate = value;
        PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if (propertyChanged == null)
          return;
        propertyChanged((object) this, new PropertyChangedEventArgs(nameof (ProductionDate)));
      }
    }

    public string ManufacturerName
    {
      get => this.manufacturerName;
      set
      {
        this.manufacturerName = value;
        PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if (propertyChanged == null)
          return;
        propertyChanged((object) this, new PropertyChangedEventArgs(nameof (ManufacturerName)));
      }
    }

    public string PhysicalSize
    {
      get => this.physicalSize;
      set
      {
        this.physicalSize = value;
        PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if (propertyChanged == null)
          return;
        propertyChanged((object) this, new PropertyChangedEventArgs(nameof (PhysicalSize)));
      }
    }

    public string NTSCGamut
    {
      get => this.ntscGamut;
      set
      {
        this.ntscGamut = value;
        PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if (propertyChanged == null)
          return;
        propertyChanged((object) this, new PropertyChangedEventArgs("ColorGamut"));
      }
    }

    public string SRGBGamut
    {
      get => this.srgbGamut;
      set
      {
        this.srgbGamut = value;
        PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if (propertyChanged == null)
          return;
        propertyChanged((object) this, new PropertyChangedEventArgs("ColorGamut"));
      }
    }

    public string AxesRedX
    {
      get => this.axesRedX;
      set
      {
        this.axesRedX = value;
        PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if (propertyChanged == null)
          return;
        propertyChanged((object) this, new PropertyChangedEventArgs(nameof (AxesRedX)));
      }
    }

    public string AxesRedY
    {
      get => this.axesRedY;
      set
      {
        this.axesRedY = value;
        PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if (propertyChanged == null)
          return;
        propertyChanged((object) this, new PropertyChangedEventArgs(nameof (AxesRedY)));
      }
    }

    public string AxesGreenX
    {
      get => this.axesGreenX;
      set
      {
        this.axesGreenX = value;
        PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if (propertyChanged == null)
          return;
        propertyChanged((object) this, new PropertyChangedEventArgs(nameof (AxesGreenX)));
      }
    }

    public string AxesGreenY
    {
      get => this.axesGreenY;
      set
      {
        this.axesGreenY = value;
        PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if (propertyChanged == null)
          return;
        propertyChanged((object) this, new PropertyChangedEventArgs("axesGreenY"));
      }
    }

    public string AxesBlueX
    {
      get => this.axesBlueX;
      set
      {
        this.axesBlueX = value;
        PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if (propertyChanged == null)
          return;
        propertyChanged((object) this, new PropertyChangedEventArgs(nameof (AxesBlueX)));
      }
    }

    public string AxesBlueY
    {
      get => this.axesBlueY;
      set
      {
        this.axesBlueY = value;
        PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if (propertyChanged == null)
          return;
        propertyChanged((object) this, new PropertyChangedEventArgs(nameof (AxesBlueY)));
      }
    }

    public string AxesWhiteX
    {
      get => this.axesWhiteX;
      set
      {
        this.axesWhiteX = value;
        PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if (propertyChanged == null)
          return;
        propertyChanged((object) this, new PropertyChangedEventArgs(nameof (AxesWhiteX)));
      }
    }

    public string AxesWhiteY
    {
      get => this.axesWhiteY;
      set
      {
        this.axesWhiteY = value;
        PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if (propertyChanged == null)
          return;
        propertyChanged((object) this, new PropertyChangedEventArgs(nameof (AxesWhiteY)));
      }
    }

    public string ColorFormat
    {
      get => this.colorFormat;
      set
      {
        this.colorFormat = value;
        PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if (propertyChanged == null)
          return;
        propertyChanged((object) this, new PropertyChangedEventArgs(nameof (ColorFormat)));
      }
    }

    public void GetInfo(byte[] monitorEDID)
    {
      this.MonitorDataString = this.GetMonitorDataString(monitorEDID);
      this.EDIDVersion = "v" + monitorEDID[18].ToString() + "." + monitorEDID[19].ToString();
      this.ProductionDate = ((int) monitorEDID[17] + 1990).ToString() + "年" + (monitorEDID[16] != (byte) 0 ? "(第" + monitorEDID[16].ToString() + "周)" : "");
      this.ManufacturerName = this.GetMonitorManufacturerName(monitorEDID);
      this.PhysicalSize = this.GetMonitorPhysicalSize(monitorEDID);
      this.ColorFormat = this.GetColorFormat(monitorEDID);
      string[] monitorColorInfo = this.GetMonitorColorInfo(monitorEDID);
      this.AxesRedX = monitorColorInfo[0];
      this.AxesRedY = monitorColorInfo[1];
      this.AxesGreenX = monitorColorInfo[2];
      this.AxesGreenY = monitorColorInfo[3];
      this.AxesBlueX = monitorColorInfo[4];
      this.AxesBlueY = monitorColorInfo[5];
      this.AxesWhiteX = monitorColorInfo[6];
      this.AxesWhiteY = monitorColorInfo[7];
      this.NTSCGamut = monitorColorInfo[8];
      this.SRGBGamut = monitorColorInfo[9];
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private string GetMonitorDataString(byte[] monitorEDID)
    {
      string monitorDataString;
      if (monitorEDID[111] == (byte) 254)
      {
        byte[] numArray = new byte[13];
        Array.Copy((Array) monitorEDID, 113, (Array) numArray, 0, 13);
        monitorDataString = Encoding.ASCII.GetString(numArray);
      }
      else
        monitorDataString = this.GetMonitorManufacturerID(monitorEDID) + Convert.ToString(monitorEDID[11], 16) + Convert.ToString(monitorEDID[10], 16);
      return monitorDataString;
    }

    private string GetMonitorManufacturerID(byte[] monitorEDID)
    {
      return Encoding.ASCII.GetString(new byte[3]
      {
        (byte) ((((int) monitorEDID[8] & 124) >> 2) + 64),
        (byte) ((((int) monitorEDID[8] & 3) << 3) + (((int) monitorEDID[9] & 224) >> 5) + 64),
        (byte) (((int) monitorEDID[9] & 31) + 64)
      });
    }

    private void ReadFromTxt()
    {
      StreamReader streamReader = new StreamReader(Application.GetResourceStream(new Uri("/Resources/MonitorManufacturerID.txt", UriKind.Relative)).Stream, Encoding.Default);
      string str;
      while ((str = streamReader.ReadLine()) != null)
      {
        string[] strArray = str.ToString().Split(',');
        this.manufacturerNameDic.Add(strArray[0], strArray[1]);
      }
    }

    private string GetMonitorManufacturerName(byte[] monitorEDID)
    {
      string monitorManufacturerId = this.GetMonitorManufacturerID(monitorEDID);
      return this.manufacturerNameDic.Keys.Contains<string>(monitorManufacturerId) ? this.manufacturerNameDic[monitorManufacturerId] : monitorManufacturerId;
    }

    private string GetMonitorPhysicalSize(byte[] monitorEDID)
    {
      return (Math.Sqrt(Math.Pow((double) monitorEDID[21], 2.0) + Math.Pow((double) monitorEDID[22], 2.0)) / 2.54).ToString("0.0") + "英寸";
    }

    private string GetColorFormat(byte[] monitorEDID)
    {
      if (((int) monitorEDID[20] & 128) == 0)
      {
        string str;
        switch ((int) monitorEDID[24] & 48)
        {
          case 0:
            str = "(黑白/灰度)";
            break;
          case 8:
            str = "(RGB)";
            break;
          case 16:
            str = "(非RGB)";
            break;
          default:
            str = "";
            break;
        }
        return "模拟信号 " + str;
      }
      string str1;
      switch ((int) monitorEDID[20] & 112)
      {
        case 16:
          str1 = "6Bits";
          break;
        case 32:
          str1 = "8Bits";
          break;
        case 48:
          str1 = "10Bits";
          break;
        case 64:
          str1 = "12Bits";
          break;
        case 80:
          str1 = "14Bits";
          break;
        case 96:
          str1 = "16Bits";
          break;
        default:
          str1 = "";
          break;
      }
      return (((int) monitorEDID[24] & 48) != 0 ? "RGB/YCrCb " : "RGB ") + str1;
    }

    private string[] GetMonitorColorInfo(byte[] monitorEDID)
    {
      double num1 = (double) (4 * (int) monitorEDID[27] + ((int) monitorEDID[25] & 3)) / 1023.0;
      double num2 = (double) (4 * (int) monitorEDID[28] + ((int) monitorEDID[25] & 3)) / 1023.0;
      double num3 = (double) (4 * (int) monitorEDID[29] + ((int) monitorEDID[25] & 3)) / 1023.0;
      double num4 = (double) (4 * (int) monitorEDID[30] + ((int) monitorEDID[25] & 3)) / 1023.0;
      double num5 = (double) (4 * (int) monitorEDID[31] + ((int) monitorEDID[26] & 3)) / 1023.0;
      double num6 = (double) (4 * (int) monitorEDID[32] + ((int) monitorEDID[26] & 3)) / 1023.0;
      double num7 = (double) (4 * (int) monitorEDID[33] + ((int) monitorEDID[26] & 3)) / 1023.0;
      double num8 = (double) (4 * (int) monitorEDID[34] + ((int) monitorEDID[26] & 3)) / 1023.0;
      double[] numArray = new double[8]
      {
        num1,
        num2,
        num3,
        num4,
        num5,
        num6,
        num7,
        num8
      };
      string str1 = (Math.Abs(numArray[0] * numArray[3] + numArray[2] * numArray[5] + numArray[4] * numArray[1] - numArray[0] * numArray[5] - numArray[2] * numArray[1] - numArray[4] * numArray[3]) / 2.0 / 0.1582).ToString("P") + " NTSC";
      string str2 = (Math.Abs(numArray[0] * numArray[3] + numArray[2] * numArray[5] + numArray[4] * numArray[1] - numArray[0] * numArray[5] - numArray[2] * numArray[1] - numArray[4] * numArray[3]) / 2.0 / 0.1582 / 0.72).ToString("P") + " sRGB";
      return new string[10]
      {
        num1.ToString("0.000"),
        num2.ToString("0.000"),
        num3.ToString("0.000"),
        num4.ToString("0.000"),
        num5.ToString("0.000"),
        num6.ToString("0.000"),
        num7.ToString("0.000"),
        num8.ToString("0.000"),
        str1,
        str2
      };
    }
  }
}
