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

AssetBundle 사용을위한 워크 플로우에 익숙해지고, 그들이 제공하는 다양한 기능을 발견하고, 개발 과정에서 시간과 노력을 절약 할 수있는 베스트 프랙티스를 배우려면 문서의이 섹션을 철저히 읽으십시오.