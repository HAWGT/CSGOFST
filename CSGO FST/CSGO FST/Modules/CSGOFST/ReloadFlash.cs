using CSGOFST.Helpers;
using CSGSI;

namespace CSGOFST.Modules.CSGOFST
{
    public static class ReloadFlash
    {

        private static int rounds = 0;

        private static bool playing = false;

        private static bool reloading = false;

        private static bool bFlashed = false;

        private static int flashed = 0;

        private const int flashThreshold = 95;

        public static void Execute(GameState gs)
        {

            rounds = gs.Map.Round;

            if (rounds >= 0)
            {
                playing = true;
            }
            else
            {
                playing = false;
            }

            if (playing && gs.Player.Activity == CSGSI.Nodes.PlayerActivity.Playing && gs.Player.SteamID == gs.Provider.SteamID)
            {

                flashed = gs.Player.State.Flashed;

                if (gs.Player.Weapons.ActiveWeapon.State != CSGSI.Nodes.WeaponState.Reloading) reloading = false;

                if (flashed <= flashThreshold) bFlashed = false;

                //Reloading
                if (gs.Player.Weapons.ActiveWeapon.State == CSGSI.Nodes.WeaponState.Reloading && !reloading)
                {
                    TelnetHelper.ExecuteCsgoCommand("playerradio Radio.CoverMe \"Reloading!\"");
                    reloading = true;
                }

                //Flashed
                if (flashed > flashThreshold && !bFlashed)
                {
                    TelnetHelper.ExecuteCsgoCommand("say_team \"I'm white, also I'm flashed!\"");
                    //TelnetHelper.ExecuteCsgoCommand("playerradio help \"I'm white, also I'm flashed!\"");
                    bFlashed = true;
                }
            }
        }
    }
}
