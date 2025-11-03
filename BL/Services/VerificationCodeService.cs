using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.services
{
    public class VerificationCodeService
    {
        // Dictionary לשמירת קודי אימות זמניים: <UserId, (Code, ExpirationTime)>
        private static Dictionary<int, (int Code, DateTime Expiration)> _verificationCodes = new();

        // מנקה קודים שפג תוקפם
        private void CleanExpiredCodes()
        {
            var expiredKeys = _verificationCodes
                .Where(x => x.Value.Expiration < DateTime.Now)
                .Select(x => x.Key)
                .ToList();

            foreach (var key in expiredKeys)
            {
                _verificationCodes.Remove(key);
            }
        }

        // שומר קוד חדש (תוקף של 10 דקות)
        public void SaveCode(int userId, int code)
        {
            CleanExpiredCodes();
            var expiration = DateTime.Now.AddMinutes(10);
            
            if (_verificationCodes.ContainsKey(userId))
            {
                _verificationCodes[userId] = (code, expiration);
            }
            else
            {
                _verificationCodes.Add(userId, (code, expiration));
            }
        }

        // מאמת קוד
        public bool VerifyCode(int userId, int code)
        {
            CleanExpiredCodes();

            if (!_verificationCodes.ContainsKey(userId))
            {
                return false; // אין קוד שמור
            }

            var (savedCode, expiration) = _verificationCodes[userId];

            if (expiration < DateTime.Now)
            {
                _verificationCodes.Remove(userId);
                return false; // פג תוקף
            }

            if (savedCode != code)
            {
                return false; // קוד שגוי
            }

            // קוד נכון - מוחקים אותו כדי שלא יוכלו להשתמש בו שוב
            _verificationCodes.Remove(userId);
            return true;
        }

        // בודק אם יש קוד פעיל למשתמש
        public bool HasActiveCode(int userId)
        {
            CleanExpiredCodes();
            return _verificationCodes.ContainsKey(userId) && 
                   _verificationCodes[userId].Expiration > DateTime.Now;
        }
    }
}
