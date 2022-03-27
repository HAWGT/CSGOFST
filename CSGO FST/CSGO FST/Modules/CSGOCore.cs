using CSGOFST.Modules.CSGOFST;
using CSGSI;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;

namespace CSGOFST.Modules
{
    class CSGOCore
    {

        public MainForm mainForm;

        public static GameStateListener _gsl;

        private GameState gs_dump;

        private ushort port = 13337;
        public CSGOCore(MainForm reference)
        {
            mainForm = reference;
            CreateGsifile();

            Process[] pname = Process.GetProcessesByName("csgo");
            if (pname.Length == 0)
            {
            }

            _gsl = new GameStateListener(port);
            _gsl.NewGameState += OnNewGameState;


            if (!_gsl.Start())
            {
            }


        }

        private void OnNewGameState(GameState gs)
        {
            gs_dump = gs;

            if (mainForm.Sounds()) FlashedKillSound.Execute(gs);
            if (mainForm.MVPLogger()) MVPLogger.Execute(gs);
            if (mainForm.ReloadFlash()) ReloadFlash.Execute(gs);
        }

        public void DumpGS()
        {
            try
            {
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\gs_dump." + (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds + ".json", gs_dump.ToString());
            }
            catch
            {

            }
        }

        private void CreateGsifile()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam");

            if (regKey != null)
            {
                string gsifolder = regKey.GetValue("SteamPath") +
                                   @"\steamapps\common\Counter-Strike Global Offensive\csgo\cfg";
                Directory.CreateDirectory(gsifolder);
                string gsifile = gsifolder + @"\gamestate_integration_CSC.cfg";
                if (File.Exists(gsifile))
                    return;

                string[] contentofgsifile =
                {
                    "\"CSC\"",
                    "{",
                    "    \"uri\"           \"http://localhost:"+port+"\"",
                    "    \"timeout\"       \"5.0\"",
                    "    \"buffer\"        \"0.1\"",
                    "    \"throttle\"      \"0.1\"",
                    "    \"heartbeat\"     \"0.1\"",
                    "    \"data\"",
                    "    {",
                    "        \"provider\"           \"1\"",
                    "        \"map\"                \"1\"",
                    "        \"round\"              \"1\"",
                    "        \"player_id\"          \"1\"",
                    "        \"player_state\"       \"1\"",
                    "        \"player_weapons\"     \"1\"",
                    "        \"player_match_stats\" \"1\"",
                    "    }",
                    "}",

                };

                File.WriteAllLines(gsifile, contentofgsifile);
            }
            else
            {
            }
        }
    }
}
