using System;

namespace CustodioUIApp
{
    public class Calculate
    {
        public static int WaysToClimb(int steps)
        {
            FilterRangeThrowExceptions(steps);

            if (steps <= 3)
            {
                return steps;
            }
            else
            {
                int result = 0;

                for (int i = steps / 2 + 1; i < steps; i++)
                {
                    result += i;
                }

                return steps % 2 == 0 ? result + 2 : result + 1;
            }
        }

        private static void FilterRangeThrowExceptions(int steps)
        {
            if (steps == 0)
            {
                throw new DivideByZeroException(Constants.Errors.EXCEPT_DIVIDE_BY_ZERO);
            }
            else if (steps < 0)
            {
                throw new ArgumentOutOfRangeException(Constants.Errors.EXCEPT_ARG_OUT_OF_RANGE_PARAM, Constants.Errors.EXCEPT_ARG_OUT_OF_RANGE);
            }
            else if (steps > 75675)
            {
                throw new OverflowException(Constants.Errors.EXCEPT_OVERFLOW);
            }
        }
    }
}