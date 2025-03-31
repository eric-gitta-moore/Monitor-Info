// Decompiled with JetBrains decompiler
// Type: monitorinfo.Properties.Resources
// Assembly: monitorinfo, Version=2.2.1.19629, Culture=neutral, PublicKeyToken=null
// MVID: DFCB46BD-326F-45DA-914E-ACAE15E31A1C
// Assembly location: C:\Users\admin\Downloads\图吧工具箱202502\tools\显示器工具\色域检测\monitorinfo.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace monitorinfo.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (monitorinfo.Properties.Resources.resourceMan == null)
          monitorinfo.Properties.Resources.resourceMan = new ResourceManager("monitorinfo.Properties.Resources", typeof (monitorinfo.Properties.Resources).Assembly);
        return monitorinfo.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => monitorinfo.Properties.Resources.resourceCulture;
      set => monitorinfo.Properties.Resources.resourceCulture = value;
    }

    internal static Bitmap gaumt_hidpi
    {
      get
      {
        return (Bitmap) monitorinfo.Properties.Resources.ResourceManager.GetObject(nameof (gaumt_hidpi), monitorinfo.Properties.Resources.resourceCulture);
      }
    }

    internal static Icon screen_icon
    {
      get
      {
        return (Icon) monitorinfo.Properties.Resources.ResourceManager.GetObject(nameof (screen_icon), monitorinfo.Properties.Resources.resourceCulture);
      }
    }
  }
}
