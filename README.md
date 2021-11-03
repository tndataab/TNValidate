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

# About The Authors
Tore Nestenius is the creator of TNValidate.NET. He is a co-founder of [Edument AB](https://www.edument.se/), a consulting and training company located in Helsingborg, Sweden. He was inspired to create TNValidate after listening to a screencast on [Building a Progressive Fluent Interface](https://www.youtube.com/channel/UCSpCNq22KHTKv736UcCkuKw/Casts). Today he works as an independent consultant at [TN Datakonsult AB](https://tn-data.se) where he provides training and consulting services.

[Jonathan Worthington](https://www.jnthn.net/) provided code review, did some refactoring, made corrections to the English translation, and wrote the documentation for TNValidate. Based in Prague, his expertise lie in compiler development, and he is one of the main developers of the Rakudo Perl 6 compiler.
