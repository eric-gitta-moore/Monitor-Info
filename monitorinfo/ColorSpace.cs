using System;

namespace monitorinfo
{
	// Token: 0x02000004 RID: 4
	internal class ColorSpace
	{
		// Token: 0x0600000E RID: 14 RVA: 0x00002330 File Offset: 0x00000530
		public void xyz_to_rgb(double xc, double yc, double zc, ref double r, ref double g, ref double b)
		{
			double num = ColorSpace.xRed;
			double num2 = ColorSpace.yRed;
			double num3 = 1.0 - (num + num2);
			double num4 = ColorSpace.xGreen;
			double num5 = ColorSpace.yGreen;
			double num6 = 1.0 - (num4 + num5);
			double num7 = ColorSpace.xBlue;
			double num8 = ColorSpace.yBlue;
			double num9 = 1.0 - (num7 + num8);
			double num10 = this.xW_E;
			double num11 = this.yW_E;
			double num12 = 1.0 - (num10 + num11);
			double num13 = num5 * num9 - num8 * num6;
			double num14 = num7 * num6 - num4 * num9;
			double num15 = num4 * num8 - num7 * num5;
			double num16 = num8 * num3 - num2 * num9;
			double num17 = num * num9 - num7 * num3;
			double num18 = num7 * num2 - num * num8;
			double num19 = num2 * num6 - num5 * num3;
			double num20 = num4 * num3 - num * num6;
			double num21 = num * num5 - num4 * num2;
			double num22 = (num13 * num10 + num14 * num11 + num15 * num12) / num11;
			double num23 = (num16 * num10 + num17 * num11 + num18 * num12) / num11;
			double num24 = (num19 * num10 + num20 * num11 + num21 * num12) / num11;
			num13 /= num22;
			num14 /= num22;
			num15 /= num22;
			num16 /= num23;
			num17 /= num23;
			num18 /= num23;
			num19 /= num24;
			num20 /= num24;
			num21 /= num24;
			r = num13 * xc + num14 * yc + num15 * zc;
			g = num16 * xc + num17 * yc + num18 * zc;
			b = num19 * xc + num20 * yc + num21 * zc;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000024D0 File Offset: 0x000006D0
		public void xyz_to_rgb_ERIC(double xc, double yc, double zc, ref double r, ref double g, ref double b)
		{
			this.rx = ColorSpace.yGreen * ColorSpace.zBlue - ColorSpace.yBlue * ColorSpace.zGreen;
			this.ry = ColorSpace.xBlue * ColorSpace.zGreen - ColorSpace.xGreen * ColorSpace.zBlue;
			this.rz = ColorSpace.xGreen * ColorSpace.yBlue - ColorSpace.xBlue * ColorSpace.yGreen;
			this.gx = ColorSpace.yBlue * ColorSpace.zRed - ColorSpace.yRed * ColorSpace.zBlue;
			this.gy = ColorSpace.xRed * ColorSpace.zBlue - ColorSpace.xBlue * ColorSpace.zRed;
			this.gz = ColorSpace.xBlue * ColorSpace.yRed - ColorSpace.xRed * ColorSpace.yBlue;
			this.bx = ColorSpace.yRed * ColorSpace.zGreen - ColorSpace.yGreen * ColorSpace.zRed;
			this.by = ColorSpace.xGreen * ColorSpace.zRed - ColorSpace.xRed * ColorSpace.zGreen;
			this.bz = ColorSpace.xRed * ColorSpace.yGreen - ColorSpace.xGreen * ColorSpace.yRed;
			this.rW_E = (this.rx * this.xW_E + this.ry * this.yW_E + this.rz * this.zW_E) / this.yW_E;
			this.gW_E = (this.gx * this.xW_E + this.gy * this.yW_E + this.gz * this.zW_E) / this.yW_E;
			this.bW_E = (this.bx * this.xW_E + this.by * this.yW_E + this.bz * this.zW_E) / this.yW_E;
			this.rx /= this.rW_E;
			this.ry /= this.rW_E;
			this.rz /= this.rW_E;
			this.gx /= this.gW_E;
			this.gy /= this.gW_E;
			this.gz /= this.gW_E;
			this.bx /= this.bW_E;
			this.by /= this.bW_E;
			this.bz /= this.bW_E;
			r = this.rx * xc + this.ry * yc + this.rz * zc;
			g = this.gx * xc + this.gy * yc + this.gz * zc;
			b = this.bx * xc + this.by * yc + this.bz * zc;
			if (r <= 0.0031308)
			{
				r *= 12.92;
			}
			else
			{
				r = 1.055 * Math.Pow(r, 0.4166666666666667) - 0.055;
			}
			if (g <= 0.0031308)
			{
				g *= 12.92;
			}
			else
			{
				g = 1.055 * Math.Pow(g, 0.4166666666666667) - 0.055;
			}
			if (b <= 0.0031308)
			{
				b *= 12.92;
			}
			else
			{
				b = 1.055 * Math.Pow(b, 0.4166666666666667) - 0.55;
			}
			if (r < g && r < b)
			{
				double num = this.rW_E / (this.rW_E - r);
				return;
			}
			if (g < r && g < b)
			{
				double num2 = this.gW_E / (this.gW_E - g);
				return;
			}
			double num3 = this.bW_E / (this.bW_E - b);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000028B8 File Offset: 0x00000AB8
		public void intialXYZtoRGBPara()
		{
			this.XRPara[0] = 0.41847;
			this.XRPara[1] = -0.15866;
			this.XRPara[2] = -0.082835;
			this.YGPara[0] = -0.091169;
			this.YGPara[1] = 0.25243;
			this.YGPara[2] = 0.015708;
			this.ZBPara[0] = 0.0009209;
			this.ZBPara[1] = -0.0025498;
			this.ZBPara[2] = 0.1786;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002960 File Offset: 0x00000B60
		public void InitialXbar()
		{
			this.arrXbar[0] = 0.17556;
			this.arrXbar[1] = 0.175161;
			this.arrXbar[2] = 0.174821;
			this.arrXbar[3] = 0.17451;
			this.arrXbar[4] = 0.174112;
			this.arrXbar[5] = 0.174008;
			this.arrXbar[6] = 0.173801;
			this.arrXbar[7] = 0.17356;
			this.arrXbar[8] = 0.173337;
			this.arrXbar[9] = 0.173021;
			this.arrXbar[10] = 0.172577;
			this.arrXbar[11] = 0.172087;
			this.arrXbar[12] = 0.171407;
			this.arrXbar[13] = 0.170301;
			this.arrXbar[14] = 0.168878;
			this.arrXbar[15] = 0.166895;
			this.arrXbar[16] = 0.164412;
			this.arrXbar[17] = 0.161105;
			this.arrXbar[18] = 0.156641;
			this.arrXbar[19] = 0.150985;
			this.arrXbar[20] = 0.14396;
			this.arrXbar[21] = 0.135503;
			this.arrXbar[22] = 0.124118;
			this.arrXbar[23] = 0.109594;
			this.arrXbar[24] = 0.091294;
			this.arrXbar[25] = 0.068706;
			this.arrXbar[26] = 0.045391;
			this.arrXbar[27] = 0.02346;
			this.arrXbar[28] = 0.008168;
			this.arrXbar[29] = 0.003859;
			this.arrXbar[30] = 0.01387;
			this.arrXbar[31] = 0.038852;
			this.arrXbar[32] = 0.074302;
			this.arrXbar[33] = 0.114161;
			this.arrXbar[34] = 0.154722;
			this.arrXbar[35] = 0.192876;
			this.arrXbar[36] = 0.22962;
			this.arrXbar[37] = 0.265775;
			this.arrXbar[38] = 0.301604;
			this.arrXbar[39] = 0.337363;
			this.arrXbar[40] = 0.373102;
			this.arrXbar[41] = 0.408736;
			this.arrXbar[42] = 0.444062;
			this.arrXbar[43] = 0.478775;
			this.arrXbar[44] = 0.512486;
			this.arrXbar[45] = 0.544787;
			this.arrXbar[46] = 0.575151;
			this.arrXbar[47] = 0.602933;
			this.arrXbar[48] = 0.627037;
			this.arrXbar[49] = 0.648233;
			this.arrXbar[50] = 0.665764;
			this.arrXbar[51] = 0.680079;
			this.arrXbar[52] = 0.691504;
			this.arrXbar[53] = 0.700606;
			this.arrXbar[54] = 0.707918;
			this.arrXbar[55] = 0.714032;
			this.arrXbar[56] = 0.719033;
			this.arrXbar[57] = 0.723032;
			this.arrXbar[58] = 0.725992;
			this.arrXbar[59] = 0.728272;
			this.arrXbar[60] = 0.729969;
			this.arrXbar[61] = 0.731089;
			this.arrXbar[62] = 0.731993;
			this.arrXbar[63] = 0.732719;
			this.arrXbar[64] = 0.733417;
			this.arrXbar[65] = 0.734047;
			this.arrXbar[66] = 0.73439;
			this.arrXbar[67] = 0.734592;
			this.arrXbar[68] = 0.73469;
			this.arrXbar[69] = 0.73469;
			this.arrXbar[70] = 0.73469;
			this.arrXbar[71] = 0.734548;
			this.arrXbar[72] = 0.73469;
			this.arrXbar[73] = 0.73469;
			this.arrXbar[74] = 0.73469;
			this.arrXbar[75] = 0.73469;
			this.arrXbar[76] = 0.73469;
			this.arrXbar[77] = 0.73469;
			this.arrXbar[78] = 0.73469;
			this.arrXbar[79] = 0.73469;
			this.arrXbar[80] = 0.73469;
			this.arrXbar[81] = 0.73469;
			this.arrXbar[82] = 0.73469;
			this.arrXbar[83] = 0.73469;
			this.arrXbar[84] = 0.73469;
			this.arrXbar[85] = 0.73469;
			this.arrXbar[86] = 0.73469;
			this.arrXbar[87] = 0.73469;
			this.arrXbar[88] = 0.73469;
			this.arrXbar[89] = 0.73469;
			this.arrXbar[90] = 0.73469;
			this.arrXbar[91] = 0.73469;
			this.arrXbar[92] = 0.73469;
			this.arrXbar[93] = 0.73469;
			this.arrXbar[94] = 0.73469;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00003014 File Offset: 0x00001214
		public void InitialYbar()
		{
			this.arrYbar[0] = 0.005294;
			this.arrYbar[1] = 0.005256;
			this.arrYbar[2] = 0.005221;
			this.arrYbar[3] = 0.005182;
			this.arrYbar[4] = 0.004964;
			this.arrYbar[5] = 0.004981;
			this.arrYbar[6] = 0.004915;
			this.arrYbar[7] = 0.004923;
			this.arrYbar[8] = 0.004797;
			this.arrYbar[9] = 0.004775;
			this.arrYbar[10] = 0.004799;
			this.arrYbar[11] = 0.004833;
			this.arrYbar[12] = 0.005102;
			this.arrYbar[13] = 0.005789;
			this.arrYbar[14] = 0.0069;
			this.arrYbar[15] = 0.008556;
			this.arrYbar[16] = 0.010858;
			this.arrYbar[17] = 0.013793;
			this.arrYbar[18] = 0.017705;
			this.arrYbar[19] = 0.02274;
			this.arrYbar[20] = 0.029703;
			this.arrYbar[21] = 0.039879;
			this.arrYbar[22] = 0.057803;
			this.arrYbar[23] = 0.086843;
			this.arrYbar[24] = 0.132702;
			this.arrYbar[25] = 0.200723;
			this.arrYbar[26] = 0.294976;
			this.arrYbar[27] = 0.412703;
			this.arrYbar[28] = 0.538423;
			this.arrYbar[29] = 0.654823;
			this.arrYbar[30] = 0.750186;
			this.arrYbar[31] = 0.812016;
			this.arrYbar[32] = 0.833803;
			this.arrYbar[33] = 0.826207;
			this.arrYbar[34] = 0.805864;
			this.arrYbar[35] = 0.781629;
			this.arrYbar[36] = 0.754329;
			this.arrYbar[37] = 0.724324;
			this.arrYbar[38] = 0.692308;
			this.arrYbar[39] = 0.658848;
			this.arrYbar[40] = 0.624451;
			this.arrYbar[41] = 0.589607;
			this.arrYbar[42] = 0.554714;
			this.arrYbar[43] = 0.520202;
			this.arrYbar[44] = 0.486591;
			this.arrYbar[45] = 0.454434;
			this.arrYbar[46] = 0.424232;
			this.arrYbar[47] = 0.396497;
			this.arrYbar[48] = 0.372491;
			this.arrYbar[49] = 0.351395;
			this.arrYbar[50] = 0.334011;
			this.arrYbar[51] = 0.319747;
			this.arrYbar[52] = 0.308342;
			this.arrYbar[53] = 0.299301;
			this.arrYbar[54] = 0.292027;
			this.arrYbar[55] = 0.285929;
			this.arrYbar[56] = 0.280935;
			this.arrYbar[57] = 0.276948;
			this.arrYbar[58] = 0.274008;
			this.arrYbar[59] = 0.271728;
			this.arrYbar[60] = 0.270031;
			this.arrYbar[61] = 0.268911;
			this.arrYbar[62] = 0.268007;
			this.arrYbar[63] = 0.267281;
			this.arrYbar[64] = 0.266583;
			this.arrYbar[65] = 0.265953;
			this.arrYbar[66] = 0.26561;
			this.arrYbar[67] = 0.265408;
			this.arrYbar[68] = 0.26531;
			this.arrYbar[69] = 0.26531;
			this.arrYbar[70] = 0.26531;
			this.arrYbar[71] = 0.265452;
			this.arrYbar[72] = 0.26531;
			this.arrYbar[73] = 0.26531;
			this.arrYbar[74] = 0.26531;
			this.arrYbar[75] = 0.26531;
			this.arrYbar[76] = 0.26531;
			this.arrYbar[77] = 0.26531;
			this.arrYbar[78] = 0.26531;
			this.arrYbar[79] = 0.26531;
			this.arrYbar[80] = 0.26531;
			this.arrYbar[81] = 0.26531;
			this.arrYbar[82] = 0.26531;
			this.arrYbar[83] = 0.26531;
			this.arrYbar[84] = 0.26531;
			this.arrYbar[85] = 0.26531;
			this.arrYbar[86] = 0.26531;
			this.arrYbar[87] = 0.26531;
			this.arrYbar[88] = 0.26531;
			this.arrYbar[89] = 0.26531;
			this.arrYbar[90] = 0.26531;
			this.arrYbar[91] = 0.26531;
			this.arrYbar[92] = 0.26531;
			this.arrYbar[93] = 0.26531;
			this.arrYbar[94] = 0.26531;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000036C8 File Offset: 0x000018C8
		public void InitialZbar()
		{
			this.arrZbar[0] = 0.819146;
			this.arrZbar[1] = 0.819582;
			this.arrZbar[2] = 0.819959;
			this.arrZbar[3] = 0.820309;
			this.arrZbar[4] = 0.820924;
			this.arrZbar[5] = 0.821012;
			this.arrZbar[6] = 0.821284;
			this.arrZbar[7] = 0.821517;
			this.arrZbar[8] = 0.821866;
			this.arrZbar[9] = 0.822204;
			this.arrZbar[10] = 0.822624;
			this.arrZbar[11] = 0.823081;
			this.arrZbar[12] = 0.82349;
			this.arrZbar[13] = 0.823911;
			this.arrZbar[14] = 0.824222;
			this.arrZbar[15] = 0.824549;
			this.arrZbar[16] = 0.824731;
			this.arrZbar[17] = 0.825102;
			this.arrZbar[18] = 0.825654;
			this.arrZbar[19] = 0.826274;
			this.arrZbar[20] = 0.826337;
			this.arrZbar[21] = 0.824618;
			this.arrZbar[22] = 0.818079;
			this.arrZbar[23] = 0.803563;
			this.arrZbar[24] = 0.776004;
			this.arrZbar[25] = 0.730571;
			this.arrZbar[26] = 0.659633;
			this.arrZbar[27] = 0.563837;
			this.arrZbar[28] = 0.453409;
			this.arrZbar[29] = 0.341318;
			this.arrZbar[30] = 0.235943;
			this.arrZbar[31] = 0.149132;
			this.arrZbar[32] = 0.091894;
			this.arrZbar[33] = 0.059632;
			this.arrZbar[34] = 0.039414;
			this.arrZbar[35] = 0.025495;
			this.arrZbar[36] = 0.016051;
			this.arrZbar[37] = 0.009901;
			this.arrZbar[38] = 0.006088;
			this.arrZbar[39] = 0.003788;
			this.arrZbar[40] = 0.002448;
			this.arrZbar[41] = 0.001657;
			this.arrZbar[42] = 0.001224;
			this.arrZbar[43] = 0.001023;
			this.arrZbar[44] = 0.000923;
			this.arrZbar[45] = 0.000779;
			this.arrZbar[46] = 0.000616;
			this.arrZbar[47] = 0.000571;
			this.arrZbar[48] = 0.000472;
			this.arrZbar[49] = 0.000372;
			this.arrZbar[50] = 0.000226;
			this.arrZbar[51] = 0.000174;
			this.arrZbar[52] = 0.000154;
			this.arrZbar[53] = 9.3E-05;
			this.arrZbar[54] = 5.5E-05;
			this.arrZbar[55] = 4E-05;
			this.arrZbar[56] = 3.2E-05;
			this.arrZbar[57] = 2E-05;
			this.arrZbar[58] = 0.0;
			this.arrZbar[59] = 0.0;
			this.arrZbar[60] = 0.0;
			this.arrZbar[61] = 0.0;
			this.arrZbar[62] = 0.0;
			this.arrZbar[63] = 0.0;
			this.arrZbar[64] = 0.0;
			this.arrZbar[65] = 0.0;
			this.arrZbar[66] = 0.0;
			this.arrZbar[67] = 0.0;
			this.arrZbar[68] = 0.0;
			this.arrZbar[69] = 0.0;
			this.arrZbar[70] = 0.0;
			this.arrZbar[71] = 0.0;
			this.arrZbar[72] = 0.0;
			this.arrZbar[73] = 0.0;
			this.arrZbar[74] = 0.0;
			this.arrZbar[75] = 0.0;
			this.arrZbar[76] = 0.0;
			this.arrZbar[77] = 0.0;
			this.arrZbar[78] = 0.0;
			this.arrZbar[79] = 0.0;
			this.arrZbar[80] = 0.0;
			this.arrZbar[81] = 0.0;
			this.arrZbar[82] = 0.0;
			this.arrZbar[83] = 0.0;
			this.arrZbar[84] = 0.0;
			this.arrZbar[85] = 0.0;
			this.arrZbar[86] = 0.0;
			this.arrZbar[87] = 0.0;
			this.arrZbar[88] = 0.0;
			this.arrZbar[89] = 0.0;
			this.arrZbar[90] = 0.0;
			this.arrZbar[91] = 0.0;
			this.arrZbar[92] = 0.0;
			this.arrZbar[93] = 0.0;
			this.arrZbar[94] = 0.0;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00003D7C File Offset: 0x00001F7C
		public void CalRGB(double x, double y, double z, ref double R, ref double G, ref double B)
		{
			R = this.XRPara[0] * x + this.XRPara[1] * y + this.XRPara[2] * z;
			G = this.YGPara[0] * x + this.YGPara[1] * y + this.YGPara[2] * z;
			B = this.ZBPara[0] * x + this.ZBPara[1] * y + this.ZBPara[2] * z;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003DF4 File Offset: 0x00001FF4
		public void XYZtoRGB(double[] x, double[] y, double[] z, ref double[] R, ref double[] G, ref double[] B, int nLen)
		{
			if (nLen > 0)
			{
				for (int i = 0; i < nLen; i++)
				{
					this.xyz_to_rgb(x[i], y[i], z[i], ref R[i], ref G[i], ref B[i]);
				}
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003E40 File Offset: 0x00002040
		public void RGBSpace(ref double[] r, ref double[] g, ref double[] b)
		{
			double[] array = new double[1000];
			double[] array2 = new double[1000];
			double[] array3 = new double[1000];
			double[] array4 = new double[1000];
			double[] array5 = new double[1000];
			double[] array6 = new double[1000];
			for (int i = 0; i < 1000; i++)
			{
				array[i] = (double)i / 1000.0;
				array2[i] = (double)i / 1000.0;
				array3[i] = 1.0 - array[i] - array2[i];
			}
			this.XYZtoRGB(array, array2, array3, ref array4, ref array5, ref array6, 1000);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00003EF4 File Offset: 0x000020F4
		public int constrain_rgb(ref double r, ref double g, ref double b)
		{
			double num = (0.0 < r) ? 0.0 : r;
			num = ((num < g) ? num : g);
			num = ((num < b) ? num : b);
			num = -num;
			if (num > 0.0)
			{
				r += num;
				g += num;
				b += num;
				return 1;
			}
			return 0;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003F58 File Offset: 0x00002158
		public void norm_rgb(ref double r, ref double g, ref double b)
		{
			double num = Math.Max(r, Math.Max(g, b));
			if (num > 0.0)
			{
				r /= num;
				g /= num;
				b /= num;
			}
		}

		// Token: 0x04000008 RID: 8
		private static double IlluminatC_x = 0.3101;

		// Token: 0x04000009 RID: 9
		private static double IlluminatC_y = 0.3162;

		// Token: 0x0400000A RID: 10
		private static double IlluminatD65_x = 0.3127;

		// Token: 0x0400000B RID: 11
		private static double IlluminatD65_y = 0.3291;

		// Token: 0x0400000C RID: 12
		public double xW_E = 0.33333333;

		// Token: 0x0400000D RID: 13
		public double yW_E = 0.33333333;

		// Token: 0x0400000E RID: 14
		public double zW_E = 0.33333333;

		// Token: 0x0400000F RID: 15
		private static double xRed = 0.7355;

		// Token: 0x04000010 RID: 16
		private static double yRed = 0.2645;

		// Token: 0x04000011 RID: 17
		private static double zRed = 1.0 - ColorSpace.xRed - ColorSpace.yRed;

		// Token: 0x04000012 RID: 18
		private static double xGreen = 0.2658;

		// Token: 0x04000013 RID: 19
		private static double yGreen = 0.7243;

		// Token: 0x04000014 RID: 20
		private static double zGreen = 1.0 - ColorSpace.xGreen - ColorSpace.yGreen;

		// Token: 0x04000015 RID: 21
		private static double xBlue = 0.1669;

		// Token: 0x04000016 RID: 22
		private static double yBlue = 0.0085;

		// Token: 0x04000017 RID: 23
		private static double zBlue = 1.0 - ColorSpace.xBlue - ColorSpace.yBlue;

		// Token: 0x04000018 RID: 24
		public double rx;

		// Token: 0x04000019 RID: 25
		public double ry;

		// Token: 0x0400001A RID: 26
		public double rz;

		// Token: 0x0400001B RID: 27
		public double gx;

		// Token: 0x0400001C RID: 28
		public double gy;

		// Token: 0x0400001D RID: 29
		public double gz;

		// Token: 0x0400001E RID: 30
		public double bx;

		// Token: 0x0400001F RID: 31
		public double by;

		// Token: 0x04000020 RID: 32
		public double bz;

		// Token: 0x04000021 RID: 33
		public double rW_E;

		// Token: 0x04000022 RID: 34
		public double gW_E;

		// Token: 0x04000023 RID: 35
		public double bW_E;

		// Token: 0x04000024 RID: 36
		private const int COLOR_LENGTH = 95;

		// Token: 0x04000025 RID: 37
		public double GAMMA_REC709;

		// Token: 0x04000026 RID: 38
		public double[] arrXbar = new double[95];

		// Token: 0x04000027 RID: 39
		public double[] arrYbar = new double[95];

		// Token: 0x04000028 RID: 40
		public double[] arrZbar = new double[95];

		// Token: 0x04000029 RID: 41
		public double[] arrR = new double[95];

		// Token: 0x0400002A RID: 42
		public double[] arrG = new double[95];

		// Token: 0x0400002B RID: 43
		public double[] arrB = new double[95];

		// Token: 0x0400002C RID: 44
		public double[] XRPara = new double[3];

		// Token: 0x0400002D RID: 45
		public double[] YGPara = new double[3];

		// Token: 0x0400002E RID: 46
		public double[] ZBPara = new double[3];

		// Token: 0x0400002F RID: 47
		private double[] x = new double[1000];

		// Token: 0x04000030 RID: 48
		private double[] y = new double[1000];

		// Token: 0x04000031 RID: 49
		private double[] z = new double[1000];

		// Token: 0x04000032 RID: 50
		private double[] R_Ori = new double[1000];

		// Token: 0x04000033 RID: 51
		private double[] G_Ori = new double[1000];

		// Token: 0x04000034 RID: 52
		private double[] B_Ori = new double[1000];

		// Token: 0x04000035 RID: 53
		public double[,] spectral_chromaticity = new double[,]
		{
			{
				0.1741,
				0.005
			},
			{
				0.174,
				0.005
			},
			{
				0.1738,
				0.0049
			},
			{
				0.1736,
				0.0049
			},
			{
				0.1733,
				0.0048
			},
			{
				0.173,
				0.0048
			},
			{
				0.1726,
				0.0048
			},
			{
				0.1721,
				0.0048
			},
			{
				0.1714,
				0.0051
			},
			{
				0.1703,
				0.0058
			},
			{
				0.1689,
				0.0069
			},
			{
				0.1669,
				0.0086
			},
			{
				0.1644,
				0.0109
			},
			{
				0.1611,
				0.0138
			},
			{
				0.1566,
				0.0177
			},
			{
				0.151,
				0.0227
			},
			{
				0.144,
				0.0297
			},
			{
				0.1355,
				0.0399
			},
			{
				0.1241,
				0.0578
			},
			{
				0.1096,
				0.0868
			},
			{
				0.0913,
				0.1327
			},
			{
				0.0687,
				0.2007
			},
			{
				0.0454,
				0.295
			},
			{
				0.0235,
				0.4127
			},
			{
				0.0082,
				0.5384
			},
			{
				0.0039,
				0.6548
			},
			{
				0.0139,
				0.7502
			},
			{
				0.0389,
				0.812
			},
			{
				0.0743,
				0.8338
			},
			{
				0.1142,
				0.8262
			},
			{
				0.1547,
				0.8059
			},
			{
				0.1929,
				0.7816
			},
			{
				0.2296,
				0.7543
			},
			{
				0.2658,
				0.7243
			},
			{
				0.3016,
				0.6923
			},
			{
				0.3373,
				0.6589
			},
			{
				0.3731,
				0.6245
			},
			{
				0.4087,
				0.5896
			},
			{
				0.4441,
				0.5547
			},
			{
				0.4788,
				0.5202
			},
			{
				0.5125,
				0.4866
			},
			{
				0.5448,
				0.4544
			},
			{
				0.5752,
				0.4242
			},
			{
				0.6029,
				0.3965
			},
			{
				0.627,
				0.3725
			},
			{
				0.6482,
				0.3514
			},
			{
				0.6658,
				0.334
			},
			{
				0.6801,
				0.3197
			},
			{
				0.6915,
				0.3083
			},
			{
				0.7006,
				0.2993
			},
			{
				0.7079,
				0.292
			},
			{
				0.714,
				0.2859
			},
			{
				0.719,
				0.2809
			},
			{
				0.723,
				0.277
			},
			{
				0.726,
				0.274
			},
			{
				0.7283,
				0.2717
			},
			{
				0.73,
				0.27
			},
			{
				0.7311,
				0.2689
			},
			{
				0.732,
				0.268
			},
			{
				0.7327,
				0.2673
			},
			{
				0.7334,
				0.2666
			},
			{
				0.734,
				0.266
			},
			{
				0.7344,
				0.2656
			},
			{
				0.7346,
				0.2654
			},
			{
				0.7347,
				0.2653
			},
			{
				0.7347,
				0.2653
			},
			{
				0.7347,
				0.2653
			},
			{
				0.7347,
				0.2653
			},
			{
				0.7347,
				0.2653
			},
			{
				0.7347,
				0.2653
			},
			{
				0.7347,
				0.2653
			},
			{
				0.7347,
				0.2653
			},
			{
				0.7347,
				0.2653
			},
			{
				0.7347,
				0.2653
			},
			{
				0.7347,
				0.2653
			},
			{
				0.7347,
				0.2653
			},
			{
				0.7347,
				0.2653
			},
			{
				0.7347,
				0.2653
			},
			{
				0.7347,
				0.2653
			},
			{
				0.7347,
				0.2653
			},
			{
				0.7347,
				0.2653
			}
		};
	}
}
