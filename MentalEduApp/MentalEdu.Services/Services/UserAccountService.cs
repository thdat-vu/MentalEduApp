using MentalEdu.Repositories.Models;
using MentalEdu.Repositories.UnitOfWork;
using System.Security.Cryptography;
using System.Text;

namespace MentalEdu.Services.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserAccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserAccount>> GetAllUsersAsync()
        {
            return await _unitOfWork.UserAccounts.FindAsync(u => u.ActiveFlag == true);
        }

        public async Task<UserAccount> GetUserByIdAsync(Guid id)
        {
            return await _unitOfWork.UserAccounts.GetByIdAsync(id);
        }

        public async Task<UserAccount> GetUserByEmailAsync(string email)
        {
            return await _unitOfWork.UserAccounts.GetByEmailAsync(email);
        }

        public async Task<IEnumerable<UserAccount>> GetUsersByRoleAsync(string role)
        {
            return await _unitOfWork.UserAccounts.GetUsersByRoleAsync(role);
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return await _unitOfWork.UserAccounts.IsEmailUniqueAsync(email);
        }

        public async Task<UserAccount> CreateUserAsync(UserAccount user, string password)
        {
            // Hash the password
            user.PasswordHash = HashPassword(password);
            user.Id = Guid.NewGuid();
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            user.ActiveFlag = true;
            user.EmailConfirmed = false;

            await _unitOfWork.UserAccounts.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            return user;
        }

        public async Task UpdateUserAsync(UserAccount user)
        {
            var existingUser = await _unitOfWork.UserAccounts.GetByIdAsync(user.Id);
            if (existingUser == null)
                throw new KeyNotFoundException($"User with ID {user.Id} not found");

            existingUser.FullName = user.FullName;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Gender = user.Gender;
            existingUser.DateOfBirth = user.DateOfBirth;
            existingUser.AvatarUrl = user.AvatarUrl;
            existingUser.UpdatedAt = DateTime.Now;

            // Don't update email or password here for security reasons
            // Those should be separate operations with proper validation

            _unitOfWork.UserAccounts.Update(existingUser);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _unitOfWork.UserAccounts.GetByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException($"User with ID {id} not found");

            // Soft delete
            user.ActiveFlag = false;
            user.UpdatedAt = DateTime.Now;

            _unitOfWork.UserAccounts.Update(user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> ValidateCredentialsAsync(string email, string password)
        {
            var user = await _unitOfWork.UserAccounts.GetByEmailAsync(email);
            if (user == null)
                return false;

            string hashedPassword = HashPassword(password);
            return user.PasswordHash == hashedPassword;
        }

        private string HashPassword(string password)
        {
            // Simple SHA256 hashing - in production, use a more secure method with salt
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}