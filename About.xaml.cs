// Decompiled with JetBrains decompiler
// Type: monitorinfo.About
// Assembly: monitorinfo, Version=2.2.1.19629, Culture=neutral, PublicKeyToken=null
// MVID: DFCB46BD-326F-45DA-914E-ACAE15E31A1C
// Assembly location: C:\Users\admin\Downloads\图吧工具箱202502\tools\显示器工具\色域检测\monitorinfo.exe

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

#nullable disable
namespace monitorinfo
{
  public partial class About : Window, IComponentConnector
  {
    internal Label LabelTitle;
    internal Label LabelAuthor;
    internal Label LabelVersion;
    internal Label LabelCopyRight;
    internal Button ButtonOK;
    internal TextBlock TextBlockDescription;
    private bool _contentLoaded;

    public About()
    {
      this.InitializeComponent();
      this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
      this.LabelTitle.Content = (object) this.AssemblyTitle.ToString();
      this.LabelAuthor.Content = (object) ("软件作者：" + this.AssemblyCompany.ToString());
      this.LabelVersion.Content = (object) ("软件版本：" + this.AssemblyVersion.ToString());
      this.LabelCopyRight.Content = (object) this.AssemblyCopyright.ToString();
    }

    private void BtnOK_Click(object sender, RoutedEventArgs e) => this.Close();

    private void TextBlockDescription_MouseDown(object sender, MouseButtonEventArgs e)
    {
      int num = (int) MessageBox.Show(this.AssemblyDescription.ToString(), "详细信息");
    }

    public string AssemblyTitle
    {
      get
      {
        object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyTitleAttribute), false);
        if (customAttributes.Length != 0)
        {
          AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute) customAttributes[0];
          if (assemblyTitleAttribute.Title != "")
            return assemblyTitleAttribute.Title;
        }
        return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
      }
    }

    public string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

    public string AssemblyCopyright
    {
      get
      {
        object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCopyrightAttribute), false);
        return customAttributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute) customAttributes[0]).Copyright;
      }
    }

    public string AssemblyDescription
    {
      get
      {
        object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyDescriptionAttribute), false);
        return customAttributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute) customAttributes[0]).Description;
      }
    }

    public string AssemblyCompany
    {
      get
      {
        object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCompanyAttribute), false);
        return customAttributes.Length == 0 ? "" : ((AssemblyCompanyAttribute) customAttributes[0]).Company;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/monitorinfo;component/about.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.LabelTitle = (Label) target;
          break;
        case 2:
          this.LabelAuthor = (Label) target;
          break;
        case 3:
          this.LabelVersion = (Label) target;
          break;
        case 4:
          this.LabelCopyRight = (Label) target;
          break;
        case 5:
          this.ButtonOK = (Button) target;
          this.ButtonOK.Click += new RoutedEventHandler(this.BtnOK_Click);
          break;
        case 6:
          this.TextBlockDescription = (TextBlock) target;
          this.TextBlockDescription.MouseDown += new MouseButtonEventHandler(this.TextBlockDescription_MouseDown);
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
