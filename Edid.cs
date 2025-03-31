// Decompiled with JetBrains decompiler
// Type: monitorinfo.Edid
// Assembly: monitorinfo, Version=2.2.1.19629, Culture=neutral, PublicKeyToken=null
// MVID: DFCB46BD-326F-45DA-914E-ACAE15E31A1C
// Assembly location: C:\Users\admin\Downloads\图吧工具箱202502\tools\显示器工具\色域检测\monitorinfo.exe

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace monitorinfo
{
  public class Edid
  {
    public readonly byte[] monitorEDID;

    public Edid(byte[] data) => this.monitorEDID = data;

    public EdidDetail GetDetail() => EdidDetail.Parse(this.monitorEDID);

    public static List<Edid> Get() => Edid.EdidUtil.GetEDID();

    private static class EdidUtil
    {
      private const int DICS_FLAG_GLOBAL = 1;
      private const int DIREG_DEV = 1;
      private const int KEY_READ = 131097;
      private const int ERROR_SUCCESS = 0;
      private static readonly Guid GUID_CLASS_MONITOR = new Guid(1295444334U, (ushort) 58149, (ushort) 4558, (byte) 191, (byte) 193, (byte) 8, (byte) 0, (byte) 43, (byte) 225, (byte) 3, (byte) 24);
      private const int DIGCF_PRESENT = 2;
      private const int ERROR_NO_MORE_ITEMS = 259;

      public static List<Edid> GetEDID()
      {
        List<Edid> lsi = new List<Edid>();
        IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf((object) Edid.EdidUtil.GUID_CLASS_MONITOR));
        Marshal.StructureToPtr((object) Edid.EdidUtil.GUID_CLASS_MONITOR, num, false);
        Edid.EdidUtil.SetupDiGetClassDevsEx(num, (string) null, IntPtr.Zero, 2, IntPtr.Zero, (string) null, IntPtr.Zero);
        Edid.EdidUtil.DISPLAY_DEVICE lpDisplayDevice1 = new Edid.EdidUtil.DISPLAY_DEVICE();
        lpDisplayDevice1.cb = Marshal.SizeOf(typeof (Edid.EdidUtil.DISPLAY_DEVICE));
        uint iDevNum1 = 0;
        for (bool flag = false; Edid.EdidUtil.EnumDisplayDevices((string) null, iDevNum1, ref lpDisplayDevice1, 0U) && !flag; ++iDevNum1)
        {
          Edid.EdidUtil.DISPLAY_DEVICE lpDisplayDevice2 = new Edid.EdidUtil.DISPLAY_DEVICE();
          lpDisplayDevice2.cb = Marshal.SizeOf(typeof (Edid.EdidUtil.DISPLAY_DEVICE));
          uint iDevNum2 = 0;
          while (Edid.EdidUtil.EnumDisplayDevices(lpDisplayDevice1.DeviceName, iDevNum2, ref lpDisplayDevice2, 0U) && !flag)
          {
            if ((lpDisplayDevice2.StateFlags & Edid.EdidUtil.DisplayDeviceStateFlags.AttachedToDesktop) != (Edid.EdidUtil.DisplayDeviceStateFlags) 0 && (lpDisplayDevice2.StateFlags & Edid.EdidUtil.DisplayDeviceStateFlags.MirroringDriver) == (Edid.EdidUtil.DisplayDeviceStateFlags) 0)
              flag = Edid.EdidUtil.GetActualEDID(out string _, lsi);
            ++iDevNum2;
            lpDisplayDevice2 = new Edid.EdidUtil.DISPLAY_DEVICE();
            lpDisplayDevice2.cb = Marshal.SizeOf(typeof (Edid.EdidUtil.DISPLAY_DEVICE));
          }
          lpDisplayDevice1 = new Edid.EdidUtil.DISPLAY_DEVICE();
          lpDisplayDevice1.cb = Marshal.SizeOf(typeof (Edid.EdidUtil.DISPLAY_DEVICE));
        }
        return lsi;
      }

      private static bool GetActualEDID(out string DeviceID, List<Edid> lsi)
      {
        IntPtr num1 = Marshal.AllocHGlobal(Marshal.SizeOf((object) Edid.EdidUtil.GUID_CLASS_MONITOR));
        Marshal.StructureToPtr((object) Edid.EdidUtil.GUID_CLASS_MONITOR, num1, false);
        IntPtr classDevsEx = Edid.EdidUtil.SetupDiGetClassDevsEx(num1, (string) null, IntPtr.Zero, 2, IntPtr.Zero, (string) null, IntPtr.Zero);
        DeviceID = string.Empty;
        int MemberIndex = 0;
        while (Marshal.GetLastWin32Error() != 259)
        {
          Edid.EdidUtil.SP_DEVINFO_DATA spDevinfoData = new Edid.EdidUtil.SP_DEVINFO_DATA();
          spDevinfoData.cbSize = Marshal.SizeOf(typeof (Edid.EdidUtil.SP_DEVINFO_DATA));
          if (Edid.EdidUtil.SetupDiEnumDeviceInfo(classDevsEx, MemberIndex, ref spDevinfoData) > 0)
          {
            UIntPtr num2 = Edid.EdidUtil.SetupDiOpenDevRegKey(classDevsEx, ref spDevinfoData, 1, 0, 1, 131097);
            Edid edid = Edid.EdidUtil.PullEDID(num2);
            if (edid != null)
              lsi.Add(edid);
            Edid.EdidUtil.RegCloseKey(num2);
          }
          ++MemberIndex;
        }
        Marshal.FreeHGlobal(num1);
        return true;
      }

      private static Edid PullEDID(UIntPtr hDevRegKey)
      {
        Edid edid = (Edid) null;
        StringBuilder lpValueName = new StringBuilder(128);
        uint lpcValueName = 128;
        byte[] source = new byte[1024];
        IntPtr num1 = Marshal.AllocHGlobal(source.Length);
        Marshal.Copy(source, 0, num1, source.Length);
        int lpcbData = 1024;
        uint dwIndex = 0;
        uint num2 = 0;
        while (num2 != 259U)
        {
          num2 = Edid.EdidUtil.RegEnumValue(hDevRegKey, dwIndex, lpValueName, ref lpcValueName, IntPtr.Zero, IntPtr.Zero, num1, ref lpcbData);
          string str = lpValueName.ToString();
          if (num2 == 0U && str.Contains("EDID") && lpcbData >= 1)
          {
            byte[] numArray = new byte[lpcbData];
            Marshal.Copy(num1, numArray, 0, lpcbData);
            edid = new Edid(numArray);
          }
          ++dwIndex;
        }
        Marshal.FreeHGlobal(num1);
        return edid;
      }

      [DllImport("advapi32.dll", SetLastError = true)]
      private static extern uint RegEnumValue(
        UIntPtr hKey,
        uint dwIndex,
        StringBuilder lpValueName,
        ref uint lpcValueName,
        IntPtr lpReserved,
        IntPtr lpType,
        IntPtr lpData,
        ref int lpcbData);

      [DllImport("setupapi.dll")]
      private static extern IntPtr SetupDiGetClassDevsEx(
        IntPtr ClassGuid,
        [MarshalAs(UnmanagedType.LPStr)] string enumerator,
        IntPtr hwndParent,
        int Flags,
        IntPtr DeviceInfoSet,
        [MarshalAs(UnmanagedType.LPStr)] string MachineName,
        IntPtr Reserved);

      [DllImport("setupapi.dll", SetLastError = true)]
      private static extern int SetupDiEnumDeviceInfo(
        IntPtr DeviceInfoSet,
        int MemberIndex,
        ref Edid.EdidUtil.SP_DEVINFO_DATA DeviceInterfaceData);

      [DllImport("Setupapi", CharSet = CharSet.Auto, SetLastError = true)]
      private static extern UIntPtr SetupDiOpenDevRegKey(
        IntPtr hDeviceInfoSet,
        ref Edid.EdidUtil.SP_DEVINFO_DATA deviceInfoData,
        int scope,
        int hwProfile,
        int parameterRegistryValueKind,
        int samDesired);

      [DllImport("user32.dll")]
      private static extern bool EnumDisplayDevices(
        string lpDevice,
        uint iDevNum,
        ref Edid.EdidUtil.DISPLAY_DEVICE lpDisplayDevice,
        uint dwFlags);

      [DllImport("advapi32.dll", SetLastError = true)]
      private static extern int RegCloseKey(UIntPtr hKey);

      [Flags]
      private enum DisplayDeviceStateFlags
      {
        AttachedToDesktop = 1,
        MultiDriver = 2,
        PrimaryDevice = 4,
        MirroringDriver = 8,
        VGACompatible = 16, // 0x00000010
        Removable = 32, // 0x00000020
        ModesPruned = 134217728, // 0x08000000
        Remote = 67108864, // 0x04000000
        Disconnect = 33554432, // 0x02000000
      }

      private struct DISPLAY_DEVICE
      {
        [MarshalAs(UnmanagedType.U4)]
        public int cb;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string DeviceName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceString;
        [MarshalAs(UnmanagedType.U4)]
        public Edid.EdidUtil.DisplayDeviceStateFlags StateFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceKey;
      }

      private struct SP_DEVINFO_DATA
      {
        public int cbSize;
        public Guid ClassGuid;
        public uint DevInst;
        public IntPtr Reserved;
      }
    }
  }
}
