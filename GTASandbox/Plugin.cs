using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using System.Windows.Forms;

namespace GTASandbox
{
    public static class Plugin
    {
        public static readonly string Directory = "Plugins//GTASandbox";

        static Runs.AnimPostFX AnimPostFX = new Runs.AnimPostFX();

        public static void Load()
        {
            System.IO.Directory.CreateDirectory(Directory);
            GameFiber.ExecuteNewWhile(Tick, () => true);
        }

        public static void Unload(bool crash)
        {

        }

        public static void Tick()
        {
            if (Game.IsKeyDown(Keys.D1)) if (AnimPostFX.IsRunning) AnimPostFX.Stop(); else AnimPostFX.Do();
        }
    }
}
