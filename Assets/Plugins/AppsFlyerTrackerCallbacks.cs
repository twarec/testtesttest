﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AppsFlyerTrackerCallbacks : MonoBehaviour {

    public UnityEngine.UI.Text text;
    public static bool IsActive = false;
    public static System.Action ALounch;
	// Use this for initialization
	void Start () {
		printCallback("AppsFlyerTrackerCallbacks on Start");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void didReceiveConversionData(string conversionData) {
		printCallback ("AppsFlyerTrackerCallbacks:: got conversion data = " + conversionData);
	}
	
	public void didReceiveConversionDataWithError(string error) {
		printCallback ("AppsFlyerTrackerCallbacks:: got conversion data error = " + error);
	}
	
	public void didFinishValidateReceipt(string validateResult) {
		printCallback ("AppsFlyerTrackerCallbacks:: got didFinishValidateReceipt  = " + validateResult);
		
	}
	
	public void didFinishValidateReceiptWithError (string error) {
		printCallback ("AppsFlyerTrackerCallbacks:: got idFinishValidateReceiptWithError error = " + error);
		
	}
	
	public void onAppOpenAttribution(string validateResult) {
		printCallback ("AppsFlyerTrackerCallbacks:: got onAppOpenAttribution  = " + validateResult);
		
	}
	
	public void onAppOpenAttributionFailure (string error) {
		printCallback ("AppsFlyerTrackerCallbacks:: got onAppOpenAttributionFailure error = " + error);
		
	}
	
	public void onInAppBillingSuccess () {
		printCallback ("AppsFlyerTrackerCallbacks:: got onInAppBillingSuccess succcess");
		
	}
	public void onInAppBillingFailure (string error) {
		printCallback ("AppsFlyerTrackerCallbacks:: got onInAppBillingFailure error = " + error);
		
	}

	public void onInviteLinkGenerated (string link) {
		printCallback("AppsFlyerTrackerCallbacks:: generated userInviteLink "+link);
	}

	void printCallback(string str) {
		Debug.Log(str);
        if(text)
            text.text = str;
        if (!IsActive)
        {
            IsActive = true;
            ALounch?.Invoke();
        }
	}
}
