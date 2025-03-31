using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace monitorinfo
{
	// Token: 0x02000007 RID: 7
	internal class GamutImage : INotifyPropertyChanged
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00004312 File Offset: 0x00002512
		// (set) Token: 0x0600002D RID: 45 RVA: 0x0000431A File Offset: 0x0000251A
		public BitmapImage ImgGamut
		{
			get
			{
				return this.imgGamut;
			}
			set
			{
				this.imgGamut = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("ImgGamut"));
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600002E RID: 46 RVA: 0x00004340 File Offset: 0x00002540
		// (remove) Token: 0x0600002F RID: 47 RVA: 0x00004378 File Offset: 0x00002578
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x06000030 RID: 48 RVA: 0x000043B0 File Offset: 0x000025B0
		public void DrawTongueDiagram(Info info, ColorSpace colorSpace, GamutImgSize gamutImgSize)
		{
			double[,] array = new double[this.RGB_DATA_ARR_LEN, this.RGB_DATA_ARR_LEN];
			double[,] array2 = new double[this.RGB_DATA_ARR_LEN, this.RGB_DATA_ARR_LEN];
			double[,] array3 = new double[this.RGB_DATA_ARR_LEN, this.RGB_DATA_ARR_LEN];
			Color color = Color.FromArgb(0, 0, 0);
			Pen pen = new Pen(Color.FromArgb(0, 0, 0));
			int num = 10;
			int num2 = 10;
			int num3 = 30;
			int num4 = 0;
			int num5 = 0;
			int num6 = 30;
			double num7 = 0.0;
			double num8 = 1.0;
			double num9 = 0.0;
			double num10 = 1.0;
			Font font = new Font("Serif", 9f);
			new Font("Serif", 7f);
			double num11 = Math.Min(gamutImgSize.GamutImgWidth - (double)num3 - (double)num4, gamutImgSize.GamutImgHeight - (double)num5 - (double)num6);
			double num12 = Math.Min(gamutImgSize.GamutImgWidth - (double)num3 - (double)num4, gamutImgSize.GamutImgHeight - (double)num5 - (double)num6) / (double)this.RGB_DATA_ARR_LEN;
			this.img_RGB = new Bitmap((int)num11 + num3 + num4 + 1, (int)num11 + num5 + num6 + 1);
			Graphics graphics = Graphics.FromImage(this.img_RGB);
			graphics.Clear(Color.White);
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			Font font2 = font;
			for (int i = 0; i < this.RGB_DATA_ARR_LEN; i++)
			{
				for (int j = 0; j < this.RGB_DATA_ARR_LEN; j++)
				{
					double num13 = (double)i / (double)this.RGB_DATA_ARR_LEN;
					double num14 = (double)j / (double)this.RGB_DATA_ARR_LEN;
					double zc = 1.0 - num13 - num14;
					colorSpace.xyz_to_rgb(num13, num14, zc, ref array[i, j], ref array2[i, j], ref array3[i, j]);
					if (colorSpace.constrain_rgb(ref array[i, j], ref array2[i, j], ref array3[i, j]) == 1)
					{
						colorSpace.norm_rgb(ref array[i, j], ref array2[i, j], ref array3[i, j]);
					}
					else
					{
						colorSpace.norm_rgb(ref array[i, j], ref array2[i, j], ref array3[i, j]);
					}
					int num15 = Convert.ToInt32(array[i, j] * 255.0);
					int num16 = Convert.ToInt32(array2[i, j] * 255.0);
					int num17 = Convert.ToInt32(array3[i, j] * 255.0);
					if (num15 >= 0 && num15 < 256 && num16 >= 0 && num16 < 256 && num17 >= 0 && num17 < 256)
					{
						color = Color.FromArgb(num15, num16, num17);
						int num18 = num3 + (int)((double)i * num12);
						int num19 = (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - (int)((double)j * num12);
						if (num18 < this.img_RGB.Width && num19 < this.img_RGB.Height)
						{
							this.img_RGB.SetPixel(num18, num19, color);
						}
					}
					else
					{
						MessageBox.Show("Incorrect RGB");
					}
				}
			}
			color = Color.FromArgb(0, 0, 0);
			GraphicsPath graphicsPath = new GraphicsPath();
			Region region = new Region();
			graphicsPath.Reset();
			pen.Color = Color.White;
			System.Drawing.Point[] array4 = new System.Drawing.Point[81];
			for (int i = 0; i < 81; i++)
			{
				array4[i] = new System.Drawing.Point(num3 + (int)(colorSpace.spectral_chromaticity[i, 0] * (double)this.RGB_DATA_ARR_LEN * num12), (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight - (double)num6 - (double)num5) - (int)(colorSpace.spectral_chromaticity[i, 1] * (double)this.RGB_DATA_ARR_LEN * num12));
			}
			pen.Color = Color.Blue;
			graphics.DrawPolygon(pen, array4);
			graphicsPath.AddPolygon(array4);
			region.MakeEmpty();
			region.Union(graphicsPath);
			graphics.ExcludeClip(region);
			SolidBrush brush = new SolidBrush(Color.White);
			graphics.FillRectangle(brush, new Rectangle(0, (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - num5 - (int)num11, (int)num11 + num3 + num4, (int)num11 + num6 + num5));
			graphics.ResetClip();
			pen = new Pen(Color.Gray, 1f);
			double num20 = num8 - num7;
			double num21 = num10 - num9;
			pen.EndCap = LineCap.Flat;
			int num22 = 0;
			for (int i = 0; i <= num; i++)
			{
				if (i == 0)
				{
					pen.DashStyle = DashStyle.Solid;
				}
				else
				{
					pen.DashStyle = DashStyle.Dash;
				}
				string text = (num7 + num20 * (double)i / (double)num).ToString("f1");
				int num23 = (int)num11 * i / num;
				SizeF sizeF = graphics.MeasureString(text, font2);
				graphics.DrawLine(pen, num3 + num23, (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6, num3 + num23, (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - (int)num11);
				PointF point = new PointF((float)(num3 + num23) - sizeF.Width / 2f, (float)((int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6));
				graphics.DrawString(text, font2, Brushes.Gray, point);
			}
			for (int i = 0; i <= num2; i++)
			{
				if (i == 0)
				{
					pen.DashStyle = DashStyle.Solid;
				}
				else
				{
					pen.DashStyle = DashStyle.Dash;
				}
				string text = (num9 + num21 * (double)i / (double)num2).ToString("f1");
				int num23 = (int)num11 * i / num2;
				SizeF sizeF = graphics.MeasureString(text, font2);
				graphics.DrawLine(pen, num3, (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - num23, num3 + (int)num11 + num22, (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - num23);
				PointF point = new PointF((float)num3 - sizeF.Width, (float)((int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - num23) - sizeF.Height / 2f);
				graphics.DrawString(text, font2, Brushes.Gray, point);
			}
			pen.Color = Color.White;
			for (int i = 0; i < 81; i++)
			{
				if (i < 16 || i <= 50)
				{
				}
			}
			pen.Color = Color.White;
			pen.DashStyle = DashStyle.Solid;
			pen.Width = 2f;
			graphics.DrawLine(pen, (int)Convert.ToInt16((double)num3 + 0.67 * num11), (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - (int)Convert.ToInt16(0.33 * num11), (int)Convert.ToInt16((double)num3 + 0.21 * num11), (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - (int)Convert.ToInt16(0.71 * num11));
			graphics.DrawLine(pen, (int)Convert.ToInt16((double)num3 + 0.67 * num11), (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - (int)Convert.ToInt16(0.33 * num11), (int)Convert.ToInt16((double)num3 + 0.14 * num11), (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - (int)Convert.ToInt16(0.08 * num11));
			graphics.DrawLine(pen, (int)Convert.ToInt16((double)num3 + 0.21 * num11), (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - (int)Convert.ToInt16(0.71 * num11), (int)Convert.ToInt16((double)num3 + 0.14 * num11), (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - (int)Convert.ToInt16(0.08 * num11));
			pen.Color = Color.Purple;
			pen.DashStyle = DashStyle.Dot;
			graphics.DrawLine(pen, (int)Convert.ToInt16((double)num3 + 0.64 * num11), (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - (int)Convert.ToInt16(0.33 * num11), (int)Convert.ToInt16((double)num3 + 0.3 * num11), (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - (int)Convert.ToInt16(0.6 * num11));
			graphics.DrawLine(pen, (int)Convert.ToInt16((double)num3 + 0.64 * num11), (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - (int)Convert.ToInt16(0.33 * num11), (int)Convert.ToInt16((double)num3 + 0.15 * num11), (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - (int)Convert.ToInt16(0.06 * num11));
			graphics.DrawLine(pen, (int)Convert.ToInt16((double)num3 + 0.3 * num11), (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - (int)Convert.ToInt16(0.6 * num11), (int)Convert.ToInt16((double)num3 + 0.15 * num11), (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - (int)Convert.ToInt16(0.06 * num11));
			pen.Color = Color.Black;
			pen.DashStyle = DashStyle.Dash;
			graphics.DrawLine(pen, (int)Convert.ToInt16((double)num3 + Convert.ToDouble(info.AxesRedX) * num11), (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - (int)Convert.ToInt16(Convert.ToDouble(info.AxesRedY) * num11), (int)Convert.ToInt16((double)num3 + Convert.ToDouble(info.AxesBlueX) * num11), (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - (int)Convert.ToInt16(Convert.ToDouble(info.AxesBlueY) * num11));
			graphics.DrawLine(pen, (int)Convert.ToInt16((double)num3 + Convert.ToDouble(info.AxesRedX) * num11), (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - (int)Convert.ToInt16(Convert.ToDouble(info.AxesRedY) * num11), (int)Convert.ToInt16((double)num3 + Convert.ToDouble(info.AxesGreenX) * num11), (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - (int)Convert.ToInt16(Convert.ToDouble(info.AxesGreenY) * num11));
			graphics.DrawLine(pen, (int)Convert.ToInt16((double)num3 + Convert.ToDouble(info.AxesBlueX) * num11), (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - (int)Convert.ToInt16(Convert.ToDouble(info.AxesBlueY) * num11), (int)Convert.ToInt16((double)num3 + Convert.ToDouble(info.AxesGreenX) * num11), (int)Convert.ToInt16(gamutImgSize.GamutImgBottom + gamutImgSize.GamutImgHeight) - num6 - (int)Convert.ToInt16(Convert.ToDouble(info.AxesGreenY) * num11));
			graphics.DrawImage(this.img_RGB, 0, (int)Convert.ToInt16(gamutImgSize.GamutImgBottom));
			this.ImgGamut = this.BitmapToBitmapImage(this.img_RGB);
			pen.Dispose();
			graphics.Dispose();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00004FB4 File Offset: 0x000031B4
		private BitmapImage BitmapToBitmapImage(Bitmap bitmap)
		{
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, ImageFormat.Png);
			BitmapImage bitmapImage = new BitmapImage();
			bitmapImage.BeginInit();
			bitmapImage.StreamSource = memoryStream;
			bitmapImage.EndInit();
			return bitmapImage;
		}

		// Token: 0x0400003D RID: 61
		private BitmapImage imgGamut;

		// Token: 0x0400003E RID: 62
		private Bitmap img_RGB;

		// Token: 0x0400003F RID: 63
		private int RGB_DATA_ARR_LEN = 800;

		// Token: 0x0200000F RID: 15
		public enum RGB_DATA_PIXELS
		{
			// Token: 0x0400007E RID: 126
			NUM300 = 300,
			// Token: 0x0400007F RID: 127
			NUM600 = 600,
			// Token: 0x04000080 RID: 128
			NUM800 = 800
		}
	}
}
