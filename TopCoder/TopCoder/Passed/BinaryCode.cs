using System.Text;

public class BinaryCode
{
    public string[] decode(string message)
    {
        string[] results = new string[2];

        for (int i = 0; i < 2; i++)
        {
            int s1 = 0;
            int s = i;
            StringBuilder sb = new StringBuilder(s.ToString());
            for (int j = 0; j < message.Length; j++)
            {
                int t =int.Parse(message[j].ToString()) - s1 - s;
                s1 = s;
                s = t;
                if (s < 0 || s > 1)
                {
                    results[i] = "NONE";
                    break;
                }
                if (j == message.Length - 1 && s != 0)
                {
                    results[i] = "NONE";
                    break;
                }
                if (j != message.Length - 1)
                {
                    sb.Append(s);
                }
            }
            results[i] = results[i] ?? sb.ToString();
        }

        return results;
    }
}
