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

## AssetBundle variants

This can be used to achieve a result similar to virtual assets. For example, you can set AssetBundle variants like “MyAssets.hd” and “MyAssets.sd”. Make sure the assets exactly match. The Unity build pipeline gives the objects in these two variant AssetBundles the same internal IDs. Now these two variant AssetBundles can be switched out arbitrarily, with AssetBundles of different variant extension at runtime.

To set AssetBundle variants:

1. From the Editor, use the one extra variant name to the right of the asset labels GUI.
2. In code, use the AssetImporter.assetBundleVariant option.

The full AssetBundle name is the combination of the AssetBundle name and the variant name. For example, if you want to add “MyAssets.hd” as a variant AssetBundle, you should set the AssetBundle name to “MyAssets” and AssetBundle variant to “hd”.

If you only set the AssetBundle a name like “MyAssets.hd”, it is created as a normal AssetBundle, not a variant AssetBundle. “MyAssets”+“hd” and “MyAssets.hd”+"" cannot coexist, as they lead to the same full AssetBundle name.

Scripting advice

### API to mark the asset as an AssetBundle

* You can use AssetImporter.assetBundleName to set the AssetBundle name.

### Building AssetBundles

Simple APIs are available to build AssetBundles: BuildPipeline.BuildAssetBundles(). You need to provide the following:

* The output path for all the AssetBundles.
* BuildAssetBundleOptions (see below).
* BuildTarget which is same as before.
* An overloaded version to provide an array of AssetBundleBuild which contains one map from assets to AsssetBundles. This provides flexibility to you: you can set your mapping information by script and build from it. This mapping information does not replace or break the existing one in the asset database.

### API to manipulate AssetBundle names in the asset database

* AssetDatabase.GetAllAssetBundleNames() returns all the AssetBundle names in the asset database.
* AssetDatabase.GetAssetPathsFromAssetBundle returns the asset paths marked in the given AssetBundle.
* AssetDatabase.RemoveAssetBundleName() removes a given AssetBundle name in the asset database.
* AssetDatabase.GetUnusedAssetBundleNames() returns the unused AssetBundle names.
* AssetDatabase.RemoveUnusedAssetBundleNames() removes all the unused AssetBundle names in the asset database.
* The callback AssetPostProcessor.OnPostprocessAssetbundleNameChanged is called if user changes the AssetBundle name of an asset.

### BuildAssetBundleOptions

* CollectDependencies and DeterministicAssetBundle are always enabled.
* CompleteAssets is ignored as it always starts from assets rather than objects. It should be complete by default.
* ForceRebuildAssetBundle. Even if there is no change to the assets, you can force rebuild the AssetBundles by setting this flag.
* IngoreTypeTreeChanges. Even if the typetree changes, you can ignore the changes with this flag.
* DisableWriteTypeTree conflicts with IngoreTypeTreeChanges. You cannot ignore typetree changes if you disable typetree.

### Manifest file

A manifest file is created for every AssetBundle which contains the following information:

* The manifest file is next to the AssetBundle.
* CRC.
* Asset file hash. A single hash for all the assets included in this AssetBundle; only used for incremental build check.
* Type tree hash. A single hash for all the types included in this AssetBundle; only used for incremental build check.
* Class types. All the class types included in this AssetBundle. These are used to get the new single hash when doing the typetree incremental build check.
* Asset names. All the assets explicitly included in this AssetBundle.
* Dependent AssetBundle names. All the AssetBundles which this AssetBundle depends on.
* This manifest file is only used for incremental build, not necessary for runtime.

### Single manifest file

A single manifest file is generated which includes:

* All the AssetBundles.
* All the AssetBundle dependencies.

### Single manifest AssetBundle

It only contains an AssetBundleManifest object which has following API:

* GetAllAssetBundles() returns all the AssetBundle names in this build.
* GetDirectDependencies() returns the direct dependent AssetBundle names.
* GetAllDependencies() returns all the dependent AssetBundle names.
* GetAssetBundleHash(string) returns the hash for the specified AssetBundle.
* GetAllAssetBundlesWithVariant() returns all the AssetBundles with variant.

### AssetBundle loading API

* AssetBundle.GetAllAssetNames(). Returns all the asset names in the AssetBundle.
* AssetBundle.GetAllScenePaths(). Returns all the scene asset paths if it’s a streamed scene AssetBundle.
* AssetBundle.LoadAsset(). Loads assets from the AssetBundle.
* AssetBundle.LoadAllAssets().
* AssetBundle.LoadAssetWithSubAssets().
* Asynchronous versions are also provided.
* Component types are not returned. To find the component type, load the GameObject first and then look up the component(s) on the object.

Typetrees

A typetree is written to the AssetBundle by default. The only exception is Metro, as it has a different serialization solution.
