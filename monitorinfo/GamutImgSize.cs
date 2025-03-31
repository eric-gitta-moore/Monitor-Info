using System;

namespace monitorinfo
{
	// Token: 0x02000008 RID: 8
	internal class GamutImgSize
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000033 RID: 51 RVA: 0x00004FFE File Offset: 0x000031FE
		// (set) Token: 0x06000034 RID: 52 RVA: 0x00005006 File Offset: 0x00003206
		public double GamutImgWidth
		{
			get
			{
				return this.gamutImgWidth;
			}
			set
			{
				this.gamutImgWidth = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000035 RID: 53 RVA: 0x0000500F File Offset: 0x0000320F
		// (set) Token: 0x06000036 RID: 54 RVA: 0x00005017 File Offset: 0x00003217
		public double GamutImgHeight
		{
			get
			{
				return this.gamutImgHeight;
			}
			set
			{
				this.gamutImgHeight = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00005020 File Offset: 0x00003220
		// (set) Token: 0x06000038 RID: 56 RVA: 0x00005028 File Offset: 0x00003228
		public double GamutImgBottom
		{
			get
			{
				return this.gamutImgBottom;
			}
			set
			{
				this.gamutImgBottom = value;
			}
		}

		// Token: 0x04000041 RID: 65
		private double gamutImgWidth;

		// Token: 0x04000042 RID: 66
		private double gamutImgHeight;

		// Token: 0x04000043 RID: 67
		private double gamutImgBottom;
	}
}
