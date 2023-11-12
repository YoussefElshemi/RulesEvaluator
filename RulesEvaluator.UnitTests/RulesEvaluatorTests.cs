using RulesEvaluator.Enums;
using RulesEvaluator.Extensions;
using RulesEvaluator.Models;

namespace RulesEvaluator.UnitTests;

public class RulesEvaluatorTests
{
    [Fact]
    public void Test_EqualToCondition_ReturnsTrue()
    {
        // Arrange
        var rule = new Rule
        {
            Field = "Amount",
            Condition = Conditions.EqualTo,
            Value = 5
        };
        
        var value = new Dictionary<string, int>
        {
            { "Amount", 5 }
        }; 
        
        // Act
        var actual = rule.Evaluate(value);
        
        // Assert
        Assert.True(actual);
    }
    
    [Fact]
    public void Test_EqualToCondition_ReturnsFalse()
    {
        // Arrange
        var rule = new Rule
        {
            Field = "Amount",
            Condition = Conditions.EqualTo,
            Value = 5
        };
        
        var value = new Dictionary<string, int>
        {
            { "Amount", 7 }
        }; 
        
        // Act
        var actual = rule.Evaluate(value);
        
        // Assert
        Assert.False(actual);
    }
    
    [Fact]
    public void Test_GreaterThanCondition_ReturnsTrue()
    {
        // Arrange
        var rule = new Rule
        {
            Field = "Amount",
            Condition = Conditions.GreaterThan,
            Value = 5
        };
        
        var value = new Dictionary<string, int>
        {
            { "Amount", 6 }
        }; 
        
        // Act
        var actual = rule.Evaluate(value);
        
        // Assert
        Assert.True(actual);
    }
    
    [Fact]
    public void Test_GreaterThanCondition_ReturnsFalse()
    {
        // Arrange
        var rule = new Rule
        {
            Field = "Amount",
            Condition = Conditions.GreaterThan,
            Value = 5
        };
        
        var value = new Dictionary<string, int>
        {
            { "Amount", 4 }
        }; 
        
        // Act
        var actual = rule.Evaluate(value);
        
        // Assert
        Assert.False(actual);
    }
    
    [Fact]
    public void Test_LessThanCondition_ReturnsTrue()
    {
        // Arrange
        var rule = new Rule
        {
            Field = "Amount",
            Condition = Conditions.LessThan,
            Value = 5
        };
        
        var value = new Dictionary<string, int>
        {
            { "Amount", 4 }
        }; 
        
        // Act
        var actual = rule.Evaluate(value);
        
        // Assert
        Assert.True(actual);
    }
    
    [Fact]
    public void Test_LessThanCondition_ReturnsFalse()
    {
        // Arrange
        var rule = new Rule
        {
            Field = "Amount",
            Condition = Conditions.LessThan,
            Value = 5
        };
        
        var value = new Dictionary<string, int>
        {
            { "Amount", 6 }
        }; 
        
        // Act
        var actual = rule.Evaluate(value);
        
        // Assert
        Assert.False(actual);
    }                                                                                                                                                                                                     
    
    [Fact]
    public void Test_GreaterThanEqualCondition_ReturnsTrue()
    {
        // Arrange
        var rule = new Rule
        {
            Field = "Amount",
            Condition = Conditions.GreaterThanEqual,
            Value = 5
        };
        
        var valueGreater = new Dictionary<string, int>
        {
            { "Amount", 6 }
        }; 
        
        var valueEqual = new Dictionary<string, int>
        {
            { "Amount", 5 }
        };
        
        // Act
        var actualGreater = rule.Evaluate(valueGreater);
        var actualEqual = rule.Evaluate(valueEqual);

        // Assert
        Assert.True(actualGreater && actualEqual);
    }
    
    [Fact]
    public void Test_GreaterThanEqualCondition_ReturnsFalse()
    {
        // Arrange
        var rule = new Rule
        {
            Field = "Amount",
            Condition = Conditions.GreaterThanEqual,
            Value = 5
        };
        
        var value = new Dictionary<string, int>
        {
            { "Amount", 4 }
        }; 
        
        // Act
        var actual = rule.Evaluate(value);
        
        // Assert
        Assert.False(actual);
    }
    
