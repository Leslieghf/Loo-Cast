using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Sound
{
    public static class Sound
    {
        public static string ToStringID(this Soundtype soundtype)
        {
            switch (soundtype)
            {
                case Sound.Soundtype.Master:
                    return "MasterVolume";
                case Sound.Soundtype.Music:
                    return "MusicVolume";
                case Sound.Soundtype.Effects:
                    return "EffectsVolume";
                case Sound.Soundtype.UI:
                    return "UIVolume";
                default:
                    throw new System.Exception("UnhandledType");
            }
        }

        public enum Soundtype
        {
            Master,
            Music,
            Effects,
            UI
        }
    } 
}
