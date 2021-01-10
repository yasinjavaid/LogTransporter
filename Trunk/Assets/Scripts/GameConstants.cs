using UnityEngine;
using System.Collections;

public class GameConstants 
{
    // INAPPS
	public const string REMOVEADS_IAP_KEY = "com.super.hero.removeads";
    public const string REMOVE_AD_PREFS = "removeAd";

    // Game Scenes

    public const string GAMEPLAY_SCENE = "GamePlayScene";
    public const string MAIN_MENU_SCENE = "MainMenu";


    public static bool TO_NEXT_LEVEL = false;
    public static bool IS_KYEBOARD_CONTROL = true;
    public const string GROUND_TAG = "Ground";
    public static bool IS_TUTORIAL_LEVEL = false;
    public const string GROUP_ENEMY_OBJECT = "EnemyGroup";

    public static int PLAYER_HEALTH = 100;
    public static GameObject CURRENT_PLAYER;
    public static int RATE_US_COUNTER;
    // Player Pref Keys
    public static string SELECTED_PLAYER = "SelectedPlayer";
    // TAGS

    public const string PLAYER_TAG = "Player";
    public const string ENEMEY_TAG = "HeroEnemy";
    public const string COMPANION_AI_TAG = "CompanionAI";
    public const string CHECKPOINT_TAG = "CheckPoint";
    public const string ROOF_TOP_TAG = "RoofTop";
    public static string CIVILIAN_DESTINATION_TAG = "CivilianDestination";
    public static string CIVILIAN_START_TAG = "CivilianStart";

}
