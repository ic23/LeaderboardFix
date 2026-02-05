using System;
using BepInEx;
using HarmonyLib;
using System.Reflection;
using UnityEngine;
using Steamworks;

[BepInPlugin("com.ic23.leaderboardfix", "LeaderboardFix", "1.0.0")]
public class LeaderboardFix : BaseUnityPlugin
{
	private void Awake()
	{
		var harmony = new Harmony("com.ic23.leaderboardfix");
		harmony.PatchAll();
	}
}

[HarmonyPatch(typeof(SteamLeaderboard), "CheckIfUsingMods")]
public static class SteamLeaderboard_CheckIfUsingMods_Patch
{
	static bool Prefix(ref bool __result)
	{
		__result = false;
		return false;
	}
}

[HarmonyPatch(typeof(FPP_Player), "IsCheatRunning")]
public static class FPP_Player_IsCheatRunning_Patch
{
	static bool Prefix(ref bool __result)
	{
		__result = false;
		return false;
	}
}

[HarmonyPatch(typeof(FPP_Player), "PerformCheatCheck")]
public static class FPP_Player_PerformCheatCheck_Patch
{
	static bool Prefix()
	{
		ES3Settings settings = new ES3Settings(new Enum[]
		{
			ES3.Location.Cache
		});
		int num = PlayerPrefs.GetInt("CheatCheck");
		if (ES3.KeyExists("UsedCheats", settings))
		{
			ES3.DeleteKey("UsedCheats", settings);
		}
		num++;
		PlayerPrefs.SetInt("CheatCheck", num);
		return false;
	}
}

[HarmonyPatch(typeof(SteamLeaderboard), "UploadScore")]
public static class SteamLeaderboard_UploadScore_Patch
{
	private static readonly MethodInfo OnLeaderboardFoundMethod =
		AccessTools.Method(typeof(SteamLeaderboard), "OnLeaderboardFound");

	static bool Prefix(SteamLeaderboard __instance, int score, string leaderboard)
	{
		if (!SteamManager.Initialized)
		{
			Debug.LogError("Steamworks.NET not initialized.");
			return false;
		}
		__instance.scoreToUpload = score;
		SteamAPICall_t hAPICall = SteamUserStats.FindLeaderboard(leaderboard);
		var del = (CallResult<LeaderboardFindResult_t>.APIDispatchDelegate)
			Delegate.CreateDelegate(
				typeof(CallResult<LeaderboardFindResult_t>.APIDispatchDelegate),
				__instance,
				OnLeaderboardFoundMethod);
		CallResult<LeaderboardFindResult_t>.Create(del).Set(hAPICall, null);
		return false;
	}
}