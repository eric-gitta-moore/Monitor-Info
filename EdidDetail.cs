// Decompiled with JetBrains decompiler
// Type: monitorinfo.EdidDetail
// Assembly: monitorinfo, Version=2.2.1.19629, Culture=neutral, PublicKeyToken=null
// MVID: DFCB46BD-326F-45DA-914E-ACAE15E31A1C
// Assembly location: C:\Users\admin\Downloads\图吧工具箱202502\tools\显示器工具\色域检测\monitorinfo.exe

using System.Text;

#nullable disable
namespace monitorinfo
{
  public class EdidDetail
  {
    public static EdidDetail Parse(byte[] data)
    {
      EdidDetail edidDetail = new EdidDetail();
      string str = Encoding.ASCII.GetString(data);
      edidDetail.Manufacturer = str.Substring(90, 17).Trim().Replace("\0", string.Empty).Replace("?", string.Empty);
      edidDetail.Model = str.Substring(108, 17).Trim().Replace("\0", string.Empty).Replace("?", string.Empty);
      int num1 = 54;
      int num2 = 4;
      int num3 = 15;
      int num4 = 15;
      edidDetail.HorizontalDisplaySize = ((int) data[num1 + 14] >> num2 & num3) << 8 | (int) data[num1 + 12];
      edidDetail.VerticalDisplaySize = ((int) data[num1 + 14] & num4) << 8 | (int) data[num1 + 13];
      edidDetail.HorizontalImageSize = (int) data[21];
      edidDetail.VerticalImageSize = (int) data[22];
      return edidDetail;
    }

    public string Manufacturer { get; private set; }

    public string Model { get; private set; }

    public int HorizontalDisplaySize { get; private set; }

    public int HorizontalImageSize { get; private set; }

    public int VerticalDisplaySize { get; private set; }

    public int VerticalImageSize { get; private set; }
  }
}
