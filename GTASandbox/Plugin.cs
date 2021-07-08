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

        static Dictionary<Keys, Run> Runs = new Dictionary<Keys, Run> 
        {
            { Keys.D1, new Runs.AnimPostFX() },
            { Keys.D2, new Runs.Timecycle() },
        };

        public static void Load()
        {
            Camera.DeleteAllCameras();
            System.IO.Directory.CreateDirectory(Directory);
            GameFiber.ExecuteNewWhile(Tick, () => true);
        }

        public static void Unload(bool crash)
        {
            Runs.Values.ToArray().ToList().ForEach(x => x.End());
        }

        public static void Tick()
        {
            foreach (var item in Runs)
            {
                if(Game.IsKeyDown(item.Key))
                {
                    if(item.Value.IsRunning)
                    {
                        item.Value.Stop();
                    } else
                    {
                        GameFiber.Sleep(5000);
                        item.Value.Do();
                    }
                }
            }
        }
    }
}
