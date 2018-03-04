namespace ThoughtHaven
{
    public static partial class Guard
    {
        public static int LessThan(string paramName, int value, int minimum) =>
            (int)LessThan(paramName, (long)value, minimum);

        public static int GreaterThan(string paramName, int value, int maximum) =>
            (int)GreaterThan(paramName, (long)value, maximum);

        public static int OutOfRange(string paramName, int value, int minimum, int maximum) =>
            (int)OutOfRange(paramName, (long)value, minimum, maximum);
    }
}