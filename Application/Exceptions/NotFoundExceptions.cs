﻿using System;

namespace Application.Exceptions
{
    public class NotFoundExceptions : Exception
    {
        public NotFoundExceptions(string message) : base(message)
        {
                
        }
    }
}