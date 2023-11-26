using Newtonsoft.Json;
using RulesEvaluator.Evaluators;
using RulesEvaluator.Models;

var jsonRuleSet = @"
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
                    ""Field"": ""Field3"",
                    ""Condition"": ""LessThan"",
                    ""Value"": 9
                }
            ]
        }
    ]
}";

var rule = JsonConvert.DeserializeObject<Rule>(jsonRuleSet)!;
var rulesEvaluator = new RulesEvaluator<CustomClass>();

var customInstance = new CustomClass { Field = 7, Field2 = 6, Field3 = 7 };
var result = rulesEvaluator.Evaluate(rule, customInstance);

Console.WriteLine(result.ToString());

public class CustomClass
{
    public int Field { get; set; }
    
    public int Field2 { get; set; }
    
    public int Field3 { get; set; }

}