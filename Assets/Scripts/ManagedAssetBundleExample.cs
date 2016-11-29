using UnityEngine;
using System.Collections;

public class ManagedAssetBundleExample : MonoBehaviour
{    
    // file://C:/UnityProjects/AssetBundlesGuide/Assets/AssetBundles/Cube.unity3d
    private static readonly string PRE_URL_FORMAT = "file://{0}/{1}";
    public string BundleURL = "AssetBundles/mycube.unity3d";
    public string AssetName = "MyCube.prefab";
    public int version = 1;

    private string url;
    private AssetBundle bundle;

    void Start()
    {
        url = string.Format(PRE_URL_FORMAT, Application.dataPath, BundleURL);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 128, 128), "Download bundle"))
        {
            bundle = AssetBundleManager.getAssetBundle(url, version);
            if (!bundle)
            { 
                StartCoroutine(DownloadAB());
            }
        }
    }

    IEnumerator DownloadAB()
    {
        yield return StartCoroutine(AssetBundleManager.downloadAssetBundle(url, version));
        bundle = AssetBundleManager.getAssetBundle(url, version);
        Instantiate(bundle.LoadAsset(AssetName));
    }

    void OnDisable()
    {
        AssetBundleManager.Unload(url, version, false);
    }
}