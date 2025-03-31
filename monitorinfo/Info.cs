using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace monitorinfo
{
	// Token: 0x02000009 RID: 9
	internal class Info : INotifyPropertyChanged
	{
		// Token: 0x0600003A RID: 58 RVA: 0x00005031 File Offset: 0x00003231
		public Info()
		{
			this.ReadFromTxt();
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600003B RID: 59 RVA: 0x0000504A File Offset: 0x0000324A
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00005052 File Offset: 0x00003252
		public string MonitorDataString
		{
			get
			{
				return this.monitorDataString;
			}
			set
			{
				this.monitorDataString = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("MonitorDataString"));
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00005076 File Offset: 0x00003276
		// (set) Token: 0x0600003E RID: 62 RVA: 0x0000507E File Offset: 0x0000327E
		public string EDIDVersion
		{
			get
			{
				return this.edidVersion;
			}
			set
			{
				this.edidVersion = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("EDIDVersion"));
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600003F RID: 63 RVA: 0x000050A2 File Offset: 0x000032A2
		// (set) Token: 0x06000040 RID: 64 RVA: 0x000050AA File Offset: 0x000032AA
		public string ProductionDate
		{
			get
			{
				return this.productionDate;
			}
			set
			{
				this.productionDate = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("ProductionDate"));
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000041 RID: 65 RVA: 0x000050CE File Offset: 0x000032CE
		// (set) Token: 0x06000042 RID: 66 RVA: 0x000050D6 File Offset: 0x000032D6
		public string ManufacturerName
		{
			get
			{
				return this.manufacturerName;
			}
			set
			{
				this.manufacturerName = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("ManufacturerName"));
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000043 RID: 67 RVA: 0x000050FA File Offset: 0x000032FA
		// (set) Token: 0x06000044 RID: 68 RVA: 0x00005102 File Offset: 0x00003302
		public string PhysicalSize
		{
			get
			{
				return this.physicalSize;
			}
			set
			{
				this.physicalSize = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("PhysicalSize"));
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00005126 File Offset: 0x00003326
		// (set) Token: 0x06000046 RID: 70 RVA: 0x0000512E File Offset: 0x0000332E
		public string NTSCGamut
		{
			get
			{
				return this.ntscGamut;
			}
			set
			{
				this.ntscGamut = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("ColorGamut"));
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00005152 File Offset: 0x00003352
		// (set) Token: 0x06000048 RID: 72 RVA: 0x0000515A File Offset: 0x0000335A
		public string SRGBGamut
		{
			get
			{
				return this.srgbGamut;
			}
			set
			{
				this.srgbGamut = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("ColorGamut"));
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000049 RID: 73 RVA: 0x0000517E File Offset: 0x0000337E
		// (set) Token: 0x0600004A RID: 74 RVA: 0x00005186 File Offset: 0x00003386
		public string AxesRedX
		{
			get
			{
				return this.axesRedX;
			}
			set
			{
				this.axesRedX = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("AxesRedX"));
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600004B RID: 75 RVA: 0x000051AA File Offset: 0x000033AA
		// (set) Token: 0x0600004C RID: 76 RVA: 0x000051B2 File Offset: 0x000033B2
		public string AxesRedY
		{
			get
			{
				return this.axesRedY;
			}
			set
			{
				this.axesRedY = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("AxesRedY"));
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600004D RID: 77 RVA: 0x000051D6 File Offset: 0x000033D6
		// (set) Token: 0x0600004E RID: 78 RVA: 0x000051DE File Offset: 0x000033DE
		public string AxesGreenX
		{
			get
			{
				return this.axesGreenX;
			}
			set
			{
				this.axesGreenX = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("AxesGreenX"));
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00005202 File Offset: 0x00003402
		// (set) Token: 0x06000050 RID: 80 RVA: 0x0000520A File Offset: 0x0000340A
		public string AxesGreenY
		{
			get
			{
				return this.axesGreenY;
			}
			set
			{
				this.axesGreenY = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("axesGreenY"));
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000051 RID: 81 RVA: 0x0000522E File Offset: 0x0000342E
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00005236 File Offset: 0x00003436
		public string AxesBlueX
		{
			get
			{
				return this.axesBlueX;
			}
			set
			{
				this.axesBlueX = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("AxesBlueX"));
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000053 RID: 83 RVA: 0x0000525A File Offset: 0x0000345A
		// (set) Token: 0x06000054 RID: 84 RVA: 0x00005262 File Offset: 0x00003462
		public string AxesBlueY
		{
			get
			{
				return this.axesBlueY;
			}
			set
			{
				this.axesBlueY = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("AxesBlueY"));
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00005286 File Offset: 0x00003486
		// (set) Token: 0x06000056 RID: 86 RVA: 0x0000528E File Offset: 0x0000348E
		public string AxesWhiteX
		{
			get
			{
				return this.axesWhiteX;
			}
			set
			{
				this.axesWhiteX = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("AxesWhiteX"));
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000057 RID: 87 RVA: 0x000052B2 File Offset: 0x000034B2
		// (set) Token: 0x06000058 RID: 88 RVA: 0x000052BA File Offset: 0x000034BA
		public string AxesWhiteY
		{
			get
			{
				return this.axesWhiteY;
			}
			set
			{
				this.axesWhiteY = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("AxesWhiteY"));
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000059 RID: 89 RVA: 0x000052DE File Offset: 0x000034DE
		// (set) Token: 0x0600005A RID: 90 RVA: 0x000052E6 File Offset: 0x000034E6
		public string ColorFormat
		{
			get
			{
				return this.colorFormat;
			}
			set
			{
				this.colorFormat = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("ColorFormat"));
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000530C File Offset: 0x0000350C
		public void GetInfo(byte[] monitorEDID)
		{
			this.MonitorDataString = this.GetMonitorDataString(monitorEDID);
			this.EDIDVersion = "v" + monitorEDID[18].ToString() + "." + monitorEDID[19].ToString();
			this.ProductionDate = ((int)monitorEDID[17] + 1990).ToString() + "年" + ((monitorEDID[16] != 0) ? ("(第" + monitorEDID[16].ToString() + "周)") : "");
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

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600005C RID: 92 RVA: 0x0000542C File Offset: 0x0000362C
		// (remove) Token: 0x0600005D RID: 93 RVA: 0x00005464 File Offset: 0x00003664
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x0600005E RID: 94 RVA: 0x0000549C File Offset: 0x0000369C
		private string GetMonitorDataString(byte[] monitorEDID)
		{
			string result;
			if (monitorEDID[111] == 254)
			{
				byte[] array = new byte[13];
				Array.Copy(monitorEDID, 113, array, 0, 13);
				result = Encoding.ASCII.GetString(array);
			}
			else
			{
				result = this.GetMonitorManufacturerID(monitorEDID) + Convert.ToString(monitorEDID[11], 16) + Convert.ToString(monitorEDID[10], 16);
			}
			return result;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000054FC File Offset: 0x000036FC
		private string GetMonitorManufacturerID(byte[] monitorEDID)
		{
			byte[] bytes = new byte[]
			{
				(byte)(((monitorEDID[8] & 124) >> 2) + 64),
				(byte)(((int)(monitorEDID[8] & 3) << 3) + ((monitorEDID[9] & 224) >> 5) + 64),
				(monitorEDID[9] & 31) + 64
			};
			return Encoding.ASCII.GetString(bytes);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00005554 File Offset: 0x00003754
		private void ReadFromTxt()
		{
			StreamReader streamReader = new StreamReader(Application.GetResourceStream(new Uri("/Resources/MonitorManufacturerID.txt", UriKind.Relative)).Stream, Encoding.Default);
			string text;
			while ((text = streamReader.ReadLine()) != null)
			{
				string[] array = text.ToString().Split(new char[]
				{
					','
				});
				this.manufacturerNameDic.Add(array[0], array[1]);
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000055B8 File Offset: 0x000037B8
		private string GetMonitorManufacturerName(byte[] monitorEDID)
		{
			string monitorManufacturerID = this.GetMonitorManufacturerID(monitorEDID);
			if (this.manufacturerNameDic.Keys.Contains(monitorManufacturerID))
			{
				return this.manufacturerNameDic[monitorManufacturerID];
			}
			return monitorManufacturerID;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000055F0 File Offset: 0x000037F0
		private string GetMonitorPhysicalSize(byte[] monitorEDID)
		{
			return (Math.Sqrt(Math.Pow((double)monitorEDID[21], 2.0) + Math.Pow((double)monitorEDID[22], 2.0)) / 2.54).ToString("0.0") + "英寸";
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0000564C File Offset: 0x0000384C
		private string GetColorFormat(byte[] monitorEDID)
		{
			int num;
			string text;
			if ((monitorEDID[20] & 128) == 0)
			{
				num = (int)(monitorEDID[24] & 48);
				if (num != 0)
				{
					if (num != 8)
					{
						if (num != 16)
						{
							text = "";
						}
						else
						{
							text = "(非RGB)";
						}
					}
					else
					{
						text = "(RGB)";
					}
				}
				else
				{
					text = "(黑白/灰度)";
				}
				return "模拟信号 " + text;
			}
			num = (int)(monitorEDID[20] & 112);
			string str;
			if (num <= 48)
			{
				if (num == 16)
				{
					str = "6Bits";
					goto IL_B1;
				}
				if (num == 32)
				{
					str = "8Bits";
					goto IL_B1;
				}
				if (num == 48)
				{
					str = "10Bits";
					goto IL_B1;
				}
			}
			else
			{
				if (num == 64)
				{
					str = "12Bits";
					goto IL_B1;
				}
				if (num == 80)
				{
					str = "14Bits";
					goto IL_B1;
				}
				if (num == 96)
				{
					str = "16Bits";
					goto IL_B1;
				}
			}
			str = "";
			IL_B1:
			if ((monitorEDID[24] & 48) == 0)
			{
				text = "RGB ";
			}
			else
			{
				text = "RGB/YCrCb ";
			}
			return text + str;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00005728 File Offset: 0x00003928
		private string[] GetMonitorColorInfo(byte[] monitorEDID)
		{
			double num = (double)(4 * monitorEDID[27] + (monitorEDID[25] & 3)) / 1023.0;
			double num2 = (double)(4 * monitorEDID[28] + (monitorEDID[25] & 3)) / 1023.0;
			double num3 = (double)(4 * monitorEDID[29] + (monitorEDID[25] & 3)) / 1023.0;
			double num4 = (double)(4 * monitorEDID[30] + (monitorEDID[25] & 3)) / 1023.0;
			double num5 = (double)(4 * monitorEDID[31] + (monitorEDID[26] & 3)) / 1023.0;
			double num6 = (double)(4 * monitorEDID[32] + (monitorEDID[26] & 3)) / 1023.0;
			double num7 = (double)(4 * monitorEDID[33] + (monitorEDID[26] & 3)) / 1023.0;
			double num8 = (double)(4 * monitorEDID[34] + (monitorEDID[26] & 3)) / 1023.0;
			double[] array = new double[]
			{
				num,
				num2,
				num3,
				num4,
				num5,
				num6,
				num7,
				num8
			};
			string text = (Math.Abs(array[0] * array[3] + array[2] * array[5] + array[4] * array[1] - array[0] * array[5] - array[2] * array[1] - array[4] * array[3]) / 2.0 / 0.1582).ToString("P") + " NTSC";
			string text2 = (Math.Abs(array[0] * array[3] + array[2] * array[5] + array[4] * array[1] - array[0] * array[5] - array[2] * array[1] - array[4] * array[3]) / 2.0 / 0.1582 / 0.72).ToString("P") + " sRGB";
			return new string[]
			{
				num.ToString("0.000"),
				num2.ToString("0.000"),
				num3.ToString("0.000"),
				num4.ToString("0.000"),
				num5.ToString("0.000"),
				num6.ToString("0.000"),
				num7.ToString("0.000"),
				num8.ToString("0.000"),
				text,
				text2
			};
		}

		// Token: 0x04000044 RID: 68
		private string monitorDataString;

		// Token: 0x04000045 RID: 69
		private string edidVersion;

		// Token: 0x04000046 RID: 70
		private string productionDate;

		// Token: 0x04000047 RID: 71
		private string manufacturerName;

		// Token: 0x04000048 RID: 72
		private string physicalSize;

		// Token: 0x04000049 RID: 73
		private string ntscGamut;

		// Token: 0x0400004A RID: 74
		private string srgbGamut;

		// Token: 0x0400004B RID: 75
		private string axesRedX;

		// Token: 0x0400004C RID: 76
		private string axesRedY;

		// Token: 0x0400004D RID: 77
		private string axesGreenX;

		// Token: 0x0400004E RID: 78
		private string axesGreenY;

		// Token: 0x0400004F RID: 79
		private string axesBlueX;

		// Token: 0x04000050 RID: 80
		private string axesBlueY;

		// Token: 0x04000051 RID: 81
		private string axesWhiteX;

		// Token: 0x04000052 RID: 82
		private string axesWhiteY;

		// Token: 0x04000053 RID: 83
		private string colorFormat;

		// Token: 0x04000055 RID: 85
		private Dictionary<string, string> manufacturerNameDic = new Dictionary<string, string>();
	}
}
