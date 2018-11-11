// Generated from D:\Antlr_Grammar\Antlr.Grammar\Grammar.g4 by ANTLR 4.7.1
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link GrammarParser}.
 */
public interface GrammarListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link GrammarParser#regla}.
	 * @param ctx the parse tree
	 */
	void enterRegla(GrammarParser.ReglaContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#regla}.
	 * @param ctx the parse tree
	 */
	void exitRegla(GrammarParser.ReglaContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#condicion}.
	 * @param ctx the parse tree
	 */
	void enterCondicion(GrammarParser.CondicionContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#condicion}.
	 * @param ctx the parse tree
	 */
	void exitCondicion(GrammarParser.CondicionContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#attributeNumeric}.
	 * @param ctx the parse tree
	 */
	void enterAttributeNumeric(GrammarParser.AttributeNumericContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#attributeNumeric}.
	 * @param ctx the parse tree
	 */
	void exitAttributeNumeric(GrammarParser.AttributeNumericContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#attributeString}.
	 * @param ctx the parse tree
	 */
	void enterAttributeString(GrammarParser.AttributeStringContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#attributeString}.
	 * @param ctx the parse tree
	 */
	void exitAttributeString(GrammarParser.AttributeStringContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#attributeBoolean}.
	 * @param ctx the parse tree
	 */
	void enterAttributeBoolean(GrammarParser.AttributeBooleanContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#attributeBoolean}.
	 * @param ctx the parse tree
	 */
	void exitAttributeBoolean(GrammarParser.AttributeBooleanContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#connector}.
	 * @param ctx the parse tree
	 */
	void enterConnector(GrammarParser.ConnectorContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#connector}.
	 * @param ctx the parse tree
	 */
	void exitConnector(GrammarParser.ConnectorContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#comparsionNumeric}.
	 * @param ctx the parse tree
	 */
	void enterComparsionNumeric(GrammarParser.ComparsionNumericContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#comparsionNumeric}.
	 * @param ctx the parse tree
	 */
	void exitComparsionNumeric(GrammarParser.ComparsionNumericContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#comparisonString}.
	 * @param ctx the parse tree
	 */
	void enterComparisonString(GrammarParser.ComparisonStringContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#comparisonString}.
	 * @param ctx the parse tree
	 */
	void exitComparisonString(GrammarParser.ComparisonStringContext ctx);
}