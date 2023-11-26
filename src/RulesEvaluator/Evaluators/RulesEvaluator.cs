using RulesEvaluator.Enums;
using RulesEvaluator.Models;

namespace RulesEvaluator.Evaluators;

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

            var value = property.GetValue(instance);

            return rule.Condition switch
            {
                Conditions.IsNull when value is int intValue => intValue == 0,
                Conditions.IsNull => value == null,
                
                Conditions.EqualTo => CompareValues(value, rule.Value) == 0,
                Conditions.GreaterThan => CompareValues(value, rule.Value) > 0,
                Conditions.LessThan => CompareValues(value, rule.Value) < 0,
                Conditions.GreaterThanEqual => CompareValues(value, rule.Value) >= 0,
                Conditions.LessThanEqual => CompareValues(value, rule.Value) <= 0,
                Conditions.Contains when value is string stringValue => stringValue.Contains(rule.Value?.ToString()!, StringComparison.OrdinalIgnoreCase),
                Conditions.StartsWith when value is string stringValue => stringValue.StartsWith(rule.Value?.ToString()!, StringComparison.OrdinalIgnoreCase),
                Conditions.EndsWith when value is string stringValue => stringValue.EndsWith(rule.Value?.ToString()!, StringComparison.OrdinalIgnoreCase),
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

    private static int CompareValues<T1, T2>(T1 value1, T2 value2)
    {
        if (value1 is IComparable<T2> comparable1 && value2 is T1)
        {
            return comparable1.CompareTo(value2);
        }
        
        if (value2 is IComparable<T1> comparable2 && value1 is T2)
        {
            return comparable2.CompareTo(value1);
        }
        
        var convertedValue1 = value1?.ToString();
        var convertedValue2 = value2?.ToString();

        return string.Compare(convertedValue1, convertedValue2, StringComparison.Ordinal);
    }
}