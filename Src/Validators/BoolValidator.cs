/* *********************************************************************************
 * TNValidate Fluent Validation Library
 * https://github.com/edumentab/TNValidate
 * Copyright (C) Edument AB 2010
 * http://www.edument.se
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 * *********************************************************************************/

using System;

namespace TNValidate
{
    /// ********************************************************************
    /// <summary>
    /// Boolean validation handler.
    /// </summary>
    public class BoolValidator : ValidatorBase<BoolValidator, bool>
    {
        /// ********************************************************************
        /// <summary>
        /// Initializes a new instance of the <see cref="BoolValidator"/> class.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <param name="validatorObj"></param>
        public BoolValidator(bool value, string fieldName, Validator validatorObj)
            : base(value, fieldName, validatorObj)
        {
        }

        /// ********************************************************************
        /// <summary>
        /// Checks if the boolean value is true.
        /// </summary>
        /// <param name="ErrorMessage"></param>
        /// <returns>My instance to allow me to chain multiple validations together</returns>
        public BoolValidator IsTrue(string ErrorMessage)
        {
            SetResult(!Value, string.Format(ErrorMessage, FieldName), ValidationErrorCode.BoolIsNotTrue);
            return this;
        }

        /// <summary>
        /// Checks if the boolean value is true.
        /// </summary>
        /// <returns>My instance to allow me to chain multiple validations together</returns>
        public BoolValidator IsTrue()
        {
            IsTrue(ValidatorObj.LookupLanguageString("bool_IsTrue", NegateNextValidationResult));
            return this;
        }

        /// ********************************************************************
        /// <summary>
        /// Checks if the boolean value is false.
        /// </summary>
        /// <param name="ErrorMessage"></param>
        /// <returns>My instance to allow me to chain multiple validations together</returns>
        public BoolValidator IsFalse(string ErrorMessage)
        {
            SetResult(Value, string.Format(ErrorMessage, FieldName), ValidationErrorCode.BoolIsNotFalse);
            return this;
        }

        /// <summary>
        /// Checks if the boolean value is false.
        /// </summary>
        /// <returns>My instance to allow me to chain multiple validations together</returns>
        public BoolValidator IsFalse()
        {
            IsFalse(ValidatorObj.LookupLanguageString("bool_IsFalse", NegateNextValidationResult));
            return this;
        }
    }
}
