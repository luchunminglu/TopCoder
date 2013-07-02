
public class TemperatureScales2
{
    public double convert(int f1, int b1, int f2, int b2, int t)
    {
        double a = (b2 - f2) * 1.0 / (b1 - f1);
        double b = f2 - a * f1;
        return a * t + b;
    }
}

