namespace PortfolioWebsite.Helpers
{
    public static class ImageHelper
    {
        public static string GetImagePath(string filename)
        {
            return $"/images/{filename}";
        }
    }
}
