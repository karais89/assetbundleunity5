using System;
using UnityEngine;
using System.Collections;

public class CachingLoadExample : MonoBehaviour
{
    // file://C:/UnityProjects/AssetBundlesGuide/Assets/AssetBundles/Cube.unity3d
    private static readonly string PRE_URL_FORMAT = "file://{0}/{1}";
    public string BundleURL = "AssetBundles/mycube.unity3d";
    public string AssetName = "MyCube";
    public int version = 1;

    void Start()
    {
        StartCoroutine(DownloadAndCache());
    }

    IEnumerator DownloadAndCache()
    {
        string url = string.Format(PRE_URL_FORMAT, Application.dataPath, BundleURL);

        // 캐싱 시스템이 준비 될 때까지 기다립니다.
        while (!Caching.ready)
        { 
            yield return null;
        }

        // 동일한 버전의 AssetBundle 파일을 캐시에서로드 하거나 다운로드하여 캐시에 저장.
        using (WWW www = WWW.LoadFromCacheOrDownload(url, version))
        {
            yield return www;
            if (www.error != null)
            { 
                throw new Exception("WWW download had an error:" + www.error);
            }

            AssetBundle bundle = www.assetBundle;
            if (AssetName == "")
            {
                Instantiate(bundle.mainAsset);
            }
            else
            { 
                Instantiate(bundle.LoadAsset(AssetName));
            }

            // 메모리를 절약하기 위해 AssetBundles 압축 내용을 언로드
            bundle.Unload(false);

        } // 메모리가 웹 스트림에서 해제됩니다 (www.Dispose ()가 암시 적으로 호출 됨)
    }
}