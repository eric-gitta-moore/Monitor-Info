using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace monitorinfo
{
	// Token: 0x02000005 RID: 5
	public class Edid
	{
		// Token: 0x0600001B RID: 27 RVA: 0x000041A7 File Offset: 0x000023A7
		public Edid(byte[] data)
		{
			this.monitorEDID = data;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000041B6 File Offset: 0x000023B6
		public EdidDetail GetDetail()
		{
			return EdidDetail.Parse(this.monitorEDID);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000041C3 File Offset: 0x000023C3
		public static List<Edid> Get()
		{
			return Edid.EdidUtil.GetEDID();
		}

		// Token: 0x04000036 RID: 54
		public readonly byte[] monitorEDID;

		// Token: 0x0200000E RID: 14
		private static class EdidUtil
		{
			// Token: 0x06000076 RID: 118 RVA: 0x00005EE4 File Offset: 0x000040E4
			public static List<Edid> GetEDID()
			{
				List<Edid> list = new List<Edid>();
				IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(Edid.EdidUtil.GUID_CLASS_MONITOR));
				Marshal.StructureToPtr(Edid.EdidUtil.GUID_CLASS_MONITOR, intPtr, false);
				Edid.EdidUtil.SetupDiGetClassDevsEx(intPtr, null, IntPtr.Zero, 2, IntPtr.Zero, null, IntPtr.Zero);
				Edid.EdidUtil.DISPLAY_DEVICE display_DEVICE = default(Edid.EdidUtil.DISPLAY_DEVICE);
				display_DEVICE.cb = Marshal.SizeOf(typeof(Edid.EdidUtil.DISPLAY_DEVICE));
				uint num = 0U;
				bool flag = false;
				while (Edid.EdidUtil.EnumDisplayDevices(null, num, ref display_DEVICE, 0U) && !flag)
				{
					Edid.EdidUtil.DISPLAY_DEVICE display_DEVICE2 = default(Edid.EdidUtil.DISPLAY_DEVICE);
					display_DEVICE2.cb = Marshal.SizeOf(typeof(Edid.EdidUtil.DISPLAY_DEVICE));
					uint num2 = 0U;
					while (Edid.EdidUtil.EnumDisplayDevices(display_DEVICE.DeviceName, num2, ref display_DEVICE2, 0U) && !flag)
					{
						if ((display_DEVICE2.StateFlags & Edid.EdidUtil.DisplayDeviceStateFlags.AttachedToDesktop) != (Edid.EdidUtil.DisplayDeviceStateFlags)0 && (display_DEVICE2.StateFlags & Edid.EdidUtil.DisplayDeviceStateFlags.MirroringDriver) == (Edid.EdidUtil.DisplayDeviceStateFlags)0)
						{
							string text;
							flag = Edid.EdidUtil.GetActualEDID(out text, list);
						}
						num2 += 1U;
						display_DEVICE2 = default(Edid.EdidUtil.DISPLAY_DEVICE);
						display_DEVICE2.cb = Marshal.SizeOf(typeof(Edid.EdidUtil.DISPLAY_DEVICE));
					}
					display_DEVICE = default(Edid.EdidUtil.DISPLAY_DEVICE);
					display_DEVICE.cb = Marshal.SizeOf(typeof(Edid.EdidUtil.DISPLAY_DEVICE));
					num += 1U;
				}
				return list;
			}

			// Token: 0x06000077 RID: 119 RVA: 0x00006014 File Offset: 0x00004214
			private static bool GetActualEDID(out string DeviceID, List<Edid> lsi)
			{
				IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(Edid.EdidUtil.GUID_CLASS_MONITOR));
				Marshal.StructureToPtr(Edid.EdidUtil.GUID_CLASS_MONITOR, intPtr, false);
				IntPtr intPtr2 = Edid.EdidUtil.SetupDiGetClassDevsEx(intPtr, null, IntPtr.Zero, 2, IntPtr.Zero, null, IntPtr.Zero);
				DeviceID = string.Empty;
				int num = 0;
				while (Marshal.GetLastWin32Error() != 259)
				{
					Edid.EdidUtil.SP_DEVINFO_DATA sp_DEVINFO_DATA = default(Edid.EdidUtil.SP_DEVINFO_DATA);
					sp_DEVINFO_DATA.cbSize = Marshal.SizeOf(typeof(Edid.EdidUtil.SP_DEVINFO_DATA));
					if (Edid.EdidUtil.SetupDiEnumDeviceInfo(intPtr2, num, ref sp_DEVINFO_DATA) > 0)
					{
						UIntPtr uintPtr = Edid.EdidUtil.SetupDiOpenDevRegKey(intPtr2, ref sp_DEVINFO_DATA, 1, 0, 1, 131097);
						Edid edid = Edid.EdidUtil.PullEDID(uintPtr);
						if (edid != null)
						{
							lsi.Add(edid);
						}
						Edid.EdidUtil.RegCloseKey(uintPtr);
					}
					num++;
				}
				Marshal.FreeHGlobal(intPtr);
				return true;
			}

			// Token: 0x06000078 RID: 120 RVA: 0x000060DC File Offset: 0x000042DC
			private static Edid PullEDID(UIntPtr hDevRegKey)
			{
				Edid result = null;
				StringBuilder stringBuilder = new StringBuilder(128);
				uint num = 128U;
				byte[] array = new byte[1024];
				IntPtr intPtr = Marshal.AllocHGlobal(array.Length);
				Marshal.Copy(array, 0, intPtr, array.Length);
				int num2 = 1024;
				uint num3 = 0U;
				uint num4 = 0U;
				while (num4 != 259U)
				{
					num4 = Edid.EdidUtil.RegEnumValue(hDevRegKey, num3, stringBuilder, ref num, IntPtr.Zero, IntPtr.Zero, intPtr, ref num2);
					string text = stringBuilder.ToString();
					if (num4 == 0U && text.Contains("EDID") && num2 >= 1)
					{
						byte[] array2 = new byte[num2];
						Marshal.Copy(intPtr, array2, 0, num2);
						result = new Edid(array2);
					}
					num3 += 1U;
				}
				Marshal.FreeHGlobal(intPtr);
				return result;
			}

			// Token: 0x06000079 RID: 121
			[DllImport("advapi32.dll", SetLastError = true)]
			private static extern uint RegEnumValue(UIntPtr hKey, uint dwIndex, StringBuilder lpValueName, ref uint lpcValueName, IntPtr lpReserved, IntPtr lpType, IntPtr lpData, ref int lpcbData);

			// Token: 0x0600007A RID: 122
			[DllImport("setupapi.dll")]
			private static extern IntPtr SetupDiGetClassDevsEx(IntPtr ClassGuid, [MarshalAs(UnmanagedType.LPStr)] string enumerator, IntPtr hwndParent, int Flags, IntPtr DeviceInfoSet, [MarshalAs(UnmanagedType.LPStr)] string MachineName, IntPtr Reserved);

			// Token: 0x0600007B RID: 123
			[DllImport("setupapi.dll", SetLastError = true)]
			private static extern int SetupDiEnumDeviceInfo(IntPtr DeviceInfoSet, int MemberIndex, ref Edid.EdidUtil.SP_DEVINFO_DATA DeviceInterfaceData);

			// Token: 0x0600007C RID: 124
			[DllImport("Setupapi", CharSet = CharSet.Auto, SetLastError = true)]
			private static extern UIntPtr SetupDiOpenDevRegKey(IntPtr hDeviceInfoSet, ref Edid.EdidUtil.SP_DEVINFO_DATA deviceInfoData, int scope, int hwProfile, int parameterRegistryValueKind, int samDesired);

			// Token: 0x0600007D RID: 125
			[DllImport("user32.dll")]
			private static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref Edid.EdidUtil.DISPLAY_DEVICE lpDisplayDevice, uint dwFlags);

			// Token: 0x0600007E RID: 126
			[DllImport("advapi32.dll", SetLastError = true)]
			private static extern int RegCloseKey(UIntPtr hKey);

			// Token: 0x04000076 RID: 118
			private const int DICS_FLAG_GLOBAL = 1;

			// Token: 0x04000077 RID: 119
			private const int DIREG_DEV = 1;

			// Token: 0x04000078 RID: 120
			private const int KEY_READ = 131097;

			// Token: 0x04000079 RID: 121
			private const int ERROR_SUCCESS = 0;

			// Token: 0x0400007A RID: 122
			private static readonly Guid GUID_CLASS_MONITOR = new Guid(1295444334U, 58149, 4558, 191, 193, 8, 0, 43, 225, 3, 24);

			// Token: 0x0400007B RID: 123
			private const int DIGCF_PRESENT = 2;

			// Token: 0x0400007C RID: 124
			private const int ERROR_NO_MORE_ITEMS = 259;

			// Token: 0x02000011 RID: 17
			[Flags]
			private enum DisplayDeviceStateFlags
			{
				// Token: 0x04000082 RID: 130
				AttachedToDesktop = 1,
				// Token: 0x04000083 RID: 131
				MultiDriver = 2,
				// Token: 0x04000084 RID: 132
				PrimaryDevice = 4,
				// Token: 0x04000085 RID: 133
				MirroringDriver = 8,
				// Token: 0x04000086 RID: 134
				VGACompatible = 16,
				// Token: 0x04000087 RID: 135
				Removable = 32,
				// Token: 0x04000088 RID: 136
				ModesPruned = 134217728,
				// Token: 0x04000089 RID: 137
				Remote = 67108864,
				// Token: 0x0400008A RID: 138
				Disconnect = 33554432
			}

			// Token: 0x02000012 RID: 18
			private struct DISPLAY_DEVICE
			{
				// Token: 0x0400008B RID: 139
				[MarshalAs(UnmanagedType.U4)]
				public int cb;

				// Token: 0x0400008C RID: 140
				[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
				public string DeviceName;

				// Token: 0x0400008D RID: 141
				[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
				public string DeviceString;

				// Token: 0x0400008E RID: 142
				[MarshalAs(UnmanagedType.U4)]
				public Edid.EdidUtil.DisplayDeviceStateFlags StateFlags;

				// Token: 0x0400008F RID: 143
				[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
				public string DeviceID;

				// Token: 0x04000090 RID: 144
				[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
				public string DeviceKey;
			}

			// Token: 0x02000013 RID: 19
			private struct SP_DEVINFO_DATA
			{
				// Token: 0x04000091 RID: 145
				public int cbSize;

				// Token: 0x04000092 RID: 146
				public Guid ClassGuid;

				// Token: 0x04000093 RID: 147
				public uint DevInst;

				// Token: 0x04000094 RID: 148
				public IntPtr Reserved;
			}
		}
	}
}
