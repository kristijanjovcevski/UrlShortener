using System.Text;

namespace UrlShortener.Service
{
    public class ShortenerService
    {
        public string GenerateShortenedLink()
        {
          

            String dict = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLNMOPQRSTUVWXYZ";


            Random random = new Random();


            StringBuilder sb = new StringBuilder();
            sb.Append("link/");

            for (int i = 0; i < 7; i++)
                sb.Append(dict.ToCharArray()[random.Next(dict.Length)]);


            return sb.ToString();

        }
    }
}
