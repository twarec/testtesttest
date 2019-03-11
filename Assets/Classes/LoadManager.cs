using Facebook.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{

    private UniWebView WebWiew;


    public UnityEngine.UI.Text text;

    private void Awake()
    { 
        ConnectAppsFlayer();
        CreateAndOpenWebView("https://mail.ru/");
        FacebookInit();

    }

    void DeepLinkCallback(IAppLinkResult result)
    {
        if (!String.IsNullOrEmpty(result.Url))
        {
            if (result.Url.EndsWith("google"))
            {
                CreateAndOpenWebView("https://www.google.ru/");
            }
            if (result.Url.EndsWith("yandex"))
            {
                CreateAndOpenWebView("https://yandex.ru/");
            }
        }
    }

    private void FacebookInit()
    {
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
            LogIAmWprkingEvent("Yura", "Guguev", 1);
            FB.GetAppLink(DeepLinkCallback);
        }
        else
        {
            FB.Init(() =>
            {
                FB.ActivateApp();
                LogIAmWprkingEvent("Yura", "Guguev", 1);
                FB.GetAppLink(DeepLinkCallback);
            });
        }

       
    }

    public void LogIAmWprkingEvent(string name, string lastName, double valToSum)
    {
        var parameters = new Dictionary<string, object>();
        parameters["Name"] = name;
        parameters["LastName"] = lastName;
        FB.LogAppEvent(
            "I am wprking",
            (float)valToSum,
            parameters
        );
    }

    private void ConnectAppsFlayer()
    {
        AppsFlyer.setAppsFlyerKey("ifZ9pXj7gsWDMy9NMWArJW");
        AppsFlyer.setAppID("com.adwa.adwda");
        AppsFlyer.init("ifZ9pXj7gsWDMy9NMWArJW", "AppsFlyerTrackerCallbacks");

        AppsFlyerTrackerCallbacks.ALounch += () =>
        {
            Dictionary<string, string> purchaseEvent = new Dictionary<string, string>
            {
                ["Name"] = "Yura"
            };
            AppsFlyer.trackRichEvent("I am working", purchaseEvent);
        };



    }

    private void CreateAndOpenWebView(string url)
    {
        if(!WebWiew)
            WebWiew = new GameObject("UWV").AddComponent<UniWebView>();

        WebWiew.OnLoadComplete += OnLoadComplete;

        WebWiew.toolBarShow = true;
        WebWiew.url = url;
        WebWiew.Load();
    }

    private void OnLoadComplete(UniWebView webView, bool success, string errorMessage)
    {
        if (success) webView.Show();
    }
}
