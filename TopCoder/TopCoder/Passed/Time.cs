using System;

public class Time
{
    public String whatTime(int seconds)
    {
        TimeSpan timeSpan = new TimeSpan(0,0,0,seconds);
        return timeSpan.Hours + ":" + timeSpan.Minutes + ":" + timeSpan.Seconds;
    }
}

