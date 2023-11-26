
# RulesEvaluator

## Overview
RulesEvaluator is a .NET package designed to provide a flexible and expressive way to evaluate sets of rules on custom data models. It enables you to define complex rule sets using a JSON-based syntax and then evaluate those rules against instances of your custom classes.

## Overview

RulesEvaluator is a .NET package designed to provide a flexible and expressive way to evaluate sets of rules on custom data models. It enables you to define complex rule sets using a JSON-based syntax and then evaluate those rules against instances of your custom classes.

## Installation

To use RulesEvaluator in your .NET project, you can install the package via NuGet Package Manager Console or the Package Manager UI:

    Install-Package RulesEvaluator

## Getting Started

## Rule Conditions

RulesEvaluator supports various conditions that you can use to define the logic for rule evaluation. The available conditions are represented by the `Conditions` enum:

- **IsNull:** Checks if the field is null.
- **EqualTo:** Checks if the field is equal to the specified value.
- **GreaterThan:** Checks if the field is greater than the specified value.
- **LessThan:** Checks if the field is less than the specified value.
- **GreaterThanEqual:** Checks if the field is greater than or equal to the specified value.
- **LessThanEqual:** Checks if the field is less than or equal to the specified value.
- **Contains:** Checks if the field contains the specified value.
- **StartsWith:** Checks if the field starts with the specified value.
- **EndsWith:** Checks if the field ends with the specified value.

You can use these conditions to create expressive and precise rule sets tailored to your specific requirements.

### Define Rules

Rules are defined using a JSON syntax that represents the logical conditions to be evaluated. You can use various logical operators like "And," "Or," and "Not" to create complex rule structures. Each rule consists of a field, a condition, and a value.

Example RuleSet JSON:
```json
{
    "And": [
        {
            "Field": "Field",
            "Condition": "GreaterThan",
            "Value": 6
        },
        {
            "And": [
                {
                    "Field": "Field2",
                    "Condition": "EqualTo",
                    "Value": 6
                },
                {
                    "Field": "Field2",
                    "Condition": "LessThan",
                    "Value": 9
                },
                {
                    "Field": "Field3",
                    "Condition": "LessThan",
                    "Value": 9
                }
            ]
        }
    ]
}
```

### Type Parameters

Create or use an existing class that represents the data structure you want to evaluate the rules against.

```csharp
public class CustomClass
{
    public int Field { get; set; }
    
    public int Field2 { get; set; }
    
    public int Field3 { get; set; }
}
```

### Evaluate Rules

Use the RulesEvaluator to deserialize the rule set, create an instance of your class, and then evaluate the rules against the instance.
```csharp
using Newtonsoft.Json;
using RulesEvaluator.Evaluators;
using RulesEvaluator.Models;

var jsonRuleSet = //... (as shown in the example above)
var rule = JsonConvert.DeserializeObject<Rule>(jsonRuleSet)!;

var customInstance = new CustomClass { Field = 7, Field2 = 6, Field3 = 7 };

var rulesEvaluator = new RulesEvaluator<CustomClass>();
var result = rulesEvaluator.Evaluate(rule, customInstance);

Console.WriteLine(result.ToString());
```

The `result` will indicate whether the provided instance satisfies the defined rules.

## Example Output

The result of the evaluation will be a boolean indicating whether the provided instance satisfies the rules. You can customize the output based on your needs.

## Contributions

Contributions are welcome! If you encounter any issues, have feature requests, or want to contribute to the project, please feel free to submit a pull request or open an issue.

## License

This project is licensed under the MIT License - see the [LICENSE](./LICENSE) for details.

----------

Feel free to customize this readme to fit your project structure and additional features. Add more details about customization, advanced configurations, and anything else that might be relevant for users of your RulesEvaluator package.
