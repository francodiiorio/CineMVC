namespace CineXperience.Helpers
{
    public class LegajoGen
    {
        private static Random random = new Random();
        private static string Caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string GetNewLegajo(int largo)
        {
            return GetRand(Caracteres, largo);
        }

        private static string GetRand(string caracteres, int largo)
        {
            return new string(Enumerable.Repeat(caracteres, largo).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
