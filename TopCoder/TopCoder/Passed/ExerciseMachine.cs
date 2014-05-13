using System;

public class ExerciseMachine
{
    public int getPercentages(String time)
    {
        TimeSpan timespane = TimeSpan.Parse(time.Trim('\"'));

        var total = (int) timespane.TotalSeconds;
        int sum = 0;
        for (int i = 1; i < total; i++)
        {
            if (i*100%total == 0)
            {
                sum++;
            }
        }
        return sum;
    }
}

