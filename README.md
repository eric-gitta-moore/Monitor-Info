# 显示器色域检测工具

> 本项目只是出于原理好奇，逆向「显示器色域检测（图拉丁版）」得到的代码，仅供学习交流使用。
> 
> 原版可以下载[图吧工具箱](https://www.tbtool.cn/)使用，此处不做任何形式发行与修改

## 版权所有
显示器色域检测（图拉丁版）

软件作者：九面相柳

软件版本：2.2.1.19629

<img width=50% src='https://github.com/user-attachments/assets/84dd1393-f068-46ca-8605-40af246189fc' /><img width=50% src='https://github.com/user-attachments/assets/25a352fc-d4a9-48e2-a1d0-a744824fd5c5' />


## 实现原理
核心函数主要是下面几个:
- [GetEDID](https://github.com/eric-gitta-moore/Monitor-Info/blob/main/Edid.cs#L35)
- [GetActualEDID](https://github.com/eric-gitta-moore/Monitor-Info/blob/main/Edid.cs#L63)

主要的几个 win32 API:
- [EnumDisplayDevicesA function (winuser.h)](https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumdisplaydevicesa)
- SetupDiGetClassDevsEx
- SetupDiEnumDeviceInfo

## 项目简介

显示器色域检测工具是一款用于检测和分析显示器色彩参数的实用软件。本工具可以读取显示器的EDID信息，分析并显示色域覆盖率、色彩坐标、制造商信息等重要参数，帮助用户了解自己显示器的色彩性能和基本信息。

## 功能特点

- **色域检测**：支持检测显示器的NTSC和sRGB色域覆盖率
- **色彩坐标**：显示RGB三原色和白点的色彩坐标值
- **色域图**：直观展示显示器色域范围的图形化表示
- **制造商信息**：识别并显示显示器制造商名称和产品ID
- **显示器参数**：显示屏幕尺寸、生产日期、EDID版本等信息
- **多显示器支持**：支持检测系统连接的多个显示器

## 系统要求

- 操作系统：Windows
- 运行环境：.NET Framework 4.5或更高版本
- 硬件要求：支持标准EDID协议的显示设备

## 使用方法

1. 运行程序，软件会自动检测当前连接的显示器
2. 如果连接了多个显示器，可以通过下拉菜单选择要检测的显示器
3. 点击"重新检测"按钮可以刷新显示器信息
4. 界面将显示所选显示器的详细信息，包括：
   - RGB三原色坐标值
   - NTSC和sRGB色域覆盖率
   - 颜色模式
   - 屏幕尺寸
   - 制造年份
   - EDID版本
   - 制造商名称和产品ID
5. 点击产品ID旁的"复制"链接可以复制产品ID到剪贴板

## 技术说明

本工具通过读取显示器的EDID（扩展显示识别数据）信息来获取显示器参数。EDID是一种数据结构，包含了显示设备的制造商、产品类型、时序、屏幕尺寸、亮度和色彩特性等信息。

软件使用色彩空间转换算法计算显示器的色域覆盖率，并通过图形化方式展示色域范围，帮助用户直观了解显示器的色彩表现能力。

## 关于

本软件是一款显示器色域检测工具，用于帮助用户了解显示器的色彩性能和基本参数。软件界面简洁直观，操作简单，适合普通用户使用。

## 其他平台类似软件推荐
- https://github.com/jmxl/MonitorInfo
   - 实测 Apple Silicon 内置显示器查不到，但是外置的可以

## 参考
- [DCI-P3 广色域屏 Webkit-logo-P3 测试图](https://v2ex.com/t/622454#r_16034770)
- https://support.touch-base.com/Documentation/50730/EDID-Structure
- [NativeDisplayBrightness/DDC.h](https://github.com/Bensge/NativeDisplayBrightness/blob/master/NativeDisplayBrightness/DDC.h#L77)
- [EDID 内存布局](https://www.cnblogs.com/fire909090/p/10523604.html)
- 核心就是一句命令 `ioreg -lw0 | grep -i "IODisplayEDID" | sed -e 's/.*<//' -e 's/>//'`

010 editor 可以解析出来
<img width="1404" alt="image" src="https://github.com/user-attachments/assets/a4581ab1-91da-462e-8ab0-7d20d6da71f3" />

[AW EDID Editor](https://www.analogway.com/products/aw-edid-editor) 可以直接解析，文件名后缀是 `.bin`，支持 win//mac
<img width="1280" alt="image" src="https://github.com/user-attachments/assets/0231f9d2-0c40-4178-92b9-39e4f7fdf2d5" />
