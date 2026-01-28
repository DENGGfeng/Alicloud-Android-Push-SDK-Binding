using Android.App;
using Android.Runtime;
using Com.Alibaba.Sdk.Android.Push;
using Com.Alibaba.Sdk.Android.Push.Noonesdk;

namespace MsgPush.Maui
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }
        
        public override void OnCreate()
        {
            base.OnCreate();
            PushInitConfig pushInitConfig = new PushInitConfig.Builder()
                .Application(this)
                .DisableChannelProcess(false)
                .DisableChannelProcessHeartbeat(false)
                .Build();
            PushServiceFactory.Init(pushInitConfig);
            
            var pushService = PushServiceFactory.CloudPushService;
            var deviceId = pushService.DeviceId;
            System.Diagnostics.Debug.WriteLine($"Device ID: {deviceId}");
            pushService.Register(this, new MessageCallback());
#if DEBUG
            //仅适用于Debug包，正式包不需要此行
            pushService.SetLogLevel(ICloudPushService.LogDebug);
#endif
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
