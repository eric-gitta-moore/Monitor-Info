using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace monitorinfo
{
	// Token: 0x02000002 RID: 2
	public partial class About : Window
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public About()
		{
			this.InitializeComponent();
			base.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			this.LabelTitle.Content = this.AssemblyTitle.ToString();
			this.LabelAuthor.Content = "软件作者：" + this.AssemblyCompany.ToString();
			this.LabelVersion.Content = "软件版本：" + this.AssemblyVersion.ToString();
			this.LabelCopyRight.Content = this.AssemblyCopyright.ToString();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020DC File Offset: 0x000002DC
		private void BtnOK_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020E4 File Offset: 0x000002E4
		private void TextBlockDescription_MouseDown(object sender, MouseButtonEventArgs e)
		{
			MessageBox.Show(this.AssemblyDescription.ToString(), "详细信息");
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000004 RID: 4 RVA: 0x000020FC File Offset: 0x000002FC
		public string AssemblyTitle
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (customAttributes.Length != 0)
				{
					AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute)customAttributes[0];
					if (assemblyTitleAttribute.Title != "")
					{
						return assemblyTitleAttribute.Title;
					}
				}
				return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002154 File Offset: 0x00000354
		public string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000006 RID: 6 RVA: 0x0000216C File Offset: 0x0000036C
		public string AssemblyCopyright
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				if (customAttributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCopyrightAttribute)customAttributes[0]).Copyright;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000021A8 File Offset: 0x000003A8
		public string AssemblyDescription
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				if (customAttributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyDescriptionAttribute)customAttributes[0]).Description;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000008 RID: 8 RVA: 0x000021E4 File Offset: 0x000003E4
		public string AssemblyCompany
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				if (customAttributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCompanyAttribute)customAttributes[0]).Company;
			}
		}
	}
}
