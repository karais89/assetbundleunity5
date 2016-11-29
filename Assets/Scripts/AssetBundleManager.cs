﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class AssetBundleManager_
{
    // AssetBundle 참조, URL 및 버전이 있는 클래스
    private class AssetBundleRef
    {
        public AssetBundle assetBundle = null;
        public int version;
        public string url;

        public AssetBundleRef(string strUrlIn, int intVersionIn)
        {
            url = strUrlIn;
            version = intVersionIn;
        }
    };

    // A dictionary to hold the AssetBundle references
    static private Dictionary<string, AssetBundleRef> dictAssetBundleRefs;

    static AssetBundleManager_()
    {
        dictAssetBundleRefs = new Dictionary<string, AssetBundleRef>();
    }

    // Get an AssetBundle
    public static AssetBundle getAssetBundle(string url, int version)
    {
        string keyName = url + version.ToString();
        AssetBundleRef abRef;
        if (dictAssetBundleRefs.TryGetValue(keyName, out abRef))
        {
            return abRef.assetBundle;
        }
        else
        {
            return null;
        }
    }

    // Download an AssetBundle
    public static IEnumerator downloadAssetBundle(string url, int version)
    {
        string keyName = url + version.ToString();
        if (dictAssetBundleRefs.ContainsKey(keyName))
        {
            yield return null;
        }
        else
        {
            while (!Caching.ready)
            { 
                yield return null;
            }

            using (WWW www = WWW.LoadFromCacheOrDownload(url, version))
            {
                yield return www;
                if (www.error != null) 
                { 
                    throw new Exception("WWW download:" + www.error);
                }

                AssetBundleRef abRef = new AssetBundleRef(url, version);
                abRef.assetBundle = www.assetBundle;
                dictAssetBundleRefs.Add(keyName, abRef);
            }
        }
    }

    // Unload an AssetBundle
    public static void Unload(string url, int version, bool allObjects)
    {
        string keyName = url + version.ToString();
        AssetBundleRef abRef;
        if (dictAssetBundleRefs.TryGetValue(keyName, out abRef))
        {
            abRef.assetBundle.Unload(allObjects);
            abRef.assetBundle = null;
            dictAssetBundleRefs.Remove(keyName);
        }
    }
}