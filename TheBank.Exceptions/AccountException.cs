﻿using System;

namespace TheBank.Exceptions
{
    /// <summary>
    /// Exception class that represents error raised in Customer class
    /// </summary>
    public class AccountException : ApplicationException
    {
        /// <summary>
        /// Contructor that initializes exception message
        /// </summary>
        /// <param name="message">exception message</param>
        public AccountException(string message) : base(message)
        {
        }
        /// <summary>
        /// Costructor that initializes exception message and inner exception 
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="InnerEcxeption">Inner exception</param>
        public AccountException(string message, Exception InnerEcxeption) : base(message, InnerEcxeption)
        {

        }

    }
}
