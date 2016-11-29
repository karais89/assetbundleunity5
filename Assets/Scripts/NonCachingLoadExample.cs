using System;
using UnityEngine;
using System.Collections;

class NonCachingLoadExample : MonoBehaviour
{
    // file://C:/UnityProjects/AssetBundlesGuide/Assets/AssetBundles/Cube.unity3d
    private static readonly string PRE_URL_FORMAT = "file://{0}/{1}";
    public string BundleURL = "AssetBundles/mycube.unity3d";    
    public string AssetName = "MyCube";
    
    IEnumerator Start()
    {
        string url = string.Format(PRE_URL_FORMAT, Application.dataPath, BundleURL);
        
        // Download the file from the URL. It will not be saved in the Cache
        using (WWW www = new WWW(url))
        {
            yield return www;
            if (www.error != null)
                throw new Exception("WWW download had an error:" + www.error);
            AssetBundle bundle = www.assetBundle;
            if (AssetName == "")
                Instantiate(bundle.mainAsset);
            else
                Instantiate(bundle.LoadAsset(AssetName));
            // Unload the AssetBundles compressed contents to conserve memory
            bundle.Unload(false);

        } // memory is freed from the web stream (www.Dispose() gets called implicitly)
    }
}