using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTASandbox
{
    abstract class Run
    {
        protected string Directory { get { System.IO.Directory.CreateDirectory(directory); return directory; } }
        protected abstract void Start();
        protected abstract void End();
        protected abstract void Process();
        protected abstract void Tick();
        protected abstract bool Player { get; }

        private readonly string directory;
        private Rage.GameFiber fiber = null;
        private Rage.Vector3 oldPos = Rage.Vector3.Zero;
        private float oldHeading = 0;

        protected Run()
        {
            directory = Plugin.Directory + "//" + GetType().Name;
        }

        protected virtual void ApplyPlayer(bool start)
        {
            
            if(!start)
            {
                Rage.Game.LocalPlayer.Character.Position = oldPos;
                Rage.Game.LocalPlayer.Character.Heading = oldHeading;
            }
            Rage.Game.LocalPlayer.IsIgnoredByPolice = start;
            Rage.Game.LocalPlayer.Character.IsInvincible = start;
            Rage.Game.LocalPlayer.Character.IsPositionFrozen = start;
            Rage.Game.LocalPlayer.Character.CanPlayAmbientAnimations = !start;
            Rage.Game.LocalPlayer.Character.CanPlayGestureAnimations = !start;
            Rage.Game.LocalPlayer.Character.CanPlayVisemeAnimations = !start;
            Rage.Game.LocalPlayer.Character.IsCollisionEnabled = !start;
            Rage.Game.LocalPlayer.Character.NeedsCollision = !start;
            Rage.Game.LocalPlayer.Character.BlockPermanentEvents = !start;
        }

        public bool IsRunning => fiber != null && fiber.IsAlive;

        public void Do()
        {
            if (fiber != null) return;
            Rage.Game.LogTrivial($"Starting {GetType().Name}...");
            oldPos = Rage.Game.LocalPlayer.Character.Position;
            oldHeading = Rage.Game.LocalPlayer.Character.Heading;
            if (Player) ApplyPlayer(true);
            fiber = Rage.GameFiber.StartNew(delegate 
            {
                Start();
                Process();
                End();
            });
            Rage.GameFiber.ExecuteNewWhile(Tick, () => fiber != null && fiber.IsAlive);
            Rage.Game.LogTrivial($"Started {GetType().Name}");
        }

        public void Stop()
        {
            if (fiber == null) return;
            Rage.Game.LogTrivial($"Stopping {GetType().Name}...");
            if (fiber.IsAlive) fiber.Abort();
            if (Player) ApplyPlayer(false);
            fiber = null;
            Rage.Game.LogTrivial($"Stopped {GetType().Name}");
        }
    }
}
