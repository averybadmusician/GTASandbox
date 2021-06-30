using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using Color = System.Drawing.Color;
using Keys = System.Windows.Forms.Keys;
using static Rage.Native.NativeFunction;

namespace GTASandbox.Runs
{
    class AnimPostFX : Run
    {
        protected override bool Player => true;

        protected override void Start()
        {
        }

        protected override void Process()
        {
            Camera cam = new Camera(false);
            for (int i = 0; i < cameras.Length; i++)
            {
                cam.Position = cameras[i].Item1;
                cam.Rotation = cameras[i].Item2;
                Game.LocalPlayer.Character.Position = cam.GetOffsetPositionFront(-3);
                GameFiber.Sleep(1000);
                foreach (var item in items)
                {
                    name = item;
                    Natives.x2206BF9A37B7F724(item, 5000, false);
                    GameFiber.Sleep(2000);
                    Functions.Screenshot(0, 0, 1920, 1080, $"{Directory}//{item}_{i}", true);
                    GameFiber.Sleep(500);
                    Natives.xB4EDDC19532BFB85();
                    GameFiber.Sleep(2500);
                }
            }
        }

        protected override void End()
        {
        }

        protected override void Tick()
        {
            if (name != "") Game.DisplaySubtitle(name, 100);
        }

        private string name = "";
        private readonly (Vector3, Rotator)[] cameras = new (Vector3, Rotator)[] 
        {

        };
        private readonly string[] items = new string[] 
        {
            "CamPushInNeutral",
            "FocusIn",
            "FocusOut",
            "BulletTime",
            "BulletTimeOut",
            "DrivingFocus",
            "DrivingFocusOut",
            "REDMIST",
            "REDMISTOut",
            "SwitchShortMichaelIn",
            "SwitchShortFranklinMid",
            "CamPushInFranklin",
            "CamPushInMichael",
            "CamPushInTrevor",
            "SwitchHUDOut",
            "DeathFailOut",
            "MinigameEndMichael",
            "MinigameEndFranklin",
            "MinigameEndTrevor",
            "MP_Celeb_Win",
            "MP_Celeb_Win_Out",
            "MP_Celeb_Lose",
            "MP_Celeb_Lose_Out",
            "MP_Celeb_Preload_Fade",
            "MinigameEndNeutral",
            "MP_race_crash",
            "DeathFailMPDark",
            "DeathFailMPIn",
            "CrossLine",
            "MinigameTransitionIn",
            "MenuMGTrevorIn",
            "MenuMGMichaelIn",
            "MenuMGFranklinIn",
            "MenuMGTrevorOut",
            "MenuMGMichaelOut",
            "MenuMGFranklinOut",
            "MenuMGIn",
            "MenuMGSelectionIn",
            "MenuMGSelectionTint",
            "MenuMGTournamentIn",
            "MenuMGHeistIn",
            "MenuMGHeistTint",
            "MenuMGHeistIntro",
            "MenuMGTournamentTint",
            "MenuMGRemixIn",
            "MenuSurvivalAlienIn",
            "MenuMGIslandHeistIn",
            "MP_job_load",
            "Heist4CameraFlash",
            "Heist4CameraFlash2",
            "BeastIntroScene",
            "BeastTransition",
            "BeastLaunch",
            "DanceIntensity03",
            "DanceIntensity02",
            "DanceIntensity01",
            "MP_OrbitalCannon",
            "RaceTurbo",
            "RemixDrone",
            "pennedIn",
            "PennedInOut",
            "PeyoteEndIn",
            "PeyoteEndOut",
            "PeyoteIn",
            "PeyoteOut",
            "MP_corona_switch_supermod",
            "WeaponUpgrade",
            "SwitchSceneMichael",
            "SuccessFranklin",
            "SuccessTrevor",
            "SuccessMichael",
            "DefaultBlinkOutro",
            "SwitchShortFranklinIn",
            "SwitchShortMichaelMid",
            "SwitchShortTrevorIn",
            "SwitchSceneFranklin",
            "SwitchSceneTrevor",
            "HeistCelebPass",
            "HeistCelebPassBW",
            "HeistCelebFail",
            "HeistCelebFailBW",
            "SuccessNeutral",
            "HeistCelebEnd",
            "MinigameTransitionOut",
            "SwitchShortTrevorMid",
            "ChopVision",
            "DMT_flight",
            "DrugsDrivingOut",
            "DMT_flight_intro",
            "DrugsDrivingIn",
            "SwitchOpenNeutralFIB5",
            "SwitchOpenMichaelMid",
            "SwitchOpenMichaelIn",
            "MenuMGHeistOut",
            "MP_corona_switch",
            "SwitchOpenNeutralOutHeist",
            "InchPurple",
            "CarDamageHit",
            "DeathFailNeutralIn",
            "SwitchShortNeutralIn",
            "CrossLineOut",
            "MP_SmugglerCheckpoint",
            "CarPitstopHealth",
            "MP_WarpCheckpoint",
            "MP_TransformRaceFlash",
            "ArenaWheelPurple",
            "MP_intro_logo",
            "InchPickup",
            "PPOrange",
            "PPPurple",
            "PPGreen",
            "PPPink",
            "DeadlineNeon",
            "HeistLocate",
            "MP_Celeb_Preload",
            "HeistTripSkipFade",
            "InchOrange",
            "InchPickupOut",
            "PPOrangeOut",
            "PPPurpleOut",
            "PPGreenOut",
            "PPPinkOut",
            "LostTimeDay",
            "LostTimeNight",
            "MP_Bull_tost",
            "PPFilter",
            "PPFilterOut",
            "TinyRacerPink",
            "TinyRacerGreen",
            "TinyRacerGreenOut",
            "TinyRacerPinkOut",
            "InchOrangeOut",
            "InchPurpleOut",
            "TinyRacerIntroCam",
            "SurvivalAlien",
            "BikerFormation",
            "BikerFormationOut",
            "ArenaEMP",
            "ArenaEMPOut",
            "SwitchOpenFranklin",
            "ExplosionJosh3",
            "SwitchSceneNeutral",
            "SniperOverlay",
            "SwitchSceneNetural",
            "Rampage",
            "RampageOut",
            "Dont_tazeme_bro",
            "SwitchHUDMichaelIn",
            "SwitchHUDFranklinIn",
            "SwitchHUDTrevorIn",
            "SwitchHUDIn",
            "SwitchHUDMichaelOut",
            "SwitchHUDFranklinOut",
            "SwitchHUDTrevorOut",
            "PokerCamTransition"
        };
    }
}
