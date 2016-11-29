using UnityEngine;
using System.Collections;

public class AssetBundleLoadAssetAsync : MonoBehaviour 
{
    private static readonly string PRE_URL_FORMAT = "file://{0}/{1}";
    public string BundleURL = "AssetBundles/mycube.unity3d";
    public string AssetName = "MyCube";
    public int version = 1;

    // Note: 이 예제는 오류를 확인하지 않습니다. 자세한 내용은 DownloadingAssetBundles 섹션의 예제를 참조하십시오.
    IEnumerator Start()
    {
        string url = string.Format(PRE_URL_FORMAT, Application.dataPath, BundleURL);        
        while (!Caching.ready)
        { 
            yield return null;
        }

        // Start a download of the given URL
        using(WWW www = WWW.LoadFromCacheOrDownload(url, version))
        {
            // 다운로드가 완료 될 때까지 대기.
            yield return www;

            // AssetBundle 로드 및 검색
            AssetBundle bundle = www.assetBundle;

            // 객체를 비동기 적으로 로드
            AssetBundleRequest request = bundle.LoadAssetAsync(AssetName, typeof(GameObject));

            // 완료 될 때까지 대기.
            yield return request;
            
            // 로드 된 객체에 대한 참조 가져 오기
            GameObject obj = request.asset as GameObject;
            
            // 생성
            Instantiate(obj);

            // 메모리를 절약하기 위해 AssetBundles 압축 내용을 언로드.
            bundle.Unload(false);
        }
    }
}
