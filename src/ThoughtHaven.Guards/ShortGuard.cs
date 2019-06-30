namespace ThoughtHaven
{
    public static partial class Guard
    {
        public static short LessThan(string paramName, short value, short minimum) =>
            (short)LessThan(paramName, (long)value, minimum);

        public static short GreaterThan(string paramName, short value, short maximum) =>
            (short)GreaterThan(paramName, (long)value, maximum);

        public static short OutOfRange(string paramName, short value, short minimum, short maximum) =>
            (short)OutOfRange(paramName, (long)value, minimum, maximum);
    }
}