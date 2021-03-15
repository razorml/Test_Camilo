namespace EmployeesTest.Repositories
{
    using EmployeesTest.Context;
    using EmployeesTest.Models;
    using Microsoft.IdentityModel.Tokens;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
    using System;

    public class UserRepository
    {
        private AppDbContext dbContext;
        public UserRepository(AppDbContext context)
        {
            this.dbContext = context;
        }

        public bool GetDataUser(Users users)
        {
            bool result = false;
            using SHA256 sha256Hash = SHA256.Create();            
            var user = this.dbContext.Users.FirstOrDefault(x => x.UserName.Equals(users.UserName));
            if (user != null)
            {
                result = this.VerifyHash(sha256Hash, users.Password, user.Password);
            }
            return result;
        }

        private string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        private bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            // Hash the input.
            var hashOfInput = GetHash(hashAlgorithm, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }
    }
}
