using UnityEngine;
using System.Collections;

public class BundleLoader : MonoBehaviour
{
    // file://C:/UnityProjects/AssetBundlesGuide/Assets/AssetBundles/Cube.unity3d
    private static readonly string PRE_URL_FORMAT = "file://{0}/{1}";
    public string BundleURL = "AssetBundles/mycube.unity3d";
    public string AssetName = "MyCube";
    public int version = 1;
    
    void Start()
    {
        StartCoroutine(LoadBundle());
    }

    public IEnumerator LoadBundle()
    {
        string url = string.Format(PRE_URL_FORMAT, Application.dataPath, BundleURL);

        while (!Caching.ready)
        {
            yield return null;
        }

        using (WWW www = WWW.LoadFromCacheOrDownload(url, version))
        {
            yield return www;

            AssetBundle assetBundle = www.assetBundle;
            GameObject gameObject = assetBundle.LoadAsset(AssetName) as GameObject;
            Instantiate(gameObject);
            assetBundle.Unload(false);
        }
    }
}