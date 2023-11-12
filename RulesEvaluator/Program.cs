using Newtonsoft.Json;
using RulesEvaluator.Extensions;
using RulesEvaluator.Models;

const string jsonRuleSet = @"
{
    ""And"": [
        {
            ""Field"": ""Field"",
            ""Condition"": ""GreaterThan"",
            ""Value"": 6
        },
        {
            ""And"": [
                {
                    ""Field"": ""Field2"",
                    ""Condition"": ""EqualTo"",
                    ""Value"": 6
                },
                {
                    ""Field"": ""Field2"",
                    ""Condition"": ""LessThan"",
                    ""Value"": 9
                },
                {
                    ""Field"": ""Field3"",
                    ""Condition"": ""LessThan"",
                    ""Value"": 9
                }
            ]
        }
    ]
}";

var rule = JsonConvert.DeserializeObject<Rule>(jsonRuleSet)!;
var values = new Dictionary<string, int>
{
    { "Field", 7 },
    { "Field2", 6 },
    { "Field3", 7 }
};

var result = rule.Evaluate(values);

if (result)
{
    Console.WriteLine("SEPA");
}
else
{
    Console.WriteLine("Not SEPA");
}