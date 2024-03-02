namespace Doxygen.DAO
{
    public class CSourceFileDao : AFileDao
    {
        /// <summary>
        /// Returns supporting file type specified by that of extension.
        /// </summary>
        /// <returns>Supporting file extension.</returns>
        protected override string GetFileExtension()
        {
            return "c";
        }
    }
}
