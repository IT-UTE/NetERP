﻿namespace Services
{
    public interface IUserServices
    {
        int Authenticate(string userName, string password);
    }
}