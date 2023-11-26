using RulesEvaluator.Enums;

namespace RulesEvaluator.Models;

public class Rule
{
    public Conditions? Condition { get; set; }
    
    public string? Field { get; set; }
    
    public object? Value { get; set; }
    
    public Rule[]? And { get; set; }
    
    public Rule[]? Or { get; set; }
    
    public Rule? Not { get; set; }
}