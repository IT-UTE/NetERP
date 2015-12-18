using System;
using System.Linq;
using Entities;
using Model.Entities;
using Model.UnitOfWork;

namespace Services
{
    public class TokenServices : ITokenServices
    {
        #region Private member variables.
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Public constructor.
        public TokenServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion


        #region Public member methods.
        public TokenEntity GenerateToken(int userId)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddHours(8);
            var tokendomain = new Token
            {
                UserId = userId,
                AuthToken = token,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn
            };

            unitOfWork.Repository<Token>().Insert(tokendomain);
            unitOfWork.Save();
            var tokenModel = new TokenEntity()
            {
                UserId = userId,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn,
                AuthToken = token
            };

            return tokenModel;
        }

        public bool ValidateToken(string tokenId)
        {
            var token = unitOfWork.Repository<Token>().Get(t => t.AuthToken == tokenId && t.ExpiresOn > DateTime.Now);
            if (token != null && !(DateTime.Now > token.ExpiresOn))
            {
                token.ExpiresOn = token.ExpiresOn.AddHours(8);
                unitOfWork.Repository<Token>().Update(token);
                unitOfWork.Save();
                return true;
            }
            return false;
        }

        public bool Kill(string tokenId)
        {
            unitOfWork.Repository<Token>().Delete(x => x.AuthToken == tokenId);
            unitOfWork.Save();
            var isNotDeleted = unitOfWork.Repository<Token>().GetMany(x => x.AuthToken == tokenId).Any();
            if (isNotDeleted) { return false; }
            return true;
        }

        public bool DeleteByUserId(int userId)
        {
            unitOfWork.Repository<Token>().Delete(x => x.UserId == userId);
            unitOfWork.Save();

            var isNotDeleted = unitOfWork.Repository<Token>().GetMany(x => x.UserId == userId).Any();
            return !isNotDeleted;
        }

        #endregion
    }
}