    [Fact]
    public void Test_LessThanEqualCondition_ReturnsTrue()
    {
        // Arrange
        var rule = new Rule
        {
            Field = "Amount",
            Condition = Conditions.LessThanEqual,
            Value = 6
        };
         
        var valueLess = new Dictionary<string, int>
        {
            { "Amount", 6 }
        }; 
        
        var valueEqual = new Dictionary<string, int>
        {
            { "Amount", 5 }
        };
        
        // Act
        var actualLess = rule.Evaluate(valueLess);
        var actualEqual = rule.Evaluate(valueEqual);

        // Assert
        Assert.True(actualLess && actualEqual);
    }
    
    [Fact]
    public void Test_LessThanEqualCondition_ReturnsFalse()
    {
        // Arrange
        var rule = new Rule
        {
            Field = "Amount",
            Condition = Conditions.LessThanEqual,
            Value = 5
        };
        
        var value = new Dictionary<string, int>
        {
            { "Amount", 6 }
        }; 
        
        // Act
        var actual = rule.Evaluate(value);
        
        // Assert
        Assert.False(actual);
    }
    
    [Fact]
    public void Test_And_EqualToCondition_ReturnsTrue()
    {
        // Arrange
        var rule = new Rule
        {
            And = new Rule[] {
                new()
                {
                    Field = "Amount1",
                    Condition = Conditions.EqualTo,
                    Value = 5
                },
                new()
                {
                    Field = "Amount2",
                    Condition = Conditions.EqualTo,
                    Value = 6
                }
            }
        };
         
        var value = new Dictionary<string, int>
        {
            { "Amount1", 5 },
            { "Amount2", 6 }
        }; 
        
        // Act
        var actual = rule.Evaluate(value);

        // Assert
        Assert.True(actual);
    }
    
    [Fact]
    public void Test_And_EqualToCondition_ReturnsFalse()
    {
        // Arrange
        var rule = new Rule
        {
            And = new Rule[] {
                new()
                {
                    Field = "Amount1",
                    Condition = Conditions.EqualTo,
                    Value = 5
                },
                new()
                {
                    Field = "Amount2",
                    Condition = Conditions.EqualTo,
                    Value = 6
                }
            }
        };
         
        var value = new Dictionary<string, int>
        {
            { "Amount1", 6 },
            { "Amount2", 6 }
        }; 
        
        // Act
        var actual = rule.Evaluate(value);

        // Assert
        Assert.False(actual);
    }
    
    [Fact]
    public void Test_Not_EqualToCondition_ReturnsTrue()
    {
        // Arrange
        var rule = new Rule
        {
            Not = new Rule {
                Field = "Amount",
                Condition = Conditions.EqualTo,
                Value = 6
            }
        };
         
        var value = new Dictionary<string, int>
        {
            { "Amount", 5 }
        }; 
        
        // Act
        var actual = rule.Evaluate(value);

        // Assert
        Assert.True(actual);
    }
    
    [Fact]
    public void Test_Not_EqualToCondition_ReturnsFalse()
    {
        // Arrange
        var rule = new Rule
        {
            Not = new Rule {
                Field = "Amount",
                Condition = Conditions.EqualTo,
                Value = 6
            }
        };
         
        var value = new Dictionary<string, int>
        {
            { "Amount", 6 }
        }; 
        
        // Act
        var actual = rule.Evaluate(value);

        // Assert
        Assert.False(actual);
    }
    
    [Fact]
    public void Test_Or_EqualToCondition_ReturnsTrue()
    {
        // Arrange
        var rule = new Rule
        {
            Or = new Rule[] {
                new()
                {
                    Field = "Amount",
                    Condition = Conditions.EqualTo,
                    Value = 5
                },
                new()
                {
                    Field = "Amount",
                    Condition = Conditions.EqualTo,
                    Value = 6
                }
            }
        };
         
        var value1 = new Dictionary<string, int>
        {
            { "Amount", 5 }
        }; 
        
        var value2 = new Dictionary<string, int>
        {
            { "Amount", 6 }
        };
        
        // Act
        var actual1 = rule.Evaluate(value1);
        var actual2 = rule.Evaluate(value2);

        // Assert
        Assert.True(actual1 && actual2);
    }
    
