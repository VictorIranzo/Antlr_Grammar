//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from D:\GitHub\Antlr_Grammar\Grammars\UserGrammar\UserGrammar.g4 by ANTLR 4.7.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="UserGrammarParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public interface IUserGrammarListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="UserGrammarParser.rul"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRul([NotNull] UserGrammarParser.RulContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="UserGrammarParser.rul"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRul([NotNull] UserGrammarParser.RulContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="UserGrammarParser.condicion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCondicion([NotNull] UserGrammarParser.CondicionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="UserGrammarParser.condicion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCondicion([NotNull] UserGrammarParser.CondicionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="UserGrammarParser.booleanAttribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBooleanAttribute([NotNull] UserGrammarParser.BooleanAttributeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="UserGrammarParser.booleanAttribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBooleanAttribute([NotNull] UserGrammarParser.BooleanAttributeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="UserGrammarParser.numericAttribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumericAttribute([NotNull] UserGrammarParser.NumericAttributeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="UserGrammarParser.numericAttribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumericAttribute([NotNull] UserGrammarParser.NumericAttributeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="UserGrammarParser.comparisionNumeric"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterComparisionNumeric([NotNull] UserGrammarParser.ComparisionNumericContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="UserGrammarParser.comparisionNumeric"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitComparisionNumeric([NotNull] UserGrammarParser.ComparisionNumericContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="UserGrammarParser.connector"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConnector([NotNull] UserGrammarParser.ConnectorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="UserGrammarParser.connector"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConnector([NotNull] UserGrammarParser.ConnectorContext context);
}