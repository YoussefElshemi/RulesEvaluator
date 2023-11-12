using RulesEvaluator.Enums;
using RulesEvaluator.Models;

namespace RulesEvaluator.Extensions;

public static class RuleExtensions
{
    public static bool Evaluate(this Rule rule, Dictionary<string, int> values)
    {
        if (rule.Not != null)
        {
            return !Evaluate(rule.Not, values);
        }
        
        if (rule.Field != null)
        {
            if (!values.TryGetValue(rule.Field, out var value))
            {
                throw new ArgumentException($"Field '{rule.Field}' not found in values dictionary.");
            }

            return rule.Condition switch
            {
                Conditions.EqualTo => value == rule.Value,
                Conditions.GreaterThan => value > rule.Value,
                Conditions.LessThan => value < rule.Value,
                Conditions.GreaterThanEqual => value >= rule.Value,
                Conditions.LessThanEqual => value <= rule.Value,
                _ => throw new ArgumentException($"Unsupported condition: {rule.Condition}")
            };
        }

        if (rule.And != null)
        {
            return rule.And.All(r => Evaluate(r, values));
        } 
        
        if (rule.Or != null)
        {
            return rule.Or.Any(r => Evaluate(r, values));
        }
        
        return false;
    }
}