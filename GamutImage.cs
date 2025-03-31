// Decompiled with JetBrains decompiler
// Type: monitorinfo.GamutImage
// Assembly: monitorinfo, Version=2.2.1.19629, Culture=neutral, PublicKeyToken=null
// MVID: DFCB46BD-326F-45DA-914E-ACAE15E31A1C
// Assembly location: C:\Users\admin\Downloads\图吧工具箱202502\tools\显示器工具\色域检测\monitorinfo.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

#nullable disable
namespace monitorinfo
{
  internal class GamutImage : INotifyPropertyChanged
  {
    private BitmapImage imgGamut;
    private Bitmap img_RGB;
    private int RGB_DATA_ARR_LEN = 800;

    public BitmapImage ImgGamut
    {
      get => this.imgGamut;
      set
      {
        this.imgGamut = value;
        PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if (propertyChanged == null)
          return;
        propertyChanged((object) this, new PropertyChangedEventArgs(nameof (ImgGamut)));
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void DrawTongueDiagram(Info info, ColorSpace colorSpace, GamutImgSize gamutImgSize)
    {
      double[,] numArray1 = new double[this.RGB_DATA_ARR_LEN, this.RGB_DATA_ARR_LEN];
      double[,] numArray2 = new double[this.RGB_DATA_ARR_LEN, this.RGB_DATA_ARR_LEN];
      double[,] numArray3 = new double[this.RGB_DATA_ARR_LEN, this.RGB_DATA_ARR_LEN];
      Color color1 = Color.FromArgb(0, 0, 0);
      Pen pen1 = new Pen(Color.FromArgb(0, 0, 0));
      int num1 = 10;
      int num2 = 10;
      int x1 = 30;
      int num3 = 0;
      int num4 = 0;
      int num5 = 30;
      double num6 = 0.0;
      double num7 = 1.0;
      double num8 = 0.0;
      double num9 = 1.0;
      Font font1 = new Font("Serif", 9f);
      Font font2 = new Font("Serif", 7f);
      double num10 = Math.Min(gamutImgSize.GamutImgWidth - (double) x1 - (double) num3, gamutImgSize.GamutImgHeight - (double) num4 - (double) num5);
      double num11 = Math.Min(gamutImgSize.GamutImgWidth - (double) x1 - (double) num3, gamutImgSize.GamutImgHeight - (double) num4 - (double) num5) / (double) this.RGB_DATA_ARR_LEN;
      this.img_RGB = new Bitmap((int) num10 + x1 + num3 + 1, (int) num10 + num4 + num5 + 1);
      Graphics graphics = Graphics.FromImage((Image) this.img_RGB);
      graphics.Clear(Color.White);
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      Font font3 = font1;
      for (int index1 = 0; index1 < this.RGB_DATA_ARR_LEN; ++index1)
      {
        for (int index2 = 0; index2 < this.RGB_DATA_ARR_LEN; ++index2)
        {
          double xc = (double) index1 / (double) this.RGB_DATA_ARR_LEN;
          double yc = (double) index2 / (double) this.RGB_DATA_ARR_LEN;
          double zc = 1.0 - xc - yc;
          colorSpace.xyz_to_rgb(xc, yc, zc, ref numArray1.Address(index1, index2), ref numArray2.Address(index1, index2), ref numArray3.Address(index1, index2));
          if (colorSpace.constrain_rgb(ref numArray1.Address(index1, index2), ref numArray2.Address(index1, index2), ref numArray3.Address(index1, index2)) == 1)
            colorSpace.norm_rgb(ref numArray1.Address(index1, index2), ref numArray2.Address(index1, index2), ref numArray3.Address(index1, index2));
          else
            colorSpace.norm_rgb(ref numArray1.Address(index1, index2), ref numArray2.Address(index1, index2), ref numArray3.Address(index1, index2));
          int int32_1 = Convert.ToInt32(numArray1[index1, index2] * (double) byte.MaxValue);
          int int32_2 = Convert.ToInt32(numArray2[index1, index2] * (double) byte.MaxValue);
          int int32_3 = Convert.ToInt32(numArray3[index1, index2] * (double) byte.MaxValue);
          if (int32_1 >= 0 && int32_1 < 256 && int32_2 >= 0 && int32_2 < 256 && int32_3 >= 0 && int32_3 < 256)
          {
            Color color2 = Color.FromArgb(int32_1, int32_2, int32_3);
            int x = x1 + (int) ((double) index1 * num11);
            int y = (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - (int) ((double) index2 * num11);
            if (x < this.img_RGB.Width && y < this.img_RGB.Height)
              this.img_RGB.SetPixel(x, y, color2);
          }
          else
          {
            int num12 = (int) MessageBox.Show("Incorrect RGB");
          }
        }
      }
      color1 = Color.FromArgb(0, 0, 0);
      GraphicsPath path = new GraphicsPath();
      Region region = new Region();
      path.Reset();
      pen1.Color = Color.White;
      System.Drawing.Point[] points = new System.Drawing.Point[81];
      for (int index = 0; index < 81; ++index)
        points[index] = new System.Drawing.Point(x1 + (int) (colorSpace.spectral_chromaticity[index, 0] * (double) this.RGB_DATA_ARR_LEN * num11), (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight - (double) num5 - (double) num4) - (int) (colorSpace.spectral_chromaticity[index, 1] * (double) this.RGB_DATA_ARR_LEN * num11));
      pen1.Color = Color.Blue;
      graphics.DrawPolygon(pen1, points);
      path.AddPolygon(points);
      region.MakeEmpty();
      region.Union(path);
      graphics.ExcludeClip(region);
      SolidBrush solidBrush = new SolidBrush(Color.White);
      graphics.FillRectangle((Brush) solidBrush, new Rectangle(0, (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - num4 - (int) num10, (int) num10 + x1 + num3, (int) num10 + num5 + num4));
      graphics.ResetClip();
      Pen pen2 = new Pen(Color.Gray, 1f);
      double num13 = num7 - num6;
      double num14 = num9 - num8;
      pen2.EndCap = LineCap.Flat;
      int num15 = 0;
      SizeF sizeF;
      PointF point;
      for (int index = 0; index <= num1; ++index)
      {
        pen2.DashStyle = index != 0 ? DashStyle.Dash : DashStyle.Solid;
        string str = (num6 + num13 * (double) index / (double) num1).ToString("f1");
        int num16 = (int) num10 * index / num1;
        sizeF = graphics.MeasureString(str, font3);
        graphics.DrawLine(pen2, x1 + num16, (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5, x1 + num16, (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - (int) num10);
        point = new PointF((float) (x1 + num16) - sizeF.Width / 2f, (float) ((int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5));
        graphics.DrawString(str, font3, Brushes.Gray, point);
      }
      for (int index = 0; index <= num2; ++index)
      {
        pen2.DashStyle = index != 0 ? DashStyle.Dash : DashStyle.Solid;
        string str = (num8 + num14 * (double) index / (double) num2).ToString("f1");
        int num17 = (int) num10 * index / num2;
        sizeF = graphics.MeasureString(str, font3);
        graphics.DrawLine(pen2, x1, (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - num17, x1 + (int) num10 + num15, (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - num17);
        point = new PointF((float) x1 - sizeF.Width, (float) ((int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - num17) - sizeF.Height / 2f);
        graphics.DrawString(str, font3, Brushes.Gray, point);
      }
      pen2.Color = Color.White;
      for (int index = 0; index < 81; ++index)
      {
        if (index >= 16 && index <= 50)
          ;
      }
      pen2.Color = Color.White;
      pen2.DashStyle = DashStyle.Solid;
      pen2.Width = 2f;
      graphics.DrawLine(pen2, (int) Convert.ToInt16((double) x1 + 0.67 * num10), (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - (int) Convert.ToInt16(0.33 * num10), (int) Convert.ToInt16((double) x1 + 0.21 * num10), (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - (int) Convert.ToInt16(0.71 * num10));
      graphics.DrawLine(pen2, (int) Convert.ToInt16((double) x1 + 0.67 * num10), (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - (int) Convert.ToInt16(0.33 * num10), (int) Convert.ToInt16((double) x1 + 0.14 * num10), (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - (int) Convert.ToInt16(0.08 * num10));
      graphics.DrawLine(pen2, (int) Convert.ToInt16((double) x1 + 0.21 * num10), (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - (int) Convert.ToInt16(0.71 * num10), (int) Convert.ToInt16((double) x1 + 0.14 * num10), (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - (int) Convert.ToInt16(0.08 * num10));
      pen2.Color = Color.Purple;
      pen2.DashStyle = DashStyle.Dot;
      graphics.DrawLine(pen2, (int) Convert.ToInt16((double) x1 + 0.64 * num10), (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - (int) Convert.ToInt16(0.33 * num10), (int) Convert.ToInt16((double) x1 + 0.3 * num10), (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - (int) Convert.ToInt16(0.6 * num10));
      graphics.DrawLine(pen2, (int) Convert.ToInt16((double) x1 + 0.64 * num10), (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - (int) Convert.ToInt16(0.33 * num10), (int) Convert.ToInt16((double) x1 + 0.15 * num10), (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - (int) Convert.ToInt16(0.06 * num10));
      graphics.DrawLine(pen2, (int) Convert.ToInt16((double) x1 + 0.3 * num10), (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - (int) Convert.ToInt16(0.6 * num10), (int) Convert.ToInt16((double) x1 + 0.15 * num10), (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - (int) Convert.ToInt16(0.06 * num10));
      pen2.Color = Color.Black;
      pen2.DashStyle = DashStyle.Dash;
      graphics.DrawLine(pen2, (int) Convert.ToInt16((double) x1 + Convert.ToDouble(info.AxesRedX) * num10), (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - (int) Convert.ToInt16(Convert.ToDouble(info.AxesRedY) * num10), (int) Convert.ToInt16((double) x1 + Convert.ToDouble(info.AxesBlueX) * num10), (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - (int) Convert.ToInt16(Convert.ToDouble(info.AxesBlueY) * num10));
      graphics.DrawLine(pen2, (int) Convert.ToInt16((double) x1 + Convert.ToDouble(info.AxesRedX) * num10), (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - (int) Convert.ToInt16(Convert.ToDouble(info.AxesRedY) * num10), (int) Convert.ToInt16((double) x1 + Convert.ToDouble(info.AxesGreenX) * num10), (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - (int) Convert.ToInt16(Convert.ToDouble(info.AxesGreenY) * num10));
      graphics.DrawLine(pen2, (int) Convert.ToInt16((double) x1 + Convert.ToDouble(info.AxesBlueX) * num10), (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - (int) Convert.ToInt16(Convert.ToDouble(info.AxesBlueY) * num10), (int) Convert.ToInt16((double) x1 + Convert.ToDouble(info.AxesGreenX) * num10), (int) Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num5 - (int) Convert.ToInt16(Convert.ToDouble(info.AxesGreenY) * num10));
      graphics.DrawImage((Image) this.img_RGB, 0, (int) Convert.ToInt16(gamutImgSize.GamutImgBottom));
      this.ImgGamut = this.BitmapToBitmapImage(this.img_RGB);
      pen2.Dispose();
      graphics.Dispose();
    }

    private BitmapImage BitmapToBitmapImage(Bitmap bitmap)
    {
      MemoryStream memoryStream = new MemoryStream();
      bitmap.Save((Stream) memoryStream, ImageFormat.Png);
      BitmapImage bitmapImage = new BitmapImage();
      bitmapImage.BeginInit();
      bitmapImage.StreamSource = (Stream) memoryStream;
      bitmapImage.EndInit();
      return bitmapImage;
    }

    public enum RGB_DATA_PIXELS
    {
      NUM300 = 300, // 0x0000012C
      NUM600 = 600, // 0x00000258
      NUM800 = 800, // 0x00000320
    }
  }
}
