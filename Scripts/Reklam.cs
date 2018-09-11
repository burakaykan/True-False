using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Reklam : MonoBehaviour
{
    void Start()
    {
        /*ReklamGoster();*/
        //RequestBanner();

        BannerView reklamObjesi = new BannerView(
                "ca-app-pub-0595402013240986/9470988812", AdSize.Banner, AdPosition.Top);
        AdRequest reklamiAl = new AdRequest.Builder().Build();
        reklamObjesi.LoadAd(reklamiAl);

    }
    //void ReklamGoster()
    //{

    //    BannerView reklamObjesi = new BannerView(
    //            "ca-app-pub-0595402013240986/9470988812", AdSize.Banner, AdPosition.Top);
    //    AdRequest reklamiAl = new AdRequest.Builder().Build();
    //    reklamObjesi.LoadAd(reklamiAl);
    //    reklamObjesi.Show();
    //}
//    private void RequestBanner()
//    {
//#if UNITY_EDITOR
//        string adUnitId = "unused";
//#elif UNITY_ANDROID
//        string adUnitId = "ca-app-pub-0595402013240986/9470988812";
//#else
//        string adUnitId = "unexpected_platform";
//#endif

//        // Create a 320x50 banner at the top of the screen.
//        BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
//        // Create an empty ad request.
//        AdRequest request = new AdRequest.Builder().Build();
//        // Load the banner with the request.
//        bannerView.LoadAd(request);
//        bannerView.Show();
//    }
}