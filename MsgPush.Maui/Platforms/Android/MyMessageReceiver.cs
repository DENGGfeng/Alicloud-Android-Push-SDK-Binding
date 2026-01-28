using Android.Content;
using Android.App; 

namespace MsgPush.Maui;

[BroadcastReceiver(
    Name = "com.companyname.mauiapp7.MyMessageReceiver",
    Exported = true,
    Enabled = true)]
[IntentFilter([
    "com.alibaba.push2.action.NOTIFICATION_OPENED",
    "com.alibaba.push2.action.NOTIFICATION_REMOVED",
    "com.alibaba.sdk.android.push.RECEIVE"
])]
public class MyMessageReceiver : Com.Alibaba.Sdk.Android.Push.MessageReceiver
{
    protected override void OnNotification(Android.Content.Context? context, string? title, string? body, global::System.Collections.Generic.IDictionary<string, string>? extMap)
    {
        System.Diagnostics.Debug.WriteLine($"收到通知: {title} - {body}");
        // 处理通知消息
    }

    protected override void OnMessage(Android.Content.Context? context, Com.Alibaba.Sdk.Android.Push.Notification.CPushMessage? cPushMessage)
    {
        System.Diagnostics.Debug.WriteLine("收到透传消息");
        // 处理透传消息
        if (cPushMessage != null)
        {
            System.Diagnostics.Debug.WriteLine($"Title: {cPushMessage.Title}, Body: {cPushMessage.Content}");
        }
    }

    protected override void OnNotificationClickedWithNoAction(Android.Content.Context? context, string? title, string? body, string? extras)
    {
        System.Diagnostics.Debug.WriteLine($"点击通知: {title} - {body}");
        // 处理通知点击事件
    }

    protected override void OnNotificationOpened(Android.Content.Context? context, string? title, string? body, string? extras)
    {
        System.Diagnostics.Debug.WriteLine($"打开通知: {title} - {body}");
        // 处理通知打开事件
    }

    protected override void OnNotificationReceivedInApp(Android.Content.Context? context, string? title, string? body, global::System.Collections.Generic.IDictionary<string, string>? extMap, int openedNotifyId, string? notifyType, string? notifyId)
    {
        System.Diagnostics.Debug.WriteLine($"应用内收到通知: {title} - {body}");
        // 处理应用内通知
    }

    protected override void OnNotificationRemoved(Android.Content.Context? context, string? messageId)
    {
        System.Diagnostics.Debug.WriteLine($"移除通知: {messageId}");
        // 处理通知移除事件
    }
}