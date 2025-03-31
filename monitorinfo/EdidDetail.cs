using System;
using System.Text;

namespace monitorinfo
{
	// Token: 0x02000006 RID: 6
	public class EdidDetail
	{
		// Token: 0x0600001E RID: 30 RVA: 0x000041CC File Offset: 0x000023CC
		public static EdidDetail Parse(byte[] data)
		{
			EdidDetail edidDetail = new EdidDetail();
			string @string = Encoding.ASCII.GetString(data);
			edidDetail.Manufacturer = @string.Substring(90, 17).Trim().Replace("\0", string.Empty).Replace("?", string.Empty);
			edidDetail.Model = @string.Substring(108, 17).Trim().Replace("\0", string.Empty).Replace("?", string.Empty);
			int num = 54;
			int num2 = 4;
			int num3 = 15;
			int num4 = 15;
			edidDetail.HorizontalDisplaySize = ((data[num + 14] >> num2 & num3) << 8 | (int)data[num + 12]);
			edidDetail.VerticalDisplaySize = (((int)data[num + 14] & num4) << 8 | (int)data[num + 13]);
			edidDetail.HorizontalImageSize = (int)data[21];
			edidDetail.VerticalImageSize = (int)data[22];
			return edidDetail;
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001F RID: 31 RVA: 0x000042A4 File Offset: 0x000024A4
		// (set) Token: 0x06000020 RID: 32 RVA: 0x000042AC File Offset: 0x000024AC
		public string Manufacturer { get; private set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000021 RID: 33 RVA: 0x000042B5 File Offset: 0x000024B5
		// (set) Token: 0x06000022 RID: 34 RVA: 0x000042BD File Offset: 0x000024BD
		public string Model { get; private set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000023 RID: 35 RVA: 0x000042C6 File Offset: 0x000024C6
		// (set) Token: 0x06000024 RID: 36 RVA: 0x000042CE File Offset: 0x000024CE
		public int HorizontalDisplaySize { get; private set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000025 RID: 37 RVA: 0x000042D7 File Offset: 0x000024D7
		// (set) Token: 0x06000026 RID: 38 RVA: 0x000042DF File Offset: 0x000024DF
		public int HorizontalImageSize { get; private set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000027 RID: 39 RVA: 0x000042E8 File Offset: 0x000024E8
		// (set) Token: 0x06000028 RID: 40 RVA: 0x000042F0 File Offset: 0x000024F0
		public int VerticalDisplaySize { get; private set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000042F9 File Offset: 0x000024F9
		// (set) Token: 0x0600002A RID: 42 RVA: 0x00004301 File Offset: 0x00002501
		public int VerticalImageSize { get; private set; }
	}
}
