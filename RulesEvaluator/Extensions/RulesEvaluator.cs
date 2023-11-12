using RulesEvaluator.Enums;
using RulesEvaluator.Models;

namespace RulesEvaluator.Extensions;

public class RulesEvaluator<T>
{
    public bool Evaluate(Rule rule, T instance)
    {
        if (rule.Not != null)
        {
            return !Evaluate(rule.Not, instance);
        }
        
        if (rule.Field != null)
        {
            var property = typeof(T).GetProperty(rule.Field);
            if (property == null)
            {
                throw new ArgumentException($"Field '{rule.Field}' not found in instance.");
            }

            var value = property.GetValue(instance) ?? throw new InvalidOperationException();

            return rule.Condition switch
            {
                Conditions.EqualTo => value.Equals(rule.Value),
                Conditions.GreaterThan when value is IComparable comparableValue => comparableValue.CompareTo(rule.Value) > 0,
                Conditions.LessThan when value is IComparable comparableValue => comparableValue.CompareTo(rule.Value) < 0,
                Conditions.GreaterThanEqual when value is IComparable comparableValue => comparableValue.CompareTo(rule.Value) >= 0,
                Conditions.LessThanEqual when value is IComparable comparableValue => comparableValue.CompareTo(rule.Value) <= 0,
                Conditions.Contains when value is string stringValue => stringValue.Contains(rule.Value.ToString()!, StringComparison.OrdinalIgnoreCase),
                _ => throw new ArgumentException($"Unsupported condition: {rule.Condition}")
            };

        }

        if (rule.And != null)
        {
            return rule.And.All(r => Evaluate(r, instance));
        } 
        
        if (rule.Or != null)
        {
            return rule.Or.Any(r => Evaluate(r, instance));
        }
        
        return false;
    }
}