# unity asset bundles

* https://docs.unity3d.com/Manual/AssetBundlesIntro.html

## AssetBundles

AssetBundles는 Unity에서 export 하여 원하는 Asset을 포함 할 수있는 파일입니다.

이 파일은 독점적인 압축 형식을 사용하며 응용 프로그램에서 필요할 때 로드 할 수 있습니다.

이 기능을 사용하면 모델, 텍스처, 오디오 클립 또는 전체 장면과 같은 컨텐츠를 사용할 Scene과 별도로 스트리밍 할 수 있습니다.

AssetBundles는 애플리케이션으로 컨텐츠를 다운로드하는 것을 단순화하도록 설계되었습니다.

파일 이름 확장자에 따라 Unity에 의해 인식되는 모든 종류의 자산 유형을 포함 할 수 있습니다.

사용자 지정 바이너리 데이터가 포함 된 파일을 포함하려면 확장명이 ".bytes"여야합니다. 

Unity는 이러한 파일을 TextAssets로 가져옵니다.

## AssetBundle workflow

AssetBundles를 준비하고 서버에 업로드하십시오:

1. **AssetBundles 빌드**: Scene의 Assets을 사용하여 Editor에서 AssetBundles를 생성하십시오. 이를 수행하는 방법은 [AssetBundle 빌드](https://docs.unity3d.com/Manual/BuildingAssetBundles.html)를 참조하십시오.

2. **AssetBundles를 외부 저장소에 업로드하십시오.** FTP 클라이언트를 사용하여 AssetBundles를 원하는 서버에 업로드하십시오. 런타임에 응용 프로그램은 필요에 따라 AssetBundle을 로드하고 필요에 따라 각 AssetBundle 내의 개별 Assets을 조작합니다.

3. **응용 프로그램에서 런타임에 AssetBundles를 다운로드하십시오.** 이 작업은 Unity Scene 내의 스크립트에서 수행되며 AssetBundle은 필요에 따라 서버에서로드됩니다. 자세한 내용은 [Asset Bundles 다운로드](https://docs.unity3d.com/Manual/DownloadingAssetBundles.html)를 참조하십시오.

4. **AssetBundles에서 GameObjects를 로드하십시오.** AssetBundle이 다운로드되면 개별 자산에 액세스 할 수 있습니다. 이를 수행하는 방법은 [AssetBundles에서 리소스로드하기](https://docs.unity3d.com/Manual/LoadingAssetBundles.html)를 참조하십시오.

AssetBundle 사용을위한 워크 플로우에 익숙해지고, 그들이 제공하는 다양한 기능을 발견하고, 개발 과정에서 시간과 노력을 절약 할 수있는 베스트 프랙티스를 배우려면 문서의 이 섹션을 철저히 읽으십시오.

## AssetBundles 빌드

AssetBundle (스크립트와 Unity Editor 내에서 AssetBundle이라고 함)을 생성하려면 프로젝트 폴더에서 번들에 포함 할 애셋을 선택하십시오.

Inspector 창의 맨 아래에 AssetBundle 메뉴가 있습니다.

이것을 클릭하면 현재 정의 된 AssetBundles의 이름과 새 번들을 정의하는 옵션이 표시됩니다:

번들을 아직 정의하지 않은 경우 New ...를 클릭하고 번들의 이름을 입력하십시오.

그런 다음이 번들에 애셋을 추가하려면 Inspector 창의 하단에있는 메뉴를 사용하여 Project 창에서 애셋을 선택하고 명명 된 번들에 할당하십시오.

기본적으로 자산의 AssetBundle 옵션은 None으로 설정됩니다. 즉, 자산이 AssetBundle에 기록되지 않고 대신 주 프로젝트 자체로 패키지화됩니다.

이 메뉴를 사용하여 하나 이상의 AssetBundle을 만들고 이름을 지정한 다음이 새 AssetBundle 이름을 자산의 대상으로 사용할 수 있습니다.

이 예제에서 asset은 environment / desert라는 AssetBundle에 추가되었습니다.

이 AssetBundle은 이전에 추가 된 다른 자산을 포함 할 수 있습니다.

AssetBundle 이름은 항상 소문자입니다. 이름에 대문자를 사용하면 소문자로 변환됩니다.

AssetBundle의 이름에 슬래시를 사용하면 실제로 위의 스크린 샷과 같이 메뉴에 하위 메뉴가 포함되도록 폴더가 만들어집니다.

애셋이 할당되지 않은 AssetBundle을 생성하면 Remove Unused Names 옵션을 사용하여 빈 AssetBundle을 삭제 할 수 있습니다.

자산에 속한 메타 파일에는 선택한 AssetBundle 이름이 기록됩니다.

## AssetBundles 내보내기

AssetBundles은 스크립트 코드를 사용하여 편집기에서 내보내집니다. 다음 스크립트는 AssetBundles를 내 보냅니다:

```
using UnityEditor;

public class CreateAssetBundles
{
    [MenuItem ("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles ()
    {
        BuildPipeline.BuildAssetBundles ("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneOSXUniversal);
    }
}
```

이 스크립트는 Assets 메뉴의 맨 아래에 메뉴 항목을 작성합니다.

이 메뉴 항목을 선택하여 함수를 호출하고 AssetBundle을 빌드하면 진행 막대가있는 빌드 대화 상자가 나타납니다.

BuildPipeline입니다. BuildAssetBundles 함수는 레이블이 붙은 AssetBundles를 만들고 "AssetBundles"출력 폴더에 넣습니다.

(주의: 이 스크립트를 실행하기 전에 프로젝트 폴더에 "AssetBundles"폴더를 만들어야합니다.)

내 보낸 각 AssetBundle에는 AssetBundle 메뉴에 표시된 이름이 있습니다.

또한 각 AssetBundle에는 ".manifest"확장자가있는 관련 파일이 있습니다.

이 매니페스트 파일은 텍스트 편집기로 열 수있는 텍스트 파일입니다.

파일 CRC 및 자산 종속성과 같은 정보를 제공합니다.

위 예제의 AssetBundle에는 다음과 같은 매니페스트 파일이 있습니다:

```
ManifestFileVersion: 0
CRC: 2422268106
Hashes:
  AssetFileHash:
    serializedVersion: 2
    Hash: 8b6db55a2344f068cf8a9be0a662ba15
  TypeTreeHash:
    serializedVersion: 2
    Hash: 37ad974993dbaa77485dd2a0c38f347a
HashAppended: 0
ClassTypes:
- Class: 91
  Script: {instanceID: 0}
Assets:
  Asset_0: Assets/Mecanim/StateMachine.controller
Dependencies: {}
```

이 외에도 다른 AssetBundle과 다른 매니페스트 파일이라는 두 개의 파일이 생성됩니다.

AssetBundles가 생성 된 각 폴더에 대해 생성되므로 AssetBundles을 항상 같은 위치에 만들면 두 개의 추가 파일 만 생성됩니다.

추가 매니페스트 파일 (이 예제에서는 AssetBundles.manifest)은 다른 매니페스트 파일과 거의 같은 방식으로 사용될 수 있지만 AssetBundles이 서로 관련되어 있고 의존하는 방식에 대한 정보를 보여줍니다.

이 경우 우리는 하나의 AssetBundle 만 가지고 있고 다른 의존성은 없다는 것을 파악 할 수 있습니다.

```
ManifestFileVersion: 0
AssetBundleManifest:
  AssetBundleInfos:
    Info_0:
      Name: scene1assetbundle
      Dependencies: {}
```

## Shader stripping

번들에 쉐이더를 포함 시키면 유니티 편집기는 현재 장면과 라이트 맵핑 설정을보고 사용할 라이트 맵 모드를 결정합니다.

즉, 번들을 만들 때 구성된 장면을 열어야합니다.

그러나 라이트 맵 모드를 계산할 장면을 수동으로 지정할 수도 있습니다. 이것은 명령 행에서 번들을 빌드 할 때 필요합니다.

사용하고 싶은 장면을 엽니 다. 그래픽 설정 관리자 (Edit > Project Settings > Graphics)에서 셰이더 stripping/Lightmap 모드로 이동하여 Manual을 선택한 다음 From current scene를 선택하십시오.

## AssetBundle editor tools

**AssetBundles의 이름 가져 오기**

다음 편집기 스크립트는 빌드 프로세스가 생성 할 수있는 AssetBundle의 이름을 표시 할 수 있습니다.

```
using UnityEditor;
using UnityEngine;

public class GetAssetBundleNames
{
    [MenuItem ("Assets/Get AssetBundle names")]
    static void GetNames ()
    {
        var names = AssetDatabase.GetAllAssetBundleNames();
        foreach (var name in names)
            Debug.Log ("AssetBundle: " + name);
    }
}
```

**asset 변경시 AssetBundle에게 콜백**

AssetPundprocessor 클래스의 OnPostprocessAssetbundleNameChanged 메서드를 사용하여 AssetBundle의 에셋이 변경 내용과 연결될 때 콜백을 가져옵니다.

```
using UnityEngine;
using UnityEditor;

public class MyPostprocessor : AssetPostprocessor {

    void OnPostprocessAssetbundleNameChanged ( string path,
            string previous, string next) {
        Debug.Log("AB: " + path + " old: " + previous + " new: " + next);
    }
}
```

## AssetBundle 변형 (두번째 인자)

이는 가상 assets과 유사한 결과를 얻는 데 사용될 수 있습니다.

예를 들어, "MyAssets.hd"와 "MyAssets.sd"와 같은 AssetBundle을 설정 할 수 있다.

애셋이 정확히 일치하는지 확인하십시오.

Unity 빌드 파이프 라인은이 두 변형 AssetBundle의 객체에 동일한 내부 ID를 제공합니다.

이제 이 두 개의 변형 AssetBundle은 런타임에 다른 변형 확장의 AssetBundles로 임의로 전환 할 수 있습니다.

AssetBundle 변형을 설정하려면 :

1. 에디터에서 asset labels GUI의 오른쪽에 하나의 추가 변형 이름을 사용하십시오.
2. 코드에서 AssetImporter.assetBundleVariant 옵션을 사용하십시오.

전체 AssetBundle 이름은 AssetBundle 이름과 변형 이름의 조합입니다.

예를 들어 "MyAssets.hd"를 변형 AssetBundle로 추가하려면 AssetBundle 이름을 "MyAssets"로, AssetBundle 변형을 "hd"로 설정해야합니다.

AssetBundle에 "MyAssets.hd"와 같은 이름 만 설정하면 변형 AssetBundle이 아닌 일반 AssetBundle로 생성됩니다.

"MyAssets"+ "hd"및 "MyAssets.hd"+ ""는 동일한 전체 AssetBundle 이름으로 이어 지므로 공존 할 수 없습니다.

## Scripting 조언

### asset을 AssetBundle로 표시하는 API

* [AssetImporter.assetBundleName](https://docs.unity3d.com/ScriptReference/AssetImporter-assetBundleName.html)을 사용하여 AssetBundle 이름을 설정할 수 있습니다.

### AssetBundles 빌드하기

간단한 API를 사용하여 AssetBundles를 빌드 할 수 있습니다. [BuildPipeline.BuildAssetBundles()](https://docs.unity3d.com/ScriptReference/BuildPipeline.BuildAssetBundles.html). 다음을 제공해야합니다.

* 모든 AssetBundle의 output 경로.
* [BuildAssetBundleOptions](https://docs.unity3d.com/ScriptReference/BuildAssetBundleOptions.html) (see below).
* 이전과 같은 [BuildTarget](https://docs.unity3d.com/ScriptReference/BuildTarget.html).
* AssetsBundles 에셋에서 하나의 맵을 포함하는 AssetBundleBuild 배열을 제공하는 오버로드 된 버전입니다. 이는 유연성을 제공합니다 : 스크립트로 맵핑 정보를 설정하고 스크립트로 빌드 할 수 있습니다. 이 매핑 정보는 자산 데이터베이스의 기존 매핑을 대체하거나 손상시키지 않습니다.

### asset db에서 AssetBundle 이름을 조작하는 API

* [AssetDatabase.GetAllAssetBundleNames()](https://docs.unity3d.com/ScriptReference/AssetDatabase.GetAllAssetBundleNames.html) asset db에서 모든 AssetBundle 이름을 반환합니다.
* [AssetDatabase.GetAssetPathsFromAssetBundle](https://docs.unity3d.com/ScriptReference/AssetDatabase.GetAssetPathsFromAssetBundle.html) 지정된 AssetBundle에 표시된 asset 경로를 반환합니다..
* [AssetDatabase.RemoveAssetBundleName()](https://docs.unity3d.com/ScriptReference/AssetDatabase.RemoveAssetBundleName.html) asset db에서 주어진 AssetBundle 이름을 제거합니다..
* [AssetDatabase.GetUnusedAssetBundleNames()](https://docs.unity3d.com/ScriptReference/AssetDatabase.GetUnusedAssetBundleNames.html) 사용되지 않은 AssetBundle 이름을 반환합니다..
* [AssetDatabase.RemoveUnusedAssetBundleNames()](https://docs.unity3d.com/ScriptReference/AssetDatabase.RemoveUnusedAssetBundleNames.html) asset db에서 사용되지 않은 모든 AssetBundle 이름을 제거합니다.
* [AssetPostProcessor.OnPostprocessAssetbundleNameChanged](https://docs.unity3d.com/ScriptReference/AssetPostprocessor.OnPostprocessAssetbundleNameChanged.html) 사용자가 asset의 AssetBundle 이름을 변경하면 호출됩니다.

### BuildAssetBundleOptions

* [CollectDependencies](https://docs.unity3d.com/ScriptReference/BuildAssetBundleOptions.CollectDependencies.html) 및 [DeterministicAssetBundle](https://docs.unity3d.com/ScriptReference/BuildAssetBundleOptions.DeterministicAssetBundle.html)은 항상 사용 가능합니다.
* [CompleteAssets](https://docs.unity3d.com/ScriptReference/BuildAssetBundleOptions.CompleteAssets.html)는 항상 객체가 아닌 자산에서 시작하므로 무시됩니다. 기본적으로 완료되어야 합니다.
* [ForceRebuildAssetBundle](https://docs.unity3d.com/ScriptReference/BuildAssetBundleOptions.ForceRebuildAssetBundle.html). 자산에 변경이 없더라도이 플래그를 설정하여 AssetBundles를 강제로 재 구축 할 수 있습니다.
* [IngoreTypeTreeChanges](https://docs.unity3d.com/ScriptReference/BuildAssetBundleOptions.IgnoreTypeTreeChanges.html). typetree가 변경 되더라도이 플래그를 사용하여 변경 사항을 무시할 수 있습니다.
* [DisableWriteTypeTree](https://docs.unity3d.com/ScriptReference/BuildAssetBundleOptions.DisableWriteTypeTree.html)가 [IngoreTypeTreeChanges](https://docs.unity3d.com/ScriptReference/BuildAssetBundleOptions.IgnoreTypeTreeChanges.html)와 충돌합니다. typetree를 사용하지 않으면 typetree 변경 사항을 무시할 수 없습니다.

### 매니페스트 파일

**매니페스트** 파일은 다음 정보가 포함 된 모든 AssetBundle에 대해 생성됩니다 :

* 매니페스트 파일은 AssetBundle 옆에 있습니다.
* CRC.
* 자산 파일 해시. 이 AssetBundle에 포함 된 모든 자산에 대한 단일 해시. 증분 빌드 확인에만 사용됩니다.
* 타입 트리 해시. 이 AssetBundle에 포함 된 모든 유형의 단일 해시. 증분 빌드 확인에만 사용됩니다.
* 클래스 유형. 이 AssetBundle에 포함 된 모든 클래스 유형. typetree 증분 빌드 확인을 수행 할 때 새 단일 해시를 가져 오는 데 사용됩니다.
* 자산 이름. 이 AssetBundle에 명시 적으로 포함 된 모든 자산.
* AssetBundle 의존성 이름. 이 AssetBundle가 의존하는 모든 AssetBundle.
* 이 매니페스트 파일은 증분 빌드에만 사용되며 런타임에는 필요하지 않습니다.

### 단일 매니페스트 파일

다음을 포함하는 단일 매니페스트 파일이 생성됩니다 :

* 모든 AssetBundle.
* 모든 AssetBundle 의존성.

### 단일 매니페스트 AssetBundle

다음 API가있는 AssetBundleManifest 객체 만 포함합니다 :

* [GetAllAssetBundles()](https://docs.unity3d.com/ScriptReference/AssetBundleManifest.GetAllAssetBundles.html) 이 빌드에서 모든 AssetBundle 이름을 반환합니다.
* [GetDirectDependencies()](https://docs.unity3d.com/ScriptReference/AssetBundleManifest.GetDirectDependencies.html) 직접 의존된 AssetBundle 이름을 반환합니다.
* [GetAllDependencies()](https://docs.unity3d.com/ScriptReference/AssetBundleManifest.GetAllDependencies.html) 모든 의존된 AssetBundle 이름을 반환합니다.
* [GetAssetBundleHash(string)](https://docs.unity3d.com/ScriptReference/AssetBundleManifest.GetAssetBundleHash.html) 지정된 AssetBundle의 해시를 반환합니다.
* [GetAllAssetBundlesWithVariant()](https://docs.unity3d.com/ScriptReference/AssetBundleManifest.GetAllAssetBundlesWithVariant.html) variant가있는 모든 AssetBundle을 반환합니다.

### AssetBundle 로딩 API

* [AssetBundle.GetAllAssetNames()](https://docs.unity3d.com/ScriptReference/AssetBundle.GetAllAssetNames.html). AssetBundle의 모든 자산 이름을 반환합니다.
* [AssetBundle.GetAllScenePaths()](https://docs.unity3d.com/ScriptReference/AssetBundle.GetAllScenePaths.html). 스트리밍 된 장면 AssetBundle 인 경우 모든 장면 자산 경로를 반환합니다.
* [AssetBundle.LoadAsset()](https://docs.unity3d.com/ScriptReference/AssetBundle.LoadAsset.html). AssetBundle에서 에셋을로드합니다.
* [AssetBundle.LoadAllAssets()](https://docs.unity3d.com/ScriptReference/AssetBundle.LoadAllAssets.html).
* [AssetBundle.LoadAssetWithSubAssets()](https://docs.unity3d.com/ScriptReference/AssetBundle.LoadAssetWithSubAssets.html).
* 비동기 버전도 제공됩니다.
* 구성 요소 유형이 반환되지 않습니다. 구성 요소 유형을 찾으려면 GameObject를 먼저로드 한 다음 해당 객체에서 구성 요소를 찾으십시오.

### Typetrees

typetree는 기본적으로 AssetBundle에 기록됩니다. 유일한 예외는 Metro입니다. 다른 직렬화 솔루션이 있기 때문에.

## Downloading AssetBundles

이 섹션에서는 asset bundle을 작성하는 방법을 이미 배웠다 고 가정합니다. 아직 배우지 않았다면 [Building AssetBundles](https://docs.unity3d.com/Manual/BuildingAssetBundles.html)를 참조하십시오.

AssetBundle을 다운로드하는 방법에는 두 가지가 있습니다.

1. **Non-caching**: 이것은 새로운 [WWW 객체](https://docs.unity3d.com/ScriptReference/WWW.html)를 생성하여 수행됩니다. AssetBundle은 로컬 저장 장치의 Unity 캐시 폴더에 캐시되지 않습니다.
2. **Caching**: 이 작업은 [WWW.LoadFromCacheOrDownload](https://docs.unity3d.com/ScriptReference/WWW.LoadFromCacheOrDownload.html) 호출을 사용하여 수행됩니다. AssetBundle은 로컬 저장 장치의 Unity 캐시 폴더에 캐시됩니다. PC / Mac 독립 실행 형 응용 프로그램 및 iOS / Android 응용 프로그램의 최대 용량은 4GB입니다. 다른 플랫폼의 스크립팅 설명서를 참조하십시오.

Non-caching 다운로드의 예는 다음과 같습니다.

```
using System;
using UnityEngine;
using System.Collections; 

class NonCachingLoadExample : MonoBehaviour {
   public string BundleURL;
   public string AssetName;
   IEnumerator Start() {
     // Download the file from the URL. It will not be saved in the Cache
     using (WWW www = new WWW(BundleURL)) {
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
```

AssetBundles를 다운로드하는 가장 좋은 방법은 [WWW.LoadFromCacheOrDownload](https://docs.unity3d.com/ScriptReference/WWW.LoadFromCacheOrDownload.html)를 사용하는 것입니다. 예 :

```
using System;
using UnityEngine;
using System.Collections;

public class CachingLoadExample : MonoBehaviour {
    public string BundleURL;
    public string AssetName;
    public int version;

    void Start() {
        StartCoroutine (DownloadAndCache());
    }

    IEnumerator DownloadAndCache (){
        // Wait for the Caching system to be ready
        while (!Caching.ready)
            yield return null;

        // Load the AssetBundle file from Cache if it exists with the same version or download and store it in the cache
        using(WWW www = WWW.LoadFromCacheOrDownload (BundleURL, version)){
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
```

.assetBundle 속성에 액세스하면 다운로드 한 데이터가 추출되고 AssetBundle 객체가 만들어집니다.

이 시점에서 번들에 포함 된 객체를 로드 할 준비가되었습니다.

LoadFromCacheOrDownload에 전달 된 두 번째 매개 변수는 다운로드 할 AssetBundle의 버전을 지정합니다.

AssetBundle이 캐시에 없거나 요청 된 버전보다 낮 으면 LoadFromCacheOrDownload가 AssetBundle을 다운로드합니다.

그렇지 않으면 AssetBundle이 캐시에서로드됩니다.

WWW.LoadFromCacheOrDownload로 다운로드 할 때 프레임 당 최대 하나의 AssetBundle 다운로드 만 완료 할 수 있습니다.

### 함께 해보기?

구성 요소가 준비되었으므로 AssetBundle을 로드하고 화면에 내용을 표시 할 수있는 장면을 만들 수 있습니다.

먼저 GameObject-> CreateEmpty로 빈 게임 객체를 만듭니다.

방금 만든 빈 게임 개체에 CachingLoadExample 스크립트를 드래그합니다.

그런 다음 BundleURL 필드에 AssetBundle의 URL을 입력하십시오.

프로젝트 디렉토리에 파일을 배치 했으므로 파일 디렉토리 위치를 복사하고 접두사 file:// 을 추가 할 수 있습니다 (예 : file://C:/UnityProjects/AssetBundlesGuide/Assets/AssetBundles/Cube.unity3d).

이제 편집기에서 재생을 할 수 있고 AssetBundle에서 로드되는 Cube 프리팹을 볼 수 있습니다.

## 편집기에서 AssetBundles로드하기

Editor에서 AssetBundle을 빌드하고 로드해야하는 경우 개발 프로세스가 느려질 수 있습니다.

예를 들어, AssetBundle의 AssetBundle을 수정하면 AssetBundle을 다시 빌드해야하며 모든 AssetBundle이 함께 구축되어 단일 AssetBundle을 업데이트하는 프로세스가 오랜 시간 수행되는 경우가 많습니다.

AssetBundle에서 AssetBundle을로드하는 대신 Asset을 직접로드하는 별도의 코드 경로를 Editor에 두는 것이 더 좋습니다.

이렇게하려면 [Resources.LoadAssetAtPath](https://docs.unity3d.com/ScriptReference/Resources.LoadAssetAtPath.html) (Editor 전용)를 사용하는 것이 가능합니다.

```
// C# Example
// Loading an Asset from disk instead of loading from an AssetBundle
// when running in the Editor
using System.Collections;
using UnityEngine;

class LoadAssetFromAssetBundle : MonoBehaviour
{
    public Object Obj;

    public IEnumerator DownloadAssetBundle<T>(string asset, string url, int version) where T : Object {
        Obj = null;

#if UNITY_EDITOR
        Obj = Resources.LoadAssetAtPath("Assets/" + asset, typeof(T));
        yield return null;

#else
        // Wait for the Caching system to be ready
        while (!Caching.ready)
            yield return null;

        // Start the download
        using(WWW www = WWW.LoadFromCacheOrDownload (url, version)){
            yield return www;
            if (www.error != null)
                        throw new Exception("WWW download:" + www.error);
            AssetBundle assetBundle = www.assetBundle;
            Obj = assetBundle.LoadAsset(asset, typeof(T));
            // Unload the AssetBundles compressed contents to conserve memory
            bundle.Unload(false);

        } // memory is freed from the web stream (www.Dispose() gets called implicitly)

#endif
    }
}
```

## AssetBundle에서 객체 로드 및 언로드

다운로드 한 데이터에서 AssetBundle 객체를 생성하면, 거기에 포함 된 객체를 로드 할 수 있습니다.

* [AssetBundle.LoadAsset](https://docs.unity3d.com/ScriptReference/AssetBundle.LoadAsset.html)은 이름 식별자를 매개 변수로 사용하여 객체를로드합니다. 이름은 프로젝트보기에서 볼 수있는 이름입니다. 필요에 따라 Load 메서드에 인수로 개체 형식을 전달하여 로드 된 개체가 특정 형식인지 확인 할 수 있습니다.

* [AssetBundle.LoadAssetAsync](https://docs.unity3d.com/ScriptReference/AssetBundle.LoadAssetAsync.html)는 위에서 설명한 Load 메서드와 동일하게 작동 하지만 자산이 로드되는 동안 주 스레드를 차단하지 않습니다. 이것은 응용 프로그램에서 일시 중지를 피하기 위해 큰 자산이나 많은 자산을 한 번에 로드 할 때 유용합니다.

* [AssetBundle.LoadAllAssets](https://docs.unity3d.com/ScriptReference/AssetBundle.LoadAllAssets.html)는 AssetBundle에 포함 된 모든 객체를 로드합니다. AssetBundle.Load와 마찬가지로 선택적으로 객체를 유형별로 필터링 할 수 있습니다.

자산을 언로드하려면 AssetBundle.Unload를 사용해야합니다.

이 메서드는 모든 데이터 (로드 된 자산 객체 포함)를 언로드할지 또는 다운로드 한 번들에서 압축 된 데이터 만 언로드할지 여부를 Unity에 알리는 부울 매개 변수를 사용합니다.

응용 프로그램이 AssetBundle의 일부 객체를 사용 중이고 일부 메모리를 비우려면 false를 전달하여 메모리에서 압축 된 데이터를 언로드 할 수 있습니다. 

AssetBundle에서 모든 것을 완전히 언로드하려면 True를 전달해야합니다. 

그러면 AssetBundle에서 로드 된 Assets이 삭제됩니다.

## AssetBundles에서 비동기 적으로 객체 로드하기

[AssetBundle.LoadAssetAsync](https://docs.unity3d.com/ScriptReference/AssetBundle.LoadAssetAsync.html) 메서드를 사용하면 개체를 비동기 적으로 로드하고 응용 프로그램에 멈춤이 생길 가능성을 줄일 수 있습니다.

```
using UnityEngine;

// Note: This example does not check for errors. Please look at the example in the DownloadingAssetBundles section for more information
IEnumerator Start () {
    while (!Caching.ready)
        yield return null;
    // Start a download of the given URL
    WWW www = WWW.LoadFromCacheOrDownload (url, 1);

    // Wait for download to complete
    yield return www;

    // Load and retrieve the AssetBundle
    AssetBundle bundle = www.assetBundle;

    // Load the object asynchronously
    AssetBundleRequest request = bundle.LoadAssetAsync ("myObject", typeof(GameObject));

    // Wait for completion
    yield return request;

    // Get the reference to the loaded object
    GameObject obj = request.asset as GameObject;

        // Unload the AssetBundles compressed contents to conserve memory
        bundle.Unload(false);

        // Frees the memory from the web stream
        www.Dispose();
}
```

## 로드 된 AssetBundles 유지하기

Unity는 애플리케이션에서 한 번에 로드 된 특정 AssetBundle의 단일 인스턴스 만 가질 수 있게 합니다.

이것이 의미하는 바는, 같은 객체가 이전에 로드되었고 언로드되지 않은 경우, AssetBundle을 WWW 객체에서 검색 할 수 없다는 것입니다.

실용적인면에서 이전에 로드 된 AssetBundle에 다음과 같이 액세스하려고 할 때 이를 의미합니다.

```
AssetBundle bundle = www.assetBundle;
```

다음 오류가 throw됩니다.

```
Cannot load cached AssetBundle. A file of the same name is already loaded from another AssetBundle
```

그리고 assetBundle 속성은 null을 반환합니다.

AssetBundle은 첫 번째로드가 아직 로드 된 상태에서 두 번째 다운로드 중에 검색 할 수 없으므로 더 이상 사용하지 않을 때 AssetBundle을 언로드하거나 해당 자산에 대한 참조를 유지하고 다운로드하지 않도록합니다. 그것은 메모리에 이미 있습니다.

필요에 따라 적절한 조치 과정을 결정할 수 있지만, 객체 로딩이 완료 되 자마자 AssetBundle을 언로드하는 것이 좋습니다.

이렇게하면 메모리가 확보되어 캐시 된 AssetBundles를 로드하는 데 더 이상 오류가 발생하지 않습니다.

Unity 5 이전에 모든 번들이 언로드 되기 전에 번들 로딩이 완료된다는 점에 유의하십시오.

따라서 번들 일부가 로드되는 동안 AssetBundle.Unload 함수를 호출하면 모든 번들이 로드 될 때까지 나머지 코드의 실행이 차단됩니다.

이것은 성능 딸꾹질을 추가 할 것입니다. 이것은 Unity 5에서 다시 수정 되었습니다.

다운로드 한 AssetBundle을 추적하고 싶다면 래퍼 클래스를 사용하여 다음과 같이 다운로드를 관리 할 수 있습니다.

```
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

static public class AssetBundleManager {
   // A dictionary to hold the AssetBundle references
   static private Dictionary<string, AssetBundleRef> dictAssetBundleRefs;
   static AssetBundleManager (){
       dictAssetBundleRefs = new Dictionary<string, AssetBundleRef>();
   }
   // Class with the AssetBundle reference, url and version
   private class AssetBundleRef {
       public AssetBundle assetBundle = null;
       public int version;
       public string url;
       public AssetBundleRef(string strUrlIn, int intVersionIn) {
           url = strUrlIn;
           version = intVersionIn;
       }
   };
   // Get an AssetBundle
   public static AssetBundle getAssetBundle (string url, int version){
       string keyName = url + version.ToString();
       AssetBundleRef abRef;
       if (dictAssetBundleRefs.TryGetValue(keyName, out abRef))
           return abRef.assetBundle;
       else
           return null;
   }
   // Download an AssetBundle
   public static IEnumerator downloadAssetBundle (string url, int version){
       string keyName = url + version.ToString();
       if (dictAssetBundleRefs.ContainsKey(keyName))
           yield return null;
       else {
           while (!Caching.ready)
               yield return null;

           using(WWW www = WWW.LoadFromCacheOrDownload (url, version)){
               yield return www;
               if (www.error != null)
                   throw new Exception("WWW download:" + www.error);
               AssetBundleRef abRef = new AssetBundleRef (url, version);
               abRef.assetBundle = www.assetBundle;
               dictAssetBundleRefs.Add (keyName, abRef);
           }
       }
   }
   // Unload an AssetBundle
   public static void Unload (string url, int version, bool allObjects){
       string keyName = url + version.ToString();
       AssetBundleRef abRef;
       if (dictAssetBundleRefs.TryGetValue(keyName, out abRef)){
           abRef.assetBundle.Unload (allObjects);
           abRef.assetBundle = null;
           dictAssetBundleRefs.Remove(keyName);
       }
   }
}
```

클래스의 사용 예는 다음과 같습니다.

```
using UnityEditor;

class ManagedAssetBundleExample : MonoBehaviour {
   public string url;
   public int version;
   AssetBundle bundle;
   void OnGUI (){
       if (GUILayout.Label ("Download bundle"){
           bundle = AssetBundleManager.getAssetBundle (url, version);
           if(!bundle)
               StartCoroutine (DownloadAB());
       }
   }
   IEnumerator DownloadAB (){
       yield return StartCoroutine(AssetBundleManager.downloadAssetBundle (url, version));
       bundle = AssetBundleManager.getAssetBundle (url, version);
   }
   void OnDisable (){
       AssetBundleManager.Unload (url, version);
   }
}
```

이 예제의 AssetBundleManager 클래스는 static이며 참조하는 모든 AssetBundle은 새 장면을 로드 할 때 소멸되지 않습니다.

이 클래스를 가이드로 사용하십시오. 하지만 AssetBundle을 사용한 직후에 AssetBundle을 언로드하는 것이 가장 좋습니다.

이전에 인스턴스화 된 객체를 복제하여 AssetBundle을 다시 로드 할 필요가 없도록 할 수 있습니다.

## AssetBundles FAQ

### AssetBundle은 어떻게 사용합니까?

AssetBundles로 작업 할 때는 두 가지 주요 단계가 필요합니다. 

첫 번째 단계는 서버 또는 디스크 위치에서 AssetBundle을 다운로드하는 것입니다. 이것은 WWW 클래스에서 수행됩니다. 

두 번째 단계는 응용 프로그램에서 사용할 AssetBundle에서 Assets을 로드하는 것입니다. 다음은 C # 스크립트의 예입니다.

```
using UnityEngine;
using System.Collections;

public class BundleLoader : MonoBehaviour{
    public string url;
    public int version;
    public IEnumerator LoadBundle(){
        while (!Caching.ready)
            yield return null;
        using(WWW www = WWW.LoadFromCacheOrDownload(url, version)) {
            yield return www;
            AssetBundle assetBundle = www.assetBundle;
            GameObject gameObject = assetBundle.mainAsset as GameObject;
            Instantiate(gameObject);
            assetBundle.Unload(false);
        }
    }
    void Start(){
        StartCoroutine(LoadBundle());
    }
}
```

이 스크립트는 GameObject Component에 추가됩니다. AssetBundle은 다음과 같은 방법으로 로드 됩니다:

* URL 및 버전 값은 이 스크립트를 실행하기 전에 관리자에서 설정 해야합니다. url은 일반적으로 인터넷상의 서버인 AssetBundle 파일의 위치입니다. 버전 번호를 통해 개발자는 디스크의 캐시에 쓸 때 AssetBundle에 숫자를 연결할 수 있습니다. AssetBundle Unity를 다운로드 할 때 파일이 캐시에 이미 있는지 확인합니다. 존재하는 경우 저장된 자산의 버전과 요청 된 버전을 비교합니다. 다른 경우 AssetBundle이 다시 다운로드됩니다. 동일하면 AssetBundle을 디스크에서로드하고 파일을 다시 다운로드하지 않아도됩니다. 이러한 매개 변수에 대한 자세한 내용은 스크립팅 참조의 WWW.LoadFromCacheOrDownload 함수를 참조하십시오.
* 이 스크립트의 Start 함수가 호출되면 Coroutine으로 함수를 호출하여 AssetBundle을로드하기 시작합니다.이 함수는 AssetBundle을 다운로드 할 때 WWW 객체에서 생성됩니다. 이것을 사용하면, 함수는 WWW 객체가 다운로드가 끝날 때까지 그 시점에서 멈추게 될 것이지만, 나머지 코드의 실행을 막지는 않을 것이다. WWW.LoadFromCacheOrDownload로 다운로드 할 때 프레임 당 최대 하나의 AssetBundle 다운로드 만 완료 할 수 있습니다.
* WWW 개체가 AssetBundle 파일을 다운로드하면 .assetBundle 속성을 사용하여 AssetBundle 개체를 검색합니다. 이 객체는 AssetBundle 파일에서 객체를로드하기위한 인터페이스입니다.
* 이 예에서는 AssetBundle의 프리 팹에 대한 참조가 .mainAsset 속성을 사용하여 AssetBundle에서 검색됩니다. 이 속성은 Object를 첫 번째 매개 변수로 전달하는 AssetBundle을 빌드 할 때 설정됩니다. AssetBundle의 주요 애셋은 AssetBundle 안에있는 객체 목록과 그 밖의 다른 정보가있는 TextAsset을 저장하는 데 사용할 수 있습니다.

간단히 하기 위해 앞의 예에서는 안전 점검을하지 않습니다. 보다 완전한 예를 보려면 [코드](https://docs.unity3d.com/Manual/DownloadingAssetBundles.html)를 살펴보십시오.

### 에디터에서 애셋 번들을 사용하려면 어떻게해야합니까?

응용 프로그램을 만드는 것은 반복적 인 과정이기 때문에 Assets을 여러 번 수정해야 할 가능성이 높습니다. 이를 변경하려면 매번 변경 후에 AssetBundle을 다시 작성해야합니다.

AssetBundles를 Editor에서로드 할 수는 있지만 권장되는 워크 플로우는 아닙니다.

대신 편집기에서 테스트하는 동안 AssetBundles를 사용하고 다시 작성하지 않으려면 Help.LoadAssetAtPath 헬퍼 함수를 사용해야합니다. 

이 함수를 사용하면 AssetBundle에서 로드 된 것처럼 Asset을 로드 할 수 있지만 빌드 프로세스를 건너 뛰고 Assets은 항상 최신 상태입니다.

다음은 Editor에서 실행 중인지 여부에 따라 Assets을로드하는 데 사용할 수있는 helper 스크립트의 예입니다.

이 코드를 AssetBundleLoader.cs라는 C # 스크립트에 넣습니다.

```
using UnityEngine;
using System.Collections;

public class AssetBundleLoader {
    public Object Obj; // The object retrieved from the AssetBundle
   
    public IEnumerator LoadBundle<T> (string url, int version, string assetName, string assetPath) where T : Object {
        Obj = null;

#if UNITY_EDITOR
        Obj = Resources.LoadAssetAtPath(assetPath, typeof(T));
        if (Obj == null)
            Debug.LogError ("Asset not found at path: " + assetPath);
        yield break;

#else
        WWW download;
        if ( Caching.enabled ) { 
            while (!Caching.ready)
                yield return null;
           download = WWW.LoadFromCacheOrDownload( url, version );
        }
        else {
            download = new WWW (url);
        }

        yield return download;
        if ( download.error != null ) {
            Debug.LogError( download.error );
            download.Dispose();
            yield break;
        }

        AssetBundle assetBundle = download.assetBundle;
        download.Dispose();
        download = null;

        if (assetName == "" || assetName == null)
            Obj = assetBundle.mainAsset;
        else
            Obj = assetBundle.Load(assetName, typeof(T));
       
        assetBundle.Unload(false);

#endif
    }
}
```

우리는 이제 AssetBundleLoader 스크립트를 사용하여 빌드 된 응용 프로그램을 실행 중이거나 AssetBundle에서 Asset을로드 할 수 있습니다.

또는 AssetBundleLoader를 Editor에서 실행중인 경우 Project 폴더에서 직접로드 할 수 있습니다.

```
using UnityEngine;
using System.Collections;

public class ExampleLoadingBundle : MonoBehaviour {
    public string url = "http://www.mygame.com/myBundle.unity3d"; // URL where the AssetBundle is
    public int version = 1; // The version of the AssetBundle

    public string assetName = "MyPrefab"; // Name of the Asset to be loaded from the AssetBundle
    public string assetPath; // Path to the Asset in the Project folder

    private Object ObjInstance; // Instance of the object
    void Start(){
        StartCoroutine(Download());
    }

    IEnumerator Download () {
        AssetBundleLoader assetBundleLoader = new AssetBundleLoader ();
        yield return StartCoroutine(assetBundleLoader.LoadBundle <GameObject> (url, version, assetName, assetPath));
        if (assetBundleLoader.Obj != null)
            ObjInstance = Instantiate (assetBundleLoader.Obj);
    }

    void OnGUI(){
        GUILayout.Label (ObjInstance ? ObjInstance.name + " instantiated" : "");
    }
}
```

이전 스크립트는 Assets 폴더의 ExampleLoadingBundle.cs 파일에 저장해야합니다. 

공용 변수를 올바른 값으로 설정하고 실행 한 후에는 AssetBundleLoader 클래스를 사용하여 자산을 로드합니다.

그런 다음이를 인스턴스화하여 GUI를 사용하여 표시합니다.

### 애셋 번들을 캐시하려면 어떻게 해야 합니까?

자동으로 AssetBundle을 디스크에 저장하는 WWW.LoadFromCacheOrDownload를 사용할 수 있습니다. 

더 많은 공간이 필요한 경우 게임용 별도의 캐싱 라이선스를 구입할 수 있습니다.

AssetBundle이 StreamingAssets 폴더에 비 압축 AssetBundle로 저장되어있는 경우 AssetBundle.CreateFromFile을 사용하여 디스크의 AssetBundle을 참조 할 수 있습니다. 

StreamingAssets 폴더의 AssetBundle이 압축 된 경우 WWW.LoadFromCacheOrDownload를 사용하여 캐시에 AssetBundle의 압축되지 않은 복사본을 만들어야합니다.

### AssetBundles는 크로스 플랫폼입니까?

(*) 모바일 플랫폼 용으로 구축 된 AssetBundles에는 최적화 된 플랫폼 별 형식으로 저장된 데이터가 포함될 수 있으며 이는 에디터가 실행되는 플랫폼과 호환되지 않습니다. 게시 된 게임마다 플랫폼마다 다른 자산 번들이 필요하다고 가정하는 것이 안전합니다. 

특히 셰이더는 플랫폼에 따라 다릅니다.

예 : GI 데이터는 ARM 아키텍처 용으로 최적화 된 형식으로 저장되므로 x86 CPU에는로드 할 수 없습니다. 

셰이더는 OpenGLES 2 구성 용으로 저장되며 DX9 / 11 렌더러를 사용하는 편집기에서는로드 할 수 없습니다 (그러나 OpenGLCore 렌더러에서 작동 함). 개발 중에 AssetBundle과 AssetBundle Manager 튜토리얼에서 언급 한 Simulation Mode를 사용하여 에디터와 모바일 플랫폼의 비 호환성을 피하는 것이 좋습니다.

### AssetBundle의 자산은 어떻게 식별됩니까?

AssetBundle을 빌드 할 때 자산은 확장자없이 파일 이름으로 내부적으로 식별됩니다. 

예를 들어 "Assets/Textures/myTexture.jpg"의 Project 폴더에 있는 텍스처는 기본 방법을 사용하는 경우 "myTexture"를 사용하여 식별되고 로드됩니다. 

BuildPipeline.BuildAssetBundleExplicitAssetNames를 사용하여 AssetBundle을 빌드 할 때 각 객체에 대한 고유 한 ids (문자열) 배열을 제공하면이 문제를보다 효과적으로 제어 할 수 있습니다.

### AssetBundle을 다른 게임에서 재사용 할 수 있습니까?

AssetBundles를 사용하면 서로 다른 게임간에 콘텐츠를 공유 할 수 있습니다. 

AssetBundle의 GameObject가 참조하는 Assets은 AssetBundle에 포함되어야합니다. 

참조 된 Assets이 빌드 될 때 AssetBundle에 포함되도록하려면 BuildAssetBundleOptions.CollectDependencies 옵션을 전달하면됩니다.

### AssetBundle은 현재 유니티의 향후 버전에서 사용할 수 있습니까?

AssetBundles에는 유형 트리라는 구조가 포함되어있어 서로 다른 버전의 Unity간에 자산 유형에 대한 정보를 올바르게 이해할 수 있습니다. 

데스크톱 플랫폼에서는 기본적으로 형식 트리가 포함되지만 BuildAssetBundleOptions.DisableWriteTypeTree를 BuildAssetBundle 함수에 전달하여 비활성화 할 수 있습니다. 

유형 트리는 모바일 및 콘솔 자산 번들에 포함되지 않으므로 직렬화 형식이 변경 될 때마다 이러한 번들을 다시 빌드해야합니다. 

이것은 새로운 버전의 Unity에서 발생할 수 있습니다. 

(버그 수정 릴리즈 제외) 자산 번들에 포함되어있는 일련 번호 필드를 추가하거나 제거하면 발생합니다. 

AssetBundle을 다시 로드 해야하는 경우, AssetBundle을로드하면 Unity가 오류 메시지를 표시합니다.

### AssetBundle에서 객체를 어떻게 나열 할 수 있습니까?

AssetBundle.LoadAllAssets를 사용하여 AssetBundle에서 모든 객체를 포함하는 배열을 검색 할 수 있습니다. 

식별자 목록을 직접 가져올 수는 없습니다. 일반적인 해결책은 별도의 TextAsset을 유지하여 AssetBundle에서 에셋의 이름을 유지하는 것입니다.

### AssetBundles는 다른 AssetBundle의 자산을 어떻게 참조 할 수 있습니까?

Bundle A에 재질과 질감이있는 Prefab이 있다고 가정합니다. 

번들 B에는 동일한 조립식의 인스턴스가있는 장면이 있습니다. 

번들 B는 자료에 액세스해야합니다. 

특정 자산 번들에 자재가 포함되어 있지 않으면 번들 A와 B에 모두 포함됩니다.