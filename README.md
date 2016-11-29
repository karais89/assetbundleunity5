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

### Putting it all together

Now that the components are in place you can build a scene that will allow you to load your AssetBundle and display the contents on screen. 

First create an empty game object by going to GameObject->CreateEmpty. Drag the CachingLoadExample script onto the empty game object you just created. Then type the the URL of your AssetBundle in the BundleURL field. As we have placed this in the project directory you can copy the file directory location and add the prefix file://, for example file://C:/UnityProjects/AssetBundlesGuide/Assets/AssetBundles/Cube.unity3d

You can now hit play in the Editor and you should see the Cube prefab being loaded from the AssetBundle. 

## Loading AssetBundles in the Editor

When working in the Editor requiring AssetBundles to be built and loaded can slow down the development process. For instance, if an Asset from an AssetBundle is modified this will then require the AssetBundle to be rebuilt and in a production environment it is most likely that all AssetBundles are built together and therefore making the process of updating a single AssetBundle a lengthy operation. A better approach is to have a separate code path in the Editor that will load the Asset directly instead of loading it from an AssetBundle. To do this it is possible to use Resources.LoadAssetAtPath (Editor only). 

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