    [Fact]
    public void Test_Or_EqualToCondition_ReturnsFalse()
    {
        // Arrange
        var rule = new Rule
        {
            Or = new Rule[] {
                new()
                {
                    Field = "Amount",
                    Condition = Conditions.EqualTo,
                    Value = 5
                },
                new()
                {
                    Field = "Amount",
                    Condition = Conditions.EqualTo,
                    Value = 6
                }
            }
        };
         
        var value = new Dictionary<string, int>
        {
            { "Amount", 4 }
        }; 
        
        // Act
        var actual = rule.Evaluate(value);

        // Assert
        Assert.False(actual);
    }
    
    [Fact]
    public void Test_Not_And_EqualToCondition_ReturnsTrue()
    {
        // Arrange
        var rule = new Rule
        {
            Not = new Rule {
                And = new Rule[] {
                    new()
                    {
                        Field = "Amount1",
                        Condition = Conditions.EqualTo,
                        Value = 6
                    },
                    new()
                    {
                        Field = "Amount2",
                        Condition = Conditions.EqualTo,
                        Value = 6
                    }
                }
            }
        };
         
        var value = new Dictionary<string, int>
        {
            { "Amount1", 5 },
            { "Amount2", 6 }
        }; 
        
        // Act
        var actual = rule.Evaluate(value);

        // Assert
        Assert.True(actual);
    }
    
    [Fact]
    public void Test_Not_And_EqualToCondition_ReturnsFalse()
    {
        // Arrange
        var rule = new Rule
        {
            Not = new Rule {
                And = new Rule[] {
                    new()
                    {
                        Field = "Amount1",
                        Condition = Conditions.EqualTo,
                        Value = 6
                    },
                    new()
                    {
                        Field = "Amount2",
                        Condition = Conditions.EqualTo,
                        Value = 6
                    }
                }
            }
        };
         
        var value = new Dictionary<string, int>
        {
            { "Amount1", 5 },
            { "Amount2", 6 }
        }; 
        
        // Act
        var actual = rule.Evaluate(value);

        // Assert
        Assert.True(actual);
    }
    
    [Fact]
    public void Test_And_Or_Or_EqualToCondition_ReturnsTrue()
    {
        // Arrange
        var rule = new Rule
        {
            And = new Rule[] {
                new () {
                    Or = new Rule[] {
                        new()
                        {
                            Field = "Amount1",
                            Condition = Conditions.EqualTo,
                            Value = 5
                        },
                        new()
                        {
                            Field = "Amount1",
                            Condition = Conditions.EqualTo,
                            Value = 6
                        }
                    }
                },
                new() {
                    Or = new Rule[] {
                        new()
                        {
                            Field = "Amount2",
                            Condition = Conditions.EqualTo,
                            Value = 5
                        },
                        new()
                        {
                            Field = "Amount2",
                            Condition = Conditions.EqualTo,
                            Value = 6
                        }
                    }
                }
            }
        };
         
        var value = new Dictionary<string, int>
        {
            { "Amount1", 5 },
            { "Amount2", 6 }
        }; 
        
        // Act
        var actual = rule.Evaluate(value);

        // Assert
        Assert.True(actual);
    }
    
    [Fact]
    public void Test_And_Or_Or_EqualToCondition_ReturnsFalse()
    {
        // Arrange
        var rule = new Rule
        {
            And = new Rule[] {
                new () {
                    Or = new Rule[] {
                        new()
                        {
                            Field = "Amount1",
                            Condition = Conditions.EqualTo,
                            Value = 5
                        },
                        new()
                        {
                            Field = "Amount1",
                            Condition = Conditions.EqualTo,
                            Value = 6
                        }
                    }
                },
                new() {
                    Or = new Rule[] {
                        new()
                        {
                            Field = "Amount2",
                            Condition = Conditions.EqualTo,
                            Value = 5
                        },
                        new()
                        {
                            Field = "Amount2",
                            Condition = Conditions.EqualTo,
                            Value = 6
                        }
                    }
                }
            }
        };
         
        var value = new Dictionary<string, int>
        {
            { "Amount1", 5 },
            { "Amount2", 7 }
        }; 
        
        // Act
        var actual = rule.Evaluate(value);

        // Assert
        Assert.False(actual);
    }
}