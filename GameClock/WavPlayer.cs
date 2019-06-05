using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace GameClock
{

    public static class WavPlayer
    {
        [DllImport("winmm.dll", SetLastError = true)]
        static extern bool PlaySound(string pszSound, UIntPtr hmod, uint fdwSound);
        [DllImport("winmm.dll", SetLastError = true)]
        static extern long mciSendString(string strCommand,
            StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        [DllImport("winmm.dll")]
        private static extern long sndPlaySound(string lpszSoundName, long uFlags);
        [DllImport("winmm.dll", SetLastError = true)]
        static extern bool StopSound(string pszSound, UIntPtr hmod, uint fdwSound);

        [Flags]
        public enum SoundFlags
        {
            /// <summary>play synchronously (default)</summary>
            SND_SYNC = 0x0000,
            /// <summary>play asynchronously</summary>
            SND_ASYNC = 0x0001,
            /// <summary>silence (!default) if sound not found</summary>
            SND_NODEFAULT = 0x0002,
            /// <summary>pszSound points to a memory file</summary>
            SND_MEMORY = 0x0004,
            /// <summary>loop the sound until next sndPlaySound</summary>
            SND_LOOP = 0x0008,
            /// <summary>don’t stop any currently playing sound</summary>
            SND_NOSTOP = 0x0010,
            /// <summary>Stop Playing Wave</summary>
            SND_PURGE = 0x40,
            /// <summary>don’t wait if the driver is busy</summary>
            SND_NOWAIT = 0x00002000,
            /// <summary>name is a registry alias</summary>
            SND_ALIAS = 0x00010000,
            /// <summary>alias is a predefined id</summary>
            SND_ALIAS_ID = 0x00110000,
            /// <summary>name is file name</summary>
            SND_FILENAME = 0x00020000,
            /// <summary>name is resource name or atom</summary>
            SND_RESOURCE = 0x00040004
        }

        public static void Play(string strFileName)
        {
            PlaySound(strFileName, UIntPtr.Zero,
               (uint)(SoundFlags.SND_FILENAME | SoundFlags.SND_SYNC | SoundFlags.SND_NOSTOP));
        }

        public static void Stop(string strFileName)
        {
            PlaySound(strFileName, UIntPtr.Zero,
               (uint)(SoundFlags.SND_FILENAME | SoundFlags.SND_SYNC | SoundFlags.SND_NOSTOP));
        }
        public static void mciPlay(string strFileName)
        {
            string playCommand = "open " + strFileName + " type WAVEAudio alias MyWav";
            mciSendString(playCommand, null, 0, IntPtr.Zero);
            mciSendString("play MyWav", null, 0, IntPtr.Zero);

        }
        public static void mciStop(string strFileName)
        {
            string playCommand = "open " + strFileName + " type WAVEAudio alias MyWav";
            mciSendString(playCommand, null, 0, IntPtr.Zero);
            mciSendString("stop MyWav", null, 0, IntPtr.Zero);

        }
        public static void sndPlay(string strFileName)
        {
            sndPlaySound(strFileName, (long)SoundFlags.SND_SYNC);
        }

        //--------------------- 
        //作者：believe209 
        //来源：CSDN 
        //原文：https://blog.csdn.net/wangzhen209/article/details/53285651/ 
        //版权声明：本文为博主原创文章，转载请附上博文链接！
    }
}
