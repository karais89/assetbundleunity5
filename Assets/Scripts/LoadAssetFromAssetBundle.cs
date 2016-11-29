// C# Example
// Loading an Asset from disk instead of loading from an AssetBundle
// when running in the Editor
using System.Collections;
using UnityEngine;

class LoadAssetFromAssetBundle : MonoBehaviour
{
    // file://C:/UnityProjects/AssetBundlesGuide/Assets/AssetBundles/Cube.unity3d
    private static readonly string PRE_URL_FORMAT = "file://{0}/{1}";
    public string BundleURL = "AssetBundles/mycube.unity3d";
    public string AssetName = "MyCube.prefab";
    public int version = 1;

    public Object Obj;

    void Start()
    {
        string url = string.Format(PRE_URL_FORMAT, Application.dataPath, BundleURL);
        StartCoroutine(DownloadAssetBundle<GameObject>(AssetName, url, version));    
    }

    public IEnumerator DownloadAssetBundle<T>(string asset, string url, int version) where T : Object
    {
        Obj = null;

#if UNITY_EDITOR
        Obj = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Samples/" + asset, typeof(T));
        yield return null;
#else
        // Wait for the Caching system to be ready
        while (!Caching.ready)
            yield return null;

        // Start the download
        using(WWW www = WWW.LoadFromCacheOrDownload (url, version))
        {
            yield return www;
            if (www.error != null)
                throw new System.Exception("WWW download:" + www.error);
            AssetBundle assetBundle = www.assetBundle;
            Obj = assetBundle.LoadAsset(asset, typeof(T));
            // Unload the AssetBundles compressed contents to conserve memory
            assetBundle.Unload(false);
        } // memory is freed from the web stream (www.Dispose() gets called implicitly)

#endif
    }
}