using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public enum GameType
    {
        Fastest = 1,
        AgainstTime = 2
    }

    public static class GameTypeExtension{
        public static string ToReadableString(this GameType gameType)
        {
            switch (gameType)
            {
                case GameType.AgainstTime:
                    return "Contre la montre";
                case GameType.Fastest:
                    return "Rapidité";
                default:
                    return gameType.ToString();
            }
        }
    }
}
