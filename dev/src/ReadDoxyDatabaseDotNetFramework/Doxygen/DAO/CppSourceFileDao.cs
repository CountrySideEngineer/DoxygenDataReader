namespace Doxygen.DAO
{
    public class CppSourceFileDao : AFileDao
    {
        /// <summary>
        /// Returns cpp source file exntension the class supports.
        /// </summary>
        /// <returns>Supporting file extension.</returns>
        protected override string GetFileExtension()
        {
            return "cpp";
        }
    }
}
