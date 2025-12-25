// <copyright file="OperationResult.cs" company=" Grupo 9: Escuela Politécnica Nacional">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Negocio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OperationResult
    {
        private OperationResult(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }

        public bool Success { get; private set; }

        public string Message { get; private set; }

        public static OperationResult Ok(string message = "")
        {
            return new OperationResult(true, message);
        }

        public static OperationResult Fail(string message)
        {
            return new OperationResult(false, message);
        }
    }
}
