# What is TNValidate?
TNValidate is a fluent validation library for .Net. It enables you to write validation
logic in a way that somewhat resembles natural language. This is not only intended to
make it a little easier for developers to scan, but also means non-programmers have a
better chance of being able to understand and modify the constraints being placed on
data.

TNValidate collects together validation failures and has a default set of error messages,
which you can present to end users. Currently we support English, Swedish and Brazilian
Portuguese languages; if you want something else, see the section on adding languages.
However, often you will want to customize the error that is given to the end user for a specific
failure, which is made quick and easy too.

Finally, TNValidate is open source, made available under the MIT license. This enables
you to use it in your free or non-free software, and does not obligate you to contribute
back any changes. However, if you are in an environment where you are allowed to do so,
contributions are welcome (especially in the area of adding support for more languages).

# Status
TNValidate was created in 2009 and is no longer actively developed. It targets .NET Framework 4.0 and is not published as a NuGet package. It still works and is kept here as open source under the MIT license, so you can read the code, copy it or fork it. Bug reports and patches are still welcome, but I can't promise a quick reply.

# Synopsis
If you want to Just Start Using It, add:

```
using TNValidate;
```

And then it's as easy as:

```
// Instantiate validator.
var Validate = new Validator(ValidationLanguageEnum.English);

// Basic validation.
Validate.That(Email, "Email address").IsEmail();

// Chaining a couple of rules.
Validate.That(Name, "Name").IsLongerThan(3).IsShorterThan(100);

// Supply a custom error message.
Validate.That(Age, "Age").IsGreaterThanOrEqual(13,
    "You must be older than 13 to sign up");

// Check if validation suceeded.
if (Validate.HasErrors())
{
    // Show errors (Validate.ValidatorResults can be data-bound).
    foreach (var Error in Validate.ValidatorResults)
        Console.WriteLine(Error.ValidationMessage);
}
else
{
    // Was fine, continue...
    // ...
}
```

# Documentation
* [Using TNValidate](https://github.com/tndataab/TNValidate/wiki/Using-TNValidate)
* [Validator Reference](https://github.com/tndataab/TNValidate/wiki/Validator-reference)
* [Error Codes](https://github.com/tndataab/TNValidate/wiki/Error-codes)
* [Extending TNValidate](https://github.com/tndataab/TNValidate/wiki/Extending-TNValidate)

# Contribute
We welcome suggestions for future features, bug reports and - of course - patches! :-) An easy way to help is to translate the error message generation file to other languages.

# About The Author
I'm [Tore Nestenius](https://nestenius.se/about/), and I created TNValidate in 2009 while I was a co-founder and CTO of [Edument](https://www.edument.se/). I was inspired to build it after watching a screencast on Building a Progressive Fluent Interface. Today I work as an independent .NET consultant and trainer through [TN-Data](https://tn-data.se), specialising in authentication, identity and security. I keep this copy so the library stays available.
