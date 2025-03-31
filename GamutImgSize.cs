// Decompiled with JetBrains decompiler
// Type: monitorinfo.GamutImgSize
// Assembly: monitorinfo, Version=2.2.1.19629, Culture=neutral, PublicKeyToken=null
// MVID: DFCB46BD-326F-45DA-914E-ACAE15E31A1C
// Assembly location: C:\Users\admin\Downloads\图吧工具箱202502\tools\显示器工具\色域检测\monitorinfo.exe

#nullable disable
namespace monitorinfo
{
  internal class GamutImgSize
  {
    private double gamutImgWidth;
    private double gamutImgHeight;
    private double gamutImgBottom;

    public double GamutImgWidth
    {
      get => this.gamutImgWidth;
      set => this.gamutImgWidth = value;
    }

    public double GamutImgHeight
    {
      get => this.gamutImgHeight;
      set => this.gamutImgHeight = value;
    }

    public double GamutImgBottom
    {
      get => this.gamutImgBottom;
      set => this.gamutImgBottom = value;
    }
  }
}
