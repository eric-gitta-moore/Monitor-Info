using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace monitorinfo
{
	// Token: 0x0200000A RID: 10
	public partial class MainWindow : Window
	{
		// Token: 0x06000065 RID: 101 RVA: 0x000059A0 File Offset: 0x00003BA0
		public MainWindow()
		{
			this.InitializeComponent();
			base.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			base.ResizeMode = ResizeMode.CanMinimize;
			base.Title = string.Concat(new string[]
			{
				"显示器色域检测(图拉丁版) V",
				Assembly.GetExecutingAssembly().GetName().Version.Major.ToString(),
				".",
				Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString(),
				".",
				Assembly.GetExecutingAssembly().GetName().Version.Build.ToString()
			});
			this.GridData.DataContext = this.info;
			this.ImgGamut.DataContext = this.gamutImage;
			this.gamutImgSize.GamutImgBottom = this.ImgGamut.Margin.Bottom;
			this.gamutImgSize.GamutImgHeight = this.ImgGamut.Height;
			this.gamutImgSize.GamutImgWidth = this.ImgGamut.Width;
			this.BtnRefresh_Click(null, null);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00005AF0 File Offset: 0x00003CF0
		private void BtnRefresh_Click(object sender, RoutedEventArgs e)
		{
			this.monitorEDID = Edid.Get();
			this.CbxMonitorList.Items.Clear();
			for (int i = 0; i < this.monitorEDID.Count; i++)
			{
				this.CbxMonitorList.Items.Add("显示器" + i.ToString());
			}
			if (this.CbxMonitorList.SelectedIndex == -1)
			{
				this.CbxMonitorList.SelectedIndex = 0;
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00005B6A File Offset: 0x00003D6A
		private void BtnAboutMe_Click(object sender, RoutedEventArgs e)
		{
			new About().ShowDialog();
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00005B78 File Offset: 0x00003D78
		private void CbxMonitorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.CbxMonitorList.SelectedIndex != -1)
			{
				this.TbkCopy.Foreground = Brushes.Blue;
				this.info.GetInfo(this.monitorEDID[this.CbxMonitorList.SelectedIndex].monitorEDID);
				base.Dispatcher.BeginInvoke(new ThreadStart(delegate()
				{
					this.gamutImage.DrawTongueDiagram(this.info, this.colorSpace, this.gamutImgSize);
				}), new object[0]);
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00005BE7 File Offset: 0x00003DE7
		private void TbkCopy_MouseDown(object sender, MouseButtonEventArgs e)
		{
			Clipboard.SetDataObject(this.LblProductID.Content);
			this.TbkCopy.Foreground = Brushes.Pink;
		}

		// Token: 0x04000056 RID: 86
		private List<Edid> monitorEDID;

		// Token: 0x04000057 RID: 87
		private Info info = new Info();

		// Token: 0x04000058 RID: 88
		private ColorSpace colorSpace = new ColorSpace();

		// Token: 0x04000059 RID: 89
		private GamutImage gamutImage = new GamutImage();

		// Token: 0x0400005A RID: 90
		private GamutImgSize gamutImgSize = new GamutImgSize();
	}
}
