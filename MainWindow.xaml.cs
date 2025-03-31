// Decompiled with JetBrains decompiler
// Type: monitorinfo.MainWindow
// Assembly: monitorinfo, Version=2.2.1.19629, Culture=neutral, PublicKeyToken=null
// MVID: DFCB46BD-326F-45DA-914E-ACAE15E31A1C
// Assembly location: C:\Users\admin\Downloads\图吧工具箱202502\tools\显示器工具\色域检测\monitorinfo.exe

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

#nullable disable
namespace monitorinfo
{
  public partial class MainWindow : Window, IComponentConnector
  {
    private List<Edid> monitorEDID;
    private Info info = new Info();
    private ColorSpace colorSpace = new ColorSpace();
    private GamutImage gamutImage = new GamutImage();
    private GamutImgSize gamutImgSize = new GamutImgSize();
    internal Grid GridData;
    internal Label LblRedX;
    internal Label LblRedY;
    internal Label LblGreenX;
    internal Label LblGreenY;
    internal Label LblBlueX;
    internal Label LblBlueY;
    internal Label LblNTSCGamut;
    internal Label LblSRGBGamut;
    internal Button BtnRefresh;
    internal Label LblColorFormat;
    internal Label LblPhysicalSize;
    internal Button BtnAboutMe;
    internal Label LblProductionDate;
    internal Label LblEDIDVersion;
    internal Label LblWhiteX;
    internal Label LblWhiteY;
    internal Label LblManufacturerName;
    internal Label LblProductID;
    internal ComboBox CbxMonitorList;
    internal TextBlock TbkCopy;
    internal Image ImgGamut;
    private bool _contentLoaded;

    public MainWindow()
    {
      this.InitializeComponent();
      this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
      this.ResizeMode = ResizeMode.CanMinimize;
      this.Title = "显示器色域检测(图拉丁版) V" + Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();
      this.GridData.DataContext = (object) this.info;
      this.ImgGamut.DataContext = (object) this.gamutImage;
      this.gamutImgSize.GamutImgBottom = this.ImgGamut.Margin.Bottom;
      this.gamutImgSize.GamutImgHeight = this.ImgGamut.Height;
      this.gamutImgSize.GamutImgWidth = this.ImgGamut.Width;
      this.BtnRefresh_Click((object) null, (RoutedEventArgs) null);
    }

    private void BtnRefresh_Click(object sender, RoutedEventArgs e)
    {
      this.monitorEDID = Edid.Get();
      this.CbxMonitorList.Items.Clear();
      for (int index = 0; index < this.monitorEDID.Count; ++index)
        this.CbxMonitorList.Items.Add((object) ("显示器" + index.ToString()));
      if (this.CbxMonitorList.SelectedIndex != -1)
        return;
      this.CbxMonitorList.SelectedIndex = 0;
    }

    private void BtnAboutMe_Click(object sender, RoutedEventArgs e) => new About().ShowDialog();

    private void CbxMonitorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (this.CbxMonitorList.SelectedIndex == -1)
        return;
      this.TbkCopy.Foreground = (Brush) Brushes.Blue;
      this.info.GetInfo(this.monitorEDID[this.CbxMonitorList.SelectedIndex].monitorEDID);
      this.Dispatcher.BeginInvoke((Delegate) (() => this.gamutImage.DrawTongueDiagram(this.info, this.colorSpace, this.gamutImgSize)));
    }

    private void TbkCopy_MouseDown(object sender, MouseButtonEventArgs e)
    {
      Clipboard.SetDataObject(this.LblProductID.Content);
      this.TbkCopy.Foreground = (Brush) Brushes.Pink;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/monitorinfo;component/mainwindow.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.GridData = (Grid) target;
          break;
        case 2:
          this.LblRedX = (Label) target;
          break;
        case 3:
          this.LblRedY = (Label) target;
          break;
        case 4:
          this.LblGreenX = (Label) target;
          break;
        case 5:
          this.LblGreenY = (Label) target;
          break;
        case 6:
          this.LblBlueX = (Label) target;
          break;
        case 7:
          this.LblBlueY = (Label) target;
          break;
        case 8:
          this.LblNTSCGamut = (Label) target;
          break;
        case 9:
          this.LblSRGBGamut = (Label) target;
          break;
        case 10:
          this.BtnRefresh = (Button) target;
          this.BtnRefresh.Click += new RoutedEventHandler(this.BtnRefresh_Click);
          break;
        case 11:
          this.LblColorFormat = (Label) target;
          break;
        case 12:
          this.LblPhysicalSize = (Label) target;
          break;
        case 13:
          this.BtnAboutMe = (Button) target;
          this.BtnAboutMe.Click += new RoutedEventHandler(this.BtnAboutMe_Click);
          break;
        case 14:
          this.LblProductionDate = (Label) target;
          break;
        case 15:
          this.LblEDIDVersion = (Label) target;
          break;
        case 16:
          this.LblWhiteX = (Label) target;
          break;
        case 17:
          this.LblWhiteY = (Label) target;
          break;
        case 18:
          this.LblManufacturerName = (Label) target;
          break;
        case 19:
          this.LblProductID = (Label) target;
          break;
        case 20:
          this.CbxMonitorList = (ComboBox) target;
          this.CbxMonitorList.SelectionChanged += new SelectionChangedEventHandler(this.CbxMonitorList_SelectionChanged);
          break;
        case 21:
          this.TbkCopy = (TextBlock) target;
          this.TbkCopy.MouseDown += new MouseButtonEventHandler(this.TbkCopy_MouseDown);
          break;
        case 22:
          this.ImgGamut = (Image) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
