using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGOFST.Helpers
{
    class SoundPlayer
    {
        public static void PlaySound(System.IO.Stream snd)
        {
            System.Media.SoundPlayer player = null;
            player = new System.Media.SoundPlayer
            {
                Stream = null
            };
            player.Stream = snd;
            player.Stream.Position = 0;
            player.Play();
        }
    }
}
