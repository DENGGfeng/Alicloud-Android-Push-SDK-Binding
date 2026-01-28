# 阿里云移动推送安卓SDK绑定示例

这是一个演示如何在.NET MAUI应用程序中集成阿里云移动推送服务的示例项目。该项目通过Android绑定库实现了对阿里云移动推送Android SDK的封装和调用。

## 项目概述

本项目展示了：
- 如何在.NET MAUI应用中集成阿里云移动推送服务
- 创建Android绑定库来包装原生Android SDK
- 在MAUI应用中处理推送消息接收和处理
- 配置推送服务初始化和注册流程

## 技术栈

- .NET MAUI (.NET 10.0)
- Android绑定库 (Android Binding Library)
- 阿里云移动推送 Android SDK (版本 3.10.1)
- 阿里云AGOO推送框架 (版本 4.9.1-emas)

## 项目结构

```
MsgPush.Maui/
├── AndroidBinding/           # Android绑定库项目
│   ├── AndroidManifest.xml # 绑定库清单文件
│   ├── Transforms/         # 转换配置文件
│   │   ├── EnumFields.xml
│   │   ├── EnumMethods.xml
│   │   └── Metadata.xml
│   └── Additions/          # 附加实现
│       └── AboutAdditions.txt
├── MsgPush.Maui/           # 主MAUI应用程序
│   ├── Platforms/
│   │   └── Android/        # Android特定实现
│   │       ├── MainActivity.cs
│   │       ├── MainApplication.cs
│   │       ├── MessgeCallback.cs
│   │       └── MyMessageReceiver.cs
│   ├── App.xaml
│   ├── App.xaml.cs
│   ├── MauiProgram.cs
│   └── MsgPush.Maui.csproj
└── README.md               # 本说明文件
```

## 功能特性

### 消息接收处理
- 支持通知消息接收（[OnNotification](file:///D:/Code/MauiApp7/MsgPush.Maui/Platforms/Android/MyMessageReceiver.cs#L17-L21)）
- 支持透传消息接收（[OnMessage](file:///D:/Code/MauiApp7/MsgPush.Maui/Platforms/Android/MyMessageReceiver.cs#L23-L31)）
- 支持通知点击事件处理（[OnNotificationClickedWithNoAction](file:///D:/Code/MauiApp7/MsgPush.Maui/Platforms/Android/MyMessageReceiver.cs#L33-L35)）

### 推送服务初始化
- 在[MainApplication](file:///D:/Code/MauiApp7/MsgPush.Maui/Platforms/Android/MainApplication.cs)中完成推送服务初始化
- 自动获取设备ID并注册回调
- 支持调试模式下的日志输出

### 权限配置
- 网络访问权限
- 通知发送权限
- 设备唤醒权限
- 启动完成接收权限

## 配置要求

### 阿里云推送配置
在[AndroidManifest.xml](file:///D:/Code/MauiApp7/MsgPush.Maui/Platforms/Android/AndroidManifest.xml)中配置以下参数：
- `com.alibaba.app.appkey`: 阿里云推送应用Key
- `com.alibaba.app.appsecret`: 阿里云推送应用密钥

### 应用权限
项目已包含以下必要权限：
- `ACCESS_NETWORK_STATE`
- `INTERNET`
- `VIBRATE`
- `POST_NOTIFICATIONS`
- `WAKE_LOCK`
- `RECEIVE_BOOT_COMPLETED`

## 使用方法

1. 克隆或下载本项目
2. 在阿里云控制台创建移动推送应用，获取AppKey和AppSecret
3. 修改`MsgPush.Maui/Platforms/Android/AndroidManifest.xml`中的配置值
4. 构建并运行项目
5. 应用启动后会自动注册推送服务，获取设备ID
6. 可通过阿里云推送控制台向设备发送消息进行测试

## 重要文件说明

- [MainApplication.cs](file:///D:/Code/MauiApp7/MsgPush.Maui/Platforms/Android/MainApplication.cs): 推送服务初始化入口
- [MyMessageReceiver.cs](file:///D:/Code/MauiApp7/MsgPush.Maui/Platforms/Android/MyMessageReceiver.cs): 消息接收处理器
- [MessageCallback.cs](file:///D:/Code/MauiApp7/MsgPush.Maui/Platforms/Android/MessgeCallback.cs): 注册回调处理器
- [AndroidManifest.xml](file:///D:/Code/MauiApp7/MsgPush.Maui/Platforms/Android/AndroidManifest.xml): 应用配置和权限声明
- [AndroidBinding.csproj](file:///D:/Code/MauiApp7/AndroidBinding/AndroidBinding.csproj): 绑定库项目定义

## 注意事项

- 本项目仅支持Android平台的推送功能
- 需要在阿里云开发者控制台配置正确的应用信息
- 生产环境需移除调试日志设置
- 推荐使用最新的阿里云推送SDK版本以获得更好的性能和安全性

## 许可证

本示例代码仅供学习参考使用，实际项目使用请遵循阿里云推送服务的相关协议。