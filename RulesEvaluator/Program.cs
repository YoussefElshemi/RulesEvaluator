﻿using Newtonsoft.Json;
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
var customInstance = new CustomClass { Field = 7, Field2 = 6, Field3 = 7 };

var rulesEvaluator = new RulesEvaluator<CustomClass>();
var result = rulesEvaluator.Evaluate(rule, customInstance);

Console.WriteLine(result ? "SEPA" : "Not SEPA");

public class CustomClass
{
    public int Field { get; set; }
    
    public int Field2 { get; set; }
    
    public int Field3 { get; set; }

}