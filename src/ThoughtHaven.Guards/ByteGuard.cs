namespace ThoughtHaven
{
    public static partial class Guard
    {
        public static byte LessThan(string paramName, byte value, byte minimum) =>
            (byte)LessThan(paramName, (long)value, minimum);

        public static byte GreaterThan(string paramName, byte value, byte maximum) =>
            (byte)GreaterThan(paramName, (long)value, maximum);

        public static byte OutOfRange(string paramName, byte value, byte minimum, byte maximum) =>
            (byte)OutOfRange(paramName, (long)value, minimum, maximum);
    }
}