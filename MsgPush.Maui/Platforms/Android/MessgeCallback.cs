using Com.Alibaba.Sdk.Android.Push;

namespace MsgPush.Maui;

public class MessageCallback : Java.Lang.Object, ICommonCallback
{
    public void OnFailed(string? p0, string? p1)
    {
        System.Diagnostics.Debug.WriteLine("MessageCallback:" + p0);
    }

    public void OnSuccess(string? p0)
    {
        System.Diagnostics.Debug.WriteLine("MessageCallback:" + p0);
    }
}