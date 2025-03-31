using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace monitorinfo.Properties
{
	// Token: 0x0200000B RID: 11
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x0600006D RID: 109 RVA: 0x0000430A File Offset: 0x0000250A
		internal Resources()
		{
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00005E4E File Offset: 0x0000404E
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("monitorinfo.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00005E7A File Offset: 0x0000407A
		// (set) Token: 0x06000070 RID: 112 RVA: 0x00005E81 File Offset: 0x00004081
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00005E89 File Offset: 0x00004089
		internal static Bitmap gaumt_hidpi
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("gaumt_hidpi", Resources.resourceCulture);
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00005EA4 File Offset: 0x000040A4
		internal static Icon screen_icon
		{
			get
			{
				return (Icon)Resources.ResourceManager.GetObject("screen_icon", Resources.resourceCulture);
			}
		}

		// Token: 0x04000072 RID: 114
		private static ResourceManager resourceMan;

		// Token: 0x04000073 RID: 115
		private static CultureInfo resourceCulture;
	}
}
