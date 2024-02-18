using System;
using System.IO;
using System.Reflection;
using BepInEx;
using UnityEngine;
using Utilla;

namespace ThePenisEek
{
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		public static AudioSource Audio;
		void Start()
		{
            GorillaTagger.OnPlayerSpawned(PlayerSpawned);
        }

		void OnEnable() => HarmonyPatches.ApplyHarmonyPatches();
		void OnDisable() => HarmonyPatches.RemoveHarmonyPatches();

		void PlayerSpawned()
		{
            var bundle = LoadAssetBundle("ThePenisEek.thepeniseek");
            var asset = bundle.LoadAsset<AudioClip>("The Penis Eek");

            Audio = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/SoundPostForest/geo/monkeneedtoswing").GetComponent<AudioSource>();
			Audio.clip = asset;
            Debug.Log("ThePenisMod Initialized");
        }

        public AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }
	}
}
