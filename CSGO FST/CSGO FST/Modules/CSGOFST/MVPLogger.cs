using CSGOFST.Helpers;
using CSGSI;

namespace CSGOFST.Modules.CSGOFST
{
    public static class MVPLogger
    {

        private static int rounds = 0;

        private static bool playing = false;

        private static int mvps = 0;

        private static int lastMVPs = 0;

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

                mvps = gs.Player.MatchStats.MVPs;


                if (mvps == 0) lastMVPs = 0;

                //MVPS
                if (mvps > lastMVPs && mvps > 0)
                {
                    TelnetHelper.ExecuteCsgoCommand("say \"[NeverWin] Owned by " + gs.Player.Name + " with " + gs.Player.State.RoundKills + " kills (" + gs.Player.State.RoundKillHS + " headshots) and " + gs.Player.State.Health + " HP (" + gs.Player.State.Armor + " armor " + (gs.Player.State.Helmet ? "with" : "without") + " helmet)\"");
                }

                lastMVPs = mvps;
            }
        }
    }
}
