using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace monitorinfo.Properties
{
	// Token: 0x0200000C RID: 12
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00005EBF File Offset: 0x000040BF
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x04000074 RID: 116
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
