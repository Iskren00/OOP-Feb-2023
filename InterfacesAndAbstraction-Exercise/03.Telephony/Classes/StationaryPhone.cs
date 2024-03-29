﻿using _03.Telephony.Interfaces;

namespace _03.Telephony.Classes;

public class StationaryPhone : ICallable
{
    public string Call(string phoneNumber)
    {
        if (!ValidatePhoneNumber(phoneNumber))
        {
            throw new ArgumentException("Invalid number!");
        }


        return $"Dialing... {phoneNumber}";
    }

    private bool ValidatePhoneNumber(string phoneNumber)
      => phoneNumber.All(c => Char.IsDigit(c));
}
