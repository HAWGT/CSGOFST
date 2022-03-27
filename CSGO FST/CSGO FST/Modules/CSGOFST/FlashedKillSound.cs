using CSGOFST.Helpers;
using CSGSI;

namespace CSGOFST.Modules.CSGOFST
{
    public static class FlashedKillSound
    {

        private static int lastKills = 0;

        private static int lastKillsHS = 0;

        private static int flashAmount = 0;

        private const int flashThreshold = 95;

        private static bool killed = false;

        private static int rounds = 0;

        private static bool playing = false;

        public static void Execute(GameState gs)
        {

            rounds = gs.Map.Round;
            killed = false;
            flashAmount = gs.Player.State.Flashed;

            if (rounds >= 0)
            {
                playing = true;
            }
            else
            {
                playing = false;
            }

            if (playing && gs.Player.Activity == CSGSI.Nodes.PlayerActivity.Playing)
            {

                int kills = gs.Player.State.RoundKills;
                int killsHS = gs.Player.State.RoundKillHS;


                if (kills == 0) lastKills = 0;
                if (killsHS == 0) lastKillsHS = 0;


                //HS KILL
                if (killsHS != lastKillsHS && killsHS > 0)
                {
                    if (killsHS > lastKillsHS && !killed)
                    {
                        if (flashAmount > flashThreshold) SoundPlayer.PlaySound(Properties.Resources.killhs);
                        killed = true;
                    }
                    lastKillsHS = killsHS;
                }

                //KILL
                if (kills != lastKills && kills > 0)
                {
                    if (kills > lastKills && !killed)
                    {
                        if (flashAmount > flashThreshold) SoundPlayer.PlaySound(Properties.Resources.kill);
                        killed = true;
                    }
                    lastKills = kills;
                }
            }
        }
    }
}
