namespace Orlde;

public static class WordRepository
{
    private static readonly string[] AnswerWords =
    {
        "ALIEN", "ANGEL", "APPLE", "BEACH", "BLADE", "BLEND", "BOARD","BRAIN",
        "BRAVE", "BREAD", "BRICK", "BRING", "CANDY", "CHAIR", "CLOUD", "CORAL",
        "CRANE", "DANCE", "DREAM", "EARTH", "FLAME", "FLOOR", "FRAME", "FRUIT",
        "GHOST", "GIANT", "GLASS", "GRAPE", "GREEN", "HEART", "HOUSE", "JUICE",
        "LIGHT", "METAL", "MONEY", "MOUSE", "NURSE", "OCEAN", "PAINT", "PEARL",
        "PHONE", "PIANO", "PLANE", "PLANT", "QUEEN", "RIVER", "ROBOT", "SHARE",
        "SHINE", "SMILE", "SNAKE", "SPACE", "SPARK", "SPOON", "STONE", "STORM",
        "TABLE", "TIGER", "TRAIN", "WATER", "WHALE", "WORLD", "YOUTH", "ZEBRA"
    };

    private static readonly HashSet<string> ValidWords = new(StringComparer.OrdinalIgnoreCase)
    {
        "ALIEN", "ANGEL", "APPLE", "BEACH", "BLADE", "BLEND", "BOARD","BRAIN",
        "BRAVE", "BREAD", "BRICK", "BRING", "CANDY", "CHAIR", "CLOUD", "CORAL",
        "CRANE", "DANCE", "DREAM", "EARTH", "FLAME", "FLOOR", "FRAME", "FRUIT",
        "GHOST", "GIANT", "GLASS", "GRAPE", "GREEN", "HEART", "HOUSE", "JUICE",
        "LIGHT", "METAL", "MONEY", "MOUSE", "NURSE", "OCEAN", "PAINT", "PEARL",
        "PHONE", "PIANO", "PLANE", "PLANT", "QUEEN", "RIVER", "ROBOT", "SHARE",
        "SHINE", "SMILE", "SNAKE", "SPACE", "SPARK", "SPOON", "STONE", "STORM",
        "TABLE", "TIGER", "TRAIN", "WATER", "WHALE", "WORLD", "YOUTH", "ZEBRA",
        "ABIDE", "ADORE", "AGREE", "ALBUM", "ALERT", "ALIVE", "AMBER", "AMONG",
        "ANGLE", "ANKLE", "ARROW", "AUDIO", "AVOID", "AWAKE", "BASIC", "BERRY",
        "BIRTH", "BLACK", "BLOND", "BLOOM", "BOUND", "BROWN", "CABLE", "CALM",
        "CHEST", "CHIME", "CLIMB", "CLOCK", "CLOSE", "COAST", "COLOR", "COUNT",
        "COURT", "COVER", "CROWD", "CROWN", "CURVE", "DEMON", "DOUBT", "DOZEN",
        "DROVE", "EAGER", "EARLY", "ELITE", "EMPTY", "ENJOY", "ENTRY", "ERROR",
        "FAITH", "FIELD", "FINAL", "FLASH", "FLOAT", "FLUNG", "FOCUS", "FORGE",
        "FRESH", "FRONT", "FUNNY", "GIVEN", "GLORY", "GRAND", "GRASS", "GUESS",
        "HAPPY", "HONEY", "HORSE", "HUMAN", "IDEAL", "IMAGE", "INDEX", "INNER",
        "INPUT", "ISSUE", "JELLY", "KNIFE", "LAUGH", "LAYER", "LEMON", "LEVEL",
        "LUCKY", "MAGIC", "MAJOR", "MESSY", "MIGHT", "MODEL", "MOTOR", "MUSIC",
        "NEVER", "NIGHT", "NOBLE", "NOISE", "NORTH", "NOVEL", "NURSE", "OFFER",
        "ORDER", "OTHER", "OUTER", "PANEL", "PARTY", "PEACE", "PEPPY", "PILOT",
        "PIZZA", "POINT", "POPULAR", "POWER", "PRESS", "PRICE", "PRIDE", "PRIME",
        "PRINT", "PROUD", "QUICK", "QUITE", "RADIO", "RANGE", "REACH", "READY",
        "RELAX", "RIGHT", "ROUND", "ROUTE", "ROYAL", "RULER", "SCALE", "SCENE",
        "SCOPE", "SELLS", "SENSE", "SERVE", "SHAPE", "SHIFT", "SHOCK", "SHORT",
        "SIGHT", "SKILL", "SLEEP", "SMALL", "SMART", "SOLVE", "SOUND", "SOUTH",
        "SPEED", "SPELL", "SPEND", "STAGE", "START", "STEEL", "STICK", "STILL",
        "STYLE", "SUGAR", "SUPER", "SWEET", "TEACH", "THEME", "THING", "THINK",
        "THREE", "STROW", "TIMES", "TODAY", "TOUCH", "TOUGH", "TRACK", "TRAIL",
        "TURST", "TRUTH", "UNITY", "VALUE", "VIDEO", "VOICE", "WEEDS", "WEIRD",
        "WHEEL", "WHERE", "WHITE", "WHOLE", "WOMAN", "WORTH", "WRITE", "YOUNG",
    };

    public static string GetRandomAnswer(Random random)
    {
        return AnswerWords[random.Next(AnswerWords.Length)];
    }

    public static bool IsValidWords(string word)
    {
        return ValidWords.Contains(word);
    }

